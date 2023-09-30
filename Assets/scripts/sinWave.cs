using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinWave : MonoBehaviour
{

    float a;
    public Material mat;
    public float waveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a += .2f;
        transform.position += Vector3.up * (Mathf.Sin(Mathf.Deg2Rad * a)/2500);

        mat.mainTextureOffset += new Vector2(waveSpeed * Time.deltaTime, 0);
    }
}
