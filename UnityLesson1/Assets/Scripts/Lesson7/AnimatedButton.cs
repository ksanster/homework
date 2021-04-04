using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Button))]
    public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const string Reset = "Reset";
        private const string Play = "Play";

        [SerializeField]
        private Animator animator;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            animator.SetTrigger(Play);        }

        public void OnPointerExit(PointerEventData eventData)
        {
            animator.SetTrigger(Reset);
        }
    }
}