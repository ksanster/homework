using UnityEngine;

namespace Lesson6
{
    public class Door : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        
        public void Open()
        {
            animator.SetTrigger("open");
        }
        
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}