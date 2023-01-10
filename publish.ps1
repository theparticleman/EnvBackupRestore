dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true
# dotnet publish -p:PublishSingleFile=true -r osx-x64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true
# dotnet publish -p:PublishSingleFile=true -r linux-x64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true

Compress-Archive .\Backup\bin\Release\net6.0\win-x64\publish\backup.exe env-backup-restore_win-64.zip
# Compress-Archive .\bin\Release\net6.0\osx-x64\publish\mega-man-quotes mega-man-quotes_osx-x64.zip
# Compress-Archive .\bin\Release\net6.0\linux-x64\publish\mega-man-quotes mega-man-quotes_linux-x64.zip