using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(90,cam.eulerAngles.y,0);
    }
}
