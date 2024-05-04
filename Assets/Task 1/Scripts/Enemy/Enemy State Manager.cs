using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(FireballPooling))]
public class EnemyStateManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Animator animator;
    [SerializeField] private Collider attackCollider;

    internal int enemyIndex;
    private float tempStoppingDistance;
    private bool canShoot;
    private const float chaseAfterLostSightDuration = 5f;

    private EnemyManager enemyManager;
    private FireballPooling fireballPooling;
    internal Enemies Enemy { get; private set; }

    private IEnemyState currentState;
    private IEnemyState idleState;
    private IEnemyState patrollingState;
    private IEnemyState followState;
    private IEnemyState attackState;
    private IEnemyState shootingState;

    private void Awake() => enemyManager = ServiceLocator.Instance.GetService<EnemyManager>();

    private void Start()
    {
        Enemy = enemyManager.GetEnemyByIndex(enemyIndex);

        canShoot = Enemy.canShoot;

        tempStoppingDistance = agent.stoppingDistance;

        idleState = new EnemyIdleState();
        patrollingState = new EnemyPatrollingState(Enemy.patrolPoints);
        followState = new EnemyFollowState();
        attackState = new EnemyAttackingState();

        if (canShoot)
        {
            fireballPooling = gameObject.GetComponent<FireballPooling>();
            shootingState = new EnemyShootingState(fireballPooling, animator);
            attackCollider.enabled = false;
        }
        else
        {
            shootingState = null;
            attackCollider.enabled = true;
        }
    }

    internal void ChangeState(IEnemyState newState) => currentState = newState;

    private bool CheckPlayerInSight(float distanceToPlayer)
    {
        if (enemyManager.playerTransformtion == null) return false;

        if (distanceToPlayer < Enemy.sightRange)
        {
            //Vector3 directionToPlayer = (enemyManager.playerTransformtion.position - agent.gameObject.transform.position).normalized;

            //if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, Enemy.sightRange))
            //    if (hit.collider.gameObject == enemyManager.playerTransformtion.gameObject)
            //        return true;

            return true;
        }

        return false;
    }

    private void HandleAnimator()
    {
        switch (currentState.GetType().Name)
        {
            case nameof(EnemyIdleState):
                animator.SetBool(GameConstant.Walk, false);
                animator.SetBool(GameConstant.Shoot, false);
                animator.SetBool(GameConstant.Attack, false);
                break;

            case nameof(EnemyPatrollingState):
                animator.SetBool(GameConstant.Walk, true);
                animator.SetBool(GameConstant.Shoot, false);
                animator.SetBool(GameConstant.Attack, false);
                break;

            case nameof(EnemyFollowState):
                animator.SetBool(GameConstant.Walk, true);
                animator.SetBool(GameConstant.Shoot, false);
                animator.SetBool(GameConstant.Attack, false);
                break;

            case nameof(EnemyShootingState):
                animator.SetBool(GameConstant.Shoot, true);
                animator.SetBool(GameConstant.Walk, false);
                break;

            case nameof(EnemyAttackingState):
                animator.SetBool(GameConstant.Attack, true);
                animator.SetBool(GameConstant.Walk, false);
                break;
        }
    }

    private void UpdateEnemyState()
    {
        float distanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, enemyManager.playerTransformtion.position);

        bool isPlayerInSight = CheckPlayerInSight(distanceToPlayer);

        if (isPlayerInSight)
        {
            agent.stoppingDistance = Enemy.attackRange;

            if (distanceToPlayer <= Enemy.attackRange)
                ChangeState(canShoot ? shootingState : attackState);
            else if (agent.CalculatePath(enemyManager.playerTransformtion.position, agent.path) && agent.path.status == NavMeshPathStatus.PathComplete)
                ChangeState(followState);
        }
        else
        {
            agent.stoppingDistance = tempStoppingDistance;
            ChangeState(patrollingState);
        }

        currentState.PerformAction(agent, enemyManager.playerTransformtion);
        HandleAnimator();
    }

    private void Update() => UpdateEnemyState();
}