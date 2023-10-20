using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
     public int CollectibleCounter = 0;
     public Text CollectibleText;


    // Update is called once per frame
    void Update()
    {
        CollectibleText.text = CollectibleCounter.ToString();

    }
}
