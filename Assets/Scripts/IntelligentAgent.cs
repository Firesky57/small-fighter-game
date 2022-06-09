using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


 
public class IntelligentAgent : Agent
{
     [SerializeField] private Transform treasure;
     [SerializeField] private Transform spikes;

     CharacterState characterState;
 
     private void Start()
     {
        characterState = GetComponent<CharacterState>();
     }
 
     public override void OnEpisodeBegin()
     {
        float[] possiblePositionX = new float[] { -1.6f, 0.08f};
        int randomIndex = Random.Range(0, possiblePositionX.Length);
        float positionX = possiblePositionX[randomIndex];
 
        treasure.transform.localPosition= new Vector3(positionX, -.5f, 0);
        spikes.transform.localPosition= (randomIndex == 0) ? new Vector3(possiblePositionX[1], -.5f, 0) : new Vector3(possiblePositionX[0], -.5f, 0);
 
         transform.localPosition= new Vector3(-5.6f, 0, 0);
    }
 
     public override void CollectObservations(VectorSensor sensor)
     {
         sensor.AddObservation(transform.localPosition);
         sensor.AddObservation(treasure.localPosition);
     }
 
     public override void OnActionReceived(ActionBuffers actions)
     {
          characterState.horizontal = actions.ContinuousActions[0];
     }
 
     public override void Heuristic(in ActionBuffers actionsOut)
     {
          ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
          continuousActions[0] = Input.GetAxisRaw("Horizontal");
     }
 
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.gameObject.name.Equals("Health"))
         {
           Debug.Log("HEALTH FOUND");
           SetReward(+20f);
           EndEpisode();
        }
       else if(collision.gameObject.name.Equals("Spikes"))
       {
        Debug.Log("SPIKES FOUND");
        SetReward(-20f);
        EndEpisode();
       }
         
      }
   
}
