FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS build

WORKDIR /app
COPY . /app
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS runtime

WORKDIR /app
COPY --from=build /app/publish /app

# USER root

# Try installing in /tmp if this doesnt work
ENV PLAYWRIGHT_BROWSERS_PATH=/opt/

RUN pwsh playwright.ps1 install --with-deps chromium
# ENV PLAYWRIGHT_BROWSERS_PATH=/root/.cache/ms-playwright
# ENV PLAYWRIGHT_BROWSERS_PATH=/ms-playwright
RUN chmod +x /app/.playwright/node/*/node

CMD ["dotnet", "Queens.dll"]
