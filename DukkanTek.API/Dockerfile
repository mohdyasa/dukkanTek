#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DukkanTek.API/DukkanTek.API.csproj", "DukkanTek.API/"]
COPY ["DukkanTek.Services/DukkanTek.Services.csproj", "DukkanTek.Services/"]
COPY ["DukkanTek.Common/DukkanTek.Common.csproj", "DukkanTek.Common/"]
COPY ["DukkanTek.Repository/DukkanTek.Repository.csproj", "DukkanTek.Repository/"]
RUN dotnet restore "DukkanTek.API/DukkanTek.API.csproj"
COPY . .
WORKDIR "/src/DukkanTek.API"
RUN dotnet build "DukkanTek.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DukkanTek.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DukkanTek.API.dll"]