FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FreelanceDJ/FreelanceDJ.csproj", "FreelanceDJ/"]
RUN dotnet restore "FreelanceDJ/FreelanceDJ.csproj"
COPY . .
WORKDIR "/src/FreelanceDJ"
RUN dotnet build "FreelanceDJ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreelanceDJ.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreelanceDJ.dll"]
