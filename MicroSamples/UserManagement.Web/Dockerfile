#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UserManagement.Web/UserManagement.Web.csproj", "UserManagement.Web/"]
COPY ["UserManagement.Models/UserManagement.Models.csproj", "UserManagement.Models/"]
COPY ["UserManagement.Services/UserManagement.Services.csproj", "UserManagement.Services/"]
COPY ["UserManagement.Domain/UserManagement.Domain.csproj", "UserManagement.Domain/"]
COPY ["UserManagement.Data/UserManagement.Data.csproj", "UserManagement.Data/"]
COPY ["Common.Extensions/Common.Extensions.csproj", "Common.Extensions/"]
COPY ["Common.Constants/Common.Constants.csproj", "Common.Constants/"]
RUN dotnet restore "UserManagement.Web/UserManagement.Web.csproj"
COPY . .
WORKDIR "/src/UserManagement.Web"
RUN dotnet build "UserManagement.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagement.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Web.dll"]
