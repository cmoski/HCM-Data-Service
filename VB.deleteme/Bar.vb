Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace HCM401kData.Web
	Public Class Bar
		Public Property Open() As Double
			Get
				Return m_Open
			End Get
			Set
				m_Open = Value
			End Set
		End Property
		Private m_Open As Double
		Public Property High() As Double
			Get
				Return m_High
			End Get
			Set
				m_High = Value
			End Set
		End Property
		Private m_High As Double
		Public Property Low() As Double
			Get
				Return m_Low
			End Get
			Set
				m_Low = Value
			End Set
		End Property
		Private m_Low As Double
		Public Property Close() As Double
			Get
				Return m_Close
			End Get
			Set
				m_Close = Value
			End Set
		End Property
		Private m_Close As Double
		Public Property Volume() As Double
			Get
				Return m_Volume
			End Get
			Set
				m_Volume = Value
			End Set
		End Property
		Private m_Volume As Double
		Public Property TimeStamp() As DateTime
			Get
				Return m_TimeStamp
			End Get
			Set
				m_TimeStamp = Value
			End Set
		End Property
		Private m_TimeStamp As DateTime
	End Class

	Public Class BarInfo
		Inherits List(Of Bar)
		Public Property Token() As HistoryRequest
			Get
				Return m_Token
			End Get
			Set
				m_Token = Value
			End Set
		End Property
		Private m_Token As HistoryRequest
	End Class
End Namespace
