using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class baseballcontroller : MonoBehaviour
{
    bool nextcheck;
    public GameObject scoreboard;
    baseballscoreboard bsb;
    bool batinhand = false;
    public Transform headpos;
    public GameObject batholder;
    float timetilmenushows;
    float timetilgamestart;
    bool gamestarted = false;
    bool startselected = false;
    bool exitselected = false;
    bool startmenutimer;
    public GameObject baseballbat;
    public GameObject begingame;
    public GameObject exit;
    public GameObject skeleton;
    skeletonthrow st;
    public GameObject startbox;
    bool inhand = false;
    bool throwableinhand = false;
    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        st = skeleton.GetComponent<skeletonthrow>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        bsb = scoreboard.GetComponent<baseballscoreboard>();

    }






    // 1
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == begingame)
        {
            begingame.GetComponent<Renderer>().material.color = Color.blue;
            startselected = true;
        }
        if (other.gameObject == exit)
        {
            exit.GetComponent<Renderer>().material.color = Color.cyan;
            exitselected = true;

        }

    }

    // 2


    // 3
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == begingame)
        {
            begingame.GetComponent<Renderer>().material.color = Color.white;
            startselected = false;


        }
        if (other.gameObject == exit)
        {
            exit.GetComponent<Renderer>().material.color = Color.white;
            exitselected = false;
        }
        if (!collidingObject)
        {
            return;
        }


    }


    private void GrabLockedObject()
    {

        baseballbat.SetActive(true);
            baseballbat.transform.position = batholder.transform.position;
            baseballbat.transform.rotation = batholder.transform.rotation;
            objectInHand = baseballbat;
            
            inhand = true;

            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        batinhand = false;
    }



    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 200000;
        fx.breakTorque = 200000;
        return fx;
    }



    //starts the baseball game specifically the pitching animation
    void startgame()
    {
        if (st.count == 0)
        {
            st.throwagain = true;
        }
    }
    private void exitgame()
    {
        SceneManager.LoadScene("Main Menu");
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (st.count == 10)
        {
            nextcheck = true;
        }
            if (bsb.d11.text != "0" && nextcheck==true)
            {
            nextcheck = false;
                startmenutimer = true;
            }
        
        if (startmenutimer == true)
        {
            timetilmenushows += Time.deltaTime;
        }
        if (timetilmenushows >= 3)
        {
           
            timetilmenushows = 0;
            begingame.SetActive(true);
            exit.SetActive(true);
            startmenutimer = false;
            baseballbat.SetActive(false);
        }

        
        // 1
        if (Controller.GetHairTriggerDown() && startselected == true)
        {
            begingame.GetComponent<Renderer>().material.color = Color.white;
            begingame.SetActive(false);
            exit.SetActive(false);
            gamestarted = true;
            startselected = false;
            batinhand = true;
        }
        if (gamestarted == true)
        {
            baseballbat.SetActive(true);
            timetilgamestart += Time.deltaTime;
        }
        if (timetilgamestart >= 3)
        {
            gamestarted = false;
            startgame();
            timetilgamestart = 0;
        }

        else if (Controller.GetHairTriggerDown() && exitselected == true)
        {
            exitselected = false;
            exit.GetComponent<Renderer>().material.color = Color.white;
            exitgame();


        }

        if (batinhand == true)
        {
            GrabLockedObject();
        }





    }
}


/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class baseballcontroller : MonoBehaviour
{
    public Transform headpos;
    public GameObject batholder;
    float timetilmenushows;
    float timetilgamestart;
    bool gamestarted;
    bool startselected = false;
    bool exitselected = false;
    bool startmenutimer;
    public GameObject baseballbat;
    public GameObject begingame;
    public GameObject exit;
    public GameObject skeleton;
    skeletonthrow st;
    public GameObject startbox;
    bool inhand = false;
    bool throwableinhand = false;
    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        st = skeleton.GetComponent<skeletonthrow>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        

    }
   
    


    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == begingame)
        {
            begingame.GetComponent<Renderer>().material.color = Color.blue;
            startselected = true;
        }
        if (other.gameObject == exit)
        {
            exit.GetComponent<Renderer>().material.color = Color.cyan;
            exitselected = true;
            
        }
        else
        {
            SetCollidingObject(other);
        }
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == begingame)
        {
            begingame.GetComponent<Renderer>().material.color = Color.white;
            startselected = false;


        }
        if (other.gameObject == exit)
        {
            exit.GetComponent<Renderer>().material.color = Color.white;
            exitselected = false;
        }
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }


    private void GrabLockedObject()
    {

        if (collidingObject == baseballbat)
        {
           
            collidingObject.transform.position = batholder.transform.position;
            collidingObject.transform.rotation = batholder.transform.rotation;
            objectInHand = collidingObject;
            collidingObject = null;

            inhand = true;
        }


      

        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private void GrabThrowableObject()
    {
        if (collidingObject)
        {
            objectInHand = collidingObject;
            collidingObject = null;
            throwableinhand = true;
        }
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 200000;
        fx.breakTorque = 200000;
        return fx;
    }

    private void ReleaseThrowableObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
    }
    private void ReleaseLockedObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            //objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            //objectInHand.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 1);
            
        }
        // 4
        objectInHand = null;
    }
    //starts the baseball game specifically the pitching animation
    void startgame()
    {
        if (st.count == 0)
        {
            st.throwagain = true;
        }
    }
    private void exitgame()
    {
        SceneManager.LoadScene("Basketball");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // begingame.transform.LookAt(headpos);
        // exit.transform.LookAt(headpos);
        if (st.count == 10)
        {
            print("at 10");
            startmenutimer = true;
        }
        if (startmenutimer == true)
        {
            timetilmenushows += Time.deltaTime;
        }
        if (timetilmenushows >= 3)
        {
            print("should be showing menu");
            timetilmenushows = 0;
            begingame.SetActive(true);
            exit.SetActive(true);
            startmenutimer = false;
        }


        // 1
        if (Controller.GetHairTriggerDown() && startselected == true)
        {
            begingame.GetComponent<Renderer>().material.color = Color.white;
            begingame.SetActive(false);
            exit.SetActive(false);
            gamestarted = true;
            startselected = false;
        }
        if(gamestarted == true)
        {
            timetilgamestart += Time.deltaTime;
        }
        if (timetilgamestart >= 3)
        {
            gamestarted = false;
            startgame();
            timetilgamestart = 0;
        }
        
        else if (Controller.GetHairTriggerDown() && exitselected == true)
        {
            exitselected = false;
            exit.GetComponent<Renderer>().material.color = Color.white;
            exitgame();
            

        }
        if (Controller.GetHairTriggerDown() && inhand == false && collidingObject.CompareTag("replaceHand"))
        {
            GrabLockedObject();
        }
        else if (Controller.GetHairTriggerDown() && inhand == true)
        {
            if (objectInHand)
            {
                ReleaseLockedObject();
                inhand = false;
            }
        }
        else if (Controller.GetHairTriggerDown() && throwableinhand == false && !collidingObject.CompareTag("replaceHand"))
        {
            GrabThrowableObject();
        }

        // 2
        if (Controller.GetHairTriggerUp() && throwableinhand == true && inhand == true)
        {
            if (objectInHand)
            {
                ReleaseThrowableObject();
                throwableinhand = false;
                inhand = false;
            }
        }
        else if (Controller.GetHairTriggerUp() && throwableinhand == true)
        {
            if (objectInHand)
            {
                ReleaseThrowableObject();
                throwableinhand = false;
            }
        }


    }
}**/
