Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Enum Periodicity
    Day = 3
    Week = 4
    Month = 5
End Enum

Public Class HistoryRequest
    Public Property Symbol() As String
        Get
            Return m_Symbol
        End Get
        Set(value As String)
            m_Symbol = value
        End Set
    End Property
    Private m_Symbol As String
    Public Property periodicity() As Periodicity
        Get
            Return m_periodicity
        End Get
        Set(value As Periodicity)
            m_periodicity = value
        End Set
    End Property
    Private m_periodicity As Periodicity
    Public Property period() As Integer
        Get
            Return m_period
        End Get
        Set(value As Integer)
            m_period = value
        End Set
    End Property
    Private m_period As Integer
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(value As String)
            m_ID = value
        End Set
    End Property
    Private m_ID As String
    Public Property MaxAmount() As Integer
        Get
            Return m_MaxAmount
        End Get
        Set(value As Integer)
            m_MaxAmount = value
        End Set
    End Property
    Private m_MaxAmount As Integer

    Public Function isEqual(value As HistoryRequest) As Boolean
        Dim ret As Boolean = True
        If Me.ID <> value.ID OrElse Me.MaxAmount <> value.MaxAmount OrElse Me.period <> value.period OrElse Me.periodicity <> value.periodicity OrElse Me.Symbol <> value.Symbol Then
            ret = False
        End If
        Return ret
    End Function
End Class
