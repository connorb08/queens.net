FROM mcr.microsoft.com/devcontainers/dotnet:latest

# Install tools
RUN dotnet tool install --global Microsoft.Playwright.CLI

# Add dotnet tools to PATH
ENV PATH="/root/.dotnet/tools:${PATH}"

