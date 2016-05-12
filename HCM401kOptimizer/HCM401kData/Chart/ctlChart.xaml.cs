using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ModulusFE;
using HCM401kAlerter;
using ModulusFE.LineStudies;
using ModulusFE.Indicators;


namespace HCM401kData
{
    public partial class ctlChart : UserControl
    {
        #region members

        bool initiated = false;
        bool UseCrossHairs = false;
        bool UserDrawingActivatedField = false;
        ChartColorsSet ColorSettings = new ChartColorsSet();
        bool FixedInfoPanel = true;
        WCFBarData NonInitChartValue;
        ChartPanel TopPanel, VolumePanel;
        private Series[] OHLCSeries;
        private Series VolumeSeries;
        string PriceStyleTag = "standard";
        List<LineStudy> AddedAroonArrows = new List<LineStudy>();
        WCFBarData CurrentBars;
        System.Collections.IEnumerable IndicatorsField;
        IEnumerable<ModulusFE.StockChartX_LineStudiesParams.LineStudyParams> LineStudiesField;
        private int IndicatorCount;
        private bool NewPanelCreated;

        #endregion //members

        #region properties

        private bool UserDrawingActivated
        {
            get { return UserDrawingActivatedField; }
            set
            {
                if (UserDrawingActivatedField != value)
                {
                    UserDrawingActivatedField = value;
                }
            }
        }

        public System.Collections.IEnumerable Indicators { get { return IndicatorsField; } }

        public IEnumerable<ModulusFE.StockChartX_LineStudiesParams.LineStudyParams> LineStudies { get { return LineStudiesField; } }

        #endregion //properties

        public ctlChart()
        {
            InitializeComponent();

            IndicatorsField = (from indicator in StockChartX_IndicatorsParameters.Indicators
                                                      where indicator.IndicatorType != IndicatorType.CustomIndicator
                                                      orderby indicator.IndicatorRealName
                                                      select indicator);

            LineStudiesField = StockChartX_LineStudiesParams.LineStudiesTypes;
        }

        #region publics

