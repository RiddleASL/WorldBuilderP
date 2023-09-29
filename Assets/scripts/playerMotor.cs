using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    CharacterController con;

    Vector3 movement;
    public float speed;
    
    public Transform groundCheck;
    public float checkR = .2f;
    bool isGrounded;
    public LayerMask ground;

    public float gravity = 9.8f;
    public float gravMod = 1;
    float yVel;
    public float jumpForce = 5f;
    


    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //groundCheck
        if(Physics.CheckSphere(groundCheck.position,checkR, ground) && yVel <= 0){
            isGrounded = true;
        } else{
            isGrounded = false;
        }

        //Movement
        float hori = Input.GetAxis("Horizontal") * speed;
        float vert = Input.GetAxis("Vertical") * speed;

        movement = Vector3.ClampMagnitude(new Vector3(hori, 0 ,vert), speed);
        movement.y = yVel;
        movement = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0) * movement;
        con.Move(movement * Time.deltaTime);

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isGrounded = false;
            yVel = jumpForce;
        }

        if(!isGrounded){
            yVel -= gravity * gravMod * Time.deltaTime;
        }
    }
}
