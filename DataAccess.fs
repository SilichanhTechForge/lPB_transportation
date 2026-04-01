namespace LpbGO.DataAccess

open LpbGO.Models
open System
open System.Collections.Generic

module MockDb =
    let Locations = [
        { Id = 1; Name = "Night Market / Town Center"; Latitude = 19.892019; Longitude = 102.135315; Description = "The vibrant night market right in the center of the town." }
        { Id = 2; Name = "Phousi Hill"; Latitude = 19.891632; Longitude = 102.136894; Description = "Sacred hill in the center of town with a panoramic view." }
        { Id = 3; Name = "Kuang Si Falls"; Latitude = 19.7483; Longitude = 101.9926; Description = "Spectacular tiered waterfall 29km south of town." }
        { Id = 4; Name = "Pak Ou Caves"; Latitude = 19.9982; Longitude = 102.1930; Description = "Caves overlooking the Mekong River filled with Buddha idols." }
        { Id = 5; Name = "Luang Prabang Airport (LPQ)"; Latitude = 19.8979; Longitude = 102.1610; Description = "International and domestic airport." }
        { Id = 6; Name = "Luang Prabang Train Station (LCR)"; Latitude = 19.8517; Longitude = 102.2612; Description = "High-speed rail station for the Laos-China Railway." }
        { Id = 7; Name = "Southern Bus Terminal"; Latitude = 19.8660; Longitude = 102.1390; Description = "Buses to Vang Vieng and Vientiane." }
        { Id = 8; Name = "Northern Bus Terminal"; Latitude = 19.9070; Longitude = 102.1620; Description = "Buses to Nong Khiaw, Phongsaly, and Luang Namtha." }
    ]

    let Routes = [
        { Id = 1; Name = "Airport Green Bus"; Mode = TransportMode.Bus; Description = "Official Green Bus transfer between Town Center and Airport" }
        { Id = 2; Name = "Kuang Si TukTuk Share"; Mode = TransportMode.TukTuk; Description = "Shared TukTuk heading to the Kouang Si Waterfalls" }
        { Id = 3; Name = "Mekong Slow Boat to Pak Ou"; Mode = TransportMode.Boat; Description = "Scenic slow boat ride up the Mekong to Pak Ou Caves" }
        { Id = 4; Name = "LCR Train Green Bus"; Mode = TransportMode.Bus; Description = "Official Green Bus to/from the high-speed train station" }
    ]

    let Schedules = [
        { Id = 1; RouteId = 1; DepartureLocationId = 5; ArrivalLocationId = 1; DepartureTime = "Frequent"; ArrivalTime = "Frequent"; PriceInKip = 45000m }
        { Id = 2; RouteId = 1; DepartureLocationId = 1; ArrivalLocationId = 5; DepartureTime = "Frequent"; ArrivalTime = "Frequent"; PriceInKip = 45000m }
        
        { Id = 3; RouteId = 2; DepartureLocationId = 1; ArrivalLocationId = 3; DepartureTime = "09:00"; ArrivalTime = "09:45"; PriceInKip = 60000m }
        { Id = 4; RouteId = 2; DepartureLocationId = 1; ArrivalLocationId = 3; DepartureTime = "11:30"; ArrivalTime = "12:15"; PriceInKip = 60000m }
        { Id = 5; RouteId = 2; DepartureLocationId = 1; ArrivalLocationId = 3; DepartureTime = "13:30"; ArrivalTime = "14:15"; PriceInKip = 60000m }
        
        { Id = 6; RouteId = 3; DepartureLocationId = 1; ArrivalLocationId = 4; DepartureTime = "08:30"; ArrivalTime = "10:30"; PriceInKip = 100000m }
        
        // Let's add more train connector schedules corresponding to train departures usually 1-2 hours before train
        { Id = 7; RouteId = 4; DepartureLocationId = 1; ArrivalLocationId = 6; DepartureTime = "07:00"; ArrivalTime = "07:45"; PriceInKip = 45000m }
        { Id = 8; RouteId = 4; DepartureLocationId = 1; ArrivalLocationId = 6; DepartureTime = "11:00"; ArrivalTime = "11:45"; PriceInKip = 45000m }
        { Id = 9; RouteId = 4; DepartureLocationId = 1; ArrivalLocationId = 6; DepartureTime = "14:00"; ArrivalTime = "14:45"; PriceInKip = 45000m }
    ]

    let mutable Tickets = new List<Ticket>()
    let mutable SupportMessages = new List<SupportMessage>()
