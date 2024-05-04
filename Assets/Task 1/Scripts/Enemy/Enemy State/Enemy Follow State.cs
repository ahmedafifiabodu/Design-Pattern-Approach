using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowState : IEnemyState
{
    public void PerformAction(NavMeshAgent agent, Transform player)
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }
}