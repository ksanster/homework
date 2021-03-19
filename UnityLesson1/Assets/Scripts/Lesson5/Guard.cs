using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson5
{
    public class Guard : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private float AttentionRange;
        [SerializeField]
        private float PursuitRange;
        [SerializeField]
        private float AttackRange;

        [Space]
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private float speed;

        private Dictionary<State, string> animations = new Dictionary<State, string>
        {
            {State.Idle, "DefendGetHit"},  
            {State.Attetnion, "IdleBattle"},  
            {State.Pursuit, "WalkFWD"},  
            {State.Attack, "Attack01"},  
            {State.Wait, "SenseSomethingRPT"},  
            {State.Return, "WalkFWD"}  
        };
        
        private State state;

        private void Start()
        {
            SetState(State.Idle);
        }

        public void SetState(State newState)
        {
            if (state == newState)
                return;
            
            state = newState;
            if (animations.ContainsKey(state))
                animator.Play(animations[state]);
            
            if (state == State.Wait)
                StartCoroutine(WaitAndReturn());
        }
        
        private IEnumerator WaitAndReturn()
        {
            var startTime = Time.time;
            yield return new WaitUntil(() => (Time.time - startTime) > 5f || state != State.Wait);
            SetState(State.Return);
        }
        
        private void LookTo(Transform target)
        {
            var newDir = Vector3.RotateTowards(transform.forward, (target.position - transform.position), Mathf.PI * 2f, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        private void Update()
        {
            var distance = Vector3.Distance(target.position, transform.position);
            
            if (state == State.Attack || state == State.Pursuit || state == State.Attetnion)
            {
                LookTo(target);
                if (state == State.Pursuit)
                    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            }
            
            if (state == State.Return)
            {
                LookTo(startPoint);
                transform.position = Vector3.Lerp(transform.position, startPoint.position, Time.deltaTime * speed * 2f);
                var distanceToStart = Vector3.Distance(transform.position, startPoint.position);
                if (distanceToStart < 0.7f)
                    SetState(State.Idle);
            }
            
            if (state == State.Attack && distance > AttackRange)
            {
                SetState(State.Pursuit);
                return;
            }
            
            if (distance < AttackRange)
            {
                SetState(State.Attack);
                return;
            }
            if (distance < PursuitRange)
            {
                SetState(State.Pursuit);
                return;
            }
            if (state == State.Idle && distance < AttentionRange)
            {
                SetState(State.Attetnion);
                return;
            }
            if (state == State.Pursuit && distance > PursuitRange)
            {
                SetState(State.Wait);
                return;
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, AttentionRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, PursuitRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }


        public enum State
        {
            Undefined, Idle, Attetnion, Pursuit, Attack, Wait, Return
        }
    }
}