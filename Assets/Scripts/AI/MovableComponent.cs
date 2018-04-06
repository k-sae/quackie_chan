using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public abstract class MovableComponent {

    public float MovementRange = 10.0f;
    private NavMeshAgent agent;
    private NavMeshPath tempPath;
    private Transform transform;
    public MovableComponent(NavMeshAgent agent ,Transform transform){
        this.agent = agent;
        this.transform = transform;
        this.tempPath= new NavMeshPath();
    }
    public Vector3 getRandomMovementPoint() {
        Vector3 point;
        while (true)
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * MovementRange;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)  ) {
				point = hit.position;
                Debug.Log(tempPath==null);
				this.agent.CalculatePath(point , this.tempPath);
				if(this.tempPath.status == NavMeshPathStatus.PathComplete) return point;
			}
        }
    }
    public abstract void move(); 
    public abstract void stop(); 
    public abstract void runaway();
    public abstract void follow();


}