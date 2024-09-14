using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject bHeart1;
    [SerializeField] private GameObject bHeart2;
    [SerializeField] private GameObject bHeart3;

    // Update is called once per frame
    void Update()
    {
        //when health changes
        if (GameManager.instance.health == 2)
        {
            heart1.SetActive(false);
            bHeart1.SetActive(true);
        } else if (GameManager.instance.health == 1)
        {
            heart2.SetActive(false);
            bHeart2.SetActive(true);
        } else if (GameManager.instance.health == 0)
        {
            heart3.SetActive(false);
            bHeart3.SetActive(true);
        }
    }
}
