# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY out/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "api.dll"]