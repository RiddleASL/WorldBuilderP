using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class rabbitAnimations : MonoBehaviour
{

    Animator anim;
    playerMotor script;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(script.movement.x, 0, script.movement.z);
        if(move != Vector3.zero){
            anim.SetBool("isWalking", true);
        } else{
            anim.SetBool("isWalking", false);
        }
    }
}
