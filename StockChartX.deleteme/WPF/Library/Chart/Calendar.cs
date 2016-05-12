using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

#if WPF
using System.Windows.Threading;
using Label=ModulusFE.PaintObjects.Label;
#endif
using ModulusFE.PaintObjects;

#if SILVERLIGHT
using ModulusFE.SL;
using ModulusFE.SL.Utils;
#endif


namespace ModulusFE    
{
	///<summary>
	///</summary>
	public partial class Calendar : Canvas, IInfoPanelAble   
	{
		private const string TimerRepaint = "TimerRepaint";
		internal StockChartX _chartX;

		private readonly ChartTimers _timerRepaint = new ChartTimers();
		//private readonly PaintObjectsManager<Line> _lines = new PaintObjectsManager<Line>();
		private readonly PaintObjectsManager<Label> _labels = new PaintObjectsManager<Label>();
		private Path _linesPath;

#if DEMO
		private Label _labelDemo;
		internal string _demoText;
#endif
		///<summary>
		///</summary>
		public Calendar()
		{
			_timerRepaint = new ChartTimers();
			_timerRepaint.RegisterTimer(TimerRepaint, () => Dispatcher.BeginInvoke(
#if WPF
					DispatcherPriority.Normal, 
#endif
					new Action(Paint)), 50);
			SizeChanged += (sender, e) => _timerRepaint.StartTimerWork(TimerRepaint);
#if SILVERLIGHT
			Mouse.RegisterMouseMoveAbleElement(this);
			MouseMove += (sender, e) => Mouse.UpdateMousePosition(this, e.GetPosition(this));
#endif

			_labels.NewObjectCreated +=
				label =>
					{
						label._textBlock.Foreground = _chartX.FontForeground;
						label._textBlock.FontSize = _chartX.FontSize;
						label._textBlock.FontFamily = _chartX.FontFamily;
					};
		}

		internal DataManager.DataManager DM
		{
			get { return _chartX._dataManager; }
		}

		internal void UpdateFontInformation()
		{
			_labels.Do(label =>
									{
										label._textBlock.Foreground = _chartX.FontForeground;
										label._textBlock.FontSize = _chartX.FontSize;
										label._textBlock.FontFamily = _chartX.FontFamily;
									});
		}

