using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public static Player instance;
    public static float playerHealth = 500;
    public HealthModule healthModule;
    public GunManager gunManager;
    public float speed;
    public Rigidbody2D rb;
    public GameObject bullet;
    public Transform noozle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            healthModule.health = playerHealth;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pointerDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction =
            new Vector2(
                    Input.GetAxisRaw("Horizontal"),
                    Input.GetAxisRaw("Vertical")
                );

        rb.velocity = direction * speed;

        float angle = Mathf.Atan2(pointerDirection.y, pointerDirection.x) * Mathf.Rad2Deg;
        rb.angularVelocity = Mathf.DeltaAngle(rb.rotation, angle) * 10;

        if (Input.GetAxis("Fire1") > 0)
        {
            gunManager.isFiring = true;
        }
        else
        {
            gunManager.isFiring = false;
        }
    }

    public void Damage(float damage)
    {
        healthModule.health -= damage;
    }

    public void Defeat()
    {
        GameObject bulletEffectShoot = PoolManager.Get("Effect_Explosion");

        if (bulletEffectShoot)
        {
            bulletEffectShoot.transform.position = transform.position;
            bulletEffectShoot.transform.eulerAngles = transform.eulerAngles;
        }

        Destroy(gameObject);
    }
}
