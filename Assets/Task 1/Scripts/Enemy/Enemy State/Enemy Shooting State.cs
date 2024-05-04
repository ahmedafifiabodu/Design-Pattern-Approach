using UnityEngine;
using UnityEngine.AI;

public class EnemyShootingState : IEnemyState
{
    private readonly FireballPooling firePooling;
    private readonly Animator animator;

    private bool hasShot = false;
    private bool canShoot = false;

    public EnemyShootingState(FireballPooling firePooling, Animator animator)
    {
        this.firePooling = firePooling;
        this.animator = animator;
    }

    public void PerformAction(NavMeshAgent agent, Transform player)
    {
        agent.isStopped = true;

        Vector3 direction = (player.position - agent.transform.position).normalized;
        direction.y = 0;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        Shoot();
    }

    private void Shoot()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(GameConstant.AnimationSpellCastName))
        {
            float normalizedTime = stateInfo.normalizedTime % 1;
            if (normalizedTime >= 0.8f && !hasShot && canShoot)
            {
                firePooling.FirePool.Get();
                hasShot = true;
                canShoot = false;
            }
            else if (normalizedTime < 0.8f)
            {
                hasShot = false;
                canShoot = true;
            }
        }
        else
        {
            hasShot = false;
            canShoot = false;
        }
    }
}