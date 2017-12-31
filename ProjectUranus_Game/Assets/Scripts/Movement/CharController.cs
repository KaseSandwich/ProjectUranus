using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;

    [SerializeField]
    private float jumpSpeed = 4f;
    
    private Vector3 forward, right;
    private Rigidbody rigidBody;


	// Use this for initialization
	void Start ()
	{
	    forward = Camera.main.transform.forward;
	    forward.y = 0;
	    forward = Vector3.Normalize(forward);
	    right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	    rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.anyKey)
	        Move();
	}

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        if (Input.GetButtonDown("Jump"))
            rigidBody.velocity = Vector3.up * jumpSpeed;
    }
}
