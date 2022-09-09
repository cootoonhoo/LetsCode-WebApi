using System.Diagnostics;

namespace CadastroCliente.Core.Interfaces
{
    public interface IBenchmarkService
    {
        void StartStopWatch();
        void StopStopWatch();
        long GetTimeByMiliseconds();
    }
}
