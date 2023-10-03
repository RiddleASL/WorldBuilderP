using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerCam : MonoBehaviour
{

    Transform player;
    public Transform defaultPos;
    public float boomLen = 5f;
    public LayerMask groundLayer;

    Vector3 target; 

    public float lerpT = .8f;

    public float sensitivity;
    public float rangeUp = 40;
    public float rangeDown = 40;

    [HideInInspector] public float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = defaultPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -rangeDown, rangeUp);

        transform.eulerAngles = new Vector3(rotY,rotX,0);

        RaycastHit hit;
        Debug.DrawRay(transform.position, Camera.main.transform.position - transform.position);
        Vector3 dir = defaultPos.position - transform.position;
        if(Physics.Raycast(transform.position, dir, out hit, boomLen, groundLayer)){
            target = hit.point - (dir.normalized/1.5f);
            Debug.Log(1);
        } else{
            target = defaultPos.position;
            Debug.Log(2);
        }

    }

    void LateUpdate(){
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, lerpT);

        //Cam Pos
        Vector3 lerp = Vector3.Lerp(transform.position, player.position, lerpT);
        transform.position = lerp;
    }
}
