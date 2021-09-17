using NUnit.Framework;
[assembly:Parallelizable(ParallelScope.Fixtures)]
[assembly:LevelOfParallelism(level:6)]

namespace HillromAutomationFramework
{
    class ParallelExecutionConfig
    {
    }
}
