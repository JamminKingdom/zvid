using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Transform target;
    
    [HideInInspector]
    public float knockbackForce = 10f;
    [HideInInspector]
    public float knockbackDuration = 0.2f;
    [HideInInspector]
    public bool isWalking;
    [HideInInspector]
    public float detectionRangeSqr = 30f;
    [HideInInspector]
    public float attackRangeSqr = 1f;
    [HideInInspector]
    public Vector2 dirVec;

    private void Update()
    {
        dirVec = target.position - transform.position;
        isWalking = dirVec.sqrMagnitude < detectionRangeSqr;
    }
}
