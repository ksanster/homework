using System;
using UnityEngine;

public class Hound : MonoBehaviour
{
    [SerializeField]        
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;

    
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == EyeBatMove.Player)
        {
            GameController.Instance.KillPlayer();
        }
    }

    private void Update()
    {
        var range = Vector3.Distance(transform.position, target.position);
        if (range <= maxRange)
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}
