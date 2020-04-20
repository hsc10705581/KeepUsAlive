using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementDir
{
    Up, Down, Left, Right, Stop
}

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static PlayerMovementDir curDir = PlayerMovementDir.Stop;
    public static Vector3 curPos { 
        get
        {
            return instance.transform.position;
        }
    }

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
        SisterStop();
    }

    private void Movement()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        bool isBack = false, isFront = false, isLeft = false, isRight = false;

        // 角色移动
        rb.velocity = new Vector2(hMove, vMove) * speed * Time.deltaTime;

        if (rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            if (rb.velocity.x > 0)
                isRight = true;
            else
                isLeft = true;
        }
        else if (rb.velocity.x == 0 && rb.velocity.y != 0)
        {
            if (rb.velocity.y > 0)
                isBack = true;
            else
                isFront = true;
        }
        else if (rb.velocity.x != 0 && rb.velocity.y != 0)
        {
            float x = Mathf.Abs(rb.velocity.x), y = Mathf.Abs(rb.velocity.y);
            if (x >= y)
            {
                if (rb.velocity.x > 0)
                    isRight = true;
                else
                    isLeft = true;
            }
            else if (x < y)
            {
                if (rb.velocity.y > 0)
                    isBack = true;
                else
                    isFront = true;
            }
        }
        anim.SetBool("IsBack", isBack);
        anim.SetBool("IsFront", isFront);
        anim.SetBool("IsLeft", isLeft);
        anim.SetBool("IsRight", isRight);

        if (Mathf.Abs(hMove) > Mathf.Abs(vMove))
        {
            curDir = hMove > 0 ? PlayerMovementDir.Right : PlayerMovementDir.Left;
        }
        else if ((Mathf.Abs(hMove) < Mathf.Abs(vMove)))
        {
            curDir = vMove > 0 ? PlayerMovementDir.Up : PlayerMovementDir.Down;
        }
        else
        {
            curDir = PlayerMovementDir.Stop;
        }
    }

    private void SisterStop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SisterMovement.isStop = !SisterMovement.isStop;
        }
    }
}
