git stash
git pull --rebase origin
@echo off
set /P comment="Kommentar: "
@echo on
git add .
git add -u .
git commit -m "%comment%"
git push -u origin master
pause