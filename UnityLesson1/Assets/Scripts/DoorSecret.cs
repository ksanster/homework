using UnityEngine;

public class DoorSecret : MonoBehaviour
{
    [SerializeField]        
    private GameObject door;

    
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == EyeBatMove.Player)
        {
            door.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}