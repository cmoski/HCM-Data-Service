﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using ModulusFE.Controls;
using ModulusFE.Data;
using ModulusFE.Indicators;
using ModulusFE.PaintObjects;
#if SILVERLIGHT
using ModulusFE.LineStudies;
using ModulusFE.SL;
using ModulusFE.SL.Utils;
using FrameworkElement=System.Windows.FrameworkElement;

#endif
#if WPF
using System.Windows.Threading;
using ModulusFE.LineStudies;
using FrameworkElement=System.Windows.FrameworkElement;

#if DEMO
using System.Reflection;
using System.IO;
using System.Diagnostics;
#endif
#if PERSONAL
using Microsoft.Win32;
using System.Reflection;
using System.IO;
#endif
#endif

[assembly: CLSCompliant(true)]
namespace ModulusFE
{
	[CLSCompliant(true)]
	public partial class StockChartX : Control
	{
#if PERSONAL
		private bool? _registered;
#elif DEMO
		private bool? _registered;
		private string _demoText;
#endif
		/// <summary>
		/// will be turned off when release
		/// </summary>
		internal readonly bool _isBeta;

		internal int _startIndex;
		internal int _endIndex;
		#region Internal Fields
		internal PanelsBarContainer _panelsBar;
		internal Calendar _calendar;
		internal PanelsContainer _panelsContainer;

		internal bool _darwasBoxes;
		internal bool _displatTitles;
		internal bool _useVolumeUpDownColors;
		internal bool _useLineSeriesColors;
		internal bool _dialogErrorShown;
		internal bool _updatingIndicator;
		internal bool _locked;
		private bool _recalc;
		internal bool _changed;

		internal double _barWidth;
		internal double _barSpacing;
		internal double _barInterval;
		internal double []_priceStyleParams = new double[Constants.MaxPriceStyleParams];
		internal double _darvasPct;

		internal Color? _candleDownOutlineColor;
		internal Color? _candleUpOutlineColor;
		internal Color _horizontalLinesColor;

		internal PriceStyleEnum _priceStyle;
		internal ChartTypeEnum _chartType = ChartTypeEnum.OHLC;
		internal ScaleAlignmentTypeEnum _scaleAlignement = ScaleAlignmentTypeEnum.Right;
		
		internal PriceStyleValuesCollection _psValues1 = new PriceStyleValuesCollection();
		internal PriceStyleValuesCollection _psValues2 = new PriceStyleValuesCollection();
		internal PriceStyleValuesCollection _psValues3 = new PriceStyleValuesCollection();
		/// <summary>
		/// it will hold the X coordinate value for any visible record on screen. 
		/// used to paint x Grid
		/// </summary>
		internal Dictionary<int, double> _xGridMap = new Dictionary<int, double>();
		internal double []_xMap = new double[0];
		internal int _xCount;

		internal class BarBrushData
		{
			public bool Changed;
			public Brush Brush;
		}
		/// <summary>
		/// Series name, candle index - Brush
		/// if series name not passe, take from string.empty
		/// </summary>
		internal Dictionary<string, Dictionary<int, BarBrushData>> _barBrushes = 
			new Dictionary<string, Dictionary<int, BarBrushData>>();

		internal DataManager.DataManager _dataManager;
		#endregion

		#region Private Fields
		private ChartPanel _currentPanel;
		private Grid _rootGrid;
		//private ChartScroller _chartScroller;
		//font properties used to paint all the text on the chart
		private string _fontFace = "Verdana";
		private double _fontSize = 9;
		private Brush _fontForeground = Brushes.Yellow;

		/// <summary>
		/// used to show an arbitraty text in any position of the chart
		/// </summary>
		private readonly TextBlock _textLabelTitle = new TextBlock();

		/// <summary>
		/// Chart Status
		/// </summary>
		public enum ChartStatus
		{
			/// <summary>
			/// Building
			/// </summary>
			Building,
			/// <summary>
			/// Resizing Panels
			/// </summary>
			ResizingPanels,
			/// <summary>
			/// Ready for action
			/// </summary>
			Ready,
			/// <summary>
			/// Moving a selected object
			/// </summary>
			MovingSelection,
			/// <summary>
			/// Line Study has been painted
			/// </summary>
			LineStudyPaintReady,
			/// <summary>
			/// Line Study is painting
			/// </summary>
			LineStudyPainting,
			/// <summary>
			/// User is moving a LineStudy
			/// </summary>
			LineStudyMoving,
			/// <summary>
			/// A zoom process has been started
			/// </summary>
			ZoomStart,
			/// <summary>
			/// A zoom rectangle is being painted
			/// </summary>
			ZoomPaintingRect,
			/// <summary>
			/// When info panel is moving 
			/// </summary>
			InfoPanelMoving, 
		}

