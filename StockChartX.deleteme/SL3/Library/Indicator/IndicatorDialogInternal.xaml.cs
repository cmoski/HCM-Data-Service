using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ModulusFE.Controls;
using ModulusFE.Indicators;

namespace ModulusFE
{
  ///<summary>
  ///</summary>
  public partial class IndicatorDialogInternal
  {
    private static readonly Color LightBlue = Color.FromArgb(0xFF, 0xAD, 0xD8, 0xE6);
    private static readonly Color LightSteelBlue = Color.FromArgb(0xFF, 0xB0, 0xC4, 0xDE);

    private static readonly Brush _defDialogBackground
      = new RadialGradientBrush
          {
            Center = new Point(0.6, 0.7),
            RadiusX = 1,
            RadiusY = 1,
            GradientStops = new GradientStopCollection
                              {
                                new GradientStop {Color = LightBlue, Offset = 0},
                                new GradientStop {Color = LightSteelBlue, Offset = 1}
                              }
          };


    
    internal Indicator _indicator;
    internal IndicatorDialog Owner { get; set; }
    internal ColorDialog _colorDialog = new ColorDialog();

    ///<summary>
    /// Ctor
    ///</summary>
    public IndicatorDialogInternal()
    {
      InitializeComponent();

      _colorDialog.OnOK += (sender, e) => Owner.SetIndicatorColor(_colorDialog.CurrentColor);

      DataContext = this;
      //Loaded += (o, args) => DataContext = Owner;
    }

