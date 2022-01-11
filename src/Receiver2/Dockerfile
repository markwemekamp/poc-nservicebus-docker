FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Receiver2/Receiver2.csproj", "src/Receiver2/"]
COPY ["src/Messages/Messages.csproj", "src/Messages/"]
RUN dotnet restore "src/Receiver2/Receiver2.csproj"
COPY . .
WORKDIR "/src/src/Receiver2"
RUN dotnet build "Receiver2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Receiver2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Receiver2.dll"]