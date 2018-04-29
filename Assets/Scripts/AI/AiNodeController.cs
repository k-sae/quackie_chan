using UnityEngine;
using UnityEngine.AI;

namespace AiManager
{
    public class AiNodeController : MonoBehaviour 
    {
        private AiComponentManager aiManager;
         private NavMeshPath tempPath;
        private void Awake() {
            aiManager = new AiComponentManager(GetComponent<Collider>());
            this.tempPath = new NavMeshPath();
        }
        private void Start() {
           InvokeRepeating("generateRandomAiAgent", 180.0f, 180f);
        }
        private void generateRandomAiAgent(){
                Vector3 point = getRandomMovementPoint();
                float num = Random.Range(0f, 10.0f);
                  NavMeshHit hit;
                if (NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas)  ) 
                if(num>=5)generateDog(point);else generateCat(point);
        }

        private void generateDog(Vector3 point){
           GameObject dog =(GameObject)Instantiate(Resources.Load("dog"),point, new  Quaternion(0,0,0,0));
           dog.GetComponent<AiComponentController>().nodeController =this;
        }
         private void generateCat(Vector3 point){
           GameObject dog =(GameObject)Instantiate(Resources.Load("cat"), point, new  Quaternion(0,0,0,0));
           dog.GetComponent<AiComponentController>().nodeController =this;
        }

        public AiComponentManager getAiManager(){
            return this.aiManager;
        }
        public Vector3 getRandomMovementPoint() {
        Vector3 point;
        NavMeshAgent navMeshAgent = new NavMeshAgent();
       
        while (true)
        {
            Vector3 randomPoint = PlayerController.playerTransform.position + Random.insideUnitSphere * 30;
            randomPoint =randomPoint; 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)  ) {
				point = hit.position;
				
				 return point;
			}
        }
    }
    Vector3 GetRandomLocation()
     {
         NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
 
         // Pick the first indice of a random triangle in the nav mesh
         int t = Random.Range(0, navMeshData.indices.Length-3);
         
         // Select a random point on it
         Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t+1]], Random.value);
         Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t+2]], Random.value);
 
         return point;
     }
        
    }
}