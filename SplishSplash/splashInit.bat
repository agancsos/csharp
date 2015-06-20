@echo off
rem THIS FILE NEEDS TO BE RUN AS ADMINISTRATOR
rem THIS FILE WILL INITIALIZE THE REGISTRY KEYS NEEDED FOR
rem A CUSTOM LOCK SCREEN
rem IT WILL ALSO COPY THE FILE TO THE CORRECT DIRECTORY

reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background\ /v OEMBackground /d 1 /t REG_DWORD /f

if not exist 'c:\windows\system32\oobe\info' (
 mkdir c:\windows\system32\oobe\info
)
if not exist 'C:\windows\system32\oobe\backgrounds' (
 mkdir c:\windows\system32\oobe\info\backgrounds
)

echo %UserPROFILE%\desktop\backgroundDefault.jpg
copy "%UserPROFILE%\desktop\backgroundDefault.jpg" c:\windows\system32\oobe\info\backgrounds
del "%USERPROFILE%\desktop\backgroundDefault.jpg"
rem del '%HOMEPATH%\desktop\moveDefault.bat'
