#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Merchant.WebAPI/Merchant.WebAPI.csproj", "Merchant.WebAPI/"]
RUN dotnet restore "Merchant.WebAPI/Merchant.WebAPI.csproj"
COPY . .
WORKDIR "/src/Merchant.WebAPI"
RUN dotnet build "Merchant.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Merchant.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Merchant.WebAPI.dll"]