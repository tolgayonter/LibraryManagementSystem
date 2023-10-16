FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LibraryManagementSystem.API/LibraryManagementSystem.API.csproj", "LibraryManagementSystem.API/"]
RUN dotnet restore "LibraryManagementSystem.API/LibraryManagementSystem.API.csproj"
COPY . .
WORKDIR "/src/LibraryManagementSystem.API"
RUN dotnet build "LibraryManagementSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryManagementSystem.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryManagementSystem.API.dll"]
