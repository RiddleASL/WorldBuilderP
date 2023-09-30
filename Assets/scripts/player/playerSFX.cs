using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSFX : MonoBehaviour
{
    public LayerMask groundLayer;

    public GameObject footStepSFX;
    public Transform leftFoot;
    public Transform rightFoot;
    public Transform leftPaw;
    public Transform rightPaw;

    bool front = true;
    bool back = true;

    public float checkR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Feet
        if(Physics.CheckSphere(leftFoot.position, checkR, groundLayer) || Physics.CheckSphere(rightFoot.position, checkR, groundLayer)){
            if(!front){
                Instantiate(footStepSFX, leftFoot.position, leftFoot.rotation);
                front = true;
            }
        } else{
            front = false;
        }

        // Paws
        if(Physics.CheckSphere(leftPaw.position, checkR, groundLayer) || Physics.CheckSphere(rightPaw.position, checkR, groundLayer)){
            if(!back){
                Instantiate(footStepSFX, leftPaw.position, leftPaw.rotation);
                back = true;
            }
        } else{
            back = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(leftFoot.position, checkR);
        Gizmos.DrawWireSphere(rightFoot.position, checkR);  
        Gizmos.DrawWireSphere(leftPaw.position, checkR);
        Gizmos.DrawWireSphere(rightPaw.position, checkR);    
    }
}
