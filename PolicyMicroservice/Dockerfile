#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PolicyMicroservice/PolicyMicroservice.csproj", "PolicyMicroservice/"]
RUN dotnet restore "PolicyMicroservice/PolicyMicroservice.csproj"
COPY . .
WORKDIR "/src/PolicyMicroservice"
RUN dotnet build "PolicyMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PolicyMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolicyMicroservice.dll"]