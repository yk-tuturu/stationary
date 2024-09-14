using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    public float multiplier;
    public Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        Vector3 maxScale = originalScale * multiplier;
        LeanTween.scale(gameObject, maxScale, 0.1f);
    }

    public void OnMouseExit()
    {
        LeanTween.scale(gameObject, originalScale, 0.1f);
    }
}
