using EnvBackupRestore.Domain;

var fileSystem = new FileSystem();
var settings = Settings.Load();

var command = new RestoreCommand(settings, fileSystem);

command.Execute();