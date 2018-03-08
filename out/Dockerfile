# build runtime image
FROM microsoft/aspnetcore
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80
COPY . ./
CMD ["dotnet", "Web.dll"]
