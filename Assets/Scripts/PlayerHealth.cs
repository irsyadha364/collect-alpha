using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D col) {
    
        if(col.gameObject.tag == "bottomBound"){
            SceneManager.LoadScene("GameOver");
        }
    }
}
