FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/SixThreeTwo_shop.Web.Host/SixThreeTwo_shop.Web.Host.csproj", "src/SixThreeTwo_shop.Web.Host/"]
COPY ["src/SixThreeTwo_shop.Web.Core/SixThreeTwo_shop.Web.Core.csproj", "src/SixThreeTwo_shop.Web.Core/"]
COPY ["src/SixThreeTwo_shop.Application/SixThreeTwo_shop.Application.csproj", "src/SixThreeTwo_shop.Application/"]
COPY ["src/SixThreeTwo_shop.Core/SixThreeTwo_shop.Core.csproj", "src/SixThreeTwo_shop.Core/"]
COPY ["src/SixThreeTwo_shop.EntityFrameworkCore/SixThreeTwo_shop.EntityFrameworkCore.csproj", "src/SixThreeTwo_shop.EntityFrameworkCore/"]
WORKDIR "/src/src/SixThreeTwo_shop.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/SixThreeTwo_shop.Web.Host", "src/SixThreeTwo_shop.Web.Host"]
COPY ["src/SixThreeTwo_shop.Web.Core", "src/SixThreeTwo_shop.Web.Core"]
COPY ["src/SixThreeTwo_shop.Application", "src/SixThreeTwo_shop.Application"]
COPY ["src/SixThreeTwo_shop.Core", "src/SixThreeTwo_shop.Core"]
COPY ["src/SixThreeTwo_shop.EntityFrameworkCore", "src/SixThreeTwo_shop.EntityFrameworkCore"]
WORKDIR "/src/src/SixThreeTwo_shop.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "SixThreeTwo_shop.Web.Host.dll"]
