﻿using System.Collections.Generic;
using ModulusFE.Indicators;
using ModulusFE.Tasdk;

namespace ModulusFE
{
  public static partial class StockChartX_IndicatorsParameters
  {
    internal static void Register_DetrendedPriceOscillator()
    {
      /*  Required inputs for this indicator:
        1. paramStr0 = Source (eg "msft.close")
        2. paramInt1 = Periods (eg 14)
        3. param2 = Moving Average Type (eg indSimpleMovingAverage)
      */
      RegisterIndicatorParameters(IndicatorType.DetrendedPriceOscillator, typeof(DetrendedPriceOscillator),
                                  "Detrended Price Oscillator",
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
                                      new IndicatorParameter
                                        {
                                          // Moving Average Type (eg indSimpleMovingAverage)
                                          Name = Indicator.GetParamName(ParameterType.ptMAType),
                                          ParameterType = ParameterType.ptMAType,
                                          DefaultValue = IndicatorType.SimpleMovingAverage,
                                          ValueType = typeof (IndicatorType)
                                        },
                                    });
    }
  }
}

namespace ModulusFE.Indicators
{
  /// <summary>
  /// The Detrended Price Oscillator is used when long-term trends or outliers must be removed from prices or index indicators.
  /// </summary>
  /// <remarks>This indicator is often used to supplement a standard price chart. Other indicators can be plotted over the Detrended Price Oscillator.
  /// <list type="table">
  /// <listheader>
  /// <term>Parameters</term>
  /// </listheader>
  /// <item><term>str Source</term></item>
  /// <item><term>int Periods</term></item>
  /// <item><term>int Moving Average Type</term></item>
  /// </list>
  /// </remarks>
  public class DetrendedPriceOscillator : Indicator
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Indicator name</param>
    /// <param name="chartPanel">Reference to a panel where it will be placed</param>
    public DetrendedPriceOscillator(string name, ChartPanel chartPanel)
      : base(name, chartPanel)
    {
      _indicatorType = IndicatorType.DetrendedPriceOscillator;

      Init();
    }

    /// <summary>
    /// Action to be executd for calculating indicator
    /// </summary>
    /// <returns>for future usage. Must be ignored at this time.</returns>
    protected override bool TrueAction()
    {
// Validate
      int size = _chartPanel._chartX.RecordCount;
      if (size == 0)
        return false;

      int paramInt1 = ParamInt(1);

      if (paramInt1 < 1 || paramInt1 > size / 2)
      {
        ProcessError("Invalid Periods for indicator " + FullName, IndicatorErrorType.ShowErrorMessage);
        return false;
      }
      IndicatorType param2 = (IndicatorType)ParamInt(2);
      if (param2 < Constants.MA_START || param2 > Constants.MA_END)
      {
        ProcessError("Invalid Moving Average Type for indicator " + FullName, IndicatorErrorType.ShowErrorMessage);
        return false;
      }


      // Get the data
      string paramStr0 = ParamStr(0);
      Field pSource = SeriesToField("Source", paramStr0, size);
      if (!EnsureField(pSource, paramStr0)) return false;

      Navigator pNav = new Navigator();
      Recordset pRS = new Recordset();

      pRS.AddField(pSource);

      pNav.Recordset_ = pRS;


      // Calculate the indicator
      Oscillator ta = new Oscillator();
      Recordset pInd = ta.DetrendedPriceOscillator(pNav, pSource, paramInt1, param2, FullName);


      // Output the indicator values
      Clear();
      for (int n = 0; n < size; ++n)
      {
        AppendValue(DM.GetTimeStampByIndex(n), n < paramInt1 * 2 ? null : pInd.Value(FullName, n + 1));
      }

      return _calculateResult = PostCalculate();
    }
  }
}

