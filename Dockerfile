FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AutoTicket.csproj", ""]
RUN dotnet restore "./AutoTicket.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AutoTicket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoTicket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENV ASPNETCORE_URLS="http://0.0.0.0:5000"                                                
ENTRYPOINT ["dotnet", "AutoTicket.dll"]