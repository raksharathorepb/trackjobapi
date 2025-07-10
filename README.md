# trackjobapi
This is the backend API for the Job Tracker app. It allows the frontend to create, read, update job applications using a RESTful API.

# How to Run the Project

Clone the repository
git clone https://github.com/raksharathorepb/trackjobapi.git
cd trackjobapi

# Restore dependencies
dotnet restore

# Run the backend server
dotnet run

By default, it will start on:
http://localhost:5257

# Technologies Used
ASP.NET Core Web API
Entity Framework Core (for database)
SQLite (DB)
C#

# API Endpoints

Method	Endpoint	        Description
GET	   /applications	    Get paginated job list
POST	/applications	    Add a new job
PUT 	/applications/{id}	Update an existing job


# Assumptions

The frontend will call the backend from: http://localhost:5257
CORS is enabled in the backend for the frontend domain (for development).
Job model contains:
id (int)
company (string)
position (string)
status (string: Applied, Interview, Offer, Rejected)
dateApplied (DateTime)


# Tip for Development

run database migration:
dotnet ef migrations add InitialCreate
dotnet ef database update
