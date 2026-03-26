namespace LpbGO.Controllers

open Microsoft.AspNetCore.Mvc
open LpbGO.Models
open LpbGO.DataAccess

[<ApiController>]
[<Route("[controller]")>]
type TransportController () =
    inherit ControllerBase()

    [<HttpGet("locations")>]
    member this.GetLocations() : IActionResult =
        this.Ok(MockDb.Locations) :> IActionResult

    [<HttpGet("routes")>]
    member this.GetRoutes() : IActionResult =
        this.Ok(MockDb.Routes) :> IActionResult

    [<HttpGet("schedules")>]
    member this.GetSchedules([<FromQuery>] fromLocationId: System.Nullable<int>, [<FromQuery>] toLocationId: System.Nullable<int>) : IActionResult =
        let mutable filtered = MockDb.Schedules |> seq

        if fromLocationId.HasValue then
            filtered <- filtered |> Seq.filter (fun s -> s.DepartureLocationId = fromLocationId.Value)
            
        if toLocationId.HasValue then
            filtered <- filtered |> Seq.filter (fun s -> s.ArrivalLocationId = toLocationId.Value)

        this.Ok(filtered |> Seq.toList) :> IActionResult
