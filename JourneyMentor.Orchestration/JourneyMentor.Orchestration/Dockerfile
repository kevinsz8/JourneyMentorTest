#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8090

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JourneyMentor.Orchestration/JourneyMentor.Orchestration/JourneyMentor.Orchestration.csproj", "JourneyMentor.Orchestration/"]
RUN dotnet restore "JourneyMentor.Orchestration/JourneyMentor.Orchestration.csproj"
COPY . .
WORKDIR "/src/JourneyMentor.Orchestration/JourneyMentor.Orchestration"
RUN dotnet build "JourneyMentor.Orchestration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JourneyMentor.Orchestration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JourneyMentor.Orchestration.dll"]