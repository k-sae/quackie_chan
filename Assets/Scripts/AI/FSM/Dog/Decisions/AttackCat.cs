using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
    public class AttackCat : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
            List<AiComponent> agents = controller.getAgentsInRange(controller.brain.getSensorRange());
            if(agents.Count>1)
            foreach(AiComponent agent in agents)
                if(agent.getController().tag == "CAT")
                return true;
            return false;
        }
    }
}