		private ChartStatus _status;
		private bool _templateLoaded;

		private LineStudy _lineStudyToAdd;
		#endregion

		///<summary>
		/// Initializes a new instance of the <seealso cref="StockChartX"/> class.
		///</summary>
		public StockChartX()
		{
			_isBeta = false;

#if WPF
			Action<Application> a = application =>
									{
										if (application != null)
											OwnerWindow = application.MainWindow;
									};
			//RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);
			Application appCurrent = Application.Current;
			if (appCurrent != null)
			{
				if (appCurrent.CheckAccess())
					a(appCurrent);
				else
					appCurrent.Dispatcher.BeginInvoke(a, appCurrent);
			}
#endif

#if SILVERLIGHT
			DefaultStyleKey = typeof (StockChartX);
#endif

			_dataManager = new DataManager.DataManager(this);

			Background = Brushes.Black;
			Foreground = Brushes.White;
			_startIndex = _endIndex = 0; //no data. all panels' data are related to these indexes

			_darwasBoxes = false;
			_displatTitles = true;
			_useVolumeUpDownColors = false;
			_useLineSeriesColors = false;

			_horizontalLinesColor = Colors.White;
			_candleDownOutlineColor = null;
			_candleUpOutlineColor = null;

			_barSpacing = 0;
			_barInterval = 60;
			_barWidth = 1;
			_darvasPct = 0.01;

			_priceStyle = PriceStyleEnum.psStandard;
			_status = ChartStatus.Ready;
			YGridStepType = YGridStepType.MinimalGap;

			_timers.RegisterTimer(TimerMove, MoveChart, 50);
			_timers.RegisterTimer(TimerResize, ResizeChart, 50);
			_timers.RegisterTimer(TimerUpdate, Update, 50);
			_timers.RegisterTimer(TimerCrossHairs, MoveCrossHairs, 50);
			_timers.RegisterTimer(TimerInfoPanel, ShowInfoPanelInternal, 50);

#if WPF
			MouseWheel += Chart_MouseWheel;
#endif
			//initialize needed variables
			CheckRegistration();

#if SILVERLIGHT
			Mouse.RegisterMouseMoveAbleElement(this);
			MouseMove += (sender, e) => Mouse.UpdateMousePosition(this, e.GetPosition(this));
#endif
		}

		#region Internal Properties
		#endregion

		#region Overrides

		/// <summary>
		/// Ovveride
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_rootGrid = GetTemplateChild("rootGrid") as Grid;
			if (_rootGrid == null) throw new NullReferenceException();
			_panelsContainer = GetTemplateChild("rootCanvas") as PanelsContainer;
			if (_panelsContainer == null) throw new NullReferenceException();
			_calendar = GetTemplateChild("calendarPanel") as Calendar;
			if (_calendar == null) throw new NullReferenceException();
			_panelsBar = GetTemplateChild("panelsBar") as PanelsBarContainer;
			if (_panelsBar == null) throw new NullReferenceException();
			_scroller = GetTemplateChild("scroller") as ChartScrollerEx;
			if (_scroller != null)
				SetupChartScroller(ChartScrollerProperties = ChartScrollerProperties.CreateDefault(this));

//      _chartScroller = GetTemplateChild("scroller") as ChartScroller;
//
//      if (_chartScroller != null)
//      {
//        _chartScroller.OnPositionChanged += ChartScrollerOnPositionChanged;
//        _chartScroller.Chart = this;
//        ShowHideChartScroller();
//        _chartScroller.TrackBackground = ChartScrollerTrackBackground;
//        _chartScroller.TrackButtonsBackground = ChartScrollerTrackButtonsBackground;
//        _chartScroller.ThumbButtonBackground = ChartScrollerThumbButtonBackground;
//      }

			//init objects
			_panelsContainer._chartX = this;
			//_panelsContainer._panelsHolder.Children.Add(_textLabelTitle);
			_panelsContainer.Children.Add(_textLabelTitle);
			_textLabelTitle.Visibility = Visibility.Collapsed;

