using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private NavMeshAgent[] agents;
    private void Start()
    {
        // transform.rotation = Quaternion.identity;
        _navMeshSurface.BuildNavMesh();
        foreach (var agent in agents)
        {
            agent.gameObject.SetActive(true);
        }
    }
}
