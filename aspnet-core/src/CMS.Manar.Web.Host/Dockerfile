FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/CMS.Manar.Web.Host/CMS.Manar.Web.Host.csproj", "src/CMS.Manar.Web.Host/"]
COPY ["src/CMS.Manar.Web.Core/CMS.Manar.Web.Core.csproj", "src/CMS.Manar.Web.Core/"]
COPY ["src/CMS.Manar.Application/CMS.Manar.Application.csproj", "src/CMS.Manar.Application/"]
COPY ["src/CMS.Manar.Core/CMS.Manar.Core.csproj", "src/CMS.Manar.Core/"]
COPY ["src/CMS.Manar.EntityFrameworkCore/CMS.Manar.EntityFrameworkCore.csproj", "src/CMS.Manar.EntityFrameworkCore/"]
WORKDIR "/src/src/CMS.Manar.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/CMS.Manar.Web.Host", "src/CMS.Manar.Web.Host"]
COPY ["src/CMS.Manar.Web.Core", "src/CMS.Manar.Web.Core"]
COPY ["src/CMS.Manar.Application", "src/CMS.Manar.Application"]
COPY ["src/CMS.Manar.Core", "src/CMS.Manar.Core"]
COPY ["src/CMS.Manar.EntityFrameworkCore", "src/CMS.Manar.EntityFrameworkCore"]
WORKDIR "/src/src/CMS.Manar.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "CMS.Manar.Web.Host.dll"]
