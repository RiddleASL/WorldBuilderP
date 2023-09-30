using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public List<GameObject> audioClips;
    int rndChoice;

    // Start is called before the first frame update
    void Start()
    {
        rndChoice = Random.Range(0,audioClips.Count - 1);

        for (int i = 0; i < audioClips.Count; i++)
        {
            if(i == rndChoice){
                audioClips[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, .5f);
    }
}
