using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    AudioCalculator audioCalculator;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        //Vector3 vel = rb.velocity;
        //vel.x = speed;
        //rb.velocity = vel;
        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.4f))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
            Quaternion rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 180) * 180;
            transform.rotation = rot;
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;            
            }
           
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Debug.Log("Down Active");
            }
  
        }
        else
        {
            transform.Rotate(Vector3.back * 5f); 
        }

        /*PlayerController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(1, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);*/

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Finish")
        {
            //LevelComplete & WinPanel shows up
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Booster")
        {
            //Debug.Log("isTrigger");
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * jumpForce * 1);
            }
        }
        isGrounded = true;
    }
}
