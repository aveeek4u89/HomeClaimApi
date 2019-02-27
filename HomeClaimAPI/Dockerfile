# Base image for dotnet sdk
FROM microsoft/dotnet:sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "CategoryService.API.dll"]