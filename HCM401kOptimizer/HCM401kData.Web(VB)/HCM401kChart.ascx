<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HCM401kChart.ascx.vb" Inherits="HCM401kChart" %>


    <asp:Panel ID="silverlightControlHost" align="center" runat="server" HorizontalAlign="Left">
    <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
        style="height: 500px; width: 700px">
        <param name="source" value="<%=SilverlightApplication %>" />
        <param name="background" value="Transparent" />
        <param name="windowless" value="true" />
        <param name="minRuntimeVersion" value="5.0.61118.0" />
        <param name="autoUpgrade" value="true" />
        <param name="InitParams" value="<%=SilverlightInitParams %>" />
        <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=5.0.61118.0" style="text-decoration: none">
            <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight"
                style="border-style: none" />
        </a>
    </object>
    
</asp:Panel>