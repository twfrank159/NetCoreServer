#download microsoft runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#Set Enviroment Variable
#ENV Key Value
ENV ASPNETCORE_URLS=http://+:5001
#Set Container Output Port
EXPOSE 5001
#COPY Execuable file to Container
COPY /publish /App
#Go to Container app folder
WORKDIR /App
#Set Enter Point ["dotnet","your project Name"]
ENTRYPOINT ["dotnet","L9_Containerize.dll"]