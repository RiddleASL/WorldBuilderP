using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerUI : MonoBehaviour
{
    public TextMeshProUGUI carrotText;

    [SerializeField] int maxCarrots;
    [HideInInspector] public int currCarrots = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carrotText.text = currCarrots + " / " + maxCarrots;
    }
}
