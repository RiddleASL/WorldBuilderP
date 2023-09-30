using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tpLink : MonoBehaviour
{
    public GameObject endPos;
    GameObject player;
    playerMotor script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<playerMotor>();
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        script.canTele = true;
    }
}
