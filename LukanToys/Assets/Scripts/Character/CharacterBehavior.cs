using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class CharacterBehavior : MonoBehaviour , IStateSwitcher
    {
        private List<StateBase> allStates;
        private StateBase currentState;

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private CharacterEventHandler characterEventHandler;

        private void Start()
        {
            allStates = new List<StateBase>()
            {
                new CharacterIdleState(this,agent,characterEventHandler),
                new CharacterMoveState(this,agent)
            };
            SetStateByDefault();
        }

        private void SetStateByDefault()
        {
            var s = allStates.FirstOrDefault(s => s is CharacterIdleState);
            currentState = s;
            currentState.Enter();
        }

        private void Update()
        {
            currentState.Update();
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdate();
        }

        public void Switch<T>() where T : StateBase
        {
            var s = allStates.FirstOrDefault(s => s is T);
            currentState.Exit();
            currentState = s;
            currentState.Enter();
        }
    }
}