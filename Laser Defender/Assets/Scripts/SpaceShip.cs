using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int health = 100;

    [Header("Projectile")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 30f;

    [Header("SFX")]
    [SerializeField] private AudioClip onDeathSound;
    [SerializeField] private AudioClip onShotSound;
    [SerializeField] [Range(0, 1)] private float deathVolume = 0.1f;
    [SerializeField] [Range(0, 1)] private float shotVolume = 0.1f;

    [Header("VFX")]
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float explosionDuration = 0.2f;



    public bool ProcessHit(DamageDealer damageDealer)
    { 
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Death();
            return true;
        }
        return false;
    }

    public void Fire(bool forwardDirection)
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity);
        if (forwardDirection)
        {
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
        else
        {
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        }
        
        AudioSource.PlayClipAtPoint(onShotSound, Camera.main.transform.position, shotVolume);
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(onDeathSound, Camera.main.transform.position, deathVolume);
        var onDeathExplosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(onDeathExplosion, explosionDuration);
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
