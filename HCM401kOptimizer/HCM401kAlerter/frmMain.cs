using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;
using HCM401kAlerter.DataClient;

namespace HCM401kAlerter
{
    public partial class frmMain : Form
    {

        #region members

        //Yahoo datafeed = new Yahoo();
        Dictionary<string, UserTickerItem> Users = new Dictionary<string, UserTickerItem>();
        bool inprogress = false;
        bool started = false;
        DateTime LastExacution = DateTime.MinValue;
        System.Timers.Timer Scheduler = new System.Timers.Timer(1000);
        ConfigSnapShot Config = new ConfigSnapShot();
        DataClient.HCM401kConnectorSoapClient DataClient = new DataClient.HCM401kConnectorSoapClient();

        public static CSIData.CSIData CSIFeed = new CSIData.CSIData();
        #endregion //members

        public frmMain()
        {
            InitializeComponent();
            //datafeed.HistoryReady += datafeed_HistoryReady;
            CSIFeed.GetHistoryComplete += CSIFeed_GetHistoryComplete;
            Scheduler.Elapsed += Scheduler_Elapsed;
        }

        Dictionary<string, UserTickerItem> GetUsersInfo()
        {
            Dictionary<string, UserTickerItem> ret = new Dictionary<string, UserTickerItem>();
            //var data = DataClient.GetUserTickerData(Config.DataServiceName, Config.DataServicePassword);
            //foreach (var itm in data)
            //    ret.Add(itm.UserName, itm);
            return ret;
        }

        #region UI events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration cfg = new frmConfiguration();
            cfg.ShowDialog(this);
            Init();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LastExacution = DateTime.MinValue;
            started = !started;
            if (!inprogress)
                DisableUI(started);

            if (started)
            {
                if (WCFService.Start())
                    lblServiceStatus.Text = "Started";
                else
                    lblServiceStatus.Text = "Error";
            }
            else
                if (WCFService.Stop())
                    lblServiceStatus.Text = "Stoped";
                else
                    lblServiceStatus.Text = "Error";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        #endregion //UI events

        #region data events

        void Scheduler_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (started && !inprogress && LastExacution.Date != DateTime.Now.Date)
                InitCalculations();
        }

        void CSIFeed_GetHistoryComplete(object sender, CSIData.BarInfo value)
        {
            if (started && value != null)
            {
                BarInfo binfo = new BarInfo
                {
                    Token = new HistoryRequest
                    {
                        ID = value.Token.ID,
                        MaxAmount = value.Token.MaxAmount,
                        period = value.Token.period,
                        periodicity = Periodicity.Day,
                        Symbol = value.Token.Symbol
                    },
                };
                foreach (var itm in value)
                    binfo.Add(new Bar
                    {
                        Close = itm.Close,
                        High = itm.High,
                        Low = itm.Low,
                        Open = itm.Open,
                        TimeStamp = itm.TimeStamp,
                        Volume = itm.Volume
                    });

                binfo = DataFeed.BarConverter.ConvertToWeekly(binfo);

                var data = TechnicalCalculations.AroonOscillator(binfo, 16);

                if (data.Count >= 2)
                    if (data[data.Count - 1].Value != data[data.Count - 2].Value)
                    {
                        var user = Users[binfo.Token.ID];
                        string content = GetMailContent(user.FirstName + " " + user.LastName, user.DefaultTiker, data[data.Count - 1].Value);
                        var ret = EmailSender.SendEmail(user.Email, Config.MailSubject, content, Config);
                        if (ret.InternalError)
                            LogFile.WriteToLog("Send mail error: " + ret.InternalErrorMessage);
                        else
                            LogFile.WriteToLog("Send mail: to " + user.Email + "| subject: " + Config.MailSubject + "| content: " + content);
                    }
                if (started)
                {
                    string nID = null;
                    bool cangetkey = false;
                    foreach (var key in Users.Keys)
                    {
                        if (cangetkey)
                        {
                            nID = key;
                            break;
                        }
                        if (key.Equals(binfo.Token.ID))
                            cangetkey = true;
                    }
                    if (nID != null)
                        ProcessCalcualtions(nID);
                    else
                        inprogress = false;
                }
                else
                {
                    inprogress = false;
                    DisableUI(started);
                }
            }
            else
            {
                inprogress = false;
                DisableUI(started);
            }
        }

        //void datafeed_HistoryReady(object sender, BarInfo value)
        //{
        //    if (started && value != null)
        //    {

        //        var data = TechnicalCalculations.AroonOscillator(value, 16);
        //        //foreach (var itm in data)
        //        //    System.Diagnostics.Debug.WriteLine(string.Format("{0}. {1} = {2}", itm.Position, itm.TimeStamp.ToShortDateString(), itm.Value.ToString("#0.00")));
        //        if (data.Count >= 2)
        //            if (data[data.Count - 1].Value != data[data.Count - 2].Value)
        //            {
        //                var user = Users[value.Token.ID];
        //                string content = GetMailContent(user.FirstName + " " + user.LastName, user.DefaultTiker, data[data.Count - 1].Value);
        //                var ret = EmailSender.SendEmail(user.Email, Config.MailSubject, content, Config);
        //                if (ret.InternalError)
        //                    LogFile.WriteToLog("Send mail error: " + ret.InternalErrorMessage);
        //            }
        //        if (started)
        //        {
        //            string nID = null;
        //            bool cangetkey = false;
        //            foreach (var key in Users.Keys)
        //            {
        //                if (cangetkey)
        //                {
        //                    nID = key;
        //                    break;
        //                }
        //                if (key.Equals(value.Token.ID))
        //                    cangetkey = true;
        //            }
        //            if (nID != null)
        //                ProcessCalcualtions(nID);
        //            else
        //                inprogress = false;
        //        }
        //        else
        //        {
        //            inprogress = false;
        //            DisableUI(started);
        //        }
        //    }
        //    else
        //    {
        //        inprogress = false;
        //        DisableUI(started);
        //    }
        //}

