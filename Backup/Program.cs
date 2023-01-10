using EnvBackupRestore.Domain;

var time = new Time();
var fileSystem = new FileSystem();
var settings = Settings.Load();

var command = new BackupCommand(settings, fileSystem, time);

command.Execute();
