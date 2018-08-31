using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public UIManager UI;
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    AudioCalculator audioCalculator;
    public bool isGrounded;
    //public bool winPanel;
    //public bool losePanel;

    void Start()
    {
        //float startDistance = Vector3.Distance(player.transform.(0,0.5f,0), win.transform.(1.928f,11.44f));
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        //winPanel = false;
        //losePanel = false;
    }

    void Update()
    {
        
        //float currentDistance = Vector3.Distance(player.transform.position, win.transform.position);

        //float percentage = (currentDistance / winDistance) * 100f;
        //Vector3 vel = rb.velocity;
        //vel.x = speed;
        //rb.velocity = vel;
        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.4f))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
            Quaternion rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 180) * 180;
            transform.rotation = rot;
            
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
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
            UI.Lose();
            Destroy(gameObject);
           
        }

        if (other.gameObject.tag == "Finish")
        {
            UI.Win();
            //LevelComplete & WinPanel shows up
        }
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    bool boosted = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Booster")
        {
            //Debug.Log("isTrigger");
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && boosted == false)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * jumpForce * 1);
                boosted = true;
            }
        }
        else
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Booster")
        {
            boosted = false;
        }
    }
}