		private bool _painting;
		internal void Paint()
		{
			try
			{
				if (_painting) return;

				_painting = true;

				_timerRepaint.StopTimerWork(TimerRepaint);
#if WPF
#if DEMO
			if (!string.IsNullOrEmpty(_demoText) && _labelDemo == null)
			{
				_labelDemo = new Label();
				_labelDemo.AddTo(this);
				_labelDemo.Left = 10;
				_labelDemo.Top = 2;
//        _labelDemo._textBlock.Opacity = 0.7;
				_labelDemo._textBlock.Foreground = Brushes.Red;
				_labelDemo.Text = _demoText;
				_labelDemo._textBlock.FontSize = 16;
				_labelDemo.ZIndex = 100;
			}
#endif
#endif
				Rect rcBounds = new Rect(0, 0, ActualWidth, ActualHeight);

				if (_linesPath == null)
				{
					_linesPath = new Path
												 {
													 Stroke = _chartX.GridStroke,
													 StrokeThickness = 1,
												 };
					Children.Add(_linesPath);
				}

				//Background = _chartX.Background;
				//_lines.C = this;
				_labels.C = this;
				//_lines.Start();
				_labels.Start();

				int startIndex = _chartX._startIndex;
				GeometryGroup lines = new GeometryGroup();

				//Utils.DrawLine(rcBounds.Left, 0, rcBounds.Right, 0, _chartX.GridStroke, LinePattern.Solid, 1, _lines);
				lines.Children.Add(new LineGeometry
														 {
															 StartPoint = new Point(rcBounds.Left, 0),
															 EndPoint = new Point(rcBounds.Right, 0),
														 });

				int rcnt = _chartX.VisibleRecordCount;
				double periodPixels = _chartX.GetXPixel(rcnt) / rcnt;
				if (periodPixels < 1)
					periodPixels = 1;

				_chartX._xGridMap.Clear();
				double tradeWeek = periodPixels * 5; // 5 trading days in a week (avg)
				double tradeMonth = periodPixels * 20; // 20 trading days in a month (avg)
				double tradeYear = periodPixels * 253; // 253 trading days in a year (avg)  

				double averageCharWidth = _chartX.GetTextWidth("0");

				// Level 1:
				// YYYY
				double level1 = averageCharWidth * 4;

				// Level 2:
				// YY F M A M J J A S O N D
				double level2 = averageCharWidth * 2;

				// Level 3:
				// YY Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec
				double level3 = averageCharWidth * 3;

				// Level 4:
				// YYYY February March April May June July August September October November December
				double level4 = averageCharWidth * 9;

				// Level 5:
				// From -5 periods on right end, begin:
				// Jan DD  Feb DD  Mar DD  Apr DD  May DD  Jun DD  Jul DD  Aug DD  Sep DD  Oct DD  Nov DD  Dec DD
				double level5 = averageCharWidth * 6;

				// Level 6
				// Jan DD HH:MM
				double level6 = averageCharWidth * 10;

				double incr;
				int xGrid = 0;
				double x, lx = 0;

				if (_chartX.RealTimeXLabels)
				{
					string prevDay = "";

					incr = level6;
					string timeFormat = "HH:mm";
					if (_chartX.ShowSeconds)
					{
						incr += averageCharWidth * 2;
						timeFormat = "HH:mm:ss";
					}

					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);
						if (x == lx) continue;
						DateTime dDate = DM.GetTimeStampByIndex(period + startIndex);
						//if (dDate.Minute % 15 != 0) continue;
						if (incr > level6)
						{
							incr = 0;
							//Draw vertical line
							//_renderDevice.PlotUnitSeparator((float)x, true, 0);
							//Utils.DrawLine(x, 0, x, rcBounds.Height / 2, _chartX.GridStroke, LinePattern.Solid, 1, _lines);
							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							string szTime = dDate.ToString(timeFormat);
							string szDay = dDate.ToString("dd");
							string szMonth = dDate.ToString("MMM");

							string szDate;
							if (prevDay != szDay)
							{
								prevDay = szDay;
								szDate = szMonth + " " + szDay + " " + szTime;
								level6 = averageCharWidth * 12;
								lx += level6 / 2;
							}
							else
							{
								szDate = szTime;
							}

							//_renderDevice.PlotUnitText((float)x, szDate, 0);
							var lb = _labels.GetPaintObject();
							lb.Left = x;
							lb.Top = 1;
							lb.Text = szDate;
							//Utils.DrawText(x, 1, szDate, _chartX.FontForeground, _chartX.FontSize, _chartX.FontFamily, _labels);
							_chartX._xGridMap[xGrid++] = x;
						}

						incr += x - lx;
						lx = x;
					}

					_painting = false;

					_linesPath.Data = (System.Windows.Media.Geometry)lines.GetAsFrozen();
					//_lines.Stop();
					_labels.Stop();
					return;
				}

				lx = 0;
				double oldX = -1;
				string sCache = "#";
				string sDate;
				DateTime timestamp;
				DateTime? prevDate = null;
				if (level5 <= tradeWeek)
				{
					incr = level5;
					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);
						timestamp = DM.GetTimeStampByIndex(period + startIndex);

						if (prevDate.HasValue && prevDate.Value.Year != timestamp.Year)
							sDate = timestamp.ToString("yyyy MMM");
						else
							sDate = timestamp.ToString("dd MMM");

						prevDate = timestamp;

