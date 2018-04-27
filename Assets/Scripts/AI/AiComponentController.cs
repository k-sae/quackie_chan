using System.Collections.Generic;
using AI.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace AiManager
{
    public  class AiComponentController : MonoBehaviour
    {
        [HideInInspector] public AiComponent brain;
        private AiComponentManager associatedNodeManager;
        public AiNodeController nodeController;
         public State currentState;
          [HideInInspector] public  Transform chasing;
          [HideInInspector] public  Transform chaser;
         [HideInInspector] public float statePassedTime;
         [HideInInspector] public  bool isChaseing;
         [HideInInspector] public  bool isChased;
         [HideInInspector] public  bool isAttack;
         [HideInInspector] public  bool isWalk;
         [HideInInspector] public  bool isRest;
         [HideInInspector] public NavMeshAgent navMeshAgent;
            private void Start() {
            this.associatedNodeManager = nodeController.getAiManager();
            this.brain = new AiComponent(this.associatedNodeManager,this);
            this.navMeshAgent = GetComponent<NavMeshAgent>();
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

    public void updateState(){
        this.currentState.UpdateState(this);
    }

    public List<AiComponent> getAgentsInRange(float range){
        List<AiComponent> temp = new List<AiComponent>();
        foreach (AiComponent agent in brain.getAgents()){
            if(Vector3.Distance(transform.position,agent.getController().transform.position)<=range){
                temp.Add(agent);
            }
        }
        return temp;
    }

        
    }
}