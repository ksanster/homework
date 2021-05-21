using System;
using UnityEngine;

namespace Game.Phys
{
    public class Pendulum : MonoBehaviour
    {
        private const float TouchForce = 1f;
        
        [SerializeField]
        private Rigidbody sphere;
        [SerializeField]
        private Transform topPoint;
        [SerializeField]
        private HingeJoint joint;

        private LineRenderer rope;
        
        
        public float Mass
        {
            get => sphere.mass;
            set => sphere.mass = value;
        }
        
        public float Length
        {
            get => joint.anchor.y;
            set => joint.anchor = new Vector3(joint.anchor.x, value, joint.anchor.z);
        }

        private void Awake()
        {
            rope = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            rope.SetPosition(0, topPoint.position);
            rope.SetPosition(1, sphere.transform.position);
        }


        private void OnGUI()
        {
            Mass = GUI.HorizontalSlider(new Rect(5, 5, 200, 20), Mass, 0.5f, 10f );
            Length = GUI.HorizontalSlider(new Rect(5, 20, 200, 20), Length, 2f, 5f );
            
            if (GUI.Button(new Rect(5, 40, 200, 40), "Touch"))
            {
                sphere.AddForce(TouchForce * Vector3.forward, ForceMode.Impulse);
            }
        }
    }
}