        public void CreateChart(WCFBarData value, bool showVolume = false, bool isLine = false)
        {
            InfoMessage(true, "Loading ...");
            CurrentBars = value;
            if (value != null && value.Data != null && value.Data.Count > 2 && !string.IsNullOrEmpty(value.Symbol))
            {
                txtSymbol.Text = value.Symbol;
                brdrNoData.Visibility = System.Windows.Visibility.Collapsed;
                if (!initiated)
                    NonInitChartValue = value;
                else
                {
                    _stockChartX.ClearAll();
                    _stockChartX.Symbol = value.Symbol;

                    Brush chartPanelsBrush = new SolidColorBrush(Colors.Black);

                    TopPanel = _stockChartX.AddChartPanel();
                    TopPanel.Background = chartPanelsBrush;
                    TopPanel.CloseBox = false;
                    TopPanel.MaximizeBox = false;
                    TopPanel.MinimizeBox = false;

                    if (showVolume)
                    {
                        VolumePanel = _stockChartX.AddChartPanel(ChartPanel.PositionType.AlwaysBottom);
                        VolumePanel.Background = chartPanelsBrush;
                    }

                    TopPanel.Name = "TopPanel";
                    if (showVolume)
                        VolumePanel.Name = "VolumePanel";

                    if (isLine)
                        OHLCSeries = new Series[] { _stockChartX.AddLineSeries(value.Symbol, TopPanel.Index, SeriesTypeOHLC.Unknown) };
                    else
                        OHLCSeries = _stockChartX.AddOHLCSeries(_stockChartX.Symbol, TopPanel.Index);

                    for (int i = 0; i < OHLCSeries.Length; i++)
                        OHLCSeries[i].Selectable = false;

                    if (showVolume)
                        VolumeSeries = _stockChartX.AddVolumeSeries(_stockChartX.Symbol, VolumePanel.Index);

                    for (int row = 0; row < value.Data.Count; row++)
                    {
                        var bd = value.Data[row];
                        if (isLine)
                            _stockChartX.AppendValue(_stockChartX.Symbol, bd.TimeStamp.ToLocalTime(), bd.Close);
                        else
                            _stockChartX.AppendOHLCValues(_stockChartX.Symbol, bd.TimeStamp.ToLocalTime(), bd.Open, bd.High, bd.Low, bd.Close);

                        if (showVolume)
                            _stockChartX.AppendVolumeValue(_stockChartX.Symbol, bd.TimeStamp.ToLocalTime(), bd.Volume);
                    }

                    if (showVolume)
                    {
                        VolumeSeries.StrokeColor = Colors.White;
                        VolumeSeries.StrokeThickness = 1;
                    }

                    for (int i = 0; i < OHLCSeries.Length; i++)
                        OHLCSeries[i].StrokeColor = Colors.White;

                    if (_stockChartX[SeriesTypeOHLC.Close] != null)
                        _stockChartX[SeriesTypeOHLC.Close].TickBox = TickBoxPosition.Right;

                    //_stockChartX.SeriesTickBoxValuePresenterTemplate = new ControlTemplate();
                    // Note: If dividing volume by millions as we have above,
                    // you should add an "M" to the volume panel like this:
                    //StockChartX1.VolumePostfix = "M"; // M for "millions"
                    // You could also divide by 1000 and show "K" for "thousands".

                    _stockChartX.VolumePostfixLetter = "M";//"M";
                    _stockChartX.VolumeDivisor = (int)1E6;//1;//(int)1E6;
                    _stockChartX.ScalePrecision = IsForexPair(value.Symbol) ? 5 : 2;
                    _stockChartX.RightChartSpace = 5;
                    _stockChartX.RealTimeXLabels = false;
                    _stockChartX.SetPanelHeight(0, _stockChartX.ActualHeight * 0.75);
                    Brush fbrush = new SolidColorBrush(Color.FromArgb(0x33, 0xCC, 0xCC, 0xCC));

                    _stockChartX.GridStroke = fbrush;
                    _stockChartX.ThreeDStyle = false;
                    fbrush = new SolidColorBrush(Colors.White);

                    _stockChartX.InfoPanelLabelsBackground = fbrush;
                    _stockChartX.OptimizePainting = true;

                    _stockChartX.UseVolumeUpDownColors = true;
                    _stockChartX.InfoPanelPosition = FixedInfoPanel ? InfoPanelPositionEnum.FixedPosition : InfoPanelPositionEnum.FollowMouse;
                    _stockChartX.MaxVisibleRecords = int.MaxValue;// _stockChartX.RecordCount;
                    _stockChartX.Update();


                    var lbl = _stockChartX.GetPanelByIndex(0).ChartPanelLabel;
                    lbl.FontSize = 60;
                    Canvas.SetLeft(lbl, 20);
                    Canvas.SetTop(lbl, 20);
                    fbrush = new SolidColorBrush(Color.FromArgb(0x33, 0xFF, 0xFF, 0xCC));

                    lbl.Foreground = fbrush;
                    lbl.Text = _stockChartX.Symbol;
                    this._stockChartX.LayoutUpdated += _stockChartX_LayoutUpdated;
                }
            }
            else
                InfoMessage(true, "No Data");
            InfoMessage(false);
        }

        #endregion //publics

        #region Chart events

        void Chart_Loaded(object sender, RoutedEventArgs e)
        {
            if (!initiated)
            {
                initiated = true;
                Init();
            }
        }

        private void _stockChartX_MouseEnter(object sender, MouseEventArgs e)
        {
            if (UseCrossHairs)
                _stockChartX.CrossHairs = true;
        }

        private void _stockChartX_MouseLeave(object sender, MouseEventArgs e)
        {
            if (UseCrossHairs)
                _stockChartX.CrossHairs = false;
        }

        private void _stockChartX_UserDrawingComplete(object sender, StockChartX.UserDrawingCompleteEventArgs e)
        {
            UserDrawingActivated = false;
        }

        private void _stockChartX_IndicatorAddComplete(object sender, StockChartX.IndicatorAddCompletedEventArgs e)
        {
            if (e.CanceledByUser)
                _stockChartX.Update();
        }

        void _stockChartX_LayoutUpdated(object sender, EventArgs e)
        {
            this._stockChartX.LayoutUpdated -= _stockChartX_LayoutUpdated;
            ApplyColors();
            RefreshAroonDrawing();
            _stockChartX.ResetZoom();
        }

        #endregion //Chart events

