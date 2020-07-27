using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float health = 100f;
    [SerializeField] private ParticleSystem explosionVFX;

    [Header("Projectile")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 2f;
    [SerializeField] private float projectileSpeed = 15f;

    [Header("Sound")]
    [SerializeField] private AudioClip onDeathSound;
    [SerializeField] private AudioClip onShotSound;
    [SerializeField] [Range(0, 1)] private float deathVolume = 0.1f;
    [SerializeField] [Range(0, 1)] private float shotVolume = 0.1f;



    private float shotCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(onShotSound, Camera.main.transform.position, shotVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        AudioSource.PlayClipAtPoint(onDeathSound, Camera.main.transform.position, deathVolume);
        var onDeathExplosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(onDeathExplosion, 0.2f);
    }

}
