using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileDirection
{
    Up, Down, Left, Right
}

public class ProjectileGenerator : MonoBehaviour
{
    [Header("Generate Interval")]
    [Tooltip("实际间隔将是interval~2*interval之间的随机值")]
    public float interval = 1.0f;

    public ProjectileDirection direction;

    private float nextTime = 0.0f;
    private Collider2D region;

    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.fixedTime;
        region = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Generate();
    }

    private void Generate()
    {
        float curTime = Time.fixedTime;
        if (curTime > nextTime)
        {
            GenerateAProjectile();
            nextTime = curTime + RandomManager.RandomIntervalTime(interval, 2 * interval);
        }
    }

    public void GenerateAProjectile()
    {
        Vector3 randomPos = 
            transform.position +
            new Vector3(region.offset.x, region.offset.y) + 
            new Vector3(
                RandomManager.RandomRange(-region.bounds.extents.x, region.bounds.extents.x),
                RandomManager.RandomRange(-region.bounds.extents.y, region.bounds.extents.y),
                0.0f);
        GameObject go = Instantiate(
            ProjectileManager.RandomProjectile("normal"),
            randomPos,
            Quaternion.identity,
            transform
            );
        go.GetComponent<ProjectileMovement>().currentDir = 
            ProjectileManager.Direction2Vector(direction);
    }
}
