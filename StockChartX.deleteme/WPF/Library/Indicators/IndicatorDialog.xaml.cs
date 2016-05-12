using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ModulusFE.Indicators
{
  /// <summary>
  /// Interaction logic for IndicatorDialog.xaml
  /// </summary>
  public partial class IndicatorDialog
  {
    private Indicator _indicator;

    /// <summary>
    /// internal usage
    /// </summary>
    public event EventHandler OnOk = delegate { };
    /// <summary>
    /// internal usage
    /// </summary>
    public event EventHandler OnCancel = delegate { };

    internal IndicatorDialog()
    {
      InitializeComponent();

      for (int i = 0; i < 10; i++)
      {
        GetTextBox(i).GotFocus += OnGotFocus;
        GetComboBox(i).GotFocus += OnGotFocus;
      }

      Loaded += (sender, args) => GetComboBox(0).Focus();

      Closing += OnClosing;

      CanClose = true;
    }

    private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
    {
      cancelEventArgs.Cancel = !CanClose;
    }

    ///<summary>
    ///</summary>
    ///<param name="sender"></param>
    ///<param name="index"></param>
    ///<param name="description"></param>
    public delegate void NeedDescriptionHandler(IndicatorDialog sender, int index, out string description);
    ///<summary>
    ///</summary>
    public event NeedDescriptionHandler NeedDescription;

    private void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
    {
      var e = NeedDescription;
      if (e != null)
      {
        string desc;
        e(this, Convert.ToInt32(((Control)sender).Name.Substring(3)), out desc);
        lblDesc.Text = desc;
      }
    }

    internal double StrokeThicknes { get; set; }

    internal Indicator Indicator
    {
      get { return _indicator; }
      set
      {
        _indicator = value;
        canvasColor.Background = new SolidColorBrush(_indicator.StrokeColor);
      }
    }

    internal bool CanClose { get; set; }

    internal ComboBox GetComboBox(int index)
    {
      return FindName("cmb" + index) as ComboBox;
    }

    internal TextBlock GetTextBlock(int index)
    {
      return FindName("lbl" + index) as TextBlock;
    }

    internal TextBox GetTextBox(int index)
    {
      return FindName("txt" + index) as TextBox;
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

    private void canvasColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      ColorPickerDialog dlg =
        new ColorPickerDialog
          {
            Owner = this,
//            Owner = Application.Current != null && Application.Current.Windows.Count > 0
//                      ? Application.Current.Windows[0]
//                      : null,
            StrokeThickness = Indicator.StrokeThickness,
            SelectedColor = Indicator.StrokeColor
          };
      if (dlg.ShowDialog() != true) return;
      Indicator.StrokeThickness = dlg.StrokeThickness;
      Indicator.StrokeColor = dlg.SelectedColor;
      canvasColor.Background = new SolidColorBrush(Indicator.StrokeColor);
    }

    internal bool _userCanceled;
    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        Indicator.SetUserInput();  
      }
      catch(InvalidCastException ex)
      {
        MessageBox.Show(this, ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      catch(FormatException ex)
      {
        MessageBox.Show(this, ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        return;        
      }
      catch(Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        return;        
      }

      if (_indicator._inputError)
      {
        if (_userCanceled)
          btnCancel_Click(this, e);
        return;
      }

      CanClose = true;
      Indicator._dialogShown = false;
      DialogResult = true;
      Close();

      OnOk(this, EventArgs.Empty); //raise event
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
      CanClose = true;
      Indicator._dialogShown = false;
      Indicator._chartPanel._chartX._locked = false;
      Indicator.OnCancelDialog();
      DialogResult = false;
      Close();

      OnCancel(this, EventArgs.Empty); //raise event
    }
  }
}
