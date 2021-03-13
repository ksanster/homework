using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public const string GhostName = "ghost";

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    public void StartMove()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
    }
    
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == EyeBatMove.Player)
        {
            GameController.Instance.KillPlayer();
        }
    }

    private void Update ()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
