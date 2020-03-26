#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ModuleAPITest/ModuleAPITest.csproj", "ModuleAPITest/"]
RUN dotnet restore "ModuleAPITest/ModuleAPITest.csproj"
COPY . .
WORKDIR "/src/ModuleAPITest"
RUN dotnet build "ModuleAPITest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModuleAPITest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModuleAPITest.dll"]