using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpLink : MonoBehaviour
{
    public GameObject endPos;
    GameObject player;
    playerMotor script;
    playerCam cam;

    public Transform boomarm;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<playerMotor>();
        cam = boomarm.GetComponent<playerCam>();
    }

    // Update is called once per frame
    void Update()
    {
        script.con.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(script.canTele){
            script.canTele = false;
            script.con.enabled = false;
            player.transform.position = endPos.transform.position;
            cam.rotX = endPos.transform.eulerAngles.y;
            script.GFX.transform.eulerAngles = new Vector3(script.GFX.transform.eulerAngles.x, endPos.transform.eulerAngles.y, script.GFX.transform.eulerAngles.z);
        }
    }

    void OnTriggerExit(Collider other)
    {
        script.canTele = true;
    }
}
