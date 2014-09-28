@echo off
set /P comment="Kommentar: "
@echo on
git add .
git add -u .
git commit -m "%comment%"
pause