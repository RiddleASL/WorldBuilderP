using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class closestArrow : MonoBehaviour
{
    public float rotSpeed = 1f;
    public GameObject carrotsObj;
    public List<Transform> listCarrots;

    Transform player;
    float currDist = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        listCarrots.Clear();
        Vector3 closestCarrot = new Vector3();
        

        for(int i=0; i < carrotsObj.transform.childCount; i++){
            listCarrots.Add(carrotsObj.transform.GetChild(i));
        }

        if(listCarrots.Count == 0){
            transform.GetChild(0).gameObject.SetActive(false);
        } else{
            transform.GetChild(0).gameObject.SetActive(true);
            closestCarrot = listCarrots[0].position;
            currDist = Vector3.Distance(player.position, closestCarrot);
        }

        for (int i = 0; i < listCarrots.Count; i++)
        {
            if(listCarrots[i].position != closestCarrot){
                if(Vector3.Distance(player.position, listCarrots[i].position) < currDist){
                    closestCarrot = listCarrots[i].position;
                }
            }
        }

        Quaternion toRot = Quaternion.LookRotation((closestCarrot - player.position).normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, rotSpeed);

        
    }
}
