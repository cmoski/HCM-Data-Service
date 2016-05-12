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
using System.ServiceModel;

namespace HCM401kData
{
    public partial class MainPage : UserControl
    {
        DataClient.HCM401kConnectorSoapClient DataClient = new DataClient.HCM401kConnectorSoapClient();
        WebClient webCient = new System.Net.WebClient();

        public MainPage(string webServiceURL)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(webServiceURL))
            {
                EndpointAddress MyEndpointAddress = new EndpointAddress(webServiceURL);
                DataClient.Endpoint.Address = MyEndpointAddress;
            }


            cbxIndicators.ItemsSource = m_Chart.Indicators;
            cbxLineStudy.ItemsSource = m_Chart.LineStudies;

            DataClient.GetDefaultTickerCompleted += DataClient_GetDefaultTickerCompleted;
            DataClient.GetAvailableTickersCompleted += DataClient_GetAvailableTickersCompleted;
            webCient.DownloadStringCompleted += webCient_DownloadStringCompleted;
            DataClient.GetDefaultTickerAsync();
        }

        void webCient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Data Service Connection Error", MessageBoxButton.OK);
            else
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    var data = WCFBarData.XmlDeSerialize<WCFBarData>(e.Result);
                    {
                        data.Data = HCM401kData.TA.BarConverter.ConvertToWeekly(data.Data);
                        m_Chart.CreateChart(data);
                    }
                }
                DataClient.GetAvailableTickersAsync();
            }
        }

        void DataClient_GetDefaultTickerCompleted(object sender, DataClient.GetDefaultTickerCompletedEventArgs e)
        {

            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Data Service Connection Error", MessageBoxButton.OK);
            else
                GetHystory(!string.IsNullOrEmpty(e.Result) ? e.Result : "AAPL",
                                                 Guid.NewGuid().ToString());
        }

        void DataClient_GetAvailableTickersCompleted(object sender, DataClient.GetAvailableTickersCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                //Not important MessageBox.Show(e.Error.Message, "Data Service Connection Error", MessageBoxButton.OK);
            }
            else
                if (e.Result != null && e.Result.Count > 0)
                {
                    cbxAvailableSymbols.ItemsSource = e.Result;
                    cbxAvailableSymbols.Visibility = System.Windows.Visibility.Visible;
                }
        }

        #region UI events

        private void ToolPannel_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolPannel.Opacity = 1;
        }

        private void ToolPannel_MouseLeave(object sender, MouseEventArgs e)
        {
            ToolPannel.Opacity = 0.4;
        }

        private void btnCrossHair_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.CrossHair();
        }

        private void btnChangeInfoPanelState_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ChangeInfoPanelState();
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ZoomOut();
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.MoveLeft();
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.MoveRight();
        }

        private void btnResetZoom_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ResetZoom();
        }

        private void btnResetYScales_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ResetYScales();
        }

        private void btnToggleSideVolumeBars_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ToggleSideVolumeBars();
        }

        private void btnToggleDarvasBoxes_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.ToggleDarvasBoxes();
        }

        private void btnSaveAsImage_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.SaveAsImage();
        }

        private void btnDeleteCurrentObject_Click(object sender, RoutedEventArgs e)
        {
            m_Chart.DeleteCurrentObject();
        }

        private void btnAddLineStudy_Click(object sender, RoutedEventArgs e)
        {
            ModulusFE.LineStudies.LineStudy.StudyTypeEnum studyTypeEnum =
             ((ModulusFE.StockChartX_LineStudiesParams.LineStudyParams)cbxLineStudy.SelectedItem).StudyTypeEnum;
            m_Chart.AddLineStudy(studyTypeEnum, Colors.Red);
        }

        private void btnAddIndicator_Click(object sender, RoutedEventArgs e)
        {
            ModulusFE.StockChartX_IndicatorsParameters.IndicatorParameters indicator =
              cbxIndicators.SelectedItem as ModulusFE.StockChartX_IndicatorsParameters.IndicatorParameters;
            m_Chart.AddIndicator(indicator);
        }

        private void cbxPriceStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxPriceStyles != null)
                m_Chart.ApplyPriceStyle(((Control)cbxPriceStyles.SelectedItem).Tag as string);
        }

        private void cbxAvailableSymbols_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string symbol = cbxAvailableSymbols.SelectedItem as string;
            if (!string.IsNullOrEmpty(symbol))
                GetHystory(symbol,
                           Guid.NewGuid().ToString());
        }

        #endregion UI events

        private void GetHystory(string symbol, string id)
        {
            webCient.DownloadStringAsync(new Uri(string.Format("http://{0}/GetHistoricalData?code={1}&symbol={2}&id={3}&max={4}", "107.20.239.57:4528", "E5136ED93A4B4687AD12089A5416D21A", symbol, id, 1000)));
        }
    }
}
