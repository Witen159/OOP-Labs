using Isu.Services;

namespace IsuExtra.Services
{
    public class Flow
    {
        public Flow(string flowName)
        {
            Name = flowName;
        }

        public string Name { get; }

        public Ognp FlowsOgnp { get; }
    }
}