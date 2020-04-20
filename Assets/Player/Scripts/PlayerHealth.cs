using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform healthBar;
    public GameObject fullHeart;
    public GameObject halfHeart;
    public GameObject emptyHeart;
    public GameObject brokenHeart;
    public AudioSource hurt;

    // 每点health对应半颗心
    public int maxHealth; // 只能是偶数
    public int health;
    public float invincibleLength;

    private bool invincible;
    private SpriteRenderer sr;

    private float twinkleTime;
    private float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdatePlayerHealthBar();
        invincible = false;
    }

    private void Update()
    {
        Twinkle();
    }

    public void InitHealth()
    {
        health = maxHealth;
        UpdatePlayerHealthBar();
    }

    private void UpdatePlayerHealthBar()
    {
        // 先删除所有♥
        if (healthBar.childCount > 1)
        {
            for (int i = 1; i < healthBar.childCount; i++)
            {
                if (healthBar.childCount == 0)
                    break;
                Destroy(healthBar.GetChild(i).gameObject);
            }
        }
        int heartAmount = (maxHealth + 1) / 2;
        // 根据health来生成新的♥
        int tempHealth = health;
        for (int i = 0; i < heartAmount; i++)
        {
            if (tempHealth <= 0)
            {
                GameObject heart = Instantiate(emptyHeart);
                heart.transform.SetParent(healthBar);
            }
            else if (tempHealth == 1)
            {
                GameObject heart = Instantiate(halfHeart);
                heart.transform.SetParent(healthBar);
                tempHealth -= 1;
            }
            else if (tempHealth >= 2)
            {
                GameObject heart = Instantiate(fullHeart);
                heart.transform.SetParent(healthBar);
                tempHealth -= 2;
            }
        }
    }

    public void HealthChange(int changeAmount)
    {
        if (invincible)
        {
            return;
        }
        health += changeAmount;
        UpdatePlayerHealthBar();

        invincible = true;
        sr.enabled = false;
        invincibleTime = Time.fixedTime + invincibleLength;
        twinkleTime = Time.fixedTime + 0.2f;

        hurt.Play();

        if (health <= 0)
        {
            //GetComponent<PlayerController>().Die();
            GameManager.PlayerDie();
        }
    }

    public void MaxHealthChange(int changeAmount)
    {
        maxHealth += changeAmount;
        UpdatePlayerHealthBar();
    }

    private void Twinkle()
    {
        float tempTime = Time.fixedTime;
        if (invincible)
        {
            if (tempTime > invincibleTime)
            {
                invincible = false;
                sr.enabled = true;
            }
            if (tempTime > twinkleTime)
            {
                twinkleTime = Time.fixedTime + 0.2f;
                sr.enabled = !sr.enabled;
            }
        }
    }
}
