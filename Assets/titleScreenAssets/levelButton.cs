using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class levelButton : MonoBehaviour
{
    public float multiplier = 1.1f;
    public Vector3 originalScale = new Vector3(1, 1, 1);
    public Vector3 ogPos;
    public bool isMoved; 
    public GameObject panel; 

    // Start is called before the first frame update
    void Start()
    {
        panel.transform.localScale = new Vector3(0, 1, 1);
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
