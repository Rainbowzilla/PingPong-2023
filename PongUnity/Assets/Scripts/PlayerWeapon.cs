using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float lifeTime = 3;

   // public AudioSource shooting;

   // public ParticleSystem sparks;

    public Vector3 force;

    #region Monobehaviour API


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            //shooting.Play();
           // sparks.Play();
        }
    }
    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        bullet.transform.position = bulletSpawn.position;

        bullet.GetComponent<Rigidbody2D>().AddForce(force);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }

    #endregion
}
