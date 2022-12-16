#!/bin/bash

oEmbedTesterApiName="oEmbedTester.API"
oEmbedTesterWebName="oEmbedTester.Web"

echo "Start exit launcher."

oEmbedTesterApiPid=$(pgrep $oEmbedTesterApiName)
oEmbedTesterWebPid=$(pgrep $oEmbedTesterWebName)

if [ ! -z "$oEmbedTesterApiPid" ] 
  then
    echo "Identified api pid: $oEmbedTesterApiPid"
    echo "Stopping API..."
    kill -15 $oEmbedTesterApiPid
  else
    echo "pass exiting API"
fi

if [ ! -z "$oEmbedTesterWebPid" ]
  then
    echo "Identified web pid: $oEmbedTesterWebPid"
    echo "Stopping Web..."
    kill -15 $oEmbedTesterWebPid
  else
    echo "pass exiting Web"
fi 


echo "exit finished."