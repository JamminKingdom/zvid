public class EnemyIdle : EnemyStateBase
{
    private void OnEnable()
    {
        anim.SetBool(data.HashIsWalking, data.isWalking);
    }
    
    private void Update()
    {
        if (data.isWalking)
        {
            anim.SetBool(data.HashIsWalking, true);
            enemy.SetState(enemy.chaseState);
        }
    }
}
