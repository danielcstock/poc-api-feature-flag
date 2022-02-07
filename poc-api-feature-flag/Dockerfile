#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["poc-api-feature-flag/poc-api-feature-flag.csproj", "poc-api-feature-flag/"]
RUN dotnet restore "poc-api-feature-flag/poc-api-feature-flag.csproj"
COPY . .
WORKDIR "/src/poc-api-feature-flag"
RUN dotnet build "poc-api-feature-flag.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "poc-api-feature-flag.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc-api-feature-flag.dll"]