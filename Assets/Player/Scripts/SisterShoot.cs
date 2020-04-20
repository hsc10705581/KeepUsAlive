using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterShoot : MonoBehaviour
{
    public float shootInterval;
    public List<GameObject> projectiles;

    private float shootTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (!SisterMovement.isStop)
        {
            return;
        }
        float tempTime = Time.fixedTime;
        if (tempTime > shootTime)
        {
            shootTime = tempTime + shootInterval;
            GameObject go = Instantiate(
                projectiles[RandomManager.RandomRange(projectiles.Count)],
                transform.position,
                Quaternion.identity,
                GameObject.Find("SisterProjectiles").transform
                );
            go.GetComponent<Projectile>().damage = 1;
            go.GetComponent<Projectile>().sisterBullet = true;
            go.GetComponent<Projectile>().destroyedByCollision = true;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (new Vector3(mousePos.x, mousePos.y) - transform.position).normalized;
            go.GetComponent<ProjectileMovement>().currentDir = direction;
        }
    }
}