						if (incr > level5 && sCache != sDate && oldX != x)
						{
							incr = 0; //Reset

							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							var lb = _labels.GetPaintObject();
							lb.Left = x + 2;
							lb.Top = 1;
							lb.Text = sDate;

							sCache = sDate;
							oldX = x;
							_chartX._xGridMap[xGrid++] = x;
						}
						incr += (x - lx);
						lx = x;

					}
				}
				else if (level4 <= tradeMonth)
				{
					incr = level4;
					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);

						timestamp = DM.GetTimeStampByIndex(period + startIndex);
						sDate = timestamp.ToString("MMMM");
						if (timestamp.Month == 1)
							sDate = timestamp.ToString("yyyy MMM");

						if (incr > level4 && sDate != sCache)
						{
							incr = 0;
							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							var lb = _labels.GetPaintObject();
							lb.Left = x;
							lb.Top = 1;
							lb.Text = sDate;

							xGrid++;
						}
						sCache = sDate;
						incr += (x - lx);
						lx = x;

						_chartX._xGridMap[xGrid] = x;
					}
				}
				else if (level3 + 2 <= tradeMonth)
				{
					incr = level3;
					sCache = "#";
					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);

						timestamp = DM.GetTimeStampByIndex(period + startIndex);

						sDate = timestamp.ToString("MMM");
						if (timestamp.Month == 1)
							sDate = timestamp.ToString("yy");

						if (incr > level3 && sCache != sDate)
						{
							incr = 0;
							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							var lb = _labels.GetPaintObject();
							lb.Left = x;
							lb.Top = 1;
							lb.Text = sDate;

							xGrid++;
						}
						sCache = sDate;
						incr += (x - lx);
						lx = x;

						_chartX._xGridMap[xGrid] = x;
					}
				}
				else if (level2 <= tradeMonth)
				{
					incr = level2;
					sCache = "#";
					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);

						timestamp = DM.GetTimeStampByIndex(period + startIndex);
						sDate = timestamp.ToString("MMM");
						string sTemp;
						if (timestamp.Month == 1)
						{
							sDate = timestamp.ToString("yy");
							sTemp = sDate;
						}
						else
						{
							sTemp = sDate.Substring(0, 1);
						}
						if (incr > level2 && sCache != sDate)
						{
							incr = 0;

							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							var lb = _labels.GetPaintObject();
							lb.Left = x;
							lb.Top = 1;
							lb.Text = sTemp;

							xGrid++;
						}
						sCache = sDate;
						incr += (x - lx);
						lx = x;

						_chartX._xGridMap[xGrid] = x;
					}
				}
				else if (level1 <= tradeYear)
				{
					incr = level1;
					sCache = "#";
					for (int period = 0; period < rcnt; period++)
					{
						x = _chartX.GetXPixel(period);
						if (x == -1) break;

						timestamp = DM.GetTimeStampByIndex(period + startIndex);
						sDate = timestamp.ToString("yyyy");

						if (incr > level1 && sDate != sCache)
						{
							incr = 0;

							lines.Children.Add(new LineGeometry
																	 {
																		 StartPoint = new Point(x, 0),
																		 EndPoint = new Point(x, rcBounds.Height / 2)
																	 });

							var lb = _labels.GetPaintObject();
							lb.Left = x;
							lb.Top = 1;
							lb.Text = sDate;

							xGrid++;
						}
						sCache = sDate;
						incr += (x - lx);
						lx = x;

						_chartX._xGridMap[xGrid] = x;
					}
				}

				//_lines.Stop();
				_linesPath.Data = (System.Windows.Media.Geometry)lines.GetAsFrozen();
				_labels.Stop();
			}
			finally
			{
				_painting = false;

				//after calendar is painted must instruct each panel to repaint the X Grid if needed
				if (_chartX.XGrid)
				{
					foreach (var panel in _chartX.PanelsCollection)
					{
						panel.PaintXGrid();
					}
				}
			}
		}


		///<summary>
		///</summary>
		public IEnumerable<InfoPanelItem> InfoPanelItems
		{
			get
			{
				return new InfoPanelItem[] {new CalendarInfoPanelItem {_noCaption = true}};
			}
		}
	}

	internal class CalendarInfoPanelItem : InfoPanelItem
	{
		public override string Caption
		{
			get { return "TimeStamp"; }
		}

		public override string Value
		{
			get
			{
				int index = (int)_infoPanel.GetReverseX();

				if (index < 0 || index >= _infoPanel._chartX._endIndex)
				{
					return string.Empty;
				}

				index += _infoPanel._chartX._startIndex;

				DateTime dateTime = _infoPanel._chartX._dataManager.GetTimeStampByIndex(index);

				return dateTime == DateTime.MinValue ? string.Empty : dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
			}
		}
	}
}

