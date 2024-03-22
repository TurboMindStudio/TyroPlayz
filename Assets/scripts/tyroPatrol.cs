using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class tyroPatrol : MonoBehaviour
{
    public Transform[] wayPoints;
    private NavMeshAgent navMeshAgent;
    public int currentIndex;
    public float rotateSpeed;
    public Transform[] wheel;


    public float detectionRadius = 5f;
    public float chaseRange;
    public LayerMask targetMask;
    private void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        
    }

    private void OnValidate()
    {
        OnDrawGizmosSelected();
    }

    private void Update()
    {

        PATROL();


        // Check for targets within detection radius
        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius, targetMask);

        foreach (Collider target in targets)
        {

            float distanceBeetweenPlayerAndEnemy = Vector3.Distance(this.transform.position, target.transform.position);
           // Debug.Log(distanceBeetweenPlayerAndEnemy);

            
            if (distanceBeetweenPlayerAndEnemy <= 1)
            {
                Debug.Log("Player caught");
            }
            else if (distanceBeetweenPlayerAndEnemy <= 10)
            {
                navMeshAgent.destination = target.transform.position;
            }
            else if(distanceBeetweenPlayerAndEnemy >= 15)
            {
                PATROL();
            }

            // Check if the target is within the enemy's field of view
            if (IsTargetInFOV(target.transform))
            {
                // Enemy has detected the target
               // Debug.Log("Enemy has detected the target: " + target.name);

                navMeshAgent.destination = target.transform.position;

                // Perform actions like attacking or chasing the target
                // For simplicity, let's just print a message
            }
        }

        foreach (Transform wheels in wheel)
        {
            wheels.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }



    }

    public void PATROL()
    {
        // Transform W = wayPoints[currentIndex];

       

        float distanceBetweenEnemyandPoints = Vector3.Distance(this.transform.position, wayPoints[currentIndex].position);

        if (distanceBetweenEnemyandPoints <= 1f)
        {
            currentIndex = (currentIndex + 1) % wayPoints.Length;
        }
        else
        {
            navMeshAgent.destination = wayPoints[currentIndex].position;
        }
    }

    private bool IsTargetInFOV(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

        // Check if the angle to the target is within the FOV
        if (angleToTarget < 45f) // Example FOV angle of 90 degrees (45 degrees to each side)
        {
            // Raycast to ensure there are no obstacles blocking the view
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToTarget, out hit, detectionRadius))
            {
                // Check if the target is in line of sight
                if (hit.collider.transform == target)
                {
                    return true;
                }
            }
        }
        return false;
    }

  

    private void OnDrawGizmosSelected()
    {
        // Draw detection radius in Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);

        // Draw FOV cone in Scene view
        float halfFOV = 45f; // Example FOV angle of 90 degrees (45 degrees to each side)
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);

        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftRayDirection * detectionRadius);
        Gizmos.DrawRay(transform.position, rightRayDirection * detectionRadius);
    }


}
