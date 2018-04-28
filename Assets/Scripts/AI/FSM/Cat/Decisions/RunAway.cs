using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Cat/Decision/RunAway")]
    public class RunAway : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
            
           if(controller.tag=="CAT"&& controller.chaser!=null)
           return true;
           return false;
        }
    }
}