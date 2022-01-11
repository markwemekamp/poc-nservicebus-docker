FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Receiver1/Receiver1.csproj", "src/Receiver1/"]
COPY ["src/Messages/Messages.csproj", "src/Messages/"]
RUN dotnet restore "src/Receiver1/Receiver1.csproj"
COPY . .
WORKDIR "/src/src/Receiver1"
RUN dotnet build "Receiver1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Receiver1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Receiver1.dll"]