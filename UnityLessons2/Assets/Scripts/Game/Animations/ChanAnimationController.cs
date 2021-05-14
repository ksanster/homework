using System;
using UnityEngine;

namespace Game.Animations
{
    public class ChanAnimationController : MonoBehaviour
    {
        private const float MaxLookDistance = 10f;
        private const float MaxHandDistance = 3f;
        
        [SerializeField] 
        private AudioClip jumpSound;
        
        [SerializeField]
        private Animator animator;
        
        [SerializeField]
        private Transform targetObject;

        private AudioSource audioSource;
        
        public float Speed
        {
            set => animator.SetFloat("Speed", value);
        }

        public float Direction
        {
            set => animator.SetFloat("Direction", value);
        }

        private void Start()
        {
            audioSource = transform.parent.GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(jumpSound);
        }
        
        private void SetIKForTargetObject()
        {
            if (targetObject == null)
                return;
            
            var direction = targetObject.position - transform.position;
            var distance = direction.magnitude;
            if (distance >= MaxLookDistance)
                return;
            
            var weight = 1f - distance / MaxLookDistance;
            animator.SetLookAtWeight(weight);
            animator.SetLookAtPosition(targetObject.position);
            
            if (Vector3.Dot(direction, transform.forward) < 0)
                return;
            
            var rightPoint = targetObject.position + 0.15f * targetObject.right;
            var leftPoint = targetObject.position - 0.15f * targetObject.right;
            
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightPoint);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftPoint);
        }
        
        private bool SetIKForWalls()
        {
            var pos = animator.GetIKHintPosition(AvatarIKHint.RightKnee);
            if (Physics.Raycast(pos, transform.forward, out var hitInfo, MaxHandDistance, LayerMask.GetMask("Wall")))
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                animator.SetIKPosition(AvatarIKGoal.RightHand, hitInfo.point);
                return true;
            }
            return false;
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (SetIKForWalls())
                return;
            
            SetIKForTargetObject();
        }
    }
}