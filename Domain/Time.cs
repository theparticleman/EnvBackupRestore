namespace EnvBackupRestore.Domain;

public interface ITime
{
    public DateTime Now { get; }
}

public class Time : ITime
{
    public DateTime Now => DateTime.Now;
}