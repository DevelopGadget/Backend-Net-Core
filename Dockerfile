FROM microsoft/aspnetcore:2.0
RUN apt-get update
RUN apt-get install gnupg wget git unzip -y
RUN curl -sL exit
RUN apt-get install nodejs -y
WORKDIR /app
COPY . /publish 
ENTRYPOINT [ "dotnet", "Web" ]