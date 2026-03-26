namespace LpbGO.Controllers

open Microsoft.AspNetCore.Mvc
open System
open LpbGO.Models
open LpbGO.DataAccess

type PurchaseRequest = {
    UserId: string
    ScheduleId: int
}

[<ApiController>]
[<Route("[controller]")>]
type TicketsController () =
    inherit ControllerBase()

    [<HttpPost("purchase")>]
    member this.PurchaseTicket([<FromBody>] req: PurchaseRequest) : IActionResult =
        let scheduleOpt = MockDb.Schedules |> List.tryFind (fun s -> s.Id = req.ScheduleId)
        
        match scheduleOpt with
        | Some _ ->
            let ticketId = Guid.NewGuid().ToString()
            let newTicket = {
                Id = ticketId
                UserId = req.UserId
                ScheduleId = req.ScheduleId
                PurchaseDate = DateTime.UtcNow
                IsValid = true
            }
            MockDb.Tickets.Add(newTicket)
            this.Ok(newTicket) :> IActionResult
        | None ->
            this.NotFound("Schedule not found") :> IActionResult

    [<HttpPost("phajay/{scheduleId}")>]
    member this.GeneratePhajayQR(scheduleId: int) : IActionResult =
        let scheduleOpt = MockDb.Schedules |> List.tryFind (fun s -> s.Id = scheduleId)
        
        match scheduleOpt with
        | Some s ->
            // In a real app, you would make an HTTP call to Phajay's BCEL CreateQR API here.
            // Example real payload mapping:
            // let payload = { amount = s.PriceInKip; currency = "LAK"; description = "LpbGO Ticket" }
            
            // Using a public dummy QR generator URL to simulate Phajay's BCEL QR output
            let qrUrl = sprintf "https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=phajay-mock-payment-amount-%M" s.PriceInKip
            
            this.Ok(
                {| 
                   Success = true
                   QrCodeUrl = qrUrl
                   Amount = s.PriceInKip
                   TransactionRef = Guid.NewGuid().ToString("N") 
                |}) :> IActionResult
        | None ->
            this.NotFound("Schedule not found for payment") :> IActionResult

    [<HttpGet("{userId}")>]
    member this.GetTickets(userId: string) : IActionResult =
        let userTickets = MockDb.Tickets |> Seq.filter (fun t -> t.UserId = userId) |> Seq.toList
        this.Ok(userTickets) :> IActionResult

    [<HttpPost("validate/{ticketId}")>]
    member this.ValidateTicket(ticketId: string) : IActionResult =
        let idx = MockDb.Tickets.FindIndex(fun t -> t.Id = ticketId)
        if idx >= 0 then
            let ticket = MockDb.Tickets.[idx]
            if ticket.IsValid then
                // Mark ticket as used/scanned
                let usedTicket = { ticket with IsValid = false }
                MockDb.Tickets.[idx] <- usedTicket
                this.Ok({| Success = true; Message = "Ticket valid and consumed!"; Ticket = usedTicket |}) :> IActionResult
            else
                this.BadRequest({| Success = false; Message = "Ticket has already been used." |}) :> IActionResult
        else
            this.NotFound({| Success = false; Message = "Invalid ticket ID." |}) :> IActionResult
