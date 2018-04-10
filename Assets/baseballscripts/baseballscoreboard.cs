using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class baseballscoreboard : MonoBehaviour {
    int homerun;
    int grandslam;
    int single;
    int foul;
    int doubler;
    int triple;
    public GameObject bball;
    ballcontact bc;
    bool resetcount;
    public GameObject skeleton;
    public Text d1;
    public Text d2;
    public Text d3;
    public Text d4;
    public Text d5;
    public Text d6;
    public Text d7;
    public Text d8;
    public Text d9;
    public Text d10;
    public Text d11;
    public Text hrtext;
    public Text gstext;
    public Text singletext;
    public Text doublertext;
    public Text tripletext;
    public Text foultext;
    Text[] texts;
    int i = 0;
    public int distancetraveled;
    Vector3 startspot;
    skeletonthrow st;

    public void updatescoreboard()
    {
        if (i == 11)
        {
            i = 0;
        }
        if (i == 0)
        {
            homerun = 0;
            single = 0;
            doubler = 0;
            triple = 0;
            grandslam = 0;
            foul = 0;
            foultext.text = foul.ToString();
            singletext.text = single.ToString();
            doublertext.text = doubler.ToString();
            tripletext.text = triple.ToString();
            hrtext.text = homerun.ToString();
            gstext.text = grandslam.ToString();
            for (i = 0; i < 11; i++)
                {
                    texts[i].text = "0";

                }
                i = 0;
        }
        if(distancetraveled== -1)
        {
            foul++;
            foultext.text = foul.ToString();
        }
        else if (distancetraveled < 20 && distancetraveled>=0)
        {
            single++;
            singletext.text = single.ToString();
        }
        else if(distancetraveled>20 && distancetraveled <= 60)
        {
            doubler++;
            doublertext.text = doubler.ToString();
        }
        else if (distancetraveled > 60 && distancetraveled <= 150)
        {
            triple++;
            tripletext.text = triple.ToString();
        }
        else if (distancetraveled > 150 && distancetraveled <= 220)
        {
            homerun++;
            hrtext.text = homerun.ToString();
        }
        else if (distancetraveled > 220)
        {
            grandslam++;
            gstext.text = grandslam.ToString();
        }


        texts[i].text = distancetraveled.ToString();
        
            i++;
        
    }
     void Awake()
    {
        bc = bball.GetComponent<ballcontact>();
        texts = new Text[11];
        st = skeleton.GetComponent<skeletonthrow>();
        
        texts[0] = d1;
        texts[1] = d2;
        texts[2] = d3;
        texts[3] = d4;
        texts[4] = d5;
        texts[5] = d6;
        texts[6] = d7;
        texts[7] = d8;
        texts[8] = d9;
        texts[9] = d10;
        texts[10] = d11;
        for (i = 0; i < 11; i++)
        {
            texts[i].text = "0";
        }
        i = 0;

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
