using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger) 
    {
        if (trigger.gameObject.name == Ghost.GhostName)
            Destroy(trigger.gameObject);
    }        
}