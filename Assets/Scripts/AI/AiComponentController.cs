using AI.FSM;
using UnityEngine;
namespace AiManager
{
    public class AiComponentController : MonoBehaviour
    {
        private AiComponent brain;
        private AiComponentManager associatedNodeManager;
        public AiNodeController nodeController;
         public State currentState;
         private Transform chasing;
         private Transform chaser;
    [HideInInspector] public float statePassedTime;
            private void Start() {
            this.associatedNodeManager = nodeController.getAiManager();
            this.brain = new AiComponent(this.associatedNodeManager);
        }
        private void Update() {
           currentState.UpdateState (this);
        }
        private void Awake() {
           
        }
        public void TransitionToState(State nextState)
    {
        if (nextState != currentState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }
    private void OnExitState()
    {
        statePassedTime = 0;
    }

        
    }
}