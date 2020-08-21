# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq

WORKDIR /src
COPY *.sln .
COPY src/Projecto/*.csproj src/Projecto/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

# ENTRYPOINT ["dotnet", "Projecto.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Projecto.dll
