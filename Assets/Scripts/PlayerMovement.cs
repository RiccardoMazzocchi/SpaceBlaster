using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Input Settings")]
    public KeyCode forwardInput = KeyCode.W;
    public KeyCode backwardInput = KeyCode.S;
    public KeyCode leftInput = KeyCode.A;
    public KeyCode rightInput = KeyCode.D;

    public float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate()
    {
        MovementOne();
        ClampMovement();
        //MovementTwo();
    }

    void MovementOne()
    {
        if (Input.GetKey(forwardInput))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(backwardInput))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(leftInput))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(rightInput))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    void MovementTwo()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");
        

        transform.position += new Vector3(moveH * moveSpeed * Time.deltaTime, 0f, moveV * moveSpeed * Time.deltaTime);
        if (Mathf.Abs(moveH) > 0.01f && Mathf.Abs(moveV) > 0.01f)
        {
            transform.position += new Vector3(moveH * moveSpeed * 0.7071f * Time.deltaTime, 0f, moveV * moveSpeed * 0.7071f * Time.deltaTime);
        }
    }

    void ClampMovement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), transform.position.y, Mathf.Clamp(transform.position.z, -0.5f, 5.5f));
    }
}