			Canvas.SetZIndex(_textLabelTitle, ZIndexConstants.TextLabelTitle);

			_panelsBar._chartX = this;
			_panelsBar.OnButtonClicked += (sender,e) => _panelsContainer.RestorePanel(e._chartPanel);

			_calendar._chartX = this;

			SetPanelsBarVisibility();

			_calendar.MouseLeftButtonDown += Calendar_OnMouseLeftButtonDown;
			_calendar.MouseLeftButtonUp += Calendar_OnMouseLeftButtonUp;
			_calendar.KeyDown += Calendar_OnKeyDown;
			_calendar.KeyUp += Calendar_OnKeyUp;
			KeyDown += Calendar_OnKeyDown;
			KeyUp += Calendar_OnKeyUp;
			MouseLeftButtonDown += (sender, e) => Focus();
#if WPF
			_calendar.MouseRightButtonDown += Calendar_OnMouseRightButtonDown;
			_calendar.MouseRightButtonUp += Calendar_OnMouseRightButtonUp;
#endif

			if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			{
				AddChartPanel();
				_panelsContainer.InvalidateMeasure();
				_panelsContainer.InvalidateArrange();
			}

			SetYAxes();
			_templateLoaded = true;

			ChartLoaded(this, EventArgs.Empty);
		}

		#endregion Overrides

		#region Private Methods
		private void SetYAxes()
		{
			foreach (ChartPanel panel in _panelsContainer.Panels)
			{
				panel.SetYAxes();
			}
			if (_calendar == null) return;
			switch (ScaleAlignment)
			{
				case ScaleAlignmentTypeEnum.Right:
					_rootGrid.ColumnDefinitions[0].Width = new GridLength(0);
					_rootGrid.ColumnDefinitions[2].Width = new GridLength(Constants.YAxisWidth);
					break;
				case ScaleAlignmentTypeEnum.Left:
					_rootGrid.ColumnDefinitions[0].Width = new GridLength(Constants.YAxisWidth);
					_rootGrid.ColumnDefinitions[2].Width = new GridLength(0);
					break;
				default:
					_rootGrid.ColumnDefinitions[0].Width = new GridLength(Constants.YAxisWidth);
					_rootGrid.ColumnDefinitions[2].Width = new GridLength(Constants.YAxisWidth);
					break;
			}
			_rootGrid.UpdateLayout();
			Update();
		}

		private void SetPanelsBarVisibility()
		{
			if (_panelsBar == null)
				return;
			_panelsBar.UpdateVisibility();
			_rootGrid.RowDefinitions[2].Height = new GridLength(_panelsBar.Visible ? Constants.PanelsBarHeight : 0);
		}

		private void ShowHideYGridLines()
		{
			if (_panelsContainer == null) 
				return;
			_panelsContainer.Panels.ForEach(p => p.ShowHideYGridLines());
		}

		private void ShowHideXGridLines()
		{
			if (_panelsContainer == null) 
				return;
			_panelsContainer.Panels.ForEach(p => p.ShowHideXGridLines());
		}
		#endregion

		#region Internal Methods
		internal void AddMinimizedPanel(ChartPanel panel)
		{
			_panelsBar.AddPanel(panel);      
			SetPanelsBarVisibility();
		}

		internal void DeleteMinimizedPanel(ChartPanel panel)
		{
			_panelsBar.DeletePanel(panel);
			SetPanelsBarVisibility();
		}

		internal double GetXPixel(double index, bool offscreen)
		{
			if (!_templateLoaded)
			{
				return 0;
			}

			if (index < 0 && !offscreen)
			{
				return 0;
			}

			if (_priceStyle != PriceStyleEnum.psStandard &&
				_priceStyle != PriceStyleEnum.psHeikinAshi &&
				index >= 0 &&
				index < _xMap.Length)
			{
				if (_xMap[(int)index] > 0)
				{
					return _xMap[(int)index];
				}
			}

			return PaintableWidth * index / VisibleRecordCount + LeftChartSpace - _barSpacing;
		}

