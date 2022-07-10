#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44332
ENV ASPNETCORE_URLS=http://*:44332

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Car.API/Car.API.csproj", "Car.API/"]
COPY ["Car.Application/Car.Application.csproj", "Car.Application/"]
COPY ["Car.Data/Car.Data.csproj", "Car.Data/"]
COPY ["Car.Domain/Car.Domain.csproj", "Car.Domain/"]
RUN dotnet restore "Car.API/Car.API.csproj"
COPY . .
WORKDIR "/src/Car.API"
RUN dotnet build "Car.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Car.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Car.API.dll"]