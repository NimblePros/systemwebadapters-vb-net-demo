Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        With SystemWebAdapterConfiguration.AddSystemWebAdapters(Me)
            .AddJsonSessionSerializer(Sub(options)
                                          options.RegisterKey(Of String)("UserName")
                                          options.RegisterKey(Of DateTime)("CurrentTime")
                                      End Sub)
            .AddRemoteAppServer(Function(options)
                                    options.ApiKey = ConfigurationManager.AppSettings("SessionServerApiKey")
                                End Function).AddSessionServer()
        End With

    End Sub
End Class