using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class CharacterMoveState : StateBase
    {
        private NavMeshAgent _agent;
        
        public CharacterMoveState(IStateSwitcher switcher, NavMeshAgent agent) : base(switcher)
        {
            _agent = agent;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
        
        public override void Update()
        {
            if (_agent.velocity.magnitude < 0.15f)
            {
                _switcher.Switch<CharacterIdleState>();
            }
        }

        public override void FixedUpdate()
        {
           
        }
    }
}