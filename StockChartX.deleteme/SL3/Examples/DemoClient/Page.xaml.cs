using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ModulusFE;
using ModulusFE.DS.Random;
using ModulusFE.Indicators;
using ModulusFE.LineStudies;
using ModulusFE.OMS.Interface;
using ModulusFE.SL;

namespace TestChart
{
    public partial class Page
    {
        private readonly DsRandom _dataFeed = new DsRandom();
        private int _barCount = 1000;

        public Page()
        {
            InitializeComponent();

            //_stockChartX.AppRoot = LayoutRoot;

            LayoutRoot.Loaded += (sender, e) =>
            {
                _stockChartX.ApplyTemplate();
                CreateChart();

                cmbIndicators.ItemsSource = from indicator in StockChartX_IndicatorsParameters.Indicators
                                            where indicator.IndicatorType != IndicatorType.CustomIndicator
                                            orderby indicator.IndicatorRealName
                                            select indicator;
                cmbIndicators.SelectedIndex = 0;

                cmbLineStudies.ItemsSource = StockChartX_LineStudiesParams.LineStudiesTypes;
                cmbLineStudies.SelectedIndex = 0;
            };
        }

        private SolidColorBrush _chartPanelsBrush;

        string RandomSymbol
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 5; i++)
                    sb.Append((char)_r.Next(65, 82));

