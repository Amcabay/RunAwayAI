using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runaway : MonoBehaviour
{
    [SerializeField] private Transform chaser = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private float displacementDist = 5f;

    private void Start() 
    {
        if(agent == null)
        {
            if(!TryGetComponent(out agent))
            {
                Debug.LogWarning(name + "needs a NavMesh Agent");
            }
        } 
    }

    private void Update() 
    {
        if(chaser == null)
        {
            return;
        }

        Vector3 normDir = (chaser.position - transform.position).normalized;

        normDir = Quaternion.AngleAxis(Random.Range(0 ,179), Vector3.up) * normDir;   //Angle to right

        MoveToPos(transform.position - (normDir * displacementDist));
    }

    private void MoveToPos(Vector3 pos) 
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }

    /*private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;

        Vector3 direction = (chaser.position - transform.position).normalized; // direction

        float mag = direction.magnitude; //will be one
        print(mag);

        Gizmos.DrawLine(transform.position, transform.position + direction );    
    }*/

}
