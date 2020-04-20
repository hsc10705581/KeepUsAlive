using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileMovementType
{
    DirectMove
}

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public ProjectileMovementType type;
    public bool isReverse;
    public Vector3 currentDir;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(
            (isReverse ? -currentDir : currentDir) * speed * Time.deltaTime, 
            Space.World
            );
        switch (type)
        {
            case ProjectileMovementType.DirectMove:
                //currentDir = new Vector3(1, 0);
                break;
        }
    }
}
