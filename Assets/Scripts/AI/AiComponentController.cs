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
             private NavMeshPath tempPath;
         public float MovementRange = 60.0f;

            private void Start() {
            this.associatedNodeManager = nodeController.getAiManager();
            this.brain = new AiComponent(this.associatedNodeManager,this);
            this.navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update() {
           currentState.UpdateState (this);
        }
        private void Awake() {
         this.tempPath=new NavMeshPath();  
        }
        public void TransitionToState(State nextState)
    {
        if (nextState!=null && nextState != currentState) 
        {
            Debug.Log(nextState);
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
             if(agent.getController()!=null)
            if(Vector3.Distance(transform.position,agent.getController().transform.position)<=range){
                temp.Add(agent);
            }
        }
        return temp;
    }
     public Vector3 getRandomMovementPoint() {
        Vector3 point;
        while (true)
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * MovementRange;
            randomPoint =randomPoint+new Vector3(50,0,50); 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)  ) {
				point = hit.position;
				this.navMeshAgent.CalculatePath(point , this.tempPath);
				if(this.tempPath.status == NavMeshPathStatus.PathComplete) return point;
			}
        }
    }

        
    }
}