                return sb.ToString();
            }
        }

        private void CreateChart()
        {
            _chartPanelsBrush = new SolidColorBrush(Colors.Black);

            _stockChartX.ClearAll();
            _stockChartX.Symbol = RandomSymbol;

            ChartPanel topPanel = _stockChartX.AddChartPanel();
            ChartPanel volumePanel = _stockChartX.AddChartPanel(ChartPanel.PositionType.AlwaysBottom);

            topPanel.Background = volumePanel.Background = _chartPanelsBrush;

            Series[] ohlcSeries = _stockChartX.AddOHLCSeries(_stockChartX.Symbol, topPanel.Index);
            Series seriesVolume = _stockChartX.AddVolumeSeries(_stockChartX.Symbol, volumePanel.Index);


            ManualResetEvent eventHistory = new ManualResetEvent(false);
            List<BarData> data = new List<BarData>();

            // here, you have to connect to a WebService 
            // get data
            // append to chart
            // AJAX
            // RIA Services

            _dataFeed.GetHistory(new HistoryRequest
                                   {
                                       BarCount = _barCount,
                                       BarSize = 1,
                                       Periodicity = Periodicity.Minutely,
                                       Symbol = _stockChartX.Symbol
                                   }, datas =>
                                        {
                                            data.AddRange(datas);
                                            eventHistory.Set();
                                        });
            eventHistory.WaitOne();

            int maxBarCount = Math.Min(200, data.Count);
            int endIndex = data.Count - (int)(maxBarCount * 0.25);
            int startIndex = data.Count - maxBarCount;

            for (int row = 0; row < endIndex; row++)
            {
                BarData bd = data[row];
                _stockChartX.AppendOHLCValues(_stockChartX.Symbol, bd.TradeDate, bd.OpenPrice, bd.HighPrice, bd.LowPrice, bd.ClosePrice);
                _stockChartX.AppendVolumeValue(_stockChartX.Symbol, bd.TradeDate, bd.Volume);
            }

            ohlcSeries[0].StrokeColor = ColorsEx.Lime;
            ohlcSeries[1].StrokeColor = ColorsEx.Lime;
            ohlcSeries[2].StrokeColor = ColorsEx.Lime;
            ohlcSeries[3].StrokeColor = ColorsEx.Lime;

            ohlcSeries[3].TickBox = TickBoxPosition.Right;

            seriesVolume.StrokeColor = Colors.Green;
            seriesVolume.StrokeThickness = 1;
            // Note: If dividing volume by millions as we have above,
            // you should add an "M" to the volume panel like this:
            //StockChartX1.VolumePostfix = "M"; // M for "millions"
            // You could also divide by 1000 and show "K" for "thousands".
            _stockChartX.VolumePostfixLetter = "M";
            _stockChartX.VolumeDivisor = (int)1E6;

            //_stockChartX.ScaleAlignment = ScaleAlignmentTypeEnum.Left;
            _stockChartX.RightChartSpace = 0;
            _stockChartX.RealTimeXLabels = true;

            _stockChartX.SetPanelHeight(0, _stockChartX.ActualHeight * 0.75);

            _stockChartX.FirstVisibleRecord = startIndex;
            _stockChartX.LastVisibleRecord = endIndex;
            _stockChartX.GridStroke = new SolidColorBrush(Color.FromArgb(0x33, 0xCC, 0xCC, 0xCC));
            _stockChartX.ThreeDStyle = false;
            _stockChartX.YGridStepType = YGridStepType.NiceStep;

            _stockChartX.OptimizePainting = true;
            _stockChartX.Update();

            var lbl = _stockChartX.GetPanelByIndex(0).ChartPanelLabel;
            lbl.FontSize = 60;
            Canvas.SetLeft(lbl, 20);
            Canvas.SetTop(lbl, 20);
            lbl.Foreground = new SolidColorBrush(Color.FromArgb(0x33, 0xFF, 0xFF, 0xCC));
            lbl.Text = _stockChartX.Symbol;
        }

        private void btnAddBar_Click(object sender, RoutedEventArgs e)
        {
            if (_stockChartX.ChartType == ChartTypeEnum.OHLC)
            {
                var barData = _dataFeed.GetNextBar(_stockChartX.Symbol);
                _stockChartX.AppendOHLCValues(_stockChartX.Symbol, barData.TradeDate, barData.OpenPrice, barData.HighPrice,
                                             barData.LowPrice, barData.ClosePrice);
                _stockChartX.AppendVolumeValue(_stockChartX.Symbol, barData.TradeDate, barData.Volume);
            }
            else
            {
                double price, volume;
                DateTime timeStamp;
                _dataFeed.GetNextTick(_stockChartX.Symbol, out price, out volume, out timeStamp);

                _stockChartX.AppendTickValue(_stockChartX.Symbol, timeStamp, price, volume);
            }
            _stockChartX.Update();
        }

        private readonly Random _r = new Random();

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();

            switch (tag)
            {
                case "zoomin": _stockChartX.ZoomIn(2); break;
                case "zoomout": _stockChartX.ZoomOut(2); break;
                case "resetzoom": _stockChartX.ResetZoom(); break;
            }
        }

        private void _stockChartX_UserDrawingComplete(object sender, StockChartX.UserDrawingCompleteEventArgs e)
        {
            btnAddLineStudy.IsEnabled = true;
        }

        private void btnShowLineStudies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddLineStudy_Click(object sender, RoutedEventArgs e)
        {

            LineStudy.StudyTypeEnum studyTypeEnum =
              ((StockChartX_LineStudiesParams.LineStudyParams)cmbLineStudies.SelectedItem).StudyTypeEnum;
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
                default:
                    break;
            }

            string studyName = studyTypeEnum.ToString();
            int count = _stockChartX.GetLineStudyCountByType(studyTypeEnum);
            if (count > 0)
                studyName += count;
            LineStudy lineStudy = _stockChartX.AddLineStudy(studyTypeEnum, studyName, new SolidColorBrush(colorPicker.SelectedColor), args);
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

            btnAddLineStudy.IsEnabled = false;

            if (studyTypeEnum == LineStudy.StudyTypeEnum.HorizontalLine)
            {
                lineStudy.ValuePresenterAlignment = LineStudy.ValuePresenterAlignmentType.Left;
                lineStudy.LineStudyValue = new CustomHorLineValueGetter(_stockChartX);
            }
        }

        private int _indicatorCount;
        private bool _newPanelCreated;
        private void btnAddIndicator_Click(object sender, RoutedEventArgs e)
        {
            StockChartX_IndicatorsParameters.IndicatorParameters indicator =
              cmbIndicators.SelectedItem as StockChartX_IndicatorsParameters.IndicatorParameters;
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
            _newPanelCreated = !_stockChartX.IsOverlayIndicator(indicator.IndicatorType);
            string name = indicator.IndicatorRealName + (_indicatorCount > 0 ? _indicatorCount.ToString() : "");
            ChartPanel panel = !_newPanelCreated ? _stockChartX.GetPanelByIndex(0) : _stockChartX.AddChartPanel();

            if (panel == null)
            {
                MessageBox.Show("Chart does not have enough place for a new panel. Resize existings or remove some.",
                                "Not enough space", MessageBoxButton.OK);
                return;
            }

            if (_newPanelCreated)
                panel.Background = _chartPanelsBrush;

            _stockChartX.AddIndicator(indicator.IndicatorType, name, panel, true);

            _stockChartX.Update();
            _indicatorCount++;
        }

        private void _stockChartX_IndicatorAddComplete(object sender, StockChartX.IndicatorAddCompletedEventArgs e)
        {
            //this code will remove the unneeded empty panel created above when adding an indicator
            if (e.CanceledByUser && _newPanelCreated)
                _stockChartX.Update();
        }

        private void btnAddTick_Click(object sender, RoutedEventArgs e)
        {
            _stockChartX.TickCompressionType = TickCompressionEnum.Ticks;
            _stockChartX.TickPeriodicity = 5; //Create a bar every 5 ticks

            double price, volume;
            DateTime timeStamp;
            if (!_dataFeed.GetNextTick(_stockChartX.Symbol, out price, out volume, out timeStamp))
            {
                MessageBox.Show("Wrong symbol.");
                return;
            }

            _stockChartX.AppendTickValue(_stockChartX.Symbol, timeStamp, price, volume);

            _stockChartX.Update();
        }

        private Timer _timerTicks;
        private bool _timerEnabled;
        private void btnStartTickTimer_Click(object sender, RoutedEventArgs e)
        {
            if (_timerTicks == null)
            {
                _stockChartX.TickCompressionType = TickCompressionEnum.Ticks;
                _stockChartX.TickPeriodicity = 5; //Create a candle every 5 ticks

                _timerTicks =
                  new Timer(state =>
                            Dispatcher.BeginInvoke(
                              () =>
                              {
                                  double price, volume;
                                  DateTime timeStamp;
                                  _dataFeed.GetNextTick(_stockChartX.Symbol, out price, out volume, out timeStamp);

                                  _stockChartX.AppendTickValue(_stockChartX.Symbol, timeStamp, price, volume);

                                  _stockChartX.Update();
                              }));
            }

            _timerEnabled = !_timerEnabled;

            btnAddBar.IsEnabled = !_timerEnabled;
            btnAddTick.IsEnabled = !_timerEnabled;

            btnStartTickTimer.Content = _timerEnabled ? "Stop Tick Timer" : "Start Tick Timer";

            if (_timerEnabled)
            {
                _timerTicks.Change((int)TimeSpan.FromSeconds(1).TotalMilliseconds,
                                   (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
                _stockChartX.KeepZoomLevel = true; //this will scroll chart when adding a new candle
            }
            else
            {
                _timerTicks.Change(Timeout.Infinite, Timeout.Infinite);
                _stockChartX.KeepZoomLevel = false; //this will compress candles when adding a new one
            }
        }

        private void btnDeleteCurrentObject_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;

            bool needUpdate = false;
            foreach (object selectedObject in _stockChartX.SelectedObjectsCollection)
            {
                if (selectedObject is Indicator)
                {
                    needUpdate = true;
                    _stockChartX.RemoveSeries((Series)selectedObject);
                }
                else if (selectedObject is LineStudy)
                    _stockChartX.RemoveObject((LineStudy)selectedObject);
            }

            if (needUpdate)
                _stockChartX.Update();
        }

        private void btnToggleSideVolumeBars_Click(object sender, RoutedEventArgs e)
        {
            ChartPanel tp = _stockChartX.GetPanelByIndex(0);
            tp.SideVolumeDepthBars = tp.SideVolumeDepthBars == 0 ? 5 : 0;
        }

        private void btnApplyPriceStyle_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((Control)cmbPriceStyles.SelectedItem).Tag.ToString();
            PriceStyleEnum priceStyle = PriceStyleEnum.psStandard;

            switch (tag)
            {
                case "standard": priceStyle = PriceStyleEnum.psStandard; break;
                case "kagi":
                    priceStyle = PriceStyleEnum.psKagi;
                    _stockChartX.SetPriceStyleParam(0, 0); //Reversal size
                    _stockChartX.SetPriceStyleParam(1, (double)ChartDataType.Points);
                    break;
                case "equivolume": priceStyle = PriceStyleEnum.psEquiVolume; break;
                case "candlevolume": priceStyle = PriceStyleEnum.psCandleVolume; break;
                case "equivolumeshadow": priceStyle = PriceStyleEnum.psEquiVolumeShadow; break;
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
                case "heikinashi": priceStyle = PriceStyleEnum.psHeikinAshi; break;
            }

            _stockChartX.PriceStyle = priceStyle;
            _stockChartX.Update();
        }

        private void btnIndProps_Click(object sender, RoutedEventArgs e)
        {
            Indicator selectedIndicator = _stockChartX.SelectedObjectsCollection.OfType<Indicator>().FirstOrDefault();

            if (selectedIndicator != null)
            {
                selectedIndicator.ShowParametersDialog();
                return;
            }

            MessageBox.Show("No indicator selected.");
        }

        private void btnToggleDarvasBoxes_Click(object sender, RoutedEventArgs e)
        {
            _stockChartX.DarvasBoxes = !_stockChartX.DarvasBoxes;
        }

        private void btnAddCustomIndicator_Click(object sender, RoutedEventArgs e)
        {
            //count indicator, just to give an unique name for a new indicator
            _indicatorCount = _stockChartX.GetIndicatorCountByType(IndicatorType.CustomIndicator);
            //create inidcator name
            string indicatorName = "Custom Indicator";
            if (_indicatorCount > 0)
                indicatorName += _indicatorCount;
            //get a reference to the custom indicator
            CustomIndicator indicator = (CustomIndicator)_stockChartX.AddIndicator(IndicatorType.CustomIndicator,
                                                                                   indicatorName, _stockChartX.AddChartPanel(),
                                                                                   true);
            //Add some parameters to the custom indicator, these parameters willl apear in indicator's dialog
            //where user will be able to set them manually
            indicator.AddParameter("My Param1", ParameterType.ptPeriods, 10, typeof(int));
            indicator.AddParameter("My Param2", ParameterType.ptPointsOrPercent, 12, typeof(int));
            indicator.AddParameter("My Param3", ParameterType.ptSymbol, "", typeof(string));
            indicator.AddParameter(null, ParameterType.ptLimitMoveValue, 16, typeof(int));

            indicator.SetParameterValue(0, 10);
            indicator.SetParameterValue(1, 12);
            indicator.SetParameterValue(2, "MSFT.CLOSE");
            indicator.SetParameterValue(3, 2);

            //after we set parameters call Update, this will raise the event OnCustomIndicatorNeedsData
            //where you use your own formulas to calculate the indicator values
            _stockChartX.Update();
        }

        private void _stockChartX_CustomIndicatorNeedsData(object sender, StockChartX.CustomIndicatorNeedsDataEventArgs e)
        {
            double?[] data = new double?[_stockChartX.RecordCount];

            //do here some calculations and pass them back to the chart
            int startValue = _r.Next(20, 40);
            double lastValue = startValue;
            //e.Values has the values already calculated from previous call
            //Here we just re-fill the array with random values
            for (int i = 0; i < data.Length; i++)
            {
                if (_r.NextDouble() > 0.5)
                    lastValue += _r.NextDouble() * 0.25;
                else
                    lastValue -= _r.NextDouble() * 0.25;

                data[i] = lastValue;
            }
            //pass calculated values back to the chart
            e.Values = data;
        }

        private void btnUserIndicator_Click(object sender, RoutedEventArgs e)
        {
            //_stockChartX[SeriesTypeOHLC.Close].TickBox = TickBoxPosition.Right;
            //return;
            //      if (_stockChartX.ScalingType == ScalingTypeEnum.Linear)
            //        _stockChartX.ScalingType = ScalingTypeEnum.Semilog;
            //      else
            //        _stockChartX.ScalingType = ScalingTypeEnum.Linear;
            //      _stockChartX.Update();
            //      return;
            //
            //      _stockChartX.SetPriceStyleParam(1, dtPoints);

            SimpleMovingAverage simpleMovingAverage =
              (SimpleMovingAverage)_stockChartX.AddIndicator(IndicatorType.SimpleMovingAverage,
                                                              Guid.NewGuid().ToString(), _stockChartX.GetPanelByIndex(0),
                                                              false);
            simpleMovingAverage.SetParameterValue(0, "MSFT.CLOSE");
            simpleMovingAverage.SetParameterValue(1, 14);
            simpleMovingAverage.UpColor = simpleMovingAverage.DownColor = Colors.Cyan;
            _stockChartX.Update();
        }

        private void btnSaveAsImage_Click(object sender, RoutedEventArgs e)
        {
            _stockChartX.SaveToFile(StockChartX.ImageExportType.Png);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StockChartX.SerializationTypeEnum serType =
              (StockChartX.SerializationTypeEnum)System.Enum.Parse(typeof(StockChartX.SerializationTypeEnum),
              cmbSerType.SelectionBoxItem.ToString(), true);
            SaveFileDialog sfd = new SaveFileDialog();

            switch (serType)
            {
                case StockChartX.SerializationTypeEnum.All:
                    sfd.Filter = "StockChartX file (*.scx)|*.scx";
                    sfd.DefaultExt = "*.scx";
                    break;
                case StockChartX.SerializationTypeEnum.General:
                    sfd.Filter = "General Template file (*.scg)|*.scg";
                    sfd.DefaultExt = "*scg";
                    break;
                case StockChartX.SerializationTypeEnum.Objects:
                    sfd.Filter = "Object template file (*.sco)|*.sco";
                    sfd.DefaultExt = "*.sco";
                    break;
            }

            if (sfd.ShowDialog() == false)
                return;

            byte[] bytes = _stockChartX.SaveFile(serType);

            using (Stream stream = sfd.OpenFile())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            MessageBox.Show("Chart saved. Bytes Count: " + bytes.Length);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes;
            StockChartX.SerializationTypeEnum serType =
              (StockChartX.SerializationTypeEnum)System.Enum.Parse(typeof(StockChartX.SerializationTypeEnum),
              cmbSerType.SelectionBoxItem.ToString(), true);
            OpenFileDialog ofd = new OpenFileDialog();

            switch (serType)
            {
                case StockChartX.SerializationTypeEnum.All:
                    ofd.Filter = "StockChartX file (*.scx)|*.scx";
                    break;
                case StockChartX.SerializationTypeEnum.General:
                    ofd.Filter = "General Template file (*.scg)|*.scg";
                    break;
                case StockChartX.SerializationTypeEnum.Objects:
                    ofd.Filter = "Object template file (*.sco)|*.sco";
                    break;
            }

            if (ofd.ShowDialog() == false)
                return;

            if (serType == StockChartX.SerializationTypeEnum.All)
            {
                _stockChartX.ClearAll();//we must clear the chart when loading ALL
                _stockChartX.Update();
            }

            using (Stream stream = ofd.File.OpenRead())
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                int res = _stockChartX.LoadFile(bytes, serType);
                if (res == 0)
                {
                    int count = _stockChartX.RecordCount;
                    int maxBarCount = Math.Min(500, count);
                    int endIndex = count - (int)(maxBarCount * 0.25);
                    int startIndex = count - maxBarCount;
                    _stockChartX.FirstVisibleRecord = startIndex;
                    _stockChartX.LastVisibleRecord = endIndex;

                    _stockChartX.Update();
                    MessageBox.Show("Chart succesfully deserialized.");
                }
                else
                {
                    MessageBox.Show("Could not deserialize the data. Error " + res);
                }
            }
        }

        private void btnIntTests_Click(object sender, RoutedEventArgs e)
        {
            Sample2();
        }

        private void Sample1()
        {
            foreach (var chartPanel in _stockChartX.PanelsCollection)
            {
                chartPanel.Background = Brushes.White;
                chartPanel.TitleBarBackground
                  = new LinearGradientBrush
                      {
                          StartPoint = new Point(0.5, 0),
                          EndPoint = new Point(0.5, 1),
                          GradientStops = new GradientStopCollection
                                  {
                                    new GradientStop {Color = Color.FromArgb(0xFF, 0xD6, 0xD6, 0xD6), Offset = 0},
                                    new GradientStop {Color = Colors.White, Offset = 0.5},
                                    new GradientStop {Color = Color.FromArgb(0xFF, 0xD6, 0xD6, 0xD6), Offset = 1},
                                  }
                      };
                chartPanel.YAxesBackground = Brushes.White;
                chartPanel.TitleBarButtonForeground = Brushes.Black;
            }

            _stockChartX[SeriesTypeOHLC.Close].StrokeColor = Color.FromArgb(0xFF, 0x00, 0x80, 0x00);
            _stockChartX[SeriesTypeOHLC.Close].TitleBrush = Brushes.Green;
            _stockChartX[SeriesTypeOHLC.Close].TickBox = TickBoxPosition.Right;

            _stockChartX.FontForeground = Brushes.Black;
            _stockChartX.CalendarBackground = Brushes.White;
            _stockChartX.XGrid = true;
            _stockChartX.InfoPanelPosition = InfoPanelPositionEnum.FixedPosition;
            _stockChartX.InfoPanelValuesBackground = Brushes.Transparent;
            _stockChartX.InfoPanelValuesForeground = Brushes.Black;
            _stockChartX.InfoPanelLabelsBackground = Brushes.Transparent;
            _stockChartX.InfoPanelLabelsForeground = Brushes.Black;
            _stockChartX.InfoPanelFontSize = 12;
            _stockChartX.Background = Brushes.White;

            _stockChartX.Update();
        }

        public void Sample2()
        {
            _stockChartX.InfoPanelPosition = InfoPanelPositionEnum.FixedPosition;
            _stockChartX.InfoPanelValuesBackground = Brushes.Transparent;
            _stockChartX.InfoPanelValuesForeground = Brushes.Red;
            _stockChartX.InfoPanelLabelsBackground = Brushes.Transparent;
            _stockChartX.InfoPanelLabelsForeground = Brushes.Red;
            _stockChartX.InfoPanelFontSize = 12;
        }

        /// <summary>
        /// Code for Support Ticket 4348. User wanted to do some tests with a small dataset on the chart.
        /// This code simply changes the amount of data that will be loaded into the chart and then completely
        /// refreshes the chart on the screen. It will delete all of the users actions such as indicators
        /// and line studies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSmallDataSetChart_Click(object sender, RoutedEventArgs e)
        {
            _barCount = 10;
            CreateChart();
        }

        /// <summary>
        /// Code for Support Ticket 4360. User wanted to know how to load lots of data into the chart at once.
        /// This loads four different lines into the chart at one time (using just the OHLC data from a standard random
        /// data set). The user could throw this into a loop and see how much they could load at once.
        /// The speed of loading data into a chart is not really an issue of the Silverlight application, it has more
        /// to do with the data access issues (where is the data coming from? and how fast can you get it here?).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTicket4360_Click(object sender, RoutedEventArgs e)
        {
            // Change the current OHLC series to a line (Just to clean up the screen)
            Series open = _stockChartX.GetSeriesByName(_stockChartX.Symbol + ".OPEN");
            Series high = _stockChartX.GetSeriesByName(_stockChartX.Symbol + ".HIGH");
            Series low = _stockChartX.GetSeriesByName(_stockChartX.Symbol + ".LOW");
            Series close = _stockChartX.GetSeriesByName(_stockChartX.Symbol + ".CLOSE");
            open.SeriesType = SeriesTypeEnum.stLineChart;
            high.SeriesType = SeriesTypeEnum.stLineChart;
            low.SeriesType = SeriesTypeEnum.stLineChart;
            close.SeriesType = SeriesTypeEnum.stLineChart;

            // Create some random series to hold a line
            string randomStmbol1 = RandomSymbol;
            string randomStmbol2 = RandomSymbol;
            string randomStmbol3 = RandomSymbol;
            string randomStmbol4 = RandomSymbol;
            _stockChartX.AddSeries(randomStmbol1, 0);
            _stockChartX.AddSeries(randomStmbol2, 0);
            _stockChartX.AddSeries(randomStmbol3, 0);
            _stockChartX.AddSeries(randomStmbol4, 0);

            // Use the standard data creation, a whack load of random data.
            ManualResetEvent eventHistory = new ManualResetEvent(false);
            List<BarData> data = new List<BarData>();
            _dataFeed.GetHistory(new HistoryRequest
            {
                BarCount = _stockChartX.RecordCount,
                BarSize = 1,
                Periodicity = Periodicity.Minutely,
                Symbol = randomStmbol1
            }, datas =>
                {
                    data.AddRange(datas);
                    eventHistory.Set();
                });
            eventHistory.WaitOne();

            for (int row = 0; row < data.Count; row++)
            {
                BarData bd = data[row];
                _stockChartX.AppendValue(randomStmbol1, _stockChartX.GetTimestampByIndex(row).Value, bd.OpenPrice);
                _stockChartX.AppendValue(randomStmbol2, _stockChartX.GetTimestampByIndex(row).Value, bd.HighPrice);
                _stockChartX.AppendValue(randomStmbol3, _stockChartX.GetTimestampByIndex(row).Value, bd.LowPrice);
                _stockChartX.AppendValue(randomStmbol4, _stockChartX.GetTimestampByIndex(row).Value, bd.ClosePrice);
            }

            _stockChartX.Update();
        }

        // Personal preference for the additional tools to be more visible when working with them.
        private void AccordionItem_Selected(object sender, RoutedEventArgs e)
        {
            if (AccordionItemOtherTools.IsSelected)
            {
                AccordionItemLineStudies.IsSelected = false;
                AccordionItemChartTools.IsSelected = false;
            }
        }
    }
}
