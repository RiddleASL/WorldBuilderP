using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    [HideInInspector] public CharacterController con;

    [HideInInspector] public Vector3 movement;
    public float speed;
    public GameObject GFX;
    public float rotSpeed;
    
    public Transform groundCheck;
    public float checkR = .2f;
    bool isGrounded;
    public LayerMask ground;

    public float gravity = 9.8f;
    public float gravMod = 1;
    float yVel;
    public float jumpForce = 5f;
    
    
    [HideInInspector] public bool canTele;

    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
        canTele = true;
    }

    // Update is called once per frame
    void Update()
    {
        //groundCheck
        if(Physics.CheckSphere(groundCheck.position,checkR, ground) && yVel <= 0){
            isGrounded = true;
            yVel = 0;
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

        //GFX
        Vector3 gfx = new Vector3(movement.x, 0, movement.z);
        if(gfx != Vector3.zero){
            Quaternion toRot = Quaternion.LookRotation(gfx.normalized);
            GFX.transform.rotation = Quaternion.RotateTowards(GFX.transform.rotation, toRot, rotSpeed);
        }
    }
}
