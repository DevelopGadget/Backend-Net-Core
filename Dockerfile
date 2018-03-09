FROM microsoft/aspnetcore:2.0
WORKDIR /app  
COPY /publish /app
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Web.dll
