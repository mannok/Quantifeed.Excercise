#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Quantifeed.Excercise.Web.Host/Quantifeed.Excercise.Web.Host.csproj", "src/Quantifeed.Excercise.Web.Host/"]
COPY ["src/Quantifeed.Excercise.Web.Core/Quantifeed.Excercise.Web.Core.csproj", "src/Quantifeed.Excercise.Web.Core/"]
COPY ["src/Quantifeed.Excercise.Application/Quantifeed.Excercise.Application.csproj", "src/Quantifeed.Excercise.Application/"]
COPY ["src/Quantifeed.Excercise.Core/Quantifeed.Excercise.Core.csproj", "src/Quantifeed.Excercise.Core/"]
COPY ["src/Quantifeed.Excercise.EntityFrameworkCore/Quantifeed.Excercise.EntityFrameworkCore.csproj", "src/Quantifeed.Excercise.EntityFrameworkCore/"]
RUN dotnet restore "src/Quantifeed.Excercise.Web.Host/Quantifeed.Excercise.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Quantifeed.Excercise.Web.Host"
RUN dotnet build "Quantifeed.Excercise.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quantifeed.Excercise.Web.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quantifeed.Excercise.Web.Host.dll"]