    private void canvasColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      _colorDialog.CurrentColor = _indicator.StrokeColor;
      //_colorDialog.AppRoot = _indicator._chartPanel._chartX.AppRoot;
      //_colorDialog.Show(Dialog.DialogStyle.ModalDimmed);        
      _colorDialog.Show();        
    }

    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
      Owner.OkClick();
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
      Owner.CancelClick(); 
    }

    #region LabelFontSizeProperty (DependencyProperty)

    /// <summary>
    /// LabelFontSize summary
    /// </summary>
    public double LabelFontSize
    {
      get { return (double)GetValue(LabelFontSizeProperty); }
      set { SetValue(LabelFontSizeProperty, value); }
    }

    /// <summary>
    /// LabelFontSize
    /// </summary>
    public static readonly DependencyProperty LabelFontSizeProperty =
      DependencyProperty.Register("LabelFontSize", typeof(double), typeof(IndicatorDialogInternal),
                                  new PropertyMetadata(11.0, OnLabelFontSizeChanged));

    private static void OnLabelFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((IndicatorDialogInternal)d).OnLabelFontSizeChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnLabelFontSizeChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    #endregion

    #region LabelFontForegroundProperty (DependencyProperty)

    /// <summary>
    /// LabelForeground summary
    /// </summary>
    public Brush LabelForeground
    {
      get { return (Brush)GetValue(LabelFontForegroundProperty); }
      set { SetValue(LabelFontForegroundProperty, value); }
    }

    /// <summary>
    /// LabelForeground
    /// </summary>
    public static readonly DependencyProperty LabelFontForegroundProperty =
      DependencyProperty.Register("LabelForeground", typeof(Brush), typeof(IndicatorDialogInternal),
                                  new PropertyMetadata(new SolidColorBrush(Colors.White), OnLabelFontForegroundChanged));

    private static void OnLabelFontForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((IndicatorDialogInternal)d).OnLabelFontForegroundChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnLabelFontForegroundChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    #endregion

    #region DialogBackgroundProperty (DependencyProperty)

    /// <summary>
    /// DialogBackground summary
    /// </summary>
    public Brush DialogBackground
    {
      get { return (Brush)GetValue(DialogBackgroundProperty); }
      set { SetValue(DialogBackgroundProperty, value); }
    }

    /// <summary>
    /// DialogBackground
    /// </summary>
    public static readonly DependencyProperty DialogBackgroundProperty =
      DependencyProperty.Register("DialogBackground", typeof(Brush), typeof(IndicatorDialogInternal),
                                  new PropertyMetadata(_defDialogBackground, OnDialogBackgroundChanged));

    private static void OnDialogBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((IndicatorDialogInternal)d).OnDialogBackgroundChanged(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnDialogBackgroundChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    #endregion



  }

  ///<summary>
  ///</summary>
  public class IndicatorDialog : ChildWindow, IDisposable
  {
    private readonly IndicatorDialogInternal _dialog;

    ///<summary>
    ///</summary>
    public event EventHandler OnOk = delegate { };
    ///<summary>
    ///</summary>
    public event EventHandler OnCancel = delegate { };

    ///<summary>
    ///</summary>
    public IndicatorDialog()
    {
      _dialog = new IndicatorDialogInternal { Owner = this };

      for (int i = 0; i < 10; i++)
      {
        GetTextBox(i).GotFocus += OnGotFocus;
        GetComboBox(i).GotFocus += OnGotFocus;
      }

      Loaded += (sender, args) => GetComboBox(0).Focus();

      Closed += OnClosed;
      Closing += OnClosing;

      CanClose = true;
    }

    private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
    {
      cancelEventArgs.Cancel = !CanClose;
    }

    private void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
    {
      _dialog.lblDesc.Text = _dialog._indicator.GetParamDescription(Convert.ToInt32(((Control)sender).Name.Substring(3)));
    }


    internal bool CanClose { get; set; }

    ///<summary>
    ///</summary>
    public Indicator Indicator
    {
      get { return _dialog._indicator; }
      set
      {
        _dialog._indicator = value;
        _dialog.DialogBackground = value._chartPanel._chartX.IndicatorDialogBackground;
        _dialog.LabelForeground = value._chartPanel._chartX.IndicatorDialogLabelForeground;
        _dialog.LabelFontSize = value._chartPanel._chartX.IndicatorDialogLabelFontSize;
      }
    }

    internal ComboBox GetComboBox(int index)
    {
      return _dialog.FindName("cmb" + index) as ComboBox;
    }

    internal TextBlock GetTextBlock(int index)
    {
      return _dialog.FindName("lbl" + index) as TextBlock;
    }

    internal TextBox GetTextBox(int index)
    {
      return _dialog.FindName("txt" + index) as TextBox;
    }

    internal void ShowHidePanel(int index, bool hide, bool showTextBox)
    {
      Visibility v = hide ? Visibility.Collapsed : Visibility.Visible;
      GetTextBox(index).Visibility = v;
      GetTextBlock(index).Visibility = v;
      GetComboBox(index).Visibility = v;

      if (hide)
        return;

      if (showTextBox)
        GetComboBox(index).Visibility = Visibility.Collapsed;
      else
        GetTextBox(index).Visibility = Visibility.Collapsed;
    }

    internal bool? ShowDialog()
    {
      _dialog.canvasColor.Background = new SolidColorBrush(Indicator.StrokeColor);
      
      Content = _dialog;
      Show();
      return false;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
      
    }

    internal bool _userCanceled;
    internal void OkClick()
    {
      try
      {
        Indicator.SetUserInput();
      }
      catch (InvalidCastException ex)
      {
        MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK);
        return;
      }
      catch (FormatException ex)
      {
        MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK);
        return;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK);
        return;
      }

      if (Indicator._inputError)
      {
        if (_userCanceled)
          CancelClick();
        return;
      }

      Indicator._dialogShown = false;
      DialogResult = true;
    }

    internal void CancelClick()
    {
      DialogResult = false;
    }

    private void OnClosed(object sender, EventArgs eventArgs)
    {
      if (DialogResult == true)
      {
        OnOk(this, EventArgs.Empty);
      }
      else
      {
        Indicator._dialogShown = false;
        Indicator._chartPanel._chartX._locked = false;
        OnCancel(this, EventArgs.Empty);
      }
    }

    internal void SetIndicatorColor(Color color)
    {
      Indicator.StrokeColor = color;
      _dialog.canvasColor.Background = new SolidColorBrush(color);
    }
  }
}
