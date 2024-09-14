using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{
    public CanvasGroup startMenu;
    public CanvasGroup levelMenu;
    // Start is called before the first frame update
    void Start()
    {
        levelMenu.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLevelMenu() {
        LeanTween.scale(startMenu.gameObject, new Vector3(0, 0, 0), 0.2f);
        LeanTween.scale(levelMenu.gameObject, new Vector3(1, 1, 1), 0.2f);
        
    }
    public void changeStartMenu() {
        GameObject[] buttonList = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject button in buttonList) {
            button.GetComponent<buttonScript>().closePanel();
        }

        LeanTween.scale(levelMenu.gameObject, new Vector3(0, 0, 0), 0.2f);
        LeanTween.scale(startMenu.gameObject, new Vector3(1, 1, 1), 0.2f);
    
    }
    
}
