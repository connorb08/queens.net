# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY . /app

RUN dotnet tool install --global Microsoft.Playwright.CLI
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN playwright install chromium

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:10.0-noble AS runtime

RUN apt-get update && apt-get install -y \
    libglib2.0-0 \
    libgobject-2.0-0 \
    libnspr4 \
    libnss3 \
    libdbus-1-3 \
    libgio-2.0-0 \
    libatk1.0-0 \
    libexpat1 \
    libx11-6 \
    libxcomposite1 \
    libxdamage1 \
    libxext6 \
    libxfixes3 \
    libxrandr2 \
    libgbm1 \
    libxcb1 \
    libxkbcommon0 \
    libatspi2.0-0t64 \
    libasound2t64 \                  
    --no-install-recommends && \
    rm -rf /var/lib/apt/lists/*

ENV HOME=/root \
    PLAYWRIGHT_BROWSERS_PATH=/root/.cache/ms-playwright

USER 0

COPY --from=build /root/.cache/ms-playwright /root/.cache/ms-playwright

WORKDIR /app
COPY --from=build /app/publish /app

CMD ["dotnet", "Queens.dll"]
