using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphabetPicker : MonoBehaviour
{
    public Text pointText;
    private int totalPoint = 0;
    void Start()
    {
        UpdateAlphabetText();
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("alpha")){
            totalPoint++;
            Destroy(hit.gameObject);
        } else if(hit.CompareTag("wrongAlpha")){
            totalPoint--;
            Destroy(hit.gameObject);
        } 
        
        UpdateAlphabetText();
    }
    private void UpdateAlphabetText()
    {
        string pointMessage = "0";
        
        pointMessage = "" + totalPoint;
    
        pointText.text = pointMessage;
    }
}
