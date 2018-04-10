using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballSounds : MonoBehaviour {




    public GameObject baseball;
    public GameObject batholder1;
    public GameObject batholder2;
    public GameObject ground;
    public GameObject skeleton;
    GameObject scoreboard;
    public GameObject OB;
    baseballscoreboard bsb;
    public AudioClip hitbat;
    public AudioClip homerun;
    //public AudioClip backgroundsounds;
    public AudioClip foulball;
    public AudioClip normalhit;
   
    
    void Awake()
    {
        scoreboard = GameObject.Find("ScoreBoard");
        bsb = scoreboard.GetComponent<baseballscoreboard>();

    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == batholder1 || other.gameObject == batholder2)
        {
            AudioSource.PlayClipAtPoint(hitbat, GameObject.Find("CameraRig").transform.position);
        }
    }
     
    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject == ground && bsb.distancetraveled>=160)
        {
            
            AudioSource.PlayClipAtPoint(homerun, skeleton.transform.position);
        }
        else if(other.gameObject == OB)
        {
          
            AudioSource.PlayClipAtPoint(foulball, skeleton.transform.position);
        }
        
    }

   

}
