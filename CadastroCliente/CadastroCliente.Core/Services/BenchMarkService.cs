using CadastroCliente.Core.Interfaces;
using System.Diagnostics;

namespace CadastroCliente.Core.Services
{
    public class BenchMarkService : IBenchmarkService
    {
        Stopwatch ApplicationTimer;

        public long GetTimeByMiliseconds()
        {
            return ApplicationTimer.ElapsedMilliseconds;
        }

        public void StartStopWatch()
        {
            ApplicationTimer = Stopwatch.StartNew();
        }

        public void StopStopWatch()
        {
            ApplicationTimer.Stop();
        }
    }
}
