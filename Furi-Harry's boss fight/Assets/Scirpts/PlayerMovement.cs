using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField]
    private float speed = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       rb.MovePosition(transform.position+movement*speed*Time.deltaTime);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
