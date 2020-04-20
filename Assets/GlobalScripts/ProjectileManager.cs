using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;
    
    private static float interval = 0.2f;
    private static float nextTime = 0.0f;

    public List<ProjectileGenerator> generatorList;
    public List<GameObject> directProjectileList;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
        nextTime = Time.fixedTime;
    }

    private void Update()
    {
        //Generate();
    }

    private void Generate()
    {
        float curTime = Time.fixedTime;
        if (curTime > nextTime)
        {
            //if (PlayerMovement.curDir != PlayerMovementDir.Stop)
            //{
            //    generatorList[(int)PlayerMovement.curDir].GenerateAProjectile();
            //}
            nextTime = curTime + RandomManager.RandomIntervalTime(interval, 2 * interval);
        }
    }

    public static GameObject RandomProjectile(string kind)
    {
        // TODO
        // Add more kinds of projectiles
        return instance.directProjectileList[
            RandomManager.RandomRange(instance.directProjectileList.Count)
            ];
    }

    public static Vector3 Direction2Vector(ProjectileDirection direction)
    {
        switch (direction)
        {
            case ProjectileDirection.Up:
                return new Vector3(0.0f, 1.0f, 0.0f);
            case ProjectileDirection.Down:
                return new Vector3(0.0f, -1.0f, 0.0f);
            case ProjectileDirection.Left:
                return new Vector3(-1.0f, 0.0f, 0.0f);
            case ProjectileDirection.Right:
                return new Vector3(1.0f, 0.0f, 0.0f);
            default:
                return Vector3.zero;
        }
    }
}
