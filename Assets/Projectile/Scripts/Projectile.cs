using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    public int damage;

    [Tooltip("Whether the projectile belongs to global.")]
    public bool globalBullet;

    [Tooltip("Whether the projectile belongs to the ‘Enemy")]
    public bool enemyBullet;
    
    [Tooltip("Whether the projectile belongs to the ‘Sister")]
    public bool sisterBullet;

    [Tooltip("Whether the projectile is destroyed in the collision, or not")]
    public bool destroyedByCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((globalBullet || enemyBullet || sisterBullet) && collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().HealthChange(-damage);
            if (destroyedByCollision)
                Destroy(gameObject);
        }
        else if ((globalBullet || enemyBullet) && collision.tag == "Sister")
        {
            collision.GetComponent<PlayerHealth>().HealthChange(-damage);
            if (destroyedByCollision)
                Destroy(gameObject);
        }
        else if ((globalBullet || sisterBullet) && collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().HealthChange(-damage);
            if (destroyedByCollision)
                Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
        {
            if (destroyedByCollision)
                Destroy(gameObject);
        }
        else if (collision.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.tag == "Background")
        //{
        //    Destroy(gameObject);
        //}
        if (collision.tag == "Wall")
        {
            destroyedByCollision = true;
        }
    }
}
