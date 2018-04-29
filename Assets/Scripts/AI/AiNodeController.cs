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
           InvokeRepeating("generateRandomAiAgent", 60.0f, 10f);
        }
        private void generateRandomAiAgent(){
                float num = Random.Range(0f, 10.0f);
                if(num>=5)generateDog();else generateCat();
        }

        private void generateDog(){
           GameObject dog =(GameObject)Instantiate(Resources.Load("dog"), getRandomMovementPoint(), new  Quaternion(0,0,0,0));
           dog.GetComponent<AiComponentController>().nodeController =this;
        }
         private void generateCat(){
           GameObject dog =(GameObject)Instantiate(Resources.Load("cat"), getRandomMovementPoint(), new  Quaternion(0,0,0,0));
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