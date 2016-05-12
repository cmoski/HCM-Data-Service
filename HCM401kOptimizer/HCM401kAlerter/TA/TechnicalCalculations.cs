using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{

    internal class TechnicalCalculations
    {
        #region Aroon Oscillator

        public static List<DataResult> AroonOscillator(List<Price> value, int period)
        {
            var data = value.OrderBy(t => t.TimeStamp);
            List<DataResult> ret = new List<DataResult>();
            List<Price> counter = new List<Price>();

            int currentIndex = 0;
            double Aroon_up = 0;
            double Aroon_down = 0;
            double Aroon_oscillator = 0;
            int nCount = 0;

            foreach (var itm in data)
            {
                counter.Add(itm);

                if (currentIndex >= period)
                {
                    int idxMax = -1;
                    int idxMin = -1;
                    double max = double.MinValue;
                    double min = double.MaxValue;

                    int cnt = period;
                    for (int idx = period; idx >= 0; idx--)
                    {

                        if (counter[currentIndex - period + idx].Value - double.Epsilon >= max)
                        {
                            max = counter[currentIndex - period + idx].Value;
                            idxMax = currentIndex - period + idx;
                        }

                        if (counter[currentIndex - period + idx].Value + double.Epsilon <= min)
                        {
                            min = counter[currentIndex - period + idx].Value;
                            idxMin = currentIndex - period + idx;
                        }
                        cnt--;
                    }

                    Aroon_up = ((double)(period - (currentIndex - idxMax)) / period) * 100;
                    Aroon_down = ((double)(period - (currentIndex - idxMin)) / period) * 100;

                    //System.Diagnostics.Debug.WriteLine(string.Format("{0}. {1} = {2} , {3}", currentIndex, itm.TimeStamp.ToShortDateString(), Aroon_up.ToString("#0.00"), Aroon_down.ToString("#0.00")));

                    Aroon_oscillator = Aroon_up - Aroon_down;
                }

                currentIndex++;


                ret.Add(new DataResult
                {
                    Position = nCount,
                    TimeStamp = itm.TimeStamp,
                    Value = Aroon_oscillator
                });

                nCount++;

            }
            return ret;
        }

#if SILVERLIGHT
        public static List<DataResult> AroonOscillator(WCFBarData value, int period)
#else
        public static List<DataResult> AroonOscillator(BarInfo value, int period)
#endif
        {
#if SILVERLIGHT
            var data = value.Data.OrderBy(t => t.TimeStamp);
#else
            var data = value.OrderBy(t => t.TimeStamp);
#endif
            List<DataResult> ret = new List<DataResult>();

#if SILVERLIGHT
            List<WCFBar> counter = new List<WCFBar>();
#else
            List<Bar> counter = new List<Bar>();
#endif

            int currentIndex = 0;
            double Aroon_up = 0;
            double Aroon_down = 0;
            double Aroon_oscillator = 0;
            int nCount = 0;

            foreach (var itm in data)
            {
                counter.Add(itm);

                if (currentIndex >= period)
                {
                    int idxMax = -1;
                    int idxMin = -1;
                    double max = double.MinValue;
                    double min = double.MaxValue;

                    int cnt = period;
                    for (int idx = period; idx >= 0; idx--)
                    {

                        if (counter[currentIndex - period + idx].High - double.Epsilon >= max)
                        {
                            max = counter[currentIndex - period + idx].High;
                            idxMax = currentIndex - period + idx;
                        }

                        if (counter[currentIndex - period + idx].Low + double.Epsilon <= min)
                        {
                            min = counter[currentIndex - period + idx].Low;
                            idxMin = currentIndex - period + idx;
                        }
                        cnt--;
                    }

                    Aroon_up = ((double)(period - (currentIndex - idxMax)) / period) * 100;
                    Aroon_down = ((double)(period - (currentIndex - idxMin)) / period) * 100;

                    //System.Diagnostics.Debug.WriteLine(string.Format("{0}. {1} = {2} , {3}", currentIndex, itm.TimeStamp.ToShortDateString(), Aroon_up.ToString("#0.00"), Aroon_down.ToString("#0.00")));

                    Aroon_oscillator = Aroon_up - Aroon_down;
                }
                currentIndex++;

                ret.Add(new DataResult
                {
                    Position = nCount,
                    TimeStamp = itm.TimeStamp,
                    Value = Aroon_oscillator
                });
                nCount++;
            }
            return ret;
        }

        #endregion
    }
}
