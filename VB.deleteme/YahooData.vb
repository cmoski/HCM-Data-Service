Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Net
Imports System.Globalization

Namespace HCM401kData.Web
	Public Class YahooData
		Private easternZoneId As String = "Eastern Standard Time"
		Private easternZone As TimeZoneInfo

		Public Function GetHistory(value As HistoryRequest) As BarInfo
			easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
			Dim webSvc As New WebClient()
			Dim addressValue As Uri = GetHistiryRequestUri(value)
			Dim result As String = webSvc.DownloadString(addressValue)
			Return ParseData(value, result)
		End Function



		Private Function ParseData(token As HistoryRequest, result As String) As BarInfo
			Dim ret As New BarInfo() With { _
				Key .Token = token _
			}

			If Not String.IsNullOrEmpty(result) Then

				Dim responseRows As New List(Of String)()
				responseRows.AddRange(result.Split(ControlChars.Lf))

				Dim outnum As Integer = 0
				If responseRows.Count - 2 > ret.Token.MaxAmount Then
					outnum = responseRows.Count - ret.Token.MaxAmount - 1
				End If

				For i As Integer = 1 To responseRows.Count - outnum - 1
					Dim rowElements As String() = responseRows(i).Split(","C)

					If rowElements.Length >= 7 Then
						Dim tStamp As System.DateTime = ParseDate(rowElements(0))
						Dim open As Double = Double.Parse(rowElements(1))
						Dim high As Double = Double.Parse(rowElements(2))
						Dim low As Double = Double.Parse(rowElements(3))
						Dim close As Double = Double.Parse(rowElements(4))
						Dim volume As Double = Double.Parse(rowElements(5))
						'double adjustedClose = double.Parse(rowElements[6]);

						ret.Add(New Bar() With { _
							Key .Close = close, _
							Key .High = high, _
							Key .Low = low, _
							Key .Open = open, _
							Key .TimeStamp = tStamp, _
							Key .Volume = volume _
						})
					End If

				Next
			End If
			Return ret
		End Function




		Private Function GetHistiryRequestUri(value As HistoryRequest) As Uri
			Dim symbol As String = value.Symbol

			If symbol.Length = 7 AndAlso symbol(3) = "/"C Then
				symbol = symbol.Remove(3, 1)
					'Forex symbol
				symbol += "=X"
			End If

			Dim address As String = "http://ichart.finance.yahoo.com/table.csv"
			address += "?s=" & symbol
			Dim beginDate As System.DateTime = GetBeginDate(value.periodicity, value.period, value.MaxAmount)
			address += "&a=" & (beginDate.Month - 1).ToString()
			' current month (yahoo range is 0-11, basic range is 1-12, so here is '- 1')
			address += "&b=" & beginDate.Day
			address += "&c=" & beginDate.Year
			address += "&d=" & (DateTime.Now.Month - 1)
			address += "&e=" & DateTime.Now.Day
			address += "&f=" & DateTime.Now.Year

			Select Case value.periodicity
				Case Periodicity.Day
					address += "&g=" & "d"
					Exit Select
				Case Periodicity.Week
					address += "&g=" & "w"
					Exit Select
				Case Periodicity.Month
					address += "&g=" & "m"
					Exit Select
			End Select

			address += "&ignore=" & ".csv"
			Dim uri As New Uri(address)
			Return New Uri(address)
		End Function

		Private Function GetBeginDate(barType As Periodicity, period As Integer, bars As Integer) As System.DateTime
			Dim neededDate As System.DateTime = System.DateTime.Now
			If (barType = Periodicity.Month) Then
				neededDate = neededDate.AddMonths(-bars * period)
			ElseIf (barType = Periodicity.Week) Then
				Dim days As Integer = bars * 7
				neededDate = neededDate.AddDays(-days * period)
			Else
				neededDate = neededDate.AddDays((-bars - bars * 0.6) * period)
			End If
			Return neededDate
		End Function

		Private Function ParseDate(dateStr As String) As System.DateTime
			Dim retDate As System.DateTime = DateTime.Now
			Dim format As String = "yyyy-MM-dd"
			System.DateTime.TryParseExact(dateStr, format, Nothing, DateTimeStyles.None, retDate)
			retDate = New DateTime(retDate.Year, retDate.Month, retDate.Day, 16, 0, 0)

			Return TimeZoneInfo.ConvertTimeToUtc(retDate, easternZone)
		End Function
	End Class
End Namespace
