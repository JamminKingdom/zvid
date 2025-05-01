using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyStateBase
{
    [SerializeField]
    private GameObject shootingPoint;
    [SerializeField]
    private GameObject projectilePrefab;
    
    private Coroutine attackCoroutine;

    private void OnEnable()
    {
        agent.isStopped = true;
        
        if (agent.isOnNavMesh)
            agent.ResetPath();

        anim.SetBool(data.HashIsWalking, false);
        
        Attack();
    }
    
    private void OnDisable()
    {
        if (agent.isOnNavMesh)
            agent.isStopped = false;
        
        if (attackCoroutine != null)
            StopCoroutine(attackCoroutine);
    }
    
    private void Attack()
    {
        StopAllCoroutines();
        attackCoroutine = StartCoroutine(AttackProcess());
    }
    
    private IEnumerator AttackProcess()
    {
        anim.SetTrigger(data.HashAttack);
        
        FireProjectile();
        
        yield return new WaitForSeconds(2f);
        
        enemy.SetState(enemy.chaseState);
    }
    
    private void FireProjectile()
    {
        GameObject projGo = Instantiate(
            projectilePrefab,
            shootingPoint.transform.position,
            shootingPoint.transform.rotation
        );
        
        EnemyProjectile proj = projGo.GetComponent<EnemyProjectile>();
        if (proj != null)
        {
            int damage = data.attackDamage;
            proj.Shot(damage, data.dirVec);
        }
    }
}