        #endregion data events

        #region privates

        private delegate void DisableUIDelegate(bool value);
        private void DisableUI(bool value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DisableUIDelegate(DisableUI), value);
                return;
            }

            configureToolStripMenuItem.Enabled = !value;
            lblStatus.Text = !value ? "Stoped" : "Working";
            btnStart.Text = value ? "Stop" : "Start";
            pgsWorking.Visible = value;
            Scheduler.Enabled = value;
        }

        private string GetMailContent(string name, string ticker, double aroonValue)
        {
            string ret = Config.MailPattern;
            ret = ret.Replace("{USER}", name);
            ret = ret.Replace("{TICKER}", ticker);
            ret = ret.Replace("{AROON}", aroonValue.ToString("#0.00"));
            return ret;
        }

        private void InitCalculations()
        {
            DateTime now = DateTime.Now;
            bool canStart = true;

            if (!Config.chkFriday && now.DayOfWeek == DayOfWeek.Friday)
                canStart = false;
            else
                if (!Config.chkMonday && now.DayOfWeek == DayOfWeek.Monday)
                    canStart = false;
                else
                    if (!Config.chkSaturday && now.DayOfWeek == DayOfWeek.Saturday)
                        canStart = false;
                    else
                        if (!Config.chkSunday && now.DayOfWeek == DayOfWeek.Sunday)
                            canStart = false;
                        else
                            if (!Config.chkThursday && now.DayOfWeek == DayOfWeek.Thursday)
                                canStart = false;
                            else
                                if (!Config.chkTuesday && now.DayOfWeek == DayOfWeek.Tuesday)
                                    canStart = false;
                                else
                                    if (!Config.chkWednesday && now.DayOfWeek == DayOfWeek.Wednesday)
                                        canStart = false;

            if (canStart)
            {
                if (Config.chkSingleStartTime)
                {
                    if (Config.dtSingleStartTime.TimeOfDay < now.TimeOfDay)
                        canStart = false;
                }
                else
                {
                    if (now.DayOfWeek == DayOfWeek.Friday && Config.dtFriday.TimeOfDay < now.TimeOfDay)
                        canStart = false;
                    else
                        if (now.DayOfWeek == DayOfWeek.Monday && Config.dtMonday.TimeOfDay < now.TimeOfDay)
                            canStart = false;
                        else
                            if (now.DayOfWeek == DayOfWeek.Saturday && Config.dtSaturday.TimeOfDay < now.TimeOfDay)
                                canStart = false;
                            else
                                if (now.DayOfWeek == DayOfWeek.Sunday && Config.dtSunday.TimeOfDay < now.TimeOfDay)
                                    canStart = false;
                                else
                                    if (now.DayOfWeek == DayOfWeek.Thursday && Config.dtThursday.TimeOfDay < now.TimeOfDay)
                                        canStart = false;
                                    else
                                        if (now.DayOfWeek == DayOfWeek.Tuesday && Config.dtTuesday.TimeOfDay < now.TimeOfDay)
                                            canStart = false;
                                        else
                                            if (now.DayOfWeek == DayOfWeek.Wednesday && Config.dtWednesday.TimeOfDay < now.TimeOfDay)
                                                canStart = false;
                }
            }

            if (canStart)
            {
                LastExacution = DateTime.Now;
                Users = GetUsersInfo();
                if (Users.Count > 0)
                {
                    string nID = string.Empty;
                    foreach (var key in Users.Keys)
                    {
                        nID = key;
                        break;
                    }
                    StartCalculationsAsync(nID);
                }
            }
        }

        private void StartCalculationsAsync(string key)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessCalcualtions), key);
        }

        private void ProcessCalcualtions(object key)
        {
            inprogress = true;
            string ID = key as string;
            string Symbol = string.Empty;

            if (Users.ContainsKey(ID))
                Symbol = Users[ID].DefaultTiker;

            CSIFeed.GetHistoryAsync(new CSIData.HistoryRequest
            {
                ID = ID,
                MaxAmount = Config.RequestBarsCount * 5,
                period = 1,
                Symbol = Symbol
            });

            //datafeed.GetHistory(new HistoryRequest
            //{
            //    ID = key as string,
            //    MaxAmount = Config.RequestBarsCount * 5,
            //    period = 1,
            //    periodicity = Periodicity.Day,
            //    Symbol = Symbol
            //});
        }

        private void Init()
        {
            Config.Update();
            EndpointAddress MyEndpointAddress = new EndpointAddress(Config.DataServiceURL);
            DataClient.Endpoint.Address = MyEndpointAddress;
        }

        #endregion //privates
    }
}
