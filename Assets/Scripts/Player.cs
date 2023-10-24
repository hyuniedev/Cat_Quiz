using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float forceJump = 1600;
    [SerializeField] private float speedMove = 300;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator anim;
    private bool isGround = false;
    private float horizontal;
    private bool isRight = true;
    private int indexIdle = 0;
    private bool change = true;
    private int[] iIdle = { 0, 1, 0, 3, 2, 0, 1, 2, 3, 1, 0, 4 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMove = 420;
                anim.SetFloat("velocityX", 1);
            }
            else
            {
                speedMove = 350;
                anim.SetFloat("velocityX", 0);
            }
        }
        if (rb.velocity.y >= 0.1)
        {
            anim.SetFloat("velocityY", 1);
        }
        else if (rb.velocity.y < -0.1)
        {
            anim.SetFloat("velocityY", -1);
        }
        Jump();
        Open();
        Angry();
    }


    private void FixedUpdate()
    {
        ChangeIdle();
        isGround = CheckGround();
        Move();
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (horizontal * speedMove * Time.fixedDeltaTime, rb.velocity.y);
        if(horizontal > 0)
        {
            isRight = true;
        }
        else if(horizontal < 0)
        {
            isRight = false;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, isRight ? 0 : 180, 0));
        anim.SetFloat("horizontal",Mathf.Abs(horizontal));
    }
    private void Jump()
    {
        if (isGround)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * forceJump);
            }
            anim.SetFloat("vertical", 0);
            anim.SetFloat("velocityY", 0);
        }
        else
        {
            anim.SetFloat("vertical", 1);
        }
    }

    private void Open()
    {
        if(horizontal == 0)
        {
            if (isGround && Input.GetKey(KeyCode.E))
            {
                anim.SetBool("open", true);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                anim.SetBool("open", false);
            }
        }
    }
    private void Angry()
    {
        if (horizontal == 0)
        {
            if (isGround && Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetBool("angry", true);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                anim.SetBool("angry", false);
            }
        }
    }
    private void ChangeIdle()
    {
        if(!Input.anyKey)
        {
            anim.SetFloat("indexIdle", iIdle[indexIdle]);
            if (change)
            {
                change = false;
                if (iIdle[indexIdle] == 0 || iIdle[indexIdle] == 1)
                {
                    Invoke(nameof(incIndex), Time.fixedDeltaTime * 80);
                }
                else
                {
                    Invoke(nameof(incIndex), Time.fixedDeltaTime * 150);
                }
            }
        }
        else
        {
            indexIdle = 0;
            change = true;
        }
    }
    private void incIndex()
    {
        if(iIdle[indexIdle] != 4)
        {
            indexIdle++;
        }
        change = true;
    }
    private bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, layerMask);
        return hit.collider != null;
    }
}