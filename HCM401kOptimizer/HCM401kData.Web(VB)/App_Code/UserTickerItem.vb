Imports Microsoft.VisualBasic

Public Class UserTickerItem

    Public Property UserName() As String
        Get
            Return m_UserName
        End Get
        Set(ByVal value As String)
            m_UserName = value
        End Set
    End Property
    Private m_UserName As String
    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(ByVal value As String)
            m_LastName = value
        End Set
    End Property
    Private m_LastName As String
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property
    Private m_Email As String
    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal value As String)
            m_FirstName = value
        End Set
    End Property
    Private m_FirstName As String
    Public Property DefaultTiker() As String
        Get
            Return m_DefaultTiker
        End Get
        Set(ByVal value As String)
            m_DefaultTiker = value
        End Set
    End Property
    Private m_DefaultTiker As String

End Class
