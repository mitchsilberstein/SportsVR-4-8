using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatescore : MonoBehaviour {
    public GameObject basketballstartbutton;
    BasketballGame basketballscript;
    private GameObject Supdater;
    // Use this for initialization
    void Awake () {
        basketballscript = basketballstartbutton.GetComponent<BasketballGame>();
        Supdater = GameObject.Find("ScoreUpdater");
         
    }
    
   

    // 1
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "scoreupdater" && basketballscript.countdown>=10 && basketballscript.startcd == true)
            
        {
            print("+2");
            basketballscript.score += 2;
            if (basketballscript.highscore < basketballscript.score)
            {
                basketballscript.highscore += basketballscript.score - basketballscript.highscore;
                
            }
        }
        else if( other.tag == "scoreupdater" && basketballscript.startcd == true)
        {
            print("+3");
            basketballscript.score += 3;
            if (basketballscript.highscore < basketballscript.score)
            {
                basketballscript.highscore += basketballscript.score - basketballscript.highscore;

            }
        }
    }

}
