using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainmenucontroller : MonoBehaviour
{




    

    public GameObject exitgames;//exitgame button
    public GameObject help;//help button
    public GameObject goback;// return to level 1 of main menu
    public GameObject goback2;// return to help selection
    public GameObject startbaseball;//startsbaseball
    public GameObject startbasketball;//startsbasketball
    public GameObject startminigolf;//startsminigolf
    public GameObject showbasketballhelp;//shows basketball help
    public GameObject showbaseballhelp;//shows baseball help
    public GameObject showminigolfhelp;//shows minigolf help
    public GameObject minigolfhelp;// minigolf controls
    public GameObject basketballhelp;// basketball controls
    public GameObject baseballhelp;//baseball controls
    GameObject[] buttons;
    bool exitbool;
    bool helpbool;
    bool gobackbool;
    bool goback2bool;
    bool startbaseballbool;
    bool startbasketballbool;
    bool startminigolfbool;
    bool showbasketballbool;
    bool showbaseballbool;
    bool showminigolfbool;
    bool minigolfhelpbool;
    bool basketballhelpbool;
    bool baseballhelpbool;
    bool[] bools;
    private SteamVR_TrackedObject trackedObj;
    // 1
   

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        buttons = new GameObject[13];
        buttons[0] = help;
        buttons[1] = exitgames;
        buttons[2] = baseballhelp;
        buttons[3] = basketballhelp;
        buttons[4] = minigolfhelp;
        buttons[5] = showbaseballhelp;
        buttons[6] = showbasketballhelp;
        buttons[7] = showminigolfhelp;
        buttons[8] = startbaseball;
        buttons[9] = startbasketball;
        buttons[10] = startminigolf;
        buttons[11] = goback;
        buttons[12] = goback2;
        for(int i =0; i< buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        help.SetActive(true);
        exitgames.SetActive(true);
        startbaseball.SetActive(true);
        startbasketball.SetActive(true);
        startminigolf.SetActive(true);
        bools = new bool[13];
        bools[0] = helpbool;
        bools[1] = exitbool;
        bools[2] = baseballhelpbool;
        bools[3] = basketballhelpbool;
        bools[4] = minigolfhelpbool;
        bools[5] = showbaseballbool;
        bools[6] = showbasketballbool;
        bools[7] = showminigolfbool;
        bools[8] = startbaseballbool;
        bools[9] = startbasketballbool;
        bools[10] = startminigolfbool;
        bools[11] = gobackbool;
        bools[12] = goback2bool;
        for(int i =0; i < bools.Length; i++)
        {
            bools[i] = false;
        }
        trackedObj = GetComponent<SteamVR_TrackedObject>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
        for(int i=0; i < buttons.Length; i++)
        {
            if(other.gameObject == buttons[i])
            {
                bools[i] = true;
                buttons[i].GetComponent<Renderer>().material.color = Color.blue;
            }
        }
       

    }

    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (other.gameObject == buttons[i])
            {
                bools[i] = false;
                buttons[i].GetComponent<Renderer>().material.color = Color.white;
            }




        }
    }
    void resetbuttoncolor()
    {
        for(int i =0; i< buttons.Length; i++)
        {
            buttons[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }
     void loadbasketball()
    {

        SceneManager.LoadScene("Basketball");
    }
         void loadbaseball()
        {
            SceneManager.LoadScene("Baseball");
        }
        void loadminigolf()
        {
            SceneManager.LoadScene("workinggolf");
        }
        void loadhelp()
        {
            for(int i =0; i<buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            goback.SetActive(true);
            showbaseballhelp.SetActive(true);
            showbasketballhelp.SetActive(true);
            showminigolfhelp.SetActive(true);

        }
        void loadgoback()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            help.SetActive(true);
            startbaseball.SetActive(true);
            startbasketball.SetActive(true);
            startminigolf.SetActive(true);
            exitgames.SetActive(true);
        }
        void loadgoback2()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            goback.SetActive(true);
            showminigolfhelp.SetActive(true);
            showbasketballhelp.SetActive(true);
            showbaseballhelp.SetActive(true);
        }
        void loadbaseballhelp()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            goback2.SetActive(true);
            baseballhelp.SetActive(true);
        }
        void loadbasketballhelp()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            goback2.SetActive(true);
            basketballhelp.SetActive(true);
        }
        void loadminigolfhelp()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                bools[i] = false;
            }
            goback2.SetActive(true);
            minigolfhelp.SetActive(true);
        }
            
        
        /**
        buttons[0] = help;
        buttons[1] = exitgames;
        buttons[2] = baseballhelp;
        buttons[3] = basketballhelp;
        buttons[4] = minigolfhelp;
        buttons[5] = showbaseballhelp;
        buttons[6] = showbasketballhelp;
        buttons[7] = showminigolfhelp;
        buttons[8] = startbaseball;
        buttons[9] = startbasketball;
        buttons[10] = startminigolf;
        buttons[11] = goback;
        buttons[12] = goback2;
        **/
        void loadexit()
    {
            Application.Quit();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Controller.GetHairTriggerDown() )
        {
            resetbuttoncolor();
        }
        if (Controller.GetHairTriggerDown() && bools[0] == true)
            {
                bools[0] = false;
                
                loadhelp();
            }
            else if (Controller.GetHairTriggerDown() && bools[1] == true)
            {
                bools[1] = false;

                loadexit();
            }
            else if (Controller.GetHairTriggerDown() && bools[2] == true)
            {
                bools[2] = false;
                
            }
            else if (Controller.GetHairTriggerDown() && bools[3] == true)
            {
                bools[3] = false;
            }
            else if (Controller.GetHairTriggerDown() && bools[4] == true)
            {
                bools[4] = false;
            }
            else if (Controller.GetHairTriggerDown() && bools[5] == true)
            {
                bools[5] = false;
                loadbaseballhelp();
            }
            else if (Controller.GetHairTriggerDown() && bools[6] == true)
            {
                bools[6] = false;
                loadbasketballhelp();
            }
            else if (Controller.GetHairTriggerDown() && bools[7] == true)
            {
                bools[7] = false;
                loadminigolfhelp();
            }
            else if (Controller.GetHairTriggerDown() && bools[8] == true)
            {
                bools[8] = false;
                loadbaseball();
            }
            else if (Controller.GetHairTriggerDown() && bools[9] == true)
            {
                bools[9] = false;
                loadbasketball();
            }
            else if (Controller.GetHairTriggerDown() && bools[10] == true)
            {
                bools[10] = false;
                loadminigolf();
            }
            else if (Controller.GetHairTriggerDown() && bools[11] == true)
            {
                bools[11] = false;
                loadgoback();
            }
            else if (Controller.GetHairTriggerDown() && bools[12] == true)
            {
                bools[12] = false;
                loadgoback2();
            }





        }
}