		/// <summary>
		/// Gets record by pixel value
		/// </summary>
		/// <param name="pixel"></param>
		/// <returns></returns>
		public double GetReverseXInternal(double pixel)
		{
			if (_priceStyle != PriceStyleEnum.psStandard && _priceStyle != PriceStyleEnum.psHeikinAshi && _xMap.Length > 0)
			{
				for (int i = 0; i < _xMap.Length; i++)
				{
					double v1 = 0;
					if (i > 0)
					{
						v1 = _xMap[i - 1];
					}

					double v2 = _xMap[i];
					if (i == 0 && pixel <= v2)
					{
						return Math.Floor(i + 0.5);
					}

					if (pixel >= v1 && pixel <= v2)
					{
						return Math.Floor(i + 0.5);
					}
				}
				return -1;
			}

			pixel -= LeftChartSpace;
			if (ScaleAlignment != ScaleAlignmentTypeEnum.Right)
			{
				pixel -= Constants.YAxisWidth;
			}

			return (pixel + (_barSpacing)) * VisibleRecordCount / PaintableWidth;
		}


		internal void DoActionOnPanels(Action<ChartPanel> action)
		{
			_panelsContainer.Panels.ForEach(action);
		}

		internal void InvalidateIndicators()
		{
			foreach (ChartPanel chartPanel in _panelsContainer.Panels)
			{
				foreach (Indicator indicator in chartPanel.IndicatorsCollection)
				{
					indicator._calculated = false;
				}
			}
		}

		internal ChartStatus Status
		{
			get { return _status; }
			set
			{
				if (_status == value) return;
				_status = value;
				switch (_status)
				{
					case ChartStatus.LineStudyPaintReady:
//            Debug.Assert(_currentPanel != null);
						Mouse.OverrideCursor =
#if WPF
							Cursors.Pen;
#endif
#if SILVERLIGHT
							Cursors.Stylus;
#endif
						break;
					case ChartStatus.Ready:
						Mouse.OverrideCursor = Cursors.Arrow;
						if (_currentPanel != null) _currentPanel.Cursor = Cursors.Arrow;
						break;
					case ChartStatus.MovingSelection:
						Mouse.OverrideCursor = Cursors.Hand;
						break;
				}
			}
		}

		internal bool ReCalc
		{
			get { return _recalc; }
			set 
			{
				_recalc = value; 
				_panelsContainer.Panels.ForEach(panel => panel._recalc = value);
			}
		}

		internal void UpdateByTimer()
		{
			_timers.StartTimerWork(TimerUpdate);
		}


#if SILVERLIGHT
		private readonly List<string> _allowedIPs = new List<string>
																				{
																					"localhost",
																					"platform.modulusfe.com",
																					"developer.modulusfe.com",
																					"50.19.251.122",
                                                                                    "50.19.251.120",
                                                                                    "www.hcm401koptimizer.com",
                                                                                    "hcm401koptimizer.com"
																				};
#endif
		//private static readonly DateTime _expirationDate = new DateTime(2008, 10, 19);
		internal bool CheckRegistration()
		{
			//in Design-Mode always return true
			if (Utils.GetIsInDesignMode(this))
				return true;
#if WPF
#if PERSONAL
			if (_registered.HasValue) return _registered.Value;
			_registered = IsLicenseValid();

			return _registered.Value;
#elif DEMO
			try
			{
				if (!_registered.HasValue)
				{
					string assemblyLocation = Assembly.GetAssembly(typeof (StockChartX)).Location;
					string directory = Path.GetDirectoryName(assemblyLocation);
					string s = Security.LicenseChecker.I.CheckLicense(directory + "\\DemoClient.lix");

					Debug.WriteLine("License info: " + s);

					_demoText = s;

					return (_registered = (s.Length > 0)).Value;
				}
				return _registered.Value;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Corrupt license information. \r\n Extended error: \r\n" + ex, 
					"Error", MessageBoxButton.OK, MessageBoxImage.Error);
				_registered = false;
				return false;
			}
#else
			//return DateTime.Now <= _expirationDate;
			return true;
#endif
#endif
#if SILVERLIGHT
            // Deals with the situation when the debug is run without a web server
            if (Application.Current.Host.Source.Scheme == Uri.UriSchemeFile)
                return true;

            // if you can see this it means you have source code, so change this checking as you wish.
            // Though as a contractual obligation it can not be removed completely. Best solution is to 
            // add your URI to the lising above (_allowedIPs variable)
            string host = Application.Current.Host.Source.Host;

