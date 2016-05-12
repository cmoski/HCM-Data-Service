﻿using System.Collections.Generic;
using ModulusFE.Indicators;
using ModulusFE.Tasdk;

namespace ModulusFE
{
  public static partial class StockChartX_IndicatorsParameters
  {
    internal static void Register_TimeSeriesMovingAverage()
    {
      /*  Required inputs for this indicator:
        1. paramStr0 = Source (eg "msft.close")
        2. paramInt1 = Periods (eg 14)
      */
      RegisterIndicatorParameters(IndicatorType.TimeSeriesMovingAverage, typeof(TimeSeriesMovingAverage),
                                  "Time Series Moving Average",
                                  new List<IndicatorParameter>
                                    {
                                      new IndicatorParameter
                                        {
                                          // Source (eg "msft.close")
                                          Name = Indicator.GetParamName(ParameterType.ptSource),
                                          ParameterType = ParameterType.ptSource,
                                          DefaultValue = "",
                                          ValueType = typeof (string)
                                        },
                                      new IndicatorParameter
                                        {
                                          // Periods (eg 14)
                                          Name = Indicator.GetParamName(ParameterType.ptPeriods),
                                          ParameterType = ParameterType.ptPeriods,
                                          DefaultValue = 14,
                                          ValueType = typeof (int)
                                        },
                                    });
    }
  }
}

namespace ModulusFE.Indicators
{
  /// <summary>
  /// A Time Series Moving Average is similar to a Simple Moving Average, except that values are derived from linear regression forecast values instead of raw values.
  /// </summary>
  /// <remarks>A Moving Average is most often used to average values for a smoother representation of the underlying price or indicator.
  /// <list type="table">
  /// <listheader>
  /// <term>Parameters</term>
  /// </listheader>
  /// <item><term>str Source</term></item>
  /// <item><term>int Periods</term></item>
  /// </list>
  /// </remarks>
  public class TimeSeriesMovingAverage : Indicator
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Indicator name</param>
    /// <param name="chartPanel">Reference to a panel where it will be placed</param>
    public TimeSeriesMovingAverage(string name, ChartPanel chartPanel)
      : base(name, chartPanel)
    {
      _indicatorType = IndicatorType.TimeSeriesMovingAverage;

      Init();
    }

    /// <summary>
    /// Action to be executd for calculating indicator
    /// </summary>
    /// <returns>for future usage. Must be ignored at this time.</returns>
    protected override bool TrueAction()
    {
// Validate
      int iSize = _chartPanel._chartX.RecordCount;
      if (iSize == 0)
        return false;

      int paramInt1 = ParamInt(1);
      if (paramInt1 < 2 || paramInt1 > iSize / 2)
      {
        ProcessError("Invalid Periods (min 2) for indicator " + FullName, IndicatorErrorType.ShowErrorMessage);
        return false;
      }



      // Get the data
      string paramStr0 = ParamStr(0);
      Field pSource = SeriesToField("Source", paramStr0, iSize);
      if (!EnsureField(pSource, paramStr0)) return false;

      Navigator pNav = new Navigator();
      Recordset pRS = new Recordset();

      pRS.AddField(pSource);

      pNav.Recordset_ = pRS;


      // Calculate the indicator
      MovingAverage ta = new MovingAverage();
      Recordset pInd = ta.TimeSeriesMovingAverage(pNav, pSource, paramInt1, FullName);


      // Output the indicator values
      Clear();
      for (int n = 0; n < iSize; ++n)
      {
        AppendValue(DM.TS(n), n < paramInt1 * 2 ? null : pInd.Value(FullName, n + 1));
      }
      return _calculateResult = PostCalculate();
    }
  }
}

