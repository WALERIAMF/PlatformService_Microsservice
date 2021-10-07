#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CommandsService/CommandsService.csproj", "CommandsService/"]
COPY ["CommandsService.Data/CommandsService.Data.csproj", "CommandsService.Data/"]
COPY ["CommandsService.Domain/CommandsService.Domain.csproj", "CommandsService.Domain/"]
COPY ["CommandsService.Application/CommandsService.Application.csproj", "CommandsService.Application/"]
RUN dotnet restore "CommandsService/CommandsService.csproj"
COPY . .
WORKDIR "/src/CommandsService"
RUN dotnet build "CommandsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsService.dll"]