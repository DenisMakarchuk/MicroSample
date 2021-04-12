#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProductManagement.Web/ProductManagement.Web.csproj", "ProductManagement.Web/"]
COPY ["ProductManagement.Services/ProductManagement.Services.csproj", "ProductManagement.Services/"]
COPY ["ProductManagement.Domain/ProductManagement.Domain.csproj", "ProductManagement.Domain/"]
COPY ["ProductManagement.Midels/ProductManagement.Midels.csproj", "ProductManagement.Midels/"]
COPY ["ProductManagement.Data/ProductManagement.Data.csproj", "ProductManagement.Data/"]
COPY ["Common.Constants/Common.Constants.csproj", "Common.Constants/"]
COPY ["Common.Extensions/Common.Extensions.csproj", "Common.Extensions/"]
RUN dotnet restore "ProductManagement.Web/ProductManagement.Web.csproj"
COPY . .
WORKDIR "/src/ProductManagement.Web"
RUN dotnet build "ProductManagement.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductManagement.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductManagement.Web.dll"]
