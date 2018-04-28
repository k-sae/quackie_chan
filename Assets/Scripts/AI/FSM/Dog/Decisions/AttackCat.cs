using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Dog/Decision/AttackCat")]
    public class AttackCat : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
          
            List<AiComponent> agents = controller.getAgentsInRange(controller.brain.getSensorRange());
            if(agents.Count>1)
            foreach(AiComponent agent in agents){
               
                if(controller.tag=="DOG"&& agent.getController().tag == "CAT"){
                    //TODO: find cat in range
                controller.chasing = agent.getController().transform;
                agent.getController().chaser = controller.transform;
                return true;}
                }
            return false;
        }
    }
}