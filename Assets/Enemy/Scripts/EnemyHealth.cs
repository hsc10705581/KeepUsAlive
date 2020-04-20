using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;

    private float curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthChange(float changeAmount)
    {
        curHealth += changeAmount;
        UpdateHealthBar();
        if (curHealth <= 0.1f)
        {
            Destroy(gameObject);
            EnemyManager.EnemyDie();
        }
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = curHealth / maxHealth;
    }
}
