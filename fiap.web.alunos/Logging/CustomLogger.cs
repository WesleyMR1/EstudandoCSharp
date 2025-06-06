namespace fiap.web.alunos.Logging
{
    public interface ICustomLogger
    {
        void Log(string message);
    }
    public class MockLogger : ICustomLogger
    {
        void ICustomLogger.Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ICustomLogger
    {
        void ICustomLogger.Log(string message)
        {
            Console.WriteLine($"File: {message}");
        }
    }
}