            // Allow the client to set an encoded URI so that they do not have to change the
            // code base. If you can read this and want to use this method, trace the code below
            // to reverse engineer a key.
            if (_uriLicenseKey.Length > 0)
            {
                if (string.Compare(_uriLicenseKey, host, StringComparison.InvariantCultureIgnoreCase) == 0
                    || string.Compare(_uriLicenseKey, "www." + host, StringComparison.InvariantCultureIgnoreCase) == 0
                    || host.EndsWith(_uriLicenseKey))
                    return true;
            }

            // Otherwise check the _allowedIPs array
			return _allowedIPs.Any(_ => 
                string.Compare(_, host, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(_, "www." + host, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                host.EndsWith(_));
#endif
		}

		internal Brush GetBarBrush(int barIndex, Brush defaultBrush)
		{
			return GetBarBrush(string.Empty, barIndex, defaultBrush);
		}

		/// <summary>
		/// returns a brush for a specified by index candle. this function is used toghether with BarColor public function.
		/// </summary>
		/// <param name="seriesName"></param>
		/// <param name="barIndex"></param>
		/// <param name="defaultBrush"></param>
		/// <returns></returns>
		internal Brush GetBarBrush(string seriesName, int barIndex, Brush defaultBrush)
		{
			BarBrushData barBrush;
			if (!_barBrushes.ContainsKey(seriesName))
			{
				if (!_barBrushes.ContainsKey(string.Empty))
				{
					return defaultBrush;
				}

				if(_barBrushes[string.Empty].TryGetValue(barIndex, out barBrush))
				{
					return barBrush.Brush ?? defaultBrush;
				}
			}
			else
			{
				if (_barBrushes[seriesName].TryGetValue(barIndex, out barBrush))
				{
					return barBrush.Brush ?? defaultBrush;
				}
			}

			return defaultBrush;
		}

		internal bool GetBarBrushChanged(int barIndex)
		{
			return GetBarBrushChanged(string.Empty, barIndex);
		}
		internal bool GetBarBrushChanged(string seriesName, int barIndex)
		{
			if (seriesName == null)
				throw new ArgumentNullException("seriesName");

			BarBrushData data;
			if (!_barBrushes.ContainsKey(seriesName))
			{
				if (!_barBrushes.ContainsKey(string.Empty))
				{
					return false;
				}
				if (_barBrushes[string.Empty].TryGetValue(barIndex, out data))
				{
					return data.Changed;
				}
			}
			else
			{
				if (_barBrushes[seriesName].TryGetValue(barIndex, out data))
				{
					return data.Changed;
				}
			}

			return false;
		}

//    internal void SetBarBrushChanged(int barIndex, bool newValue)
//    {
//      SetBarBrushChanged(string.Empty, barIndex, newValue);  
//    }
//    internal void SetBarBrushChanged(string seriesName, int barIndex, bool newValue)
//    {
//      if (_barBrushes.ContainsKey(seriesName) && _barBrushes[seriesName].ContainsKey(barIndex))
//      {
//        _barBrushes[seriesName][barIndex].Changed = newValue;
//        return;
//      }
//      if (!string.IsNullOrEmpty(seriesName))
//        SetBarBrushChanged(string.Empty, barIndex, newValue);
//    }

		internal double GetMax(Series series, bool ignoreZero, bool onlyVisible)
		{
			double max = double.MinValue;
			int start = 0;
			int count = series.RecordCount;
			if (onlyVisible)
			{
				start = _startIndex;
				count = _endIndex;
			}
			for (int i = start; i < count; i++)
			{
				if (ignoreZero)
				{
					if (series[i].Value.HasValue && series[i].Value > max && series[i].Value.Value != 0.0)
						max = series[i].Value.Value;
				}
				else
				{
					if (series[i].Value.HasValue && series[i].Value > max)
						max = series[i].Value.Value;
				}
			}
			return max;
		}
		internal double GetMax(Series series, bool ignoreZero)
		{
			return GetMax(series, ignoreZero, false);
		}

		internal Rect AbsoluteRect(FrameworkElement element)
		{
			GeneralTransform generalTransform = 
#if WPF
				element.TransformToAncestor(this);
#endif
#if SILVERLIGHT
				element.TransformToVisual(this);
#endif
			Point location = generalTransform.Transform(new Point(0, 0));
			return new Rect(location.X, location.Y, element.ActualWidth, element.ActualHeight);
		}


		internal int _groupingInterval = 1;
		internal void SetGroupingValue()
		{
			_groupingInterval = 1;
			return;  
//      while (((_endIndex - _startIndex) / _groupingInterval > MaxVisibleRecords))
//      {
//        _groupingInterval++;
//      }
//  
//      Debug.WriteLine("Grouping Interval: " + _groupingInterval);
		}
		#endregion

		private static bool IsLicenseValid()
		{
			// the personal license must always check for the license 
			// file and is limited to only three installations:
#if PERSONAL
			// Personal license must check the license file
			// because it can only run on this computer

			//Bios date
			string biosDate = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System", "SystemBiosDate", "").ToString();

			//Central processor 0 Identifier
			string processorId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "Identifier", "").ToString();

			string id = biosDate + processorId;
			if (string.IsNullOrEmpty(id))
				id = "modulus-bt8-keycode"; //failsafe

			string temp = "";
			const string key = "bt8";

			// Encode or decode and extract letters
			for (int i = 0; i < id.Length; i++)
			{
				int c = key[i % key.Length] ^ id[i];
				if ((c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122))
					temp += (char)c;
			}
			id = temp;

			// Now create the encoded hardware id
			string hid = id;
			temp = "";
			for (int i = 0; i < id.Length; i++)
			{
				char c = hid[i];
				temp += (c >= 48 && c < 57) || (c >= 65 && c < 90) || (c >= 97 && c < 121) ? (char)(c + 1) : c;
			}
			string encId = temp;

			// Get the path of the ModulusFE.StockChartX.dll assembly file
			string assemblyPath = Assembly.GetExecutingAssembly().Location;
			if (string.IsNullOrEmpty(assemblyPath))
			{
				MessageBox.Show("Critical error. Could not find assembly path.", "Error", MessageBoxButton.OK,
												MessageBoxImage.Error);
				return false;                        
			}
			FileInfo assemblyInfo = new FileInfo(assemblyPath);
			FileInfo licenseInfo = new FileInfo(assemblyInfo.DirectoryName + @"\StockChartX.WPF.plc");
			string licenseText;
			try
			{
				licenseText = licenseInfo.OpenText().ReadLine();  
			}
			catch
			{
				licenseText = "";
			}
			
			if (licenseText != encId)
			{
				MessageBox.Show("Development license missing or invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			return true;
#else
			return true;
#endif
		}

		internal void GetLineStudyToAdd(ChartPanel chartPanel)
		{
			_currentPanel = chartPanel;

			chartPanel._lineStudyToAdd = _lineStudyToAdd;
			_lineStudyToAdd.SetChartPanel(chartPanel);
		}

		private void ShowHideChartScroller()
		{
			//if (_chartScroller == null) return;
			if (_scroller == null) return;
			if (IsChartScrollerVisible)
			{
				//_chartScroller.Visibility = Visibility.Visible;
				_scroller.Visibility = Visibility.Visible;
				//_rootGrid.RowDefinitions[3].Height = new GridLength(15);
			}
			else
			{
				//_chartScroller.Visibility = Visibility.Collapsed;
				_scroller.Visibility = Visibility.Collapsed;
				//_rootGrid.RowDefinitions[3].Height = new GridLength(0);
			}
		}
		
		internal void ShowLineStudyContextMenu(Point position, ContextLine contextLine)
		{
			_panelsContainer._lineStudyContextMenu.ContextLine = contextLine;
			_panelsContainer._lineStudyContextMenu.Show(position);
		}

		internal LineStudyContextMenu LsContextMenu
		{
			get { return _panelsContainer._lineStudyContextMenu; }
		}

		/// <summary>
		/// Gets the left position of work area, Does not include Y axis if any
		/// </summary>
		internal double WorkAreaLeft
		{
			get
			{
				if (_scaleAlignement == ScaleAlignmentTypeEnum.Right)
					return 0;
				return ActualWidth - Constants.YAxisWidth;
			}
		}

		internal double WorkAreaRight
		{
			get
			{
				if (_scaleAlignement == ScaleAlignmentTypeEnum.Left)
					return ActualWidth;
				return ActualWidth - Constants.YAxisWidth;
			}
		}

		private void UpdatePanelsFontInformation()
		{
			if (_panelsContainer != null && _panelsContainer.Panels != null)
				_panelsContainer.Panels.ForEach(_ => _.UpdateYAxesFontInformation());
		}
	}
}

