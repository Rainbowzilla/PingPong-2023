using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon Instance;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float lifeTime = 3;

   // public AudioSource shooting;

   // public ParticleSystem sparks;

    public Vector3 force;

    public KeyCode fireKey, reloadKey;

    public float fireRate = 1f, nextFire = 0f;

    public int currentClip, maxClipSize;

    public Image bullet1, bullet2, bullet3, bullet4, bullet5, bullet6;

    public float countTimer, countTime;

    public Slider reloadSlider;

    #region Monobehaviour API

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        countTimer = countTime;

        reloadSlider.maxValue = countTimer;
        reloadSlider.value = countTimer;
    }

    void Update()
    {
        Fire();
        Reload();
        BulletUI();
        // shooting.Play();
        // sparks.Play();
    }
    private void Fire()
    {
        if (Input.GetKeyDown(fireKey) && Time.time > nextFire && currentClip > 0)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab);

            bullet.transform.position = bulletSpawn.position;

            bullet.GetComponent<Rigidbody2D>().AddForce(force);

            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));

            currentClip--;

            print("Player 1 has " + currentClip + " bullets left");
        }

        if (Input.GetKeyDown(fireKey) && Time.time > nextFire && currentClip <= 0)
        {
            nextFire = Time.time + fireRate;
        }
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }

    public void Reload()
    {
        if (Input.GetKey(reloadKey))
        {
            countTimer -= Time.deltaTime;
            reloadSlider.value = countTimer;
            print("Player 1 is reloading");

            if (countTimer < 0)
            {
                int reloadAmount = maxClipSize - currentClip;
                currentClip += reloadAmount;

                countTimer = countTime;

                print("Player 1 has reloaded");
            }
        }
    }

    public void BulletUI()
    {
        if (currentClip == 5)
        {
            bullet1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 4)
        {
            bullet2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 3)
        {
            bullet3.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 2)
        {
            bullet4.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 1)
        {
            bullet5.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 0)
        {
            bullet6.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (currentClip == 6)
        {
            bullet1.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            bullet2.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            bullet3.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            bullet4.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            bullet5.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            bullet6.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
        }
    }

    #endregion
}
