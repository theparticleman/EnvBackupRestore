dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true
dotnet publish -p:PublishSingleFile=true -r osx.11.0-arm64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true
dotnet publish -p:PublishSingleFile=true -r linux-x64 -c Release --self-contained true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true

Compress-Archive -LiteralPath.\Backup\bin\Release\net6.0\win-x64\publish\backup.exe, .\Restore\bin\Release\net6.0\win-x64\publish\restore.exe, config.json env-backup-restore_win-64.zip
Compress-Archive -LiteralPath .\Backup\bin\Release\net6.0\osx.11.0-arm64\publish\backup, .\Restore\bin\Release\net6.0\osx.11.0-arm64\publish\restore, config.json env-backup-restore_osx-11-0-arm64.zip
Compress-Archive -LiteralPath .\Backup\bin\Release\net6.0\linux-x64\publish\backup, .\Restore\bin\Release\net6.0\linux-x64\publish\restore, config.json env-backup-restore_linux-x64.zip