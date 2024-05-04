using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackingState : IEnemyState
{
    public void PerformAction(NavMeshAgent agent, Transform player)
    {
        agent.isStopped = true;

        Vector3 direction = (player.position - agent.transform.position).normalized;
        direction.y = 0;
        agent.transform.rotation = Quaternion.LookRotation(direction);
    }
}