#!/bin/bash

oEmbedTesterApiPath="../src/oEmbedTester.API"
oEmbedTesterWebPath="../src/oEmbedTester.WEB"

echo "Start launching."

mkdir logs
mkdir logs/api
mkdir logs/web

echo "Starting oEmbedTester API..."
nohup dotnet run --project $oEmbedTesterApiPath > logs/api/oEmbedTester.API.log 2>&1 &

echo "Starting oEmbedTester Web..."
nohup dotnet run --project $oEmbedTesterWebPath > logs/web/oEmbedTester.Web.log 2>&1 &

echo "now web is listening on: http://localhost:5176"
echo "Launching completed."