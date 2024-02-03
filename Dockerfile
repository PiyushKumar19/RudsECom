#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RudsECom/RudsECom.csproj", "RudsECom/"]
RUN dotnet restore "./RudsECom/./RudsECom.csproj"
COPY . .
WORKDIR "/src/RudsECom"
RUN dotnet build "./RudsECom.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN mkdir /app
WORKDIR /app
COPY ./linux64_musl/. ./

RUN chmod +x ./RudsECom
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RudsECom.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["./RudsECom", "--urls", "http://0.0.0.0:8080"]
ENTRYPOINT ["dotnet", "RudsECom.dll"]