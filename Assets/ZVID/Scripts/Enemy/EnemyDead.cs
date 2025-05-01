using System.Collections;
using UnityEngine;

public class EnemyDead : EnemyStateBase
{
    private void OnEnable()
    {
        Dead();
    }
    
    private void Dead()
    {
        StopAllCoroutines();
        StartCoroutine(DeadProcess());
    }
    
    private IEnumerator DeadProcess()
    {
        anim.SetTrigger(data.HashDead);
        
        rb.simulated = false;
        collider.enabled = false;
        
        yield return new WaitForSeconds(2f);
        
        SpawnManager.Instance.SpawnRandomItem(transform);
        GameManager.Instance.AddKillCount();
        Destroy(gameObject);
    }
}
