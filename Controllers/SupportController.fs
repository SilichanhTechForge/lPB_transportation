namespace LpbGO.Controllers

open Microsoft.AspNetCore.Mvc
open System
open LpbGO.Models
open LpbGO.DataAccess
open Giraffe.ViewEngine

type SupportRequest = {
    Category: string
    Message: string
}

[<ApiController>]
[<Route("[controller]")>]
type SupportController () =
    inherit ControllerBase()

    [<HttpPost("submit")>]
    member this.Submit([<FromBody>] req: SupportRequest) : IActionResult =
        let newMessage = {
            Id = Guid.NewGuid().ToString()
            Category = req.Category
            Message = req.Message
            SubmittedAt = DateTime.UtcNow
            IsResolved = false
        }
        MockDb.SupportMessages.Add(newMessage)
        this.Ok({| Success = true; TicketId = newMessage.Id |}) :> IActionResult

    [<HttpPost("resolve/{id}")>]
    member this.Resolve(id: string) : IActionResult =
        let idx = MockDb.SupportMessages.FindIndex(fun m -> m.Id = id)
        if idx >= 0 then
            let msg = MockDb.SupportMessages.[idx]
            MockDb.SupportMessages.[idx] <- { msg with IsResolved = true }
            this.Redirect("/support") :> IActionResult
        else
            this.NotFound() :> IActionResult

    [<HttpGet>]
    member this.AdminDashboard() : IActionResult =
        // Fetch all messages, newest first
        let messages = 
            MockDb.SupportMessages 
            |> Seq.sortByDescending (fun m -> m.SubmittedAt)
            |> Seq.toList

        // Helper to define table rows
        let row (msg: SupportMessage) =
            let statusColor = if msg.IsResolved then "#10b981" else "#ef4444"
            let statusText = if msg.IsResolved then "Resolved" else "Pending"
            
            tr [] [
                td [ _style "padding: 10px; border-bottom: 1px solid #333;" ] [ str (msg.SubmittedAt.ToString("g")) ]
                td [ _style "padding: 10px; border-bottom: 1px solid #333;" ] [ strong [] [ str msg.Category ] ]
                td [ _style "padding: 10px; border-bottom: 1px solid #333;" ] [ str msg.Message ]
                td [ _style (sprintf "padding: 10px; border-bottom: 1px solid #333; color: %s;" statusColor) ] [ strong [] [ str statusText ] ]
                td [ _style "padding: 10px; border-bottom: 1px solid #333;" ] [
                    if not msg.IsResolved then
                        form [ _method "POST"; _action (sprintf "/support/resolve/%s" msg.Id) ] [
                            button [ _style "background: #3b82f6; color: white; border: none; padding: 5px 10px; border-radius: 4px; cursor: pointer;" ] [
                                str "Resolve"
                            ]
                        ]
                ]
            ]

        // Main HTML View built using Giraffe.ViewEngine in F#
        let document = 
            html [ _lang "en" ] [
                head [] [
                    meta [ _charset "UTF-8" ]
                    meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                    title [] [ str "Support Admin - LpbGO" ]
                    style [] [
                        str "body { background: #0f172a; color: #f8fafc; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; padding: 2rem; }"
                        str "h1 { color: #3b82f6; text-align: center; } table { width: 100%; border-collapse: collapse; margin-top: 2rem; background: #1e293b; border-radius: 8px; overflow: hidden; }"
                        str "th { text-align: left; padding: 15px; background: #334155; color: #94a3b8; }"
                    ]
                ]
                body [] [
                    h1 [] [ str "Customer Support Dashboard" ]
                    p [ _style "text-align: center; color: #94a3b8;" ] [ str "Manage user feedback and issues. Generated completely with F# Giraffe!" ]
                    
                    if messages.Length = 0 then
                        p [ _style "text-align: center; margin-top: 2rem; font-style: italic;" ] [ str "No support tickets yet. You're all caught up!" ]
                    else
                        table [] [
                            thead [] [
                                tr [] [
                                    th [] [ str "Date" ]
                                    th [] [ str "Category" ]
                                    th [] [ str "Message" ]
                                    th [] [ str "Status" ]
                                    th [] [ str "Action" ]
                                ]
                            ]
                            tbody [] (messages |> List.map row)
                        ]
                ]
            ]

        // Render HTML to string
        let htmlString = RenderView.AsString.htmlDocument document
        this.Content(htmlString, "text/html") :> IActionResult
