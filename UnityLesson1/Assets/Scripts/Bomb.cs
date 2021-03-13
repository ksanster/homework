using UnityEngine;

namespace DefaultNamespace
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField]
        private bool isSecret;
        
        private void OnTriggerEnter (Collider other)
        {
            if (isSecret && other.gameObject.name == EyeBatMove.Player)
            {
                other.gameObject.GetComponent<EyeBatMove>().HasBomb = true;
                Destroy(gameObject);
            }
            if (other.gameObject.name == Ghost.GhostName)
            {
                GameController.Instance.KillEnemy();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

    }
}