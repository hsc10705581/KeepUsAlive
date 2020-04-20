using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;

    public List<Transform> spawnPositions;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public static Transform GetRandomSpawnPosition()
    {
        return instance.spawnPositions[RandomManager.RandomRange(instance.spawnPositions.Count)];
    }

}
