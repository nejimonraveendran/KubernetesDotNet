## Multi-container app using Docker Compose and Kubernetes with debugging capabilities - in Visual Studio 2022

In this setup, Docker Compose is used for development and debugging in VS2022 locally.  For deployment, Kubernetes is used.  All Docker Compose settings are in *docker-compose.yml* file.  All Kubernetes settings are in *app-deployment.yml* in the solution root folder.

### Main changes made to default VS solution manually:
- Added and set up each project in Docker compose file manually.
- Removed *docker-compose.override.yml* file.
- Set Docker compose project name manually in the dcproj file ```<DockerComposeProjectName>mylinuxapp</DockerComposeProjectName>```

### Instructions for debugging.
- Open Developer Powershell in VS, and run the following command to run SQL server: 
  ``` kubectl apply -f sqlserver-statefulset.yml ```
- If not already done, change directory to dal folder, and issue the following command to set up initial DB migration setup:
  ``` dotnet ef database update ```
- Continue development / debugging.

### Instructions for app deployment in Kubernetes:
- If not already done, build Web API and Demon App images with the following command (from the Solution root folder):
  ```
  docker build --target final -t webapi:v1 -f webapi/Dockerfile .
  docker build --target final -t demonapp:v1 -f demonapp/Dockerfile .
  ```
- To deploy the app:
  ``` kubectl apply -f app-deployment.yml ```
- Access the app:
  - Web API Swagger URL: http://localhost:8082/swagger/index.html
  - View Demon App Logs: ``` kubectl logs <demon-app-pod-name> ``` 



 
