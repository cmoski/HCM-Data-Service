Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class Bar
    Public Property Open() As Double
        Get
            Return m_Open
        End Get
        Set(ByVal value As Double)
            m_Open = value
        End Set
    End Property
    Private m_Open As Double
    Public Property High() As Double
        Get
            Return m_High
        End Get
        Set(ByVal value As Double)
            m_High = value
        End Set
    End Property
    Private m_High As Double
    Public Property Low() As Double
        Get
            Return m_Low
        End Get
        Set(ByVal value As Double)
            m_Low = value
        End Set
    End Property
    Private m_Low As Double
    Public Property Close() As Double
        Get
            Return m_Close
        End Get
        Set(ByVal value As Double)
            m_Close = value
        End Set
    End Property
    Private m_Close As Double
    Public Property Volume() As Double
        Get
            Return m_Volume
        End Get
        Set(ByVal value As Double)
            m_Volume = value
        End Set
    End Property
    Private m_Volume As Double
    Public Property TimeStamp() As DateTime
        Get
            Return m_TimeStamp
        End Get
        Set(ByVal value As DateTime)
            m_TimeStamp = value
        End Set
    End Property
    Private m_TimeStamp As DateTime
End Class

Public Class BarInfo

    Public Property Bars() As List(Of Bar)
        Get
            Return m_Bars
        End Get
        Set(ByVal value As List(Of Bar))
            m_Bars = value
        End Set
    End Property

    Public Property Token() As HistoryRequest
        Get
            Return m_Token
        End Get
        Set(ByVal value As HistoryRequest)
            m_Token = value
        End Set
    End Property
    Private m_Token As HistoryRequest
    Private m_Bars As List(Of Bar)
End Class
