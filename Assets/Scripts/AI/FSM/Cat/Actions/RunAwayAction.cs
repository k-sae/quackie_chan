using AiManager;
using UnityEngine;
using UnityEngine.AI;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Cat/Action/RunAway")]
    public class RunAwayAction : Action
    {
        public override void Act(AiComponentController controller)
        {
           // if(checkAttackDistance( controller.chasing, controller.chaser)){
                //TODO: start attack animation 
                //TODO: call the damage script onthe target 
            //}      

           RunFrom(controller,controller.chaser);   
        }
        public void RunFrom(AiComponentController controller,Transform from)
     {
         Transform transform = controller.transform;
         // store the starting transform
        Transform startTransform = transform;
         
         //temporarily point the object to look away from the player
         transform.rotation = Quaternion.LookRotation(transform.position - from.position);
 
         //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
         // for this if you want variable results) and store it in a new Vector3 called runTo
         Vector3 runTo = transform.position + transform.forward * 20;
         //Debug.Log("runTo = " + runTo);
         
         //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.
         
         NavMeshHit hit;    // stores the output in a variable called hit
 
         // 5 is the distance to check, assumes you use default for the NavMesh Layer name
         NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Default")); 
         //Debug.Log("hit = " + hit + " hit.position = " + hit.position);
 
         // just used for testing - safe to ignore
 
         // reset the transform back to our start transform
         transform.position = startTransform.position;
         transform.rotation = startTransform.rotation;
 
         // And get it to head towards the found NavMesh position
         controller.navMeshAgent.SetDestination(hit.position);
     }

       
    }
}