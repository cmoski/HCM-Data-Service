﻿using System;
using System.Collections.Generic;
using ModulusFE.Indicators;
using ModulusFE.Tasdk;

namespace ModulusFE
{
  public static partial class StockChartX_IndicatorsParameters
  {
    internal static void Register_PositiveVolumeIndex()
    {
      /*  Required inputs for this indicator:
        1. paramStr0 = Source (eg "msft.close")
        2. paramStr1 = Volume (eg "msft.volume")
      */
      RegisterIndicatorParameters(IndicatorType.PositiveVolumeIndex, typeof(PositiveVolumeIndex),
                                  "Positive Volume Index",
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
                                          // Source (eg "msft.volume")
                                          Name = Indicator.GetParamName(ParameterType.ptVolume),
                                          ParameterType = ParameterType.ptVolume,
                                          DefaultValue = "",
                                          ValueType = typeof (string)
                                        },
                                    });
    }
  }
}

namespace ModulusFE.Indicators
{
  /// <summary>
  /// The Positive Volume Index shows focus on periods when volume increases from the previous period.
  /// </summary>
  /// <remarks>The interpretation of the Positive Volume Index is that many investors are buying when the index rises, and selling when the index falls.
  /// <list type="table">
  /// <listheader>
  /// <term>Parameters</term>
  /// </listheader>
  /// <item><term>str Source</term></item>
  /// <item><term>str Volume</term></item>
  /// </list>
  /// </remarks>
  public class PositiveVolumeIndex : Indicator
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Indicator name</param>
    /// <param name="chartPanel">Reference to a panel where it will be placed</param>
    public PositiveVolumeIndex(string name, ChartPanel chartPanel)
      : base(name, chartPanel)
    {
      _indicatorType = IndicatorType.PositiveVolumeIndex;

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

      string paramStr0 = ParamStr(0);
      string paramStr1 = ParamStr(1);
      if (paramStr0 == paramStr1)
      {
        ProcessError("Source 1 cannot be the same as Source 2" + Environment.NewLine +  "Source 2 must be a volume series", IndicatorErrorType.ShowErrorMessage);
        return false;
      }

      // Get the data
      Field pSource = SeriesToField("Source", paramStr0, iSize);
      if (!EnsureField(pSource, paramStr0)) return false;

      Field pVolume = SeriesToField("Volume", paramStr1, iSize);
      if (!EnsureField(pVolume, paramStr1)) return false;

      Navigator pNav = new Navigator();
      Recordset pRS = new Recordset();

      pRS.AddField(pSource);
      pRS.AddField(pVolume);

      pNav.Recordset_ = pRS;


      // Calculate the indicator
      Index ta = new Index();
      Recordset pInd = ta.PositiveVolumeIndex(pNav, pSource, pVolume, FullName);


      // Output the indicator values
      Clear();
      for (int n = 0; n < iSize; ++n)
      {
        AppendValue(DM.TS(n), pInd.Value(FullName, n + 1));
      }
      return _calculateResult = PostCalculate();
    }
  }
}
