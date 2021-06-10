#download microsoft runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#Set Enviroment Variable
#ENV Key Value
ENV ASPNETCORE_URLS=http://+:5001
ENV http_proxy=http://10.160.3.88:8080 
ENV https_proxy=http://10.160.3.88:8080 
#Set Container Output Port
EXPOSE 5001
#COPY Execuable file to Container
COPY /publish /app
#Go to Container app folder
WORKDIR /app
#Set Enter Point ["dotnet","your project Name"]
ENTRYPOINT ["dotnet","L10_DockerCompose.dll"]