using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrollingState : IEnemyState
{
    private readonly Transform[] patrolPoints;
    private int currentPatrolIndex;
    private float timeSinceLastPatrolPoint;

    public EnemyPatrollingState(Transform[] patrolPoints) => this.patrolPoints = patrolPoints;

    public void PerformAction(NavMeshAgent agent, Transform player)
    {
        agent.isStopped = false;
        timeSinceLastPatrolPoint += Time.deltaTime;

        if (!agent.pathPending && (agent.remainingDistance < 0.5f || timeSinceLastPatrolPoint > 5f))
        {
            GoToNextPatrolPoint(agent);
            timeSinceLastPatrolPoint = 0f;
        }
    }

    private void GoToNextPatrolPoint(NavMeshAgent agent)
    {
        if (patrolPoints.Length == 0)
            return;

        currentPatrolIndex = Random.Range(0, patrolPoints.Length);
        agent.destination = patrolPoints[currentPatrolIndex].position;
    }
}