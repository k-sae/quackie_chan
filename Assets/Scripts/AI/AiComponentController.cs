using UnityEngine;
namespace AiManager
{
    public class AiComponentController : MonoBehaviour
    {
        private AiComponent brain;
        private AiComponentManager associatedNodeManager;
        public AiNodeController nodeController;
        private void Start() {
            this.associatedNodeManager = nodeController.getAiManager();
            this.brain = new AiComponent(this.associatedNodeManager);
        }
        
    }
}