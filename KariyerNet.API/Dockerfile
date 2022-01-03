#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["KariyerNet.API/KariyerNet.API.csproj", "KariyerNet.API/"]
COPY ["KariyerNet.Data/KariyerNet.Data.csproj", "KariyerNet.Data/"]
COPY ["KariyerNet.Dto/KariyerNet.Dto.csproj", "KariyerNet.Dto/"]
COPY ["KariyerNet.Service/KariyerNet.Business.csproj", "KariyerNet.Service/"]
RUN dotnet restore "KariyerNet.API/KariyerNet.API.csproj"
COPY . .
WORKDIR "/src/KariyerNet.API"
RUN dotnet build "KariyerNet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KariyerNet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KariyerNet.API.dll"]