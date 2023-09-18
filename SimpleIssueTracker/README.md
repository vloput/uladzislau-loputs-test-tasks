## How to start

This archive contains two folders:
**SimpleIssueTracker.WebApi** - the back-end service is an ASP.NET app, which can be run with Docker.
**SimpleIssueTracker.ClientSideApp** - the front-end is a React app initialized with create-react-app. I suggest to use the development server provided with create-react-app. `\SimpleIssueTracker.ClientSideApp\src\constants.ts` file contains a url to the back-end service - replace it with your address.

1. Make sure you have Node.js 18.13.0 installed.
2. Run `npm i` to restore the dependencies.
3. Run `npm run start` to start the application.

## Notes
I just wanted to mention, that this app doesn't contain a lot of necessary validations both on the front-end and back-end sides, which I didn't implement due to lack of time.

Also, the authentication process is quite simple, and has only two hard-coded users in its 'database', which you can use for testing:
vlad:12345
bob:98765

It would be better to implement a separate identity server with IdentityServer or to use some 3rd-party identity providers, like Auth0, Okta, or Microsoft Identity. That's the reason I didn't store user credentials in the in-memory database.
