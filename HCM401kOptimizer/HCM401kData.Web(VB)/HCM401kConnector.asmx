<%@ WebService Language="VB" Class="HCM401kConnector" %>

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Data 
Imports System.Data.SqlClient
Imports System.Configuration
Imports DotNetNuke
Imports DotNetNuke.Security
Imports DotNetNuke.Security.Membership
Imports DotNetNuke.Services.Authentication


<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class HCM401kConnector
    Inherits System.Web.Services.WebService

    Private Const TickerFieldName As String = "CompanyTicker"

#Region "private"
    Private Shared Function GetCurrentUserInfo() As UserInfo
        Return CType(HttpContext.Current.Items("UserInfo"), UserInfo)
    End Function

    Private Shared ReadOnly Property IsAuthenticated As Boolean
        Get
            Return (HttpContext.Current.User IsNot Nothing And HttpContext.Current.User.Identity IsNot Nothing And HttpContext.Current.User.Identity.IsAuthenticated)
        End Get
    End Property
    
    Private Function Login(ByVal userName As String, ByVal password As String, ByRef status As UserLoginStatus) As UserInfo
        Return UserController.ValidateUser(PortalController.GetCurrentPortalSettings().PortalId, userName, password, "DNN", (PortalController.GetCurrentPortalSettings()).PortalName, AuthenticationLoginBase.GetIPAddress(), status)
    End Function
#End Region

    <WebMethod()> _
    Public Function GetUserTickerData(ByVal userName As String, ByVal password As String) As List(Of UserTickerItem)
        Dim status As UserLoginStatus = UserLoginStatus.LOGIN_FAILURE
        Dim _user As UserInfo = Login(userName, password, status)
        Dim _userTickerItems As New List(Of UserTickerItem)
        If status = UserLoginStatus.LOGIN_SUPERUSER Then
            Dim _con As New SqlConnection(ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString)
            Dim _cmd As New SqlCommand("hcm401kGetUserTickersInfo", _con)
            _cmd.CommandType = CommandType.StoredProcedure
            
            Dim _reader As SqlDataReader
            
            Try
                _con.Open()
                _reader = _cmd.ExecuteReader()
                While (_reader.Read())
                    _userTickerItems.Add(New UserTickerItem() With _
                { _
                .UserName = _reader("Username").ToString(), _
                .LastName = _reader("LastName").ToString(), _
                .FirstName = _reader("FirstName").ToString(), _
                .Email = _reader("Email").ToString(), _
                .DefaultTiker = _reader("DefaultTicker").ToString() _
                })
                End While
            Catch

            Finally
                _con.Close()
            End Try
           
        End If

        Return _userTickerItems
    End Function

    <WebMethod()> _
    Public Function GetDefaultTicker() As String
        If IsAuthenticated Then
            Return UserController.GetCachedUser((PortalController.GetCurrentPortalSettings()).PortalId, _
                Context.User.Identity.Name).Profile.GetPropertyValue(TickerFieldName)
        Else
            Return Nothing
        End If
    End Function

    <WebMethod()> _
    Public Function GetAvailableTickers() As List(Of String)
       
        'TODO -- Here we can return available symbols for SL application
        
        Return Nothing
    End Function

    <WebMethod()> _
    Public Function GetHistoricalDataX(ByVal token As HistoryRequest) As BarInfo
        If IsAuthenticated Then
            Dim data As New YahooData
            Return data.GetHistory(token)
        Else
            Return Nothing
        End If
    End Function
End Class
