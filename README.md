# LpbGO - Luang Prabang Transport App

🌍 **Live Application:** [https://lpb-transportation.onrender.com/](https://lpb-transportation.onrender.com/)

[![Deploy to Render](https://render.com/images/deploy-to-render-button.svg)](https://render.com/deploy)
Welcome to **LpbGO**, a smart transportation and ticketing platform designed specifically for Luang Prabang public transit! 

> After struggling to navigate Laos without transit routes on Google Maps, I built this smart app to help tourists and locals easily travel around Luang Prabang. LpbGO provides fast digital ticketing, clear route info, and seamless cashless payments via the local Phajay API for a stress-free experience.

**This project is built using a 100% Pure F# Architecture**, utilizing **ASP.NET Core** and **Giraffe ViewEngine** for Server-Side Rendering (SSR).

## 🚍 Key Features

- **Route Search & Scheduling**: View complete trip schedules, prices, and available seats.
- **Ticketing System**: Securely purchase tickets to travel around Luang Prabang.
- **Phajay BCEL QR Integration**: Easily pay for tickets using the Phajay payment gateway sandbox API.
- **Ticket Validation**: Animated interface mimicking BudapestGO ticket validation patterns.
- **Customer Support Ticketing System**: Fully featured F# backend that accepts user issues and generates an Admin Dashboard for resolution.
- **100% F# Codebase**: All HTML views (Passenger App, Inspector Terminal, and Support Dashboard) are generated dynamically using F#'s Giraffe ViewEngine DSL.

---

##  Project Architecture & F# Implementation Report

For this semester's F# project (LpbGO), the aim was to build a robust public transit ticketing and management system. To maximize the utilization of functional programming paradigms, the application was architected entirely in F#.

### Advanced Technical Implementations:

1. **Pure F# Frontend (Giraffe ViewEngine):** 
   Instead of relying on static `.html` files, the entire user interface (Passenger App, Inspector Terminal, and Support Dashboard) is dynamically generated and Server-Side Rendered (SSR) using the `Giraffe.ViewEngine` DSL. This ensures strict type safety across both backend endpoints and frontend views, allowing for >90% F# repository composition.

2. **Domain-Driven Design (DDD) Modeling:** 
   Leveraged F#'s powerful type system in `Models.fs` to design a strongly-typed transit domain. This includes Records and Discriminated Unions to represent Routes, Transport Modes, Schedules, Tickets, and Support Messages.

3. **Clean Controller Separation:** 
   The application routes are cleanly decoupled into distinct ASP.NET Core controllers, adhering to single-responsibility principles:
   - **`TransportController.fs`**: Handles queries for schedules, pricing, and searching best routes.
   - **`TicketsController.fs`**: Manages the life-cycle of tickets including purchasing (triggering QR generation) and validation.
   - **`SupportController.fs`**: API for receiving customer issues and resolving them.
   - **`PageController.fs`**: Serves the dynamic `Giraffe.ViewEngine` views for the frontend applications.

4. **Multi-Interface Web Application:** 
   The backend successfully handles three entirely different user experiences from a unified, functional data store:
   - **Passenger App**: Mobile-first transit app for buying tickets.
   - **Inspector App**: Web-based QR scanner for drivers to validate boarding passes.
   - **Admin Dashboard**: Server-rendered table view to manage and resolve customer support queries.

5. **In-Memory State Management:**
   Managed application state seamlessly using an in-memory database configuration pattern within `DataAccess.fs`.

---

##  Running the Project Locally

To test this project on your local machine:

1. Have the [.NET 10.0+ SDK](https://dotnet.microsoft.com/download) installed.
2. Open a terminal in the project directory.
3. Run the following command:
   ```bash
   dotnet watch run
   ```
4. Open your browser and navigate to `http://localhost:5063` (or the port specified in your console).

---

## What I learned
This project successfully taught me how to combine the strict reliability of an F# functional backend with a dynamic, user-centric mobile web application. Transitioning from standard HTML files to a **Giraffe ViewEngine** SSR structure proved just how powerful F# is at bridging the gap between back-end data logic and front-end user experience without sacrificing type safety!
## Screenshot
<img width="1919" height="992" alt="Screenshot 2026-04-23 133009" src="https://github.com/user-attachments/assets/f6e8db2d-4dcc-4159-b625-0eb920b4cb26" />
<img width="1916" height="1032" alt="Screenshot 2026-04-23 133001" src="https://github.com/user-attachments/assets/f3da083b-1789-4651-954c-6324570dcf9b" />
<img width="1919" height="1040" alt="Screenshot 2026-04-23 132949" src="https://github.com/user-attachments/assets/26002f2f-7fd8-4084-9ebe-510df8b0486f" />
<img width="1919" height="1037" alt="Screenshot 2026-04-23 132930" src="https://github.com/user-attachments/assets/076fc77c-a9e1-41c8-9e7f-9d7b10b6dd74" />

