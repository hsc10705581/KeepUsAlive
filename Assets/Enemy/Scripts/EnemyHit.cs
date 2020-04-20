using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int damage;

    private Collider2D col;
    private SpriteRenderer sr;
    private float startTime;
    private bool isInit;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        startTime = Time.fixedTime;
        isInit = true;
    }

    private void Update()
    {
        if (isInit)
        {
            if (startTime + 1.0f < Time.fixedTime)
            {
                isInit = false;
                col.enabled = true;
                sr.color = new Color(1, 1, 1, 1);
                GetComponent<EnemyShoot>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Sister") 
            && !isInit)
        {
            collision.gameObject.GetComponent<PlayerHealth>().HealthChange(-damage);
        }
    }

}