        #region chart equipment

        public void CrossHair()
        {
            UseCrossHairs = !UseCrossHairs;
            _stockChartX.CrossHairs = UseCrossHairs;
        }

        public void DeleteCurrentObject()
        {
            if (MessageBox.Show("Selected item will be removed", "Information", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool _needUpdate = false;
                foreach (object selectedObject in _stockChartX.SelectedObjectsCollection)
                {
                    if (selectedObject is Indicator)
                    {
                        _needUpdate = true;
                        _stockChartX.RemoveSeries((Series)selectedObject);
                    }
                    else if (selectedObject is LineStudy)
                    {
                        _stockChartX.RemoveObject((LineStudy)selectedObject);
                    }
                    else
                        if (selectedObject is Series)
                        {
                            _needUpdate = true;
                            _stockChartX.RemoveSeries(((Series)selectedObject).FullName);
                        }
                }
                if (_needUpdate)
                    _stockChartX.Update();
            }
        }

        public void ZoomIn()
        {
            _stockChartX.ZoomIn(2);
        }

        public void ZoomOut()
        {
            _stockChartX.ZoomOut(2);
        }

        public void MoveLeft()
        {
            _stockChartX.ScrollLeft(_stockChartX.FirstVisibleRecord);
        }

        public void MoveRight()
        {
            _stockChartX.ScrollRight(_stockChartX.RecordCount - _stockChartX.LastVisibleRecord);
        }

        public void ResetZoom()
        {
            _stockChartX.ResetZoom();
        }

        public void ResetYScales()
        {
            foreach (ChartPanel pnl in _stockChartX.PanelsCollection)
                _stockChartX.ResetYScale(pnl.Index);
        }

        public void ToggleSideVolumeBars()
        {
            ChartPanel tp = _stockChartX.GetPanelByIndex(0);
            tp.SideVolumeDepthBars = tp.SideVolumeDepthBars == 0 ? 5 : 0;
        }

        public void ToggleDarvasBoxes()
        {
            _stockChartX.DarvasBoxes = !_stockChartX.DarvasBoxes;
        }

        public void SaveAsImage()
        {
            _stockChartX.SaveToFile(StockChartX.ImageExportType.Png);
        }

        public void ChangeInfoPanelState()
        {
            if (_stockChartX.InfoPanelPosition == InfoPanelPositionEnum.FixedPosition)
                _stockChartX.InfoPanelPosition = InfoPanelPositionEnum.FollowMouse;
            else
                _stockChartX.InfoPanelPosition = InfoPanelPositionEnum.FixedPosition;
        }

        public void ApplyPriceStyle(string tag)
        {
            ApplyPriceStyle(tag, 1);
        }

        public void AddLineStudy(LineStudy.StudyTypeEnum studyTypeEnum, Color color)
        {
            AddLineStudy(studyTypeEnum, color, null);
        }

        public LineStudy AddText(double x, double y, string text)
        {
            Brush fbrush = new SolidColorBrush(Colors.Blue);
            LineStudy line = _stockChartX.CreateLineStudy(LineStudy.StudyTypeEnum.StaticText, Guid.NewGuid().ToString(), fbrush, 0, new object[] { text });
            line.StrokeThickness = 10;
            line.SetXYValues(x, y, x, y);
            line.Selectable = false;
            return line;
        }

        public void AddIndicator(StockChartX_IndicatorsParameters.IndicatorParameters indicator)
        {
            if (indicator == null)
            {
                MessageBox.Show("Could not get indicator");
                return;
            }
            if (indicator.IndicatorType == IndicatorType.CustomIndicator)
            {
                MessageBox.Show("Custom indicator can't be added via this. Use menu point [Data/Add Custom Indicator]", "Error",
                  MessageBoxButton.OK);
                return;
            }

            //mark a flag whether a new panel was created, must update chart if it was and user pressed Cancel in indicator dialog
            NewPanelCreated = !_stockChartX.IsOverlayIndicator(indicator.IndicatorType);
            string name = indicator.IndicatorRealName + (IndicatorCount > 0 ? IndicatorCount.ToString() : "");
            ChartPanel panel = !NewPanelCreated ? _stockChartX.GetPanelByIndex(0) : _stockChartX.AddChartPanel();

            if (panel == null)
            {
                MessageBox.Show("Chart does not have enough place for a new panel. Resize existings or remove some.",
                                "Not enough space", MessageBoxButton.OK);
                return;
            }

            if (NewPanelCreated)
            {
                Brush brsh = GetGradient(ColorSettings.PanelTopColor, ColorSettings.PanelBottomColor);
                Brush fbrush = new SolidColorBrush(ColorSettings.YAxesColor);
                panel.Background = brsh;
                panel.YAxesBackground = fbrush;
            }
            _stockChartX.AddIndicator(indicator.IndicatorType, name, panel, true);
            _stockChartX.Update();
            IndicatorCount++;
        }

        #endregion //chart equipment

        #region privates

        private void Init()
        {
            ColorSettings.UpColor = Colors.Green;
            ColorSettings.DownColor = Colors.Red;
            ColorSettings.VolumeColor = Colors.Blue;
            ColorSettings.TextsColor = Colors.White;
            ColorSettings.PanelTopColor = Colors.White;
            ColorSettings.PanelBottomColor = Colors.White;
            ColorSettings.PanelGridColor = Colors.LightGray;
            ColorSettings.CrosshairColor = Colors.Black;
            ColorSettings.YAxesColor = Colors.Black;
            ColorSettings.CalendarColor = Colors.Black;
            ColorSettings.ClosingPriceColor = Colors.White;

            _stockChartX.ApplyTemplate();

            if (NonInitChartValue != null && NonInitChartValue.Data != null && NonInitChartValue.Data.Count > 0)
                CreateChart(NonInitChartValue, true, false);
        }

        private void ApplyColors()
        {
            ApplyColors(ColorSettings.UpColor, ColorSettings.DownColor, ColorSettings.VolumeColor, ColorSettings.TextsColor, ColorSettings.PanelTopColor, ColorSettings.PanelBottomColor, ColorSettings.PanelGridColor, ColorSettings.CrosshairColor, ColorSettings.YAxesColor, ColorSettings.CalendarColor, ColorSettings.ClosingPriceColor);
        }

        public void ApplyColors(Color up, Color down, Color volume, Color text, Color pnlTop, Color pnlBotom, Color pnlGrid, Color crossHair, Color yAxes, Color calendar, Color closingPrice)
        {
            if (OHLCSeries != null)
            {
                SetOHLCVcolors(up, down, volume, closingPrice);
                SetPanelsColor(pnlTop, pnlBotom, pnlGrid, crossHair, yAxes, calendar, text);
                _stockChartX.Update();
            }
        }

        private void SetOHLCVcolors(Color up, Color down, Color volume, Color closingPrice)
        {
            if (OHLCSeries != null)
            {
                for (int i = 0; i < OHLCSeries.Length; i++)
                {
                    OHLCSeries[i].StrokeColor = closingPrice;
                    if (OHLCSeries.Length > 1)
                    {
                        OHLCSeries[i].UpColor = up;
                        OHLCSeries[i].DownColor = down;
                    }
                }
            }
            if (VolumeSeries != null)
                VolumeSeries.StrokeColor = volume;

        }

        private void SetPanelsColor(Color pnlTop, Color pnlBotom, Color pnlGrid, Color crossHair, Color yAxes, Color calendar, Color text)
        {
            Brush brsh = GetGradient(pnlTop, pnlBotom);
            Brush fbrush = new SolidColorBrush(yAxes);
            if (_stockChartX != null)
                foreach (ChartPanel pnl in _stockChartX.PanelsCollection)
                {
                    pnl.Background = brsh;
                    pnl.YAxesBackground = fbrush;
                }
            fbrush = new SolidColorBrush(calendar);
            _stockChartX.CalendarBackground = fbrush;
            fbrush = new SolidColorBrush(yAxes);
            _stockChartX.Background = fbrush;
            fbrush = new SolidColorBrush(pnlGrid);
            _stockChartX.GridStroke = fbrush;
            fbrush = new SolidColorBrush(text);
            _stockChartX.FontForeground = fbrush;
            fbrush = new SolidColorBrush(crossHair);
            _stockChartX.CrossHairsStroke = fbrush;
        }

        public void AddLineStudy(LineStudy.StudyTypeEnum studyTypeEnum, Color color, object[] extraArgs = null)
        {
            object[] args = new object[0];
            double strokeThicknes = 1;

            //set some extra parameters to line studies
            switch (studyTypeEnum)
            {
                case LineStudy.StudyTypeEnum.StaticText:
                    args = new object[] { "Some text for testing" };
                    strokeThicknes = 12; //for text objects is FontSize
                    break;
                case LineStudy.StudyTypeEnum.VerticalLine:
                    //when first parameter is false, vertical line will display DataTime instead on record number
                    args = new object[]
                     {
                       false, //true - show record number, false - show datetime
                       true, //true - show text with line, false - show only line
                       "d", //custom datetime format, when args[0] == false. See MSDN:DateTime.ToString(string) for legal values
                     };
                    break;
                case LineStudy.StudyTypeEnum.ImageObject:
                    args = new object[]
                   {
                     "Res/open.png"
                   };
                    break;
                case LineStudy.StudyTypeEnum.FibonacciRetracements:
                    if (extraArgs != null)
                        args = extraArgs;
                    else
                        args = new object[]
                             {
                               1.0,
                               0.763932,
                               0.618034,
                               0.5,
                               0.381966,
                               0.236068,
                               0.0,
                             };
                    break;
                default:
                    break;
            }
            UserDrawingActivated = true;
            string studyName = studyTypeEnum.ToString();
            int count = _stockChartX.GetLineStudyCountByType(studyTypeEnum);
            if (count > 0)
                studyName += count;
            Brush fbrush = new SolidColorBrush(color);
            LineStudy lineStudy = _stockChartX.AddLineStudy(studyTypeEnum, studyName, fbrush, args);
            lineStudy.StrokeThickness = strokeThicknes;

            switch (studyTypeEnum)
            {
                case LineStudy.StudyTypeEnum.StaticText:
                    //if linestudy is a text object we can change its text directly
                    ((StaticText)lineStudy).Text = "Some other text for testing";
                    break;
                case LineStudy.StudyTypeEnum.HorizontalLine:
                    //change the appearance of horizontal Line
                    lineStudy.StrokeType = LinePattern.DashDot;
                    break;
                case LineStudy.StudyTypeEnum.ImageObject:
                    //set an additional ImageAlign property, this is very usefull when setting 
                    //images for close and open price, when you want to put image below or above a candle
                    //for Open price you'd use ImageObject.ImageAlign.BottomMiddle
                    //for Close price you'd use ImageObject.ImageAlign.TopMiddle
                    ((ImageObject)lineStudy).Align = ImageObject.ImageAlign.Center;
                    break;
            }

            if (studyTypeEnum == LineStudy.StudyTypeEnum.HorizontalLine)
            {
                lineStudy.ValuePresenterAlignment = LineStudy.ValuePresenterAlignmentType.Left;
                lineStudy.LineStudyValue = new CustomHorLineValueGetter(_stockChartX);
            }
        }

        public void ApplyPriceStyle(string tag, int size = 1)
        {
            PriceStyleTag = tag;

            if (_stockChartX.RecordCount > 0)
            {
                PriceStyleEnum priceStyle = PriceStyleEnum.psStandard;
                SeriesTypeEnum seriesType = SeriesTypeEnum.stCandleChart;

                switch (tag)
                {
                    case "bar":
                        seriesType = SeriesTypeEnum.stStockBarChart;
                        break;
                    case "line":
                        seriesType = SeriesTypeEnum.stLineChart;
                        break;
                    case "standard":
                        priceStyle = PriceStyleEnum.psStandard;
                        break;
                    case "kagi":
                        priceStyle = PriceStyleEnum.psKagi;
                        _stockChartX.SetPriceStyleParam(0, 0); //Reversal size
                        _stockChartX.SetPriceStyleParam(1, (double)ChartDataType.Points);
                        break;
                    case "equivolume":
                        priceStyle = PriceStyleEnum.psEquiVolume;
                        break;
                    case "candlevolume":
                        priceStyle = PriceStyleEnum.psCandleVolume;
                        break;
                    case "equivolumeshadow":
                        priceStyle = PriceStyleEnum.psEquiVolumeShadow;
                        break;
                    case "pointandfigure":
                        priceStyle = PriceStyleEnum.psPointAndFigure;
                        _stockChartX.SetPriceStyleParam(0, 0); //Allow StockChartX to figure the box size
                        _stockChartX.SetPriceStyleParam(1, 3); //Reversal size
                        break;
                    case "renko":
                        priceStyle = PriceStyleEnum.psRenko;
                        _stockChartX.SetPriceStyleParam(0, 1); //Box size
                        break;
                    case "threelinebreak":
                        priceStyle = PriceStyleEnum.psThreeLineBreak;
                        _stockChartX.SetPriceStyleParam(0, 3); //Three line break (could be 1 to 50 line break)
                        break;
                    case "heikinashi":
                        priceStyle = PriceStyleEnum.psHeikinAshi;
                        break;
                }

                if (OHLCSeries != null && OHLCSeries.Length > 3)
                {
                    OHLCSeries[0].SeriesType = seriesType;
                    OHLCSeries[1].SeriesType = seriesType;
                    OHLCSeries[2].SeriesType = seriesType;
                    OHLCSeries[3].SeriesType = seriesType;
                }
                _stockChartX.PriceStyle = priceStyle;
                SetLinesSize(size);
                _stockChartX.Update();
            }
        }

        public void SetLinesSize(int size)
        {
            if (OHLCSeries != null)
            {
                for (int i = 0; i < OHLCSeries.Length; i++)
                    OHLCSeries[i].StrokeThickness = size;
                _stockChartX.Update();
            }
            _stockChartX.FirstVisibleRecord++;
            _stockChartX.FirstVisibleRecord--;
        }

        private LineStudy DrawArrowObject(int idx, double price, SymbolType symbolType)
        {
            LineStudy _buyObject = _stockChartX.CreateSymbolObject(symbolType, Guid.NewGuid().ToString(), 0, new Size(12, 14));
            _buyObject.SetXYValues(0, 0, idx, price);
            _buyObject.Selectable = false;
            return _buyObject;
        }

        private void RemoveAroonArrowsOnChart()
        {
            for (int i = 0; i < AddedAroonArrows.Count; i++)
                _stockChartX.RemoveObject(AddedAroonArrows[i]);
            AddedAroonArrows.Clear();
        }

        private Brush GetGradient(Color top, Color bottom)
        {
            Brush brsh = new LinearGradientBrush
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1),
                GradientStops = new GradientStopCollection
                                           {
                                             new GradientStop
                                               {
                                                 Color = top,
                                                 Offset = 0
                                               },
                                             new GradientStop
                                               {
                                                 Color = bottom,
                                                 Offset = 1
                                               }
                                           }
            };
            return brsh;
        }

