﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JsonFx.WapTemplate._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="<%= System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>">
<head runat="server">
	<meta http-equiv="Content-Type" content="application/xhtml+xml; charset=UTF-8" />

	<title>TreeView</title>

	<%-- one tag to include all the style sheets --%>
	<JsonFx:ResourceInclude runat="server" SourceUrl="~/Styles/Styles.merge" />
</head>
<body>

	<%-- one tag to include all the client scripts --%>
	<JsonFx:ResourceInclude runat="server" SourceUrl="~/Scripts/Scripts.merge" />

	<%--
		Service proxies are generated at build time
		if application is being run as a virtual directory
		then we need to let the JSON-RPC marshalling system
		know it needs to adjust the end-point URLs
		NOTE: you can remove this when app root will always be "/"
	--%>
	<% if (HttpRuntime.AppDomainAppVirtualPath.Length > 1) { %>
		<script type="text/javascript">JsonFx.IO.Service.setAppRoot("<%= HttpRuntime.AppDomainAppVirtualPath %>");</script>
	<% } %>

</body>
</html>
