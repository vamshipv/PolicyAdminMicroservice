#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AuthorizationMicroservice/AuthorizationMicroservice.csproj", "AuthorizationMicroservice/"]
RUN dotnet restore "AuthorizationMicroservice/AuthorizationMicroservice.csproj"
COPY . .
WORKDIR "/src/AuthorizationMicroservice"
RUN dotnet build "AuthorizationMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthorizationMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthorizationMicroservice.dll"]