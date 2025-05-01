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
        // agent.isStopped = true;
        // if (agent.isOnNavMesh)
        //     agent.ResetPath();

        agent.enabled = false;
        
        anim.SetTrigger(data.HashDead);
        AudioManager.Instance.PlaySFX(SFXType.EnemyDead);
        
        rb.simulated = false;
        collider.enabled = false;
        
        yield return new WaitForSeconds(2f);
        
        SpawnManager.Instance.SpawnRandomItem(transform);
        GameManager.Instance.AddKillCount();
        Destroy(gameObject);
    }
}
