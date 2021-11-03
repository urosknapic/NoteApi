# NoteApi

## DOCKER
  - before making any calls to app make sure DB is running
  - download latest MYSQL image container 
      running command: `docker run --name notesDb -e MYSQL_ROOT_PASSWORD=password -p 3306:3306 -d mysql:latest`
  - once MySql is running proceed to 'Project' instructions

## PROJECT:
  - Download code NoteApi solution from git repository in your favourite folder (for example: `c:\noteapirepo\`)
  - download and install VSC from here: https://code.visualstudio.com/
  - download and install SDK .netcore 5.0 from here: https://dotnet.microsoft.com/download
    select latest SDK:  https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.402-windows-x64-installer

  If error (The framework 'Microsoft.NETCore.App', version '1.0.0' was not found.) occurs download NETCORE 1.0 runtime framework:
  - https://dotnet.microsoft.com/download/dotnet/1.0/runtime?utm_source=getdotnetcore&utm_medium=referral

  - reopen VSC othervise terminal wont work with `dotnet` command

  - once you downloaded code from git into folder `noteapirepo` a folder NoteApi will be created with solution
  - open solution folder in VSC (File -> Open Folder -> and now select `c:\noteapirepo\NoteApi`)
  - once this step is complete open terminal and run `dotnet run`; This will start project localy
  - please run command `dotnet ef database update`. This will create needed database inside MySql container.

## POSTMAN:
  - in \NoteApi folder you will find 'NotesApi.postman_collection' exported in 2.1 version; Import that file into Postman for API calls
  - import globals in postman as well


## Users
I have prepared 3 users:
1. User: Janez Novak,
    username: janezNovak,
    password: 1234
2. User: Miha Nagode,
  username: mihaNagode,
  password: 4321
3. User: Anja Hudovernik,
  username: anjaHudovernik
  password: 9999
