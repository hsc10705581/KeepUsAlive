using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootInterval;
    public List<GameObject> projectiles;

    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        float tempTime = Time.fixedTime;
        if (tempTime > shootTime)
        {
            shootTime = tempTime + shootInterval;
            GameObject go = Instantiate(
                projectiles[RandomManager.RandomRange(projectiles.Count)],
                transform.position,
                Quaternion.identity,
                GameObject.Find("EnemyProjectiles").transform
                );
            go.GetComponent<Projectile>().damage = GetComponent<EnemyHit>().damage;
            go.GetComponent<Projectile>().enemyBullet = true;
            go.GetComponent<Projectile>().destroyedByCollision = true;
            go.GetComponent<ProjectileMovement>().currentDir =
                (PlayerMovement.curPos - transform.position).normalized;
        }
    }
}
