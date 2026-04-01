namespace LpbGO.Models

type TransportMode =
    | TukTuk = 0
    | Minibus = 1
    | Train = 2
    | Boat = 3
    | Bus = 4

type Location = {
    Id: int
    Name: string
    Latitude: float
    Longitude: float
    Description: string
}

type Route = {
    Id: int
    Name: string
    Mode: TransportMode
    Description: string
}

type Schedule = {
    Id: int
    RouteId: int
    DepartureLocationId: int
    ArrivalLocationId: int
    DepartureTime: string // e.g., "08:00", "nullable" if frequent
    ArrivalTime: string
    PriceInKip: decimal
}

type Ticket = {
    Id: string
    UserId: string
    ScheduleId: int
    PurchaseDate: System.DateTime
    IsValid: bool
}

type SupportMessage = {
    Id: string
    Category: string
    Message: string
    SubmittedAt: System.DateTime
    IsResolved: bool
}