        private void InfoMessage(bool show, string messag = "")
        {
            brdrNoData.Visibility = show ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            txtInfo.Text = messag;
        }

        private bool IsForexPair(string symbol)
        {
            return (symbol.Length == 7 && symbol[3] == '/');
        }

        private void RefreshAroonDrawing()
        {
            RemoveAroonArrowsOnChart();
            if (CurrentBars != null && CurrentBars.Data != null && CurrentBars.Data.Count > 0)
            {
                var bars = CurrentBars.Data.OrderBy(x => x.TimeStamp).ToList();
                var data = TechnicalCalculations.AroonOscillator(CurrentBars, 16);
                DataResult prevItem = null;
                SymbolType prevType = SymbolType.Signal;
                
                foreach (var itm in data)
                {
                    if (prevItem != null)
                    {
                        if (prevItem.Value <= 0 && itm.Value > 0)
                            if (prevType != SymbolType.Buy)
                            {
                                prevType = SymbolType.Buy;
                                var bar = bars[itm.Position];
                                double pos = bars[itm.Position].Low - bars[itm.Position].Low * 0.015;

                                DrawArrowObject(itm.Position, pos, SymbolType.Buy);
                            }

                        if (prevItem.Value >= 0 && itm.Value < 0)
                            if (prevType != SymbolType.Sell)
                            {
                                prevType = SymbolType.Sell;
                                var bar = bars[itm.Position];
                                double pos = bars[itm.Position].High +  bars[itm.Position].High * 0.015;

                                DrawArrowObject(itm.Position, pos, SymbolType.Sell);
                            }
                    }
                    else
                        prevItem = itm;
                }
            }
        }

        #endregion //privates
       
    }
}
