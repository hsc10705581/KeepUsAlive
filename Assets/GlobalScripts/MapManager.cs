using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    private static Collider2D region;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
        region = GetComponent<Collider2D>();
    }

    public static Vector3 RandomPosition()
    {
        return RandomManager.RandomPositionInCollider(region);
    }
}
