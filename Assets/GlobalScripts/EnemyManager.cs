using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public static int level = 0;

    public List<GameObject> enemyPool;
    public List<float> level2EnemyShootInterval;
    public List<int> level2EnemyHealth;
    public List<int> level2EnemyAmount;
    public List<int> level2EnemySpeed;
    public AudioSource enemyDie;

    private static int enemyAlive = 0;
    private static float curEnemyShootInterval
    {
        get
        {
            return level >= instance.level2EnemyShootInterval.Count ?
                instance.level2EnemyShootInterval[instance.level2EnemyShootInterval.Count - 1] :
                instance.level2EnemyShootInterval[level];
        }
    }
    private static int curEnemyHealth
    {
        get
        {
            return level >= instance.level2EnemyHealth.Count ?
                instance.level2EnemyHealth[instance.level2EnemyHealth.Count - 1] :
                instance.level2EnemyHealth[level];
        }
    }
    private static int curEnemyAmount
    {
        get
        {
            return level >= instance.level2EnemyAmount.Count ?
                instance.level2EnemyAmount[instance.level2EnemyAmount.Count - 1] :
                instance.level2EnemyAmount[level];
        }
    }
    private static int curEnemySpeed
    {
        get
        {
            return level >= instance.level2EnemySpeed.Count ?
                instance.level2EnemySpeed[instance.level2EnemySpeed.Count - 1] :
                instance.level2EnemySpeed[level];
        }
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    private void Start()
    {
        enemyAlive = curEnemyAmount;
        EnemyGenerate();
    }

    public static void EnemyDie()
    {
        GameManager.AddScore(1);
        instance.enemyDie.Play();
        if (GameManager.score % 3 == 0)
        {
            level++;
        }
        enemyAlive--;
        if (enemyAlive <= 0)
        {
            enemyAlive = curEnemyAmount;
            EnemyGenerate();
        }
    }
    private static void EnemyGenerate()
    {
        for (int i = 0; i < curEnemyAmount; i++)
        {
            GameObject enemy = Instantiate(
                instance.enemyPool[RandomManager.RandomRange(instance.enemyPool.Count)],
                MapManager.RandomPosition(),
                Quaternion.identity,
                GameObject.Find("Enemies").transform
                );
            enemy.GetComponent<EnemyMovement>().speed = curEnemySpeed;
            enemy.GetComponent<EnemyHealth>().maxHealth = curEnemyHealth;
            enemy.GetComponent<EnemyHit>().damage = 1;
            enemy.GetComponent<EnemyShoot>().shootInterval = curEnemyShootInterval;
        }
    }
}
