FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FreelanceDJ_UserService/FreelanceDJ_UserService.csproj", "FreelanceDJ_UserService/"]
RUN dotnet restore "FreelanceDJ_UserService/FreelanceDJ_UserService.csproj"
COPY . .
WORKDIR "/src/FreelanceDJ_UserService"
RUN dotnet build "FreelanceDJ_UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreelanceDJ_UserService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreelanceDJ_UserService.dll"]
