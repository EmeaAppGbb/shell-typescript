#!/bin/bash
set -e

# Install npm dependencies
npm install
cd src/web && npm install && cd ../..
cd src/api && npm install && cd ../..

# Install Playwright browsers and system dependencies
npx playwright install-deps
npx playwright install

# Trust HTTPS dev certificates
dotnet dev-certs https --trust 2>/dev/null || true

# Install TypeScript language server for Copilot CLI LSP support
npm install -g typescript-language-server

# Install Python docs tooling
pip install mkdocs mkdocs-material
