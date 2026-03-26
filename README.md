# LpbGO - Luang Prabang Transport App

Welcome to **LpbGO**, a transportation management backend and mobile-friendly frontend for Luang Prabang public transit! Similar to modern transport apps like BudapestGO, LpbGO aims to provide seamless route scheduling, ticket purchasing, and smart boarding validation.

This project was built using **F#**, **ASP.NET Core**, and standard web technologies for the frontend (HTML, CSS, JS).

## 🚍 Key Features

- **Route Search & Scheduling**: View complete trip schedules, prices, and available seats.
- **Ticketing System**: Securely purchase tickets to travel around Luang Prabang.
- **Phajay BCEL QR Integration**: Easily pay for tickets using the Phajay payment gateway sandbox API using the BCEL One app.
- **Ticket Validation**: Animated interface mimicking BudapestGO ticket validation patterns for securely boarding vehicles.
- **In-memory SQLite/Dictionary caching** *(depending on `DataAccess.fs` setup)* for fast backend response times.

---

## 🏗️ How LpbGO Came to Be (The Beginning)

The aim of this study project was to learn Functional Programming with F# in a practical real-world scenario by building a complete backend and connecting it to a responsive mobile web interface. 

Here is the step-by-step evolution of how this project was structured and developed:

### 1. Project Initialization
The application started as an empty ASP.NET Core F# Web API project. F# was chosen for its strong typing, immutability, and succinct syntax, which makes processing travel logistics and payments highly reliable.
The project was initialized with:
```bash
dotnet new webapi -lang F# -o LpbGO
```

### 2. Modeling the Data (`Models.fs`)
First, the core domain concepts were modeled. We created functional records in `Models.fs` to represent everything traveling through our system:
- **Routes & Transport**: Definitions for origin, destination, schedules, and vehicle details.
- **Tickets**: Ticket statuses (Active, Used, Expired) and types.
- **Transactions**: For recording Phajay QR payment states.

### 3. Data Storage & Repositories (`DataAccess.fs`)
A robust data access layer was written in `DataAccess.fs`. Due to F#'s functional nature, operations to fetch transport schedules, check ticket validity, and insert payment records are implemented using clean composable functions and standard collections or databases.

### 4. Setting up the Controllers (`Controllers/`)
We implemented standard REST API endpoints to bridge the backend logic with the mobile frontend:
- **`TransportController.fs`**: Handles queries for schedules, pricing, and searching best routes.
- **`TicketsController.fs`**: Manages the life-cycle of tickets including purchasing (triggering QR generation) and validation (updating ticket status and activating the validation animation).

### 5. Mobile-Friendly Frontend (`wwwroot/`)
To achieve a BudapestGO-style experience, static assets were hosted from the `wwwroot` directory:
- **`index.html`**: A mobile-first transit web app allowing users to buy tickets and review their purchased passes.
- **`inspector.html`**: A ticket inspector validation interface showing an engaging, animated QR code scanning pattern.

### 6. App Wiring (`Program.fs`)
Finally, `Program.fs` ties it all together by configuring the ASP.NET Core middleware to serve static files (the frontend) and route API queries to the controllers.

---

## 🚀 Running the Project Locally

To test this project on your local machine:

1. Have the [.NET 8+ SDK (or whichever version you used)](https://dotnet.microsoft.com/download) installed.
2. Open a terminal in the project directory.
3. Run the following command:
   ```bash
   dotnet watch run
   ```
4. Open your browser and navigate to `http://localhost:5000` (or the port specified in your console).

---

## 📚 What I learned
This project successfully taught me how to combine the strict reliability of an F# functional backend with a dynamic, user-centric mobile web application. Connecting the Phajay Sandbox showed me how real-world fintech integrations operate under the hood!
