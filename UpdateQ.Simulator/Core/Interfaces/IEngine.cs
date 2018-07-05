namespace UpdateQ.Simulator.Core.Interfaces
{
    public interface IEngine
    {
        void Run();
        void ExecuteCommand(string[] cmdArgs);
    }
}
