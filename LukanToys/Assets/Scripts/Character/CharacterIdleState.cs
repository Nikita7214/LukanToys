using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Script
{
    public class CharacterIdleState : StateBase
    {
        private NavMeshAgent _agent;
        private CharacterEventHandler _characterEventHandler;
        public CharacterIdleState(IStateSwitcher switcher,NavMeshAgent agent,CharacterEventHandler characterEventHandler) : base(switcher)
        {
            _agent = agent;
            _characterEventHandler = characterEventHandler;
        }

        public override void Enter()
        {
            Debug.Log("Enter Idle");
            _characterEventHandler.OnInteracted += OnInteract;
        }

        public override void Exit()
        {
            Debug.Log("Exit Idle");
        }

        public override void Update()
        {
        }

        private void OnInteract(InteractiveObject interactiveObject)
        {
            Debug.Log(interactiveObject.targetTransform.position);
            _agent.SetDestination(interactiveObject.targetTransform.position);
            _switcher.Switch<CharacterMoveState>();
        }

        public override void FixedUpdate()
        {
        }
    }
}