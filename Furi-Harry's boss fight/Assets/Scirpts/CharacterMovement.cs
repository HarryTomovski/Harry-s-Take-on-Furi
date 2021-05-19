using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    Vector3 movement;
    int isWalkingHash;
    int isRunningHash;
    int isDeadHash;

    private float speed = 5f;
   private float turnSpeed = 10.0f;
   
    public Vector3 forward;

    //Dash
    [SerializeField]
    private GameObject dashEffect;
    private float dashSpeed = 40.0f;
    private bool isDashing = false;

    private void Start()
    {
       
        StartCoroutine(Dash());

        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isDeadHash = Animator.StringToHash("isDead");
        

        Debug.Log(animator);
    }

    private void Update()
    {
        
        Move();
        Debug.Log(speed);
        FaceForward();
       
    }
    private void FaceForward()
    {
        if (transform.forward != movement && movement != Vector3.zero)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);

        }

    }

    IEnumerator Dash()
    {
        var wait = new WaitForSeconds(0.10f);
        var dashCooldown = new WaitForSeconds(0.25f);
        while (true)
        {
            Debug.Log("It is in the dash");
            if (Input.GetKey(KeyCode.Space))
            {
                isDashing = true;
                speed = dashSpeed;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                Debug.Log(speed);
                
                yield return wait;
                speed = 5.0f;
                isDashing = false;
                Debug.Log(speed);
                yield return dashCooldown;
            }
            else
            {
                Debug.Log("In the else statement coroutine");
                yield return null;
            }
            
        }
      
    }

  
    private void Move()
    {
       
        bool walking=false;
        bool running=false;
        
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

       
        
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

            if (running && !isDashing)
            {
                
                animator.SetBool(isRunningHash, true);
                speed = 10.0f;
            }
            else if (running && isDashing)
            {
                animator.SetBool(isRunningHash, true);
            }
            else if (!running && !isDashing)
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