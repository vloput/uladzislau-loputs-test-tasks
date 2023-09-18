## Requriments

Building a Simple Issue Tracker with Authentication

## Task Description:
As a candidate for the Senior Full Stack Engineer position, you are required to create a basic issue tracker using .NET 6/7 and 
React, demonstrating your technical skills in both backend and frontend development. The tracker will have two main components: 
a backend REST API built with .NET, and a frontend built using React. The issue tracker should allow users to create, 
update, delete, and view issues. The issues should be stored in a simple in-memory data store.
Additionally, you will need to implement a basic login page and ensure that the issue Create, 
Update, and Delete actions are protected by authentication, showcasing your understanding of authentication 
and security best practices.

## Requirements:
### Backend:
Develop a RESTful API using .NET 6/7 with the following endpoints:

GET /issues: Retrieve all issues.
POST /issues: Create a new issue (protected).
PUT /issues/{id}: Update an existing issue (protected).
DELETE /issues/{id}: Delete an issue (protected).
POST /auth/login: Authenticate the user with the provided credentials and return an access token.

Use an in-memory data store for simplicity (e.g., List<Issue> or a similar data structure).
Implement a simple middleware that checks for a valid access token in the request headers for protected routes.

### Frontend:
Create a React application with the following components:

Login: Allow users to input their username and password for authentication.
IssuesList: Display a list of all issues.
IssueForm: Allow users to create and edit issues (protected).
IssueDetails: Display details of a single issue.
Use React hooks for state management and side effects.

## Issue Model:
An issue should have the following attributes:
Id: Unique identifier.
Title: Short summary of the issue.
Description: Detailed information about the issue.
Status: Open or Closed.
CreatedAt: Timestamp of when the issue was created.
UpdatedAt: Timestamp of when the issue was last updated.

## Expected Duration:
The task should take approximately 3-6 hours to complete if you have the necessary skills.
Submission:
Please submit a zip file containing the source code for both the backend and frontend applications, along
with a brief README describing how to run and test the applications.

## Evaluation:
Your submission will be evaluated based on the following criteria:

Code quality and maintainability.
Functionality and correctness of the implemented features.
Security of the authentication system and protection of the Create, Update, and Delete actions.

User experience and interface design.

Good luck! We are looking forward to reviewing your work and assessing your skills as a Senior Full Stack Engineer.