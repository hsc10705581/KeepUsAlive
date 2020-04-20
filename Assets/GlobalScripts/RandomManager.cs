using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public static RandomManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public static int RandomRange(int max)
    {
        return Random.Range(0, max);
    }
    public static int RandomRange(int min, int max)
    {
        return Random.Range(min, max);
    }
    public static float RandomRange(float max)
    {
        return Random.Range(0, max);
    }
    public static float RandomRange(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static float RandomIntervalTime(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static Vector3 RandomPositionInCollider(Collider2D collider)
    {
        return collider.transform.position +
            new Vector3(collider.offset.x, collider.offset.y) +
            new Vector3(
                RandomRange(-collider.bounds.extents.x, collider.bounds.extents.x),
                RandomRange(-collider.bounds.extents.y, collider.bounds.extents.y),
                0.0f);
    }
}
