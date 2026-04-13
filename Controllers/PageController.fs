namespace LpbGO.Controllers

open Microsoft.AspNetCore.Mvc
open LpbGO.Views
open Giraffe.ViewEngine

[<ApiController>]
[<Route("")>]
type PageController () =
    inherit ControllerBase()

    [<HttpGet("")>]
    member this.Index() : IActionResult =
        let htmlString = RenderView.AsString.htmlDocument AppViews.indexView
        this.Content(htmlString, "text/html") :> IActionResult

    [<HttpGet("inspector")>]
    member this.Inspector() : IActionResult =
        let htmlString = RenderView.AsString.htmlDocument AppViews.inspectorView
        this.Content(htmlString, "text/html") :> IActionResult

    [<HttpGet("driver")>]
    member this.Driver() : IActionResult =
        let htmlString = RenderView.AsString.htmlDocument AppViews.driverView
        this.Content(htmlString, "text/html") :> IActionResult
