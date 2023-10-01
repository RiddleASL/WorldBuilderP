using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{

    playerUI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("Player").GetComponent<playerUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        ui.currCarrots++;
        Destroy(this.gameObject);
    }
}
