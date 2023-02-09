@echo off
dotnet new console
rm .\Program.cs
curl -o Program.cs https://pastebin.com/raw/3DmSC2U7
dotnet run