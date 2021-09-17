using NUnit.Framework;
[assembly:Parallelizable(ParallelScope.Fixtures)]
[assembly:LevelOfParallelism(level:4)]

namespace HillromAutomationFramework
{
    class ParallelExecutionConfig
    {
    }
}
