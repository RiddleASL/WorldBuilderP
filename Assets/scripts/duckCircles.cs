using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckCircles : MonoBehaviour
{
    float a;
    public float size = 1f;
    public float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a += speed;
        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * a), 0, -Mathf.Cos(Mathf.Deg2Rad * a))/(size*10);

        transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Sin(Mathf.Deg2Rad * a), 0, -Mathf.Cos(Mathf.Deg2Rad * a))/(size*10) - transform.position);
    }
}
