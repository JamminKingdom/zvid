using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject play;
    public float Speed = 1f;

    private Vector3 dir;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");

        var v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, v, 0f);
        transform.position += Speed * Time.deltaTime * dir;
    }
}
