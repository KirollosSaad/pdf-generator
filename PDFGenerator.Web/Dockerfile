#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PDFGenerator.Web/PDFGenerator.Web.csproj", "PDFGenerator.Web/"]
RUN dotnet restore "PDFGenerator.Web/PDFGenerator.Web.csproj"
COPY . .
WORKDIR "/src/PDFGenerator.Web"
RUN dotnet build "PDFGenerator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDFGenerator.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDFGenerator.Web.dll"]