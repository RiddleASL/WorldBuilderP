using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerCam : MonoBehaviour
{

    Transform player;
    public float lerpT = .8f;

    public float sensitivity;
    public float rangeUp = 40;
    public float rangeDown = 40;

    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Cam Pos
        Vector3 lerp = Vector3.Lerp(transform.position, player.position, lerpT);
        transform.position = lerp;

        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -rangeDown, rangeUp);

        transform.eulerAngles = new Vector3(rotY,rotX,0);
    }
}
