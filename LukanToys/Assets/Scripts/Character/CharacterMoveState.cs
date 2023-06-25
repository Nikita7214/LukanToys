using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class CharacterMoveState : StateBase
    {
        private NavMeshAgent _agent;
        private float speed;
        
        public CharacterMoveState(IStateSwitcher switcher, NavMeshAgent agent) : base(switcher)
        {
            _agent = agent;
        }

        public override void Enter()
        {
            speed = _agent.speed;
            Debug.Log("enter move");
        }

        public override void Exit()
        {
            Debug.Log("exit move");
        }
        
        public override void Update()
        {
            
        }

        void changeSpeed()
        {
            float speedMultiplyer = 1.0f - 0.9f*Vector3.Angle(_agent.transform.forward, _agent.steeringTarget-_agent.transform.position)/180.0f;
            _agent.speed = speed*speedMultiplyer;
        }
        
        public override void FixedUpdate()
        {
            changeSpeed();
            if (_agent.isStopped)
            {
                _switcher.Switch<CharacterIdleState>();
            }
        }
    }
}