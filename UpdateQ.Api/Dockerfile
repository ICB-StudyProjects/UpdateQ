FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY UpdateQ.Api/UpdateQ.Api.csproj UpdateQ.Api/
RUN dotnet restore UpdateQ.Api/UpdateQ.Api.csproj
COPY . .
WORKDIR /src/UpdateQ.Api
RUN dotnet build UpdateQ.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish UpdateQ.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UpdateQ.Api.dll"]
