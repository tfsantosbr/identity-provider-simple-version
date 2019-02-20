FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

EXPOSE 80

# restore
COPY Identity.Api.csproj ./
RUN dotnet restore

# build and publish
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]