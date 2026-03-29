FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/632Shop.Web.Host/632Shop.Web.Host.csproj", "src/632Shop.Web.Host/"]
COPY ["src/632Shop.Web.Core/632Shop.Web.Core.csproj", "src/632Shop.Web.Core/"]
COPY ["src/632Shop.Application/632Shop.Application.csproj", "src/632Shop.Application/"]
COPY ["src/632Shop.Core/632Shop.Core.csproj", "src/632Shop.Core/"]
COPY ["src/632Shop.EntityFrameworkCore/632Shop.EntityFrameworkCore.csproj", "src/632Shop.EntityFrameworkCore/"]
WORKDIR "/src/src/632Shop.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/632Shop.Web.Host", "src/632Shop.Web.Host"]
COPY ["src/632Shop.Web.Core", "src/632Shop.Web.Core"]
COPY ["src/632Shop.Application", "src/632Shop.Application"]
COPY ["src/632Shop.Core", "src/632Shop.Core"]
COPY ["src/632Shop.EntityFrameworkCore", "src/632Shop.EntityFrameworkCore"]
WORKDIR "/src/src/632Shop.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "632Shop.Web.Host.dll"]
