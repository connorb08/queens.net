FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS build

WORKDIR /app
COPY . /app
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS runtime

WORKDIR /app
COPY --from=build /app/publish /app

ENV PLAYWRIGHT_BROWSERS_PATH=/opt/
RUN pwsh playwright.ps1 install --with-deps chromium
RUN chmod +x /app/.playwright/node/*/node

CMD ["dotnet", "Queens.dll"]
