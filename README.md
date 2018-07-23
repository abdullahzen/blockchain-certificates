# blockchain-certificates

This project uses Keeper product to verify validity of auto-generated certificates. Keeper is part of Mantle's BAAS platform (Blockchain as a Service).

# setup

## UI: 
cd frontend<br/>
npm install<br/>
npm start

## Backend:
cd backend<br/>
run BlockchainCertificates.sln<br/>
set your Mantle credentials in Startup.cs<br/>
build & start project

## Database:
cd backend/BlockchainCertificates<br/>
run database.sql in your mysql database cli or workbench<br/>
set blockchain_certificates as your default schema
