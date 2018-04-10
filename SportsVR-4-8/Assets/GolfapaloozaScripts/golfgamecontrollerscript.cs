using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class golfgamecontrollerscript : MonoBehaviour
{

    bool inhand = false;
    bool clubinhand = false;
    bool throwableinhand = false;
    bool exitselected = false;
    public GameObject putterholder;
    public GameObject inhandputter;
    public GameObject toggleputter;
    public GameObject exitbutton;

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
        if (other.gameObject == exitbutton)
        {
            exitselected = true;
            exitbutton.GetComponent<Renderer>().material.color = Color.cyan;
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
        
        
        if (other.gameObject == exitbutton)
        {
            exitselected = false;
            exitbutton.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            collidingObject = null;
        }

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

    private void GrabLockedObject()
    {

        inhandputter.SetActive(true);
        inhandputter.transform.position = putterholder.transform.position;
        inhandputter.transform.rotation = putterholder.transform.rotation;
        objectInHand = inhandputter;

        inhand = true;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        clubinhand = false;
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
            objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            objectInHand.GetComponent<Rigidbody>().rotation = objectInHand.GetComponent<Rigidbody>().rotation;
        }
        // 4
        objectInHand = null;
        inhand = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        // 1
        if(Controller.GetHairTriggerDown() && exitselected == true)
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (inhand == false )
        {
            GrabLockedObject();
            inhand = true;
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
}

