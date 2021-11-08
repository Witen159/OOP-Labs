using System.Collections.Generic;

namespace IsuExtra.Services
{
    public class Ognp
    {
        private List<Flow> _allFlows;
        public Ognp(string name, string specialization)
        {
            Name = name;
            Specialization = specialization;
            _allFlows = new List<Flow>();
        }

        public string Name { get; }
        public string Specialization { get; }

        public IReadOnlyList<Flow> AllFlows => _allFlows;

        public void AddFlow(Flow flow)
        {
            flow.FlowsOgnp = this;
            _allFlows.Add(flow);
        }
    }
}