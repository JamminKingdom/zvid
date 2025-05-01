using System;
using UnityEngine;

public class Gun_void : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource gunAudio;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunAudio.Play();
        Instantiate(bulletPrefab);
    }
}
