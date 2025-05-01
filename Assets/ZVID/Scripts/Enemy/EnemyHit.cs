using System.Collections;
using UnityEngine;

public class EnemyHit : EnemyStateBase
{
    private void OnEnable()
    {
        OnHit();
    }

    private void OnHit(int damage = 0)
    {
        StopAllCoroutines();
        StartCoroutine(HitProcess());
    }
    
    private IEnumerator HitProcess()
    {
        anim.SetTrigger(data.HashHit);
        
        yield return new WaitForSeconds(0.5f);

        enemy.SetState(enemy.chaseState);
    }
}
