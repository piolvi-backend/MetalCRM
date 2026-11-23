FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/Backend/MetalCRM.API/MetalCRM.API.csproj", "src/Backend/MetalCRM.API/"]
COPY ["src/Backend/MetalCRM.Application/MetalCRM.Application.csproj", "src/Backend/MetalCRM.Application/"]
COPY ["src/Backend/MetalCRM.Domain/MetalCRM.Domain.csproj", "src/Backend/MetalCRM.Domain/"]
COPY ["src/Backend/MetalCRM.Infrastructure/MetalCRM.Infrastructure.csproj", "src/Backend/MetalCRM.Infrastructure/"]

RUN dotnet restore "src/Backend/MetalCRM.API/MetalCRM.API.csproj"

COPY . .

WORKDIR "/src/src/Backend/MetalCRM.API"
RUN dotnet build "MetalCRM.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetalCRM.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "MetalCRM.API.dll"]