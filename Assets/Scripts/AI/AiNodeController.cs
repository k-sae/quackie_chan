using UnityEngine;
namespace AiManager
{
    public class AiNodeController : MonoBehaviour 
    {
        private AiComponentManager aiManager;
        private void Awake() {
            aiManager = new AiComponentManager(GetComponent<Collider>());
        }
        private void Start() {
           
        }

        public AiComponentManager getAiManager(){
            return this.aiManager;
        }
        
    }
}