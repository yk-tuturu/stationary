using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class buttonScript : MonoBehaviour
{
    public float multiplier = 1.1f;
    public Vector3 originalScale = new Vector3(1, 1, 1);
    public Vector3 ogPos;
    public bool isMoved; 
    public GameObject panel; 
    public bool disableHover;
    public RectTransform canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (panel!=null) {
            panel.transform.localScale = new Vector3(0, 1, 1);
        }
        ogPos = transform.position;
        if (gameObject.tag == "LevelButton") {
            canvas = transform.parent.GetComponent<RectTransform>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        if (!disableHover) {
            Vector3 maxScale = originalScale * multiplier;
            LeanTween.scale(gameObject, maxScale, 0.1f);
        }
        
    }

    public void OnMouseExit()
    {
        if (!disableHover) {
            LeanTween.scale(gameObject, originalScale, 0.1f);
        }
        
    }

    public void MoveLeft() {
        GameObject[] buttonList = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject button in buttonList) {
            button.GetComponent<buttonScript>().closePanel();
        }

        float center = canvas.TransformPoint(canvas.rect.center).x;

        LeanTween.moveX(gameObject, center-250f, 0.2f);
        LeanTween.scale(panel, new Vector3(1, 1, 1), 0.2f);
        LeanTween.scale(gameObject, originalScale, 0.1f);
        disableHover = true;
    }

    public void closePanel() {
        float center = canvas.TransformPoint(canvas.rect.center).x;

        LeanTween.moveX(gameObject, center, 0.2f);
        LeanTween.scale(panel, new Vector3(0, 1, 1), 0.2f);
        disableHover = false;
    }

    public void StartGame() {
        SceneManager.LoadScene("game");
    }
}
