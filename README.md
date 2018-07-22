# blockchain-certificates

This project uses Keeper product to verify validity of auto-generated certificates. Keeper is part of Mantle's BAAS platform (Blockchain as a Service).

# setup

## UI: 
cd frontend
npm install
npm start

## Backend:
cd backend
run BlockchainCertificates.sln
set your Mantle credentials in Startup.cs
build & start project

## Database:
cd backend/BlockchainCertificates
run database.sql in your mysql database cli or workbench
set blockchain_certificates as your default schema