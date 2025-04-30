using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyStateBase
{
    [SerializeField]
    private GameObject shootingPoint;
    [SerializeField]
    private GameObject projectilePrefab;

    private void OnEnable()
    {
        Attack();
    }
    
    private void Attack()
    {
        StopAllCoroutines();
        StartCoroutine(AttackProcess());
    }
    
    private IEnumerator AttackProcess()
    {
        anim.SetTrigger(data.HashAttack);
        
        FireProjectile();
        
        yield return new WaitForSeconds(2f);
        
        enemy.SetState(enemy.idleState);
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