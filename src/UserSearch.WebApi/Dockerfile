FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/UserSearch.WebApi/UserSearch.WebApi.csproj", "src/UserSearch.WebApi/"]
RUN dotnet restore "src/UserSearch.WebApi/UserSearch.WebApi.csproj"
COPY . .
WORKDIR "/src/src/UserSearch.WebApi"
RUN dotnet build "UserSearch.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserSearch.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserSearch.WebApi.dll"]
