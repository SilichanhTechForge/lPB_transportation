namespace LpbGO.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Authentication
open Microsoft.AspNetCore.Authentication.Cookies
open System.Security.Claims
open LpbGO.Models
open LpbGO.DataAccess
open LpbGO.Views
open Giraffe.ViewEngine
open System.Threading.Tasks
open System

[<ApiController>]
[<Route("auth")>]
type AuthController () =
    inherit ControllerBase()

    [<HttpGet("login")>]
    member this.Login() : IActionResult =
        let htmlString = RenderView.AsString.htmlDocument (AuthViews.loginView "")
        this.Content(htmlString, "text/html") :> IActionResult

    [<HttpPost("login")>]
    member this.LoginPost([<FromForm>] req: AuthRequest) : Task<IActionResult> =
        task {
            let user = MockDb.Users |> Seq.tryFind (fun u -> u.Username = req.Username)
            match user with
            | Some u when BCrypt.Net.BCrypt.Verify(req.Password, u.PasswordHash) ->
                let claims = [
                    Claim(ClaimTypes.NameIdentifier, u.Id)
                    Claim(ClaimTypes.Name, u.Username)
                ]
                let identity = ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                let principal = ClaimsPrincipal(identity)
                
                do! this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal)
                
                return this.Redirect("/") :> IActionResult
            | _ ->
                let htmlString = RenderView.AsString.htmlDocument (AuthViews.loginView "Invalid username or password.")
                return this.Content(htmlString, "text/html") :> IActionResult
        }

    [<HttpGet("register")>]
    member this.Register() : IActionResult =
        let htmlString = RenderView.AsString.htmlDocument (AuthViews.registerView "")
        this.Content(htmlString, "text/html") :> IActionResult

    [<HttpPost("register")>]
    member this.RegisterPost([<FromForm>] req: AuthRequest) : IActionResult =
        if String.IsNullOrWhiteSpace(req.Username) || String.IsNullOrWhiteSpace(req.Password) then
            let htmlString = RenderView.AsString.htmlDocument (AuthViews.registerView "Username and password are required.")
            this.Content(htmlString, "text/html") :> IActionResult
        elif req.Password.Length < 6 then
            let htmlString = RenderView.AsString.htmlDocument (AuthViews.registerView "Password must be at least 6 characters.")
            this.Content(htmlString, "text/html") :> IActionResult
        elif MockDb.Users |> Seq.exists (fun u -> u.Username = req.Username) then
            let htmlString = RenderView.AsString.htmlDocument (AuthViews.registerView "Username already exists.")
            this.Content(htmlString, "text/html") :> IActionResult
        else
            let newUser = {
                Id = Guid.NewGuid().ToString()
                Username = req.Username
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
            }
            MockDb.Users.Add(newUser)
            this.Redirect("/auth/login") :> IActionResult

    [<HttpGet("logout"); HttpPost("logout")>]
    member this.Logout() : Task<IActionResult> =
        task {
            do! this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
            return this.Redirect("/") :> IActionResult
        }
