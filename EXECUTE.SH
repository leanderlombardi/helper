#!/bin/bash

dotnet new console
rm -rf Program.cs
curl -o Program.cs https://pastebin.com/raw/3DmSC2U7
dotnet run