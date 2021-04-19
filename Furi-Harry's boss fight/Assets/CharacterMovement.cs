using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    Vector3 movement;
    int isWalkingHash;
    int isRunningHash;
    int isShootingHash;
    float speed = 5.0f;
    public Vector3 forward;

    private void Start()
    {
       
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isShootingHash = Animator.StringToHash("isShooting");
        

        Debug.Log(animator);
    }

    private void Update()
    {
        Move();
        FaceForward();
    }
    private void FaceForward()
    {
        if (transform.forward!=movement&& movement !=Vector3.zero)
        {
            forward = movement;
            transform.forward = movement;
            
        }

    }

    public Vector3 getForward()
    {
        return forward;
    }
    private void Move()
    {
        //bool isWalking = animator.GetBool("isWalking");
        //bool isRunning = animator.GetBool("isRunning");

        //bool forwardPressed = Input.GetKey(KeyCode.W);
        //bool RunningPressed = Input.GetKey(KeyCode.LeftShift);
        //bool RunningRightPressed = Input.GetKey(KeyCode.D);
        //bool RunningLeftPressed = Input.GetKey(KeyCode.A);
        //bool RunningBackwardsPressed = Input.GetKey(KeyCode.S);
        bool walking=false;
        bool running=false;
        bool shooting=false;
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isShooting",true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
        
        movement = movement.normalized;
        if (movement != Vector3.zero)
        {
            walking = true;
            if (Input.GetKey(KeyCode.LeftShift) )
            {
                running = true;
                
                
            }
            else
            {
                running = false;
            }
        }
        else
        {
            walking = false;
            running = false;
        }

        transform.position = transform.position + movement * Time.deltaTime*speed;

        if (walking)
        {
            animator.SetBool(isWalkingHash, true);

            if (running)
            {
                
                animator.SetBool(isRunningHash, true);
                speed = 10.0f;
            }
            else
            {
                animator.SetBool(isRunningHash, false);
                
                speed = 5.0f;
            }
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
      
        
    }    

}