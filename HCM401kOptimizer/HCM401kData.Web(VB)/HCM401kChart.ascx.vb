'Imports DotNetNuke
Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports System


Partial Class HCM401kChart
    'Inherits System.Web.UI.UserControl
    Inherits Entities.Modules.PortalModuleBase

    Public Property SilverlightApplication() As String
        Get
            Return m_SilverlightApplication
        End Get
        Set(ByVal value As String)
            m_SilverlightApplication = value
        End Set
    End Property
    Private m_SilverlightApplication As String
    Public Property SilverlightInitParams() As String
        Get
            Return m_SilverlightInitParams
        End Get
        Set(ByVal value As String)
            m_SilverlightInitParams = value
        End Set
    End Property
    Private m_SilverlightInitParams As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        
        ' Set the path to the .xap file
        SilverlightApplication = Me.ResolveClientUrl("./ClientBin/HCM401kData.xap") ' [String].Format("{0}{1}", TemplateSourceDirectory, "/ClientBin/HCM401kChart.xap")

        ' Pass the Initialization Parameters to the Silverlight Control
        SilverlightInitParams = String.Format("WebServiceURL={0}", [String].Format("http://{0}{1}/{2}", Me.Context.Request.Url.Authority, Me.Context.Request.ApplicationPath, Me.ResolveClientUrl("./HCM401kConnector.asmx")))
    End Sub


End Class
