using UnityEngine;

namespace Game.Animations
{
    public class ChanAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        
        public float Speed
        {
            set => animator.SetFloat("Speed", value);
        }

        public float Direction
        {
            set => animator.SetFloat("Direction", value);
        }
        
        public void Jump()
        {
            animator.SetTrigger("Jump");
        }

        public void Landing()
        {
            animator.SetTrigger("Landing");
        }
        
        public void JumpSound()
        {
            Debug.Log("JumpSound");
        }
        
        
    }
}