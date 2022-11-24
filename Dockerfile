#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src C:\Users\Juan Pablo\source\repos\Isw3-final\Dockerfile
#COPY ["Isw3-integrador.Controller/Isw3-integrador.Controller.csproj.user", "Isw3-integrador.Controller/"]
#RUN dotnet restore "Isw3-integrador.Controller/Isw3-integrador.Controller.csproj.user"
#COPY . .
#WORKDIR "/src/Isw3-integrador.Controller"
#RUN dotnet build "Isw3-integrador.Controller.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Isw3-integrador.Controller.csproj" -c Release -o /app/publish /p:UseAppHost=false

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Isw3-integrador.Controller.dll"]





FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
COPY . .
WORKDIR "/src/Isw3-integrador.Controller"
RUN dotnet build  -c Release -o /app/build
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Isw3-final.dll"]
