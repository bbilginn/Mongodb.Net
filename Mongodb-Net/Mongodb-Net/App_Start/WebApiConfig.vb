Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports System.Net.Http.Formatting

Public Class WebApiConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)
        config.Routes.MapHttpRoute( _
            name:="DefaultApi", _
            routeTemplate:="api/{controller}/{id}", _
            defaults:=New With {.id = RouteParameter.Optional} _
        )
        'GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()

        GlobalConfiguration.Configuration.Formatters.Clear()
        GlobalConfiguration.Configuration.Formatters.Add(New System.Net.Http.Formatting.JsonMediaTypeFormatter())

        'GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(New QueryStringMapping("json", "true", "application/json"))

    End Sub
End Class