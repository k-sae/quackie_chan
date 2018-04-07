using UnityEngine;
namespace AiManager
{
    public class AiNodeController : MonoBehaviour 
    {
        private AiComponentManager aiManager;
        private void Awake() {
            aiManager = new AiComponentManager();
        }

        public AiComponentManager getAiManager(){
            return this.aiManager;
        }
        
    }
}