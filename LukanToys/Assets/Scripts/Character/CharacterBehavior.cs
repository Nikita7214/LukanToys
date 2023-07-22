using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Script
{
    public class CharacterBehavior : MonoBehaviour , IStateSwitcher
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private CharacterEventHandler characterEventHandler;
        [SerializeField] private Text _forestText;
        [SerializeField] private double _targetNum = -4.055089;
        private List<StateBase> allStates;
        private StateBase currentState;

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

        public void OnTriggerEnter(Collider other)
        {
            if (agent.transform.position.x >= _targetNum)
            {
                _forestText.gameObject.SetActive(true);
            }
        }
    }
}