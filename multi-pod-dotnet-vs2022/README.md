## Multi-container setup using Docker Compose with debugging capabilities - in Visual Studio 2022

This document demonstrates how to run multiple containers using Docker Compose.  In this:

### Main changes made to VS solution manually (compared to WSL-based development in VS Code):
- Added and set up each project in Docker compose file manually.
- Removed *docker-compose.override.yml* file.
- Set Docker compose project name manually in the dcproj file ```<DockerComposeProjectName>mylinuxapp</DockerComposeProjectName>```


### To run standalone (outside Visual Studio)
- Open PowerShell/windows command prompt in the solutin directory and run: ``` docker compose -p myapp up ```
- CD into "dal" folder, and issue: ``` dotnet ef database update ```
- CD back into solution directory and issue: ``` docker compose -p myapp restart ```
- In the browser, go to: http://localhost:5000/swagger/index.html
- To stop, issue: ``` docker compose -p myapp down ```


 
