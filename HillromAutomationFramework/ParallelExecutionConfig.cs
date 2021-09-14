using NUnit.Framework;
[assembly:Parallelizable(ParallelScope.Fixtures)]
[assembly:LevelOfParallelism(level:3)]

namespace HillromAutomationFramework
{
    class ParallelExecutionConfig
    {
    }
}
