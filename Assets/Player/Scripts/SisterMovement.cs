using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterMovement : MonoBehaviour
{
    public static SisterMovement instance;
    public static Vector3 curPos
    {
        get
        {
            return instance.transform.position;
        }
    }
    public static bool isStop = false;

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 towardsPostion
    {
        get
        {
            return PlayerMovement.curPos;
        }
    }
    private bool canMove = true;

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
    }

    private void Movement()
    {
        bool isBack = false, isFront = false, isLeft = false, isRight = false;
        if (isStop || !canMove)
        {
            rb.velocity = Vector2.zero;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (new Vector3(mousePos.x, mousePos.y) - transform.position).normalized;
            
            anim.SetBool("IsBack", isBack);
            anim.SetBool("IsFront", isFront);
            anim.SetBool("IsLeft", isLeft);
            anim.SetBool("IsRight", isRight);
            return;
        }
        Vector3 dir = (towardsPostion - transform.position).normalized;

        // 角色移动
        rb.velocity = new Vector2(dir.x, dir.y) * speed * Time.deltaTime;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = true;
        }
    }
}
