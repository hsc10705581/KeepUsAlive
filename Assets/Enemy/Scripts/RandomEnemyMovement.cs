using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyMovement : EnemyMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        towardsPosition = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Movement();
    }

    protected override void Movement()
    {
        //base.Movement();
        if (Vector3.Distance(transform.position, towardsPosition) < 0.1f)
        {
            towardsPosition = MapManager.RandomPosition();
        }
        Vector3 moveTowards = Vector3.MoveTowards(
            transform.position,
            towardsPosition, 
            speed * Time.deltaTime
            );
        rb.MovePosition(moveTowards);
    }
}
