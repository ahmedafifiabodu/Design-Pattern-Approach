using UnityEngine;
using UnityEngine.AI;

public interface IEnemyState
{
    void PerformAction(NavMeshAgent agent, Transform player);
}