using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpVelocity;
    public Vector2 velocity;
    public float gravity;
    public LayerMask floormask;
    public new Rigidbody2D rigidbody2D;

    private bool walk, walk_left, walk_right, jump;

    public enum PlayerState
    {
        jumping,
        idle,  
        walking
    }

    private PlayerState playerState = PlayerState.idle;
    private bool grounded = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Fall();
        anim = GetComponent<Animator>();
        anim.SetBool("Ground", true);
        anim.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();
        UpdatePlayerPosition();
        BorderUpdate();
        //UpdateAnimationStates();
    }

    

    void BorderUpdate()
    {
        if (transform.localPosition.x < -9)
        {
            
            transform.localPosition = new Vector3(-9, transform.localPosition.y, transform.localPosition.z);

        }

        if (transform.localPosition.x > 28.51)
        {
          
            transform.localPosition = new Vector3((float)28.51, transform.localPosition.y, transform.localPosition.z);

        }

        if (transform.localPosition.y < 1.4584)
        {

            //transform.localPosition = new Vector3(transform.localPosition.x, (float)1.4584, transform.localPosition.z);
            playerState = PlayerState.idle;
            grounded = true;

            if (velocity.y <= 0)
            {
            velocity.y = 0;
            }

            
            



        }

        
    }

    void UpdateAnimationStates()
    {
        if (grounded && !walk)
        {
            anim.SetBool("Ground", true);
            anim.SetBool("isRunning", false);
        }

        if (grounded && walk)
        {
            anim.SetBool("Ground", true);
            anim.SetBool("isRunning", true);
        }

        if (playerState == PlayerState.jumping)
        {
            anim.SetBool("Ground", false);
            anim.SetBool("isRunning", false);
        }
    }


    void UpdatePlayerPosition()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        if (walk)
        {
            if (walk_left)
            {
                pos.x -= velocity.x * Time.deltaTime;
                scale.x = (float)-0.233553;

                anim.SetBool("Ground", true);
                anim.SetBool("isRunning", true);
            }

            if (walk_right)
            {
                pos.x += velocity.x * Time.deltaTime;
                scale.x = (float)0.233553;

                anim.SetBool("Ground", true);
                anim.SetBool("isRunning", true);
            }

            


        } else
        {
            anim.SetBool("Ground", true);
            anim.SetBool("isRunning", false);
        }

        if (jump && playerState != PlayerState.jumping)
        {
            playerState = PlayerState.jumping;
            velocity = new Vector2(velocity.x, jumpVelocity);
            
            anim.SetBool("Ground", false);
            anim.SetBool("isRunning", false);

        }

        if(playerState == PlayerState.jumping)
        {
            //rigidbody2D.AddForce(velocity);
            pos.y += velocity.y * Time.deltaTime;
            velocity.y -= gravity * Time.deltaTime;

            //rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocity.y));

            anim.SetBool("Ground", false);
            anim.SetBool("isRunning", false);

        }      

        transform.localPosition = pos;
        transform.localScale = scale;
    }

    

    void CheckPlayerInput()
    {
        bool input_left = Input.GetKey(KeyCode.A);
        bool input_right = Input.GetKey(KeyCode.D);
        bool input_space = Input.GetKey(KeyCode.Space);

        walk = input_left || input_right;

        walk_left = input_left && !input_right;
        walk_right = !input_left && input_right;

        jump = input_space;
    }

    void Fall()
    {
        velocity.y = (float)1.4584;
        playerState = PlayerState.jumping;

        grounded = false;
    }



    

    
}
