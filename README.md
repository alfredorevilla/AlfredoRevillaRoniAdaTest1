
# Demo for Roni Adna


## Pre-requisites

- Download and install [.NET Core 3.1 SDK](https://download.visualstudio.microsoft.com/download/pr/547f9f81-599a-4b58-9322-d1d158385df6/ebe3e02fd54c29487ac32409cb20d352/dotnet-sdk-3.1.401-win-x64.exe)
- Optional: [Download and install Visual Studio 2019](https://visualstudio.microsoft.com/es/downloads)

## Setup
- Create a database and execute the included script *DemoDBScriptQuery.sql*
- Update settings in *appsettings.json*:
  - *ConnectionStrings\DefaultConnection*
  - Optional: *ApplicationInsights\InstrumentationKey*


## Run

- From command prompt:
  - Run the following command at the solution folder level:<br>
    `dotnet run`

- From Visual Studio 2019:
  - Open the solution file *AlfredoRevillaRoniAdaTest1.snl*.
  - Press *CTRL+F5* (Ensure *AlfredoRevillaRoniAdaTest1* is selected as the startup project)

## Try
- Open the following URLs in your brower:<br>
https://localhost:{port}/api/jobs<br>
https://localhost:{port}/api/jobs/summary

- Use postman or other REST client and do:<br>
POST https://localhost:{port}/api/jobs/{id}/complete

Where {port} is 5001 by default.


## Test
- From command prompt:
  - Run the following command at the solution folder level:<br>
    `dotnet test`

- From Visual Studio 2019:
  - Open the solution file *AlfredoRevillaRoniAdaTest1.snl*.
  - Press *CTRL+R* and *A*

---
Copyright (C) 2020 Alfredo Octavio Revilla Tenorio
