using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using ModulusFE.Controls;
using ModulusFE.PaintObjects;

namespace ModulusFE
{
  public partial class StockChartX
  {
    static StockChartX()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof (StockChartX), new FrameworkPropertyMetadata(typeof (StockChartX)));

//      AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
//      if (Application.Current != null)
//        Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

      #region Dependency properties registration

      ShowAnimationsProperty =
        DependencyProperty.Register("ShowAnimations",
                                    typeof (bool), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShowAnimationsChanged)));
      ScaleAlignmentProperty =
        DependencyProperty.Register("ScaleAlignment", typeof (ScaleAlignmentTypeEnum), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(ScaleAlignmentTypeEnum.Right, OnScaleAlignmentChanged));

      YGridProperty =
        DependencyProperty.Register("ShowYGrid", typeof (bool), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(true, OnShowYGridChanged));

      XGridProperty =
        DependencyProperty.Register("ShowXGrid", typeof (bool), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(false, OnShowXGridChanged));

      GridStrokeProperty =
        DependencyProperty.Register("GridStroke", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Silver, OnGridStrokeChanged));

      CrossHairsProperty =
        DependencyProperty.Register("CrossHairs", typeof (bool), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(false, OnCrossHairsChanged));

      CrossHairsStrokeProperty =
        DependencyProperty.Register("CrossHairsStroke", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Yellow, OnCrossHairsColorChanged));

      DisplatTitlesProperty =
        DependencyProperty.Register("DisplayTitles", typeof (bool), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(true, OnDisplatTitlesChanged));

      IndicatorDialogBackgroundProperty =
        DependencyProperty.Register("IndicatorDialogBackground", typeof (Brush), typeof (StockChartX),
                                    new PropertyMetadata(
                                      new RadialGradientBrush
                                        {
                                          Center = new Point(0.6, 0.7),
                                          RadiusX = 1,
                                          RadiusY = 1,
                                          GradientStops =
                                            new GradientStopCollection
                                              {
                                                new GradientStop(Colors.LightBlue, 0),
                                                new GradientStop(Colors.LightSteelBlue, 1)
                                              }
                                        }));

      InfoPanelLabelsBackgroundProperty =
        DependencyProperty.Register("InfoPanelLabelsBackground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Yellow, OnInfoPanelLabelsBackgroundChanged));

      InfoPanelLabelsForegroundProperty =
        DependencyProperty.Register("InfoPanelLabelsForeground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Black, OnInfoPanelLabelsForegroundChanged));

      InfoPanelValuesBackgroundProperty =
        DependencyProperty.Register("InfoPanelValuesBackground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.White, OnInfoPanelValuesBackgroundChanged));

      InfoPanelValuesForegroundProperty =
        DependencyProperty.Register("InfoPanelValuesForeground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Black, OnInfoPanelValuesForegroundChanged));

      InfoPanelFontFamilyProperty =
        DependencyProperty.Register("InfoPanelFontFamily", typeof (FontFamily), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(new FontFamily("Arial"), OnInfoPanelFontFamilyChanged));

      InfoPanelFontSizeProperty =
        DependencyProperty.Register("InfoPanelFontSize", typeof (double), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(9.0, OnInfoPanelFontSizeChanged));

      InfoPanelPositionProperty =
        DependencyProperty.Register("InfoPanelPosition", typeof (InfoPanelPositionEnum), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(InfoPanelPositionEnum.FollowMouse,
                                                                  OnInfoPanelPositionChanged));

      VolumePostfixLetterProperty =
        DependencyProperty.Register("VolumePostfix", typeof (string), typeof (StockChartX),
                                    new PropertyMetadata(""));

      HeatPanelLabelsForegroundProperty =
        DependencyProperty.Register("HeatPanelLabelsForeground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Yellow, OnHeatPanelLabelsForegroundChanged));

      HeatPanelLabelsBackgroundProperty =
        DependencyProperty.Register("HeatPanelLabelsBackground", typeof (Brush), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(Brushes.Black, OnHeatPanelLabelsBackgroundChanged));

      HeatPanelLabelsFontSizeProperty =
        DependencyProperty.Register("HeatPanelLabelsFontSize", typeof (double), typeof (StockChartX),
                                    new FrameworkPropertyMetadata(12.0, OnHeatPanelLabelFontSizeChanged));

      LineStudyPropertyDialogBackgroundProperty =
        DependencyProperty.Register("LineStudyPropertyDialogBackground", typeof (Brush), typeof (StockChartX),
                                    new PropertyMetadata(Brushes.White));

      #endregion
    }


    #region ShowAnimations
    /// <summary>
    /// Gets os sets the value indicating whether the animations will be shown or not. 
    /// </summary>
    public static DependencyProperty ShowAnimationsProperty;
    ///<summary>
    /// Gets os sets the value indicating whether the animations will be shown or not. 
    ///</summary>
    public bool ShowAnimations
    {
      get { return (bool)GetValue(ShowAnimationsProperty); }
      set { SetValue(ShowAnimationsProperty, value); }
    }
    private static void OnShowAnimationsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      
    }
    #endregion

    #region ShowYGrid
    /// <summary>
    /// Gets or sets the visibility of Y grid
    /// </summary>
    public static readonly DependencyProperty YGridProperty;
    ///<summary>
    /// Gets or sets the visibility of Y grid
    ///</summary>
    public bool YGrid
    {
      get { return (bool)GetValue(YGridProperty); }
      set { SetValue(YGridProperty, value); }
    }
    private static void OnShowYGridChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      ((StockChartX)sender).ShowHideYGridLines();
    }
    #endregion

    #region ShowXGrid
    /// <summary>
    /// Gets or sets the visibility of X grid
    /// </summary>
    public static readonly DependencyProperty XGridProperty;
    ///<summary>
    /// Gets or sets the visibility of X grid
    ///</summary>
    public bool XGrid
    {
      get { return (bool)GetValue(XGridProperty); }
      set { SetValue(XGridProperty, value); }
    }
    private static void OnShowXGridChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      ((StockChartX)sender).ShowHideXGridLines();      
    }
    #endregion  


    #region Grid Color
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> that specifies how grid lines are painted
    ///</summary>
    public static readonly DependencyProperty GridStrokeProperty;
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> that specifies how grid lines are painted
    ///</summary>
    public Brush GridStroke
    {
      get { return (Brush)GetValue(GridStrokeProperty); }
      set { SetValue(GridStrokeProperty, value); }
    }
    private static void OnGridStrokeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      ((StockChartX)sender).Update();  
    }
    #endregion

    #region ScaleAlignment
    ///<summary>
    /// Gets or sets the value that deermines what Y axis is shown
    ///</summary>
    public static readonly DependencyProperty ScaleAlignmentProperty;
    ///<summary>
    /// Gets or sets the value that deermines what Y axis is shown
    ///</summary>
    public ScaleAlignmentTypeEnum ScaleAlignment
    {
      get { return (ScaleAlignmentTypeEnum)GetValue(ScaleAlignmentProperty); }
      set { SetValue(ScaleAlignmentProperty, value); }
    }
    private static void OnScaleAlignmentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._scaleAlignement = (ScaleAlignmentTypeEnum)eventArgs.NewValue;
      chartX.SetYAxes();
    }
    
    #endregion

    #region CrossHairs
    ///<summary>
    /// Gets or sets the visibility of crosshairs lines
    ///</summary>
    public static readonly DependencyProperty CrossHairsProperty;
    ///<summary>
    /// Gets or sets the visibility of crosshairs lines
    ///</summary>
    public bool CrossHairs
    {
      get { return (bool)GetValue(CrossHairsProperty); }
      set { SetValue(CrossHairsProperty, value); }
    }
    private static void OnCrossHairsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;

      if ((bool)eventArgs.NewValue)
        chartX._timers.StartTimerWork(TimerCrossHairs);
      else
      {
        chartX._timers.StopTimerWork(TimerCrossHairs);
        chartX._panelsContainer.HideCrossHairs();
      }
    }
    #endregion

    #region CrossHairs Color
    /// <summary>
    /// Gets or sets the color of crosshairs lines
    /// </summary>
    public static readonly DependencyProperty CrossHairsStrokeProperty;
    /// <summary>
    /// Gets or sets the color of crosshairs lines
    /// </summary>
    public Brush CrossHairsStroke
    {
      get { return (Brush) GetValue(CrossHairsStrokeProperty); }
      set { SetValue(CrossHairsStrokeProperty, value); }
    }
    private static void OnCrossHairsColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX) sender;

      if (chartX._panelsContainer != null)
        chartX._panelsContainer.UpdateCrossHairsColor();
    }

    #endregion


    #region DisplayTitles
    ///<summary>
    /// Gets or sets the value indicator whether to display panels titles or not.
    ///</summary>
    public static readonly DependencyProperty DisplatTitlesProperty;
    ///<summary>
    /// Gets or sets the value indicator whether to display panels titles or not.
    ///</summary>
    public bool DisplayTitles
    {
      get { return (bool)GetValue(DisplatTitlesProperty); }
      set { SetValue(DisplatTitlesProperty, value); }
    }
    private static void OnDisplatTitlesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = ((StockChartX)sender);
      foreach (ChartPanel chartPanel in chartX._panelsContainer.Panels)
      {
        chartPanel.ShowHideTitleBar();
      }  
    }
    #endregion

    #region IndicatorDialogBackground
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> used as background for indicators dialog.
    ///</summary>
    public static readonly DependencyProperty IndicatorDialogBackgroundProperty;
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> used as background for indicators dialog.
    ///</summary>
    public Brush IndicatorDialogBackground
    {
      get { return (Brush)GetValue(IndicatorDialogBackgroundProperty); }
      set { SetValue(IndicatorDialogBackgroundProperty, value); }
    }

    /// <summary>
    /// Gets or sets the postfix letter used on to display volume in millions (e.g. you want to show 5,200,000 as "5.2 M" in the Y scale). 
    /// </summary>
    public static readonly DependencyProperty VolumePostfixLetterProperty;
    /// <summary>
    /// Gets or sets the postfix letter used on to display volume in millions (e.g. you want to show 5,200,000 as "5.2 M" in the Y scale). 
    /// </summary>
    public string VolumePostfixLetter
    {
      get { return (string)GetValue(VolumePostfixLetterProperty); }
      set { SetValue(VolumePostfixLetterProperty, value); }
    }
    #endregion

    #region InfoPanel
    ///<summary>
    /// Gets or sets the background <seealso cref="Brush"/> of infopanel's labels.
    ///</summary>
    public static readonly DependencyProperty InfoPanelLabelsBackgroundProperty;
    ///<summary>
    /// Gets or sets the background <seealso cref="Brush"/> of infopanel's labels.
    ///</summary>
    public Brush InfoPanelLabelsBackground
    {
      get { return (Brush)GetValue(InfoPanelLabelsBackgroundProperty); }
      set { SetValue(InfoPanelLabelsBackgroundProperty, value); }
    }
    private static void OnInfoPanelLabelsBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();     
    }

    ///<summary>
    /// Gets or sets the foreground <seealso cref="Brush"/> of infopanel's labels.
    ///</summary>
    public static readonly DependencyProperty InfoPanelLabelsForegroundProperty;
    ///<summary>
    /// Gets or sets the foreground <seealso cref="Brush"/> of infopanel's labels.
    ///</summary>
    public Brush InfoPanelLabelsForeground
    {
      get { return (Brush)GetValue(InfoPanelLabelsForegroundProperty); }
      set { SetValue(InfoPanelLabelsForegroundProperty, value); }
    }
    private static void OnInfoPanelLabelsForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();     
    }

    ///<summary>
    /// Gets or sets the background <seealso cref="Brush"/> of infopanel's values.
    ///</summary>
    public static readonly DependencyProperty InfoPanelValuesBackgroundProperty;
    ///<summary>
    /// Gets or sets the background <seealso cref="Brush"/> of infopanel's values.
    ///</summary>
    public Brush InfoPanelValuesBackground
    {
      get { return (Brush)GetValue(InfoPanelValuesBackgroundProperty); }
      set { SetValue(InfoPanelValuesBackgroundProperty, value); }
    }
    private static void OnInfoPanelValuesBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();     
    }

    ///<summary>
    /// Gets or sets the foreground <seealso cref="Brush"/> of infopanel's values.
    ///</summary>
    public static readonly DependencyProperty InfoPanelValuesForegroundProperty;
    ///<summary>
    /// Gets or sets the foreground <seealso cref="Brush"/> of infopanel's values.
    ///</summary>
    public Brush InfoPanelValuesForeground
    {
      get { return (Brush)GetValue(InfoPanelValuesForegroundProperty); }
      set { SetValue(InfoPanelValuesForegroundProperty, value); }
    }
    private static void OnInfoPanelValuesForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();     
    }

    ///<summary>
    /// Gets or sets the preferred top-level font family for the textblock used in info panel.
    ///</summary>
    public static readonly DependencyProperty InfoPanelFontFamilyProperty;
    ///<summary>
    /// Gets or sets the preferred top-level font family for the textblock used in info panel.
    ///</summary>
    public FontFamily InfoPanelFontFamily
    {
      get { return (FontFamily)GetValue(InfoPanelFontFamilyProperty); }
      set { SetValue(InfoPanelFontFamilyProperty, value); }
    }
    private static void OnInfoPanelFontFamilyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();     
    }

    ///<summary>
    /// Gets or sets the preferred top-level font size for the textblock used in info panel.
    ///</summary>
    public static readonly DependencyProperty InfoPanelFontSizeProperty;
    ///<summary>
    /// Gets or sets the preferred top-level font size for the textblock used in info panel.
    ///</summary>
    public double InfoPanelFontSize
    {
      get { return (double)GetValue(InfoPanelFontSizeProperty); }
      set { SetValue(InfoPanelFontSizeProperty, value); }
    }
    private static void OnInfoPanelFontSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      chartX._panelsContainer.EnforceInfoPanelUpdate();
    }

    ///<summary>
    /// Gets or sets the positioning type of info panel.
    ///</summary>
    public static readonly DependencyProperty InfoPanelPositionProperty;
    ///<summary>
    /// Gets or sets the positioning type of info panel.
    ///</summary>
    public InfoPanelPositionEnum InfoPanelPosition
    {
      get { return (InfoPanelPositionEnum)GetValue(InfoPanelPositionProperty); }
      set { SetValue(InfoPanelPositionProperty, value); }
    }

    private static void OnInfoPanelPositionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      InfoPanelPositionEnum positionEnum = (InfoPanelPositionEnum)eventArgs.NewValue;
      if (positionEnum == InfoPanelPositionEnum.Hidden || positionEnum == InfoPanelPositionEnum.FollowMouse)
      {
        chartX._timers.StopTimerWork(TimerInfoPanel);
        chartX._panelsContainer.HideInfoPanel();
        return;
      }
      if (positionEnum != InfoPanelPositionEnum.FixedPosition) return;
      chartX._timers.StartTimerWork(TimerInfoPanel);
      chartX._panelsContainer.MakeInfoPanelStatic();
    }
    #endregion

    #region Heat Panel Labels

    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> to apply to labels in heat panel.
    ///</summary>
    public static readonly DependencyProperty HeatPanelLabelsForegroundProperty;
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> to apply to labels in heat panel.
    ///</summary>
    public Brush HeatPanelLabelsForeground
    {
      get { return (Brush)GetValue(HeatPanelLabelsForegroundProperty); }
      set { SetValue(HeatPanelLabelsForegroundProperty, value); }
    }
    private static void OnHeatPanelLabelsForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      if (chartX._panelsContainer != null)
        chartX._panelsContainer.ResetHeatMapPanels();
    }

    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> to apply to labels background
    ///</summary>
    public static readonly DependencyProperty HeatPanelLabelsBackgroundProperty;
    ///<summary>
    /// Gets or sets the <seealso cref="Brush"/> to apply to labels background
    ///</summary>
    public Brush HeatPanelLabelsBackground
    {
      get { return (Brush)GetValue(HeatPanelLabelsBackgroundProperty); }
      set { SetValue(HeatPanelLabelsBackgroundProperty, value); }
    }
    private static void OnHeatPanelLabelsBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      if (chartX._panelsContainer != null)
        chartX._panelsContainer.ResetHeatMapPanels();
    }

    ///<summary>
    /// Gets or sets the font-size for labels used in heat-panel
    ///</summary>
    public static readonly DependencyProperty HeatPanelLabelsFontSizeProperty;
    ///<summary>
    /// Gets or sets the font-size for labels used in heat-panel
    ///</summary>
    public double HeatPanelLabelsFontSize
    {
      get { return (double)GetValue(HeatPanelLabelsFontSizeProperty); }
      set { SetValue(HeatPanelLabelsFontSizeProperty, value); }
    }
    private static void OnHeatPanelLabelFontSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
      StockChartX chartX = (StockChartX)sender;
      if (chartX._panelsContainer != null)
        chartX._panelsContainer.ResetHeatMapPanels();  
    }
    #endregion


    private static void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
    {
      ExceptionWindow exceptionWindow = new ExceptionWindow(args.Exception);
      exceptionWindow.ShowDialog();
      args.Handled = true;
    }

    #region Chart Scroller

    #region ChartScrollerVisibleProperty (DependencyProperty)

    /// <summary>
    /// A description of the IsChartScrollerVisible.
    /// </summary>
    public bool IsChartScrollerVisible
    {
      get { return (bool)GetValue(ChartScrollerVisibleProperty); }
      set { SetValue(ChartScrollerVisibleProperty, value); }
    }

    /// <summary>
    /// IsChartScrollerVisible
    /// </summary>
    public static readonly DependencyProperty ChartScrollerVisibleProperty =
      DependencyProperty.Register("IsChartScrollerVisible", typeof (bool), typeof (StockChartX),
                                  new PropertyMetadata(true, OnChartScrollerVisibleChanged));

    private static void OnChartScrollerVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnChartScrollerVisibleChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnChartScrollerVisibleChanged(DependencyPropertyChangedEventArgs e)
    {
      ShowHideChartScroller();      
    }

    #endregion

    #region ChartScrollerTrackBackgroundProperty (DependencyProperty)

    /// <summary>
    /// A description of the ChartScrollerTrackBackground.
    /// </summary>
    public Brush ChartScrollerTrackBackground
    {
      get { return (Brush)GetValue(ChartScrollerTrackBackgroundProperty); }
      set { SetValue(ChartScrollerTrackBackgroundProperty, value); }
    }

    /// <summary>
    /// ChartScrollerTrackBackground
    /// </summary>
    public static readonly DependencyProperty ChartScrollerTrackBackgroundProperty =
      DependencyProperty.Register("ChartScrollerTrackBackground", typeof (Brush), typeof (StockChartX),
                                  new PropertyMetadata(Brushes.Silver, OnChartScrollerTrackBackgroundChanged));

    private static void OnChartScrollerTrackBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnChartScrollerTrackBackgroundChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnChartScrollerTrackBackgroundChanged(DependencyPropertyChangedEventArgs e)
    {
//      if (_chartScroller != null)
//        _chartScroller.TrackBackground = (Brush)e.NewValue;
    }

    #endregion

    #region ChartScrollerTrackButtonsBackgroundProperty (DependencyProperty)

    /// <summary>
    /// A description of the ChartScrollerTrackButtonsBackground.
    /// </summary>
    public Brush ChartScrollerTrackButtonsBackground
    {
      get { return (Brush)GetValue(ChartScrollerTrackButtonsBackgroundProperty); }
      set { SetValue(ChartScrollerTrackButtonsBackgroundProperty, value); }
    }

    /// <summary>
    /// ChartScrollerTrackButtonsBackground
    /// </summary>
    public static readonly DependencyProperty ChartScrollerTrackButtonsBackgroundProperty =
      DependencyProperty.Register("ChartScrollerTrackButtonsBackground", typeof (Brush), typeof (StockChartX),
                                  new PropertyMetadata(Brushes.Green, OnChartScrollerTrackButtonsBackgroundChanged));

    private static void OnChartScrollerTrackButtonsBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnChartScrollerTrackButtonsBackgroundChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnChartScrollerTrackButtonsBackgroundChanged(DependencyPropertyChangedEventArgs e)
    {
//      if (_chartScroller != null)
//        _chartScroller.TrackButtonsBackground = (Brush)e.NewValue;
    }

    #endregion

    #region ChartScrollerThumbButtonBackgroundProperty (DependencyProperty)

    /// <summary>
    /// A description of the ChartScrollerThumbButtonBackground.
    /// </summary>
    public Brush ChartScrollerThumbButtonBackground
    {
      get { return (Brush)GetValue(ChartScrollerThumbButtonBackgroundProperty); }
      set { SetValue(ChartScrollerThumbButtonBackgroundProperty, value); }
    }

    /// <summary>
    /// ChartScrollerThumbButtonBackground
    /// </summary>
    public static readonly DependencyProperty ChartScrollerThumbButtonBackgroundProperty =
      DependencyProperty.Register("ChartScrollerThumbButtonBackground", typeof (Brush), typeof (StockChartX),
                                  new PropertyMetadata(new LinearGradientBrush
                                                         {
                                                           StartPoint = new Point(0.486, 0),
                                                           EndPoint = new Point(0.486, 0.986),
                                                           GradientStops = new GradientStopCollection
                                                                             {
                                                                               new GradientStop(Colors.Gray, 0),
                                                                               new GradientStop(Colors.MidnightBlue, 0.5),
                                                                               new GradientStop(Colors.Gray, 1)
                                                                             }
                                                         }, OnChartScrollerThumbButtonBackgroundChanged));

    private static void OnChartScrollerThumbButtonBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnChartScrollerThumbButtonBackgroundChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnChartScrollerThumbButtonBackgroundChanged(DependencyPropertyChangedEventArgs e)
    {
//      if (_chartScroller != null)
//        _chartScroller.ThumbButtonBackground = (Brush)e.NewValue;
    }

    #endregion

    #endregion

    #region AppendTickVolumeBehaviorProperty (DependencyProperty)

    /// <summary>
    /// A description of the AppendTickVolumeBehavior.
    /// </summary>
    public DataManager.AppendTickVolumeBehavior AppendTickVolumeBehavior
    {
      get { return (DataManager.AppendTickVolumeBehavior)GetValue(AppendTickVolumeBehaviorProperty); }
      set { SetValue(AppendTickVolumeBehaviorProperty, value); }
    }

    /// <summary>
    /// AppendTickVolumeBehavior
    /// </summary>
    public static readonly DependencyProperty AppendTickVolumeBehaviorProperty =
      DependencyProperty.Register("AppendTickVolumeBehavior", typeof(DataManager.AppendTickVolumeBehavior), typeof(StockChartX),
                                  new PropertyMetadata(DataManager.AppendTickVolumeBehavior.Increment, OnAppendTickVolumeBehaviorChanged));

    private static void OnAppendTickVolumeBehaviorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnAppendTickVolumeBehaviorChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnAppendTickVolumeBehaviorChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    #endregion


    #region LineStudies dialog background
    ///<summary>
    /// Gets or sets the background for the dialog properties if LineStudy objects
    ///</summary>
    public static DependencyProperty LineStudyPropertyDialogBackgroundProperty;
    ///<summary>
    /// /// Gets or sets the background for the dialog properties if LineStudy objects
    ///</summary>
    public Brush LineStudyPropertyDialogBackground
    {
      get { return (Brush) GetValue(LineStudyPropertyDialogBackgroundProperty); }
      set { SetValue(LineStudyPropertyDialogBackgroundProperty, value); }
    }

    #endregion

    #region ShowSecondsProperty (DependencyProperty)

    /// <summary>
    /// Gets or sets whether to show the seconds in calendar panel. Does not have effect when 
    /// <see cref="RealTimeXLabels"/>=false
    /// </summary>
    public bool ShowSeconds
    {
      get { return (bool)GetValue(ShowSecondsProperty); }
      set { SetValue(ShowSecondsProperty, value); }
    }

    /// <summary>
    /// ShowSeconds
    /// </summary>
    public static readonly DependencyProperty ShowSecondsProperty =
      DependencyProperty.Register("ShowSeconds", typeof(bool), typeof(StockChartX),
                                  new PropertyMetadata(false, OnShowSecondsChanged));

    private static void OnShowSecondsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnShowSecondsChanged(e);
    }

    /// <summary>
    /// Method called when <see cref="ShowSeconds"/> property changes
    /// </summary>
    /// <param name="e">Arguments</param>
    protected virtual void OnShowSecondsChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_calendar == null)
        return;
      _calendar.Paint();
    }

    #endregion

    ///<summary>
    ///</summary>
    public static readonly DependencyProperty CalendarBackgroundProperty =
      DependencyProperty.Register("CalendarBackground", typeof(Brush), typeof(StockChartX),
                                  new PropertyMetadata(new SolidColorBrush(Colors.Black)));
    ///<summary>
    /// Gets or sets the calendar background
    ///</summary>
    public Brush CalendarBackground
    {
      get { return (Brush) GetValue(CalendarBackgroundProperty); }
      set { SetValue(CalendarBackgroundProperty, value); }
    }

    #region MaxVisibleRecordsProperty (DependencyProperty)

    /// <summary>
    /// Gets or sets the maximum visible records in the chart.
    /// </summary>
    public int MaxVisibleRecords
    {
      get { return (int)GetValue(MaxVisibleRecordsProperty); }
      set { SetValue(MaxVisibleRecordsProperty, value); }
    }

    /// <summary>
    /// MaxVisibleRecords
    /// </summary>
    public static readonly DependencyProperty MaxVisibleRecordsProperty =
      DependencyProperty.Register("MaxVisibleRecords", typeof (int), typeof (StockChartX),
                                  new PropertyMetadata(300, OnMaxVisibleRecordsChanged));

    private static void OnMaxVisibleRecordsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((StockChartX)d).OnMaxVisibleRecordsChanged(e);
    }

    /// <summary>
    /// Method called when <see cref="MaxVisibleRecords"/> property changes
    /// </summary>
    /// <param name="e">Arguments</param>
    protected virtual void OnMaxVisibleRecordsChanged(DependencyPropertyChangedEventArgs e)
    {
      Update();
    }

    #endregion

    #region HorizontalGridLinePatternProperty

    ///<summary>
    ///</summary>
    public static readonly DependencyProperty HorizontalGridLinePatternProperty =
      DependencyProperty.Register("HorizontalGridLinePattern", typeof (DoubleCollection), typeof (StockChartX),
                                  new PropertyMetadata(null));

    ///<summary>
    /// Gets or sets a collection of Double values that indicate the pattern of dashes and gaps that is used to outline shapes
    /// for horizontal grid lines.
    ///</summary>
    public DoubleCollection HorizontalGridLinePattern
    {
      get { return (DoubleCollection) GetValue(HorizontalGridLinePatternProperty); }
      set { SetValue(HorizontalGridLinePatternProperty, value); }
    }
    #endregion

    #region VerticalGridLinePatternProperty

    ///<summary>
    ///</summary>
    public static readonly DependencyProperty VerticalGridLinePatternProperty =
      DependencyProperty.Register("VerticalGridLinePattern", typeof (DoubleCollection), typeof (StockChartX),
                                  new PropertyMetadata(null));

    ///<summary>
    /// Gets or sets a collection of Double values that indicate the pattern of dashes and gaps that is used to outline shapes
    /// for vertical grid lines.
    ///</summary>
    public DoubleCollection VerticalGridLinePattern
    {
      get { return (DoubleCollection) GetValue(VerticalGridLinePatternProperty); }
      set { SetValue(VerticalGridLinePatternProperty, value); }
    }
    #endregion

    /// <summary>
    /// Identifies the <see cref="ChartScrollerProperties"/> dependency property 
    /// </summary>
    public static readonly DependencyProperty ChartScrollerPropertiesProperty =
      DependencyProperty.Register("ChartScrollerProperties", typeof (ChartScrollerProperties), 
      typeof (StockChartX), 
      new PropertyMetadata(null, PropertyChangedCallback));

    private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
      ((StockChartX)dependencyObject).SetupChartScroller((ChartScrollerProperties) args.NewValue);
    }

    /// <summary>
    /// Gets or sets the chart scroller properties
    /// </summary>
    public ChartScrollerProperties ChartScrollerProperties
    {
      get { return (ChartScrollerProperties) GetValue(ChartScrollerPropertiesProperty); }
      set { SetValue(ChartScrollerPropertiesProperty, value); }
    }
  }
}

