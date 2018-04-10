using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfballreturn : MonoBehaviour {
    public GameObject golfball;
    public GameObject storage;
    public float depth = -.85f;
    public int timeTillMove = 150;
     Vector3 initialpos = new Vector3();
    //private Vector3 storage = new Vector3();
    Vector3 lowerbound = new Vector3(-.25f, -.25f, -.25f);
     Vector3 upperbound = new Vector3(.25f, .25f, .25f);
     int timecounter = 0;
     int hitCounter = 0;
     int minhits;
     Rigidbody rb;


    // Use this for initialization
    void Awake () {
        storage.transform.position = golfball.transform.position;
        initialpos = golfball.transform.position;
        rb = golfball.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(golfball.transform.position.y <= storage.transform.position.y + depth)
        {
            
            golfball.transform.position = storage.transform.position;
            rb.velocity = Vector3.zero;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.x > lowerbound.x && rb.velocity.y > lowerbound.y &&
    rb.velocity.z > lowerbound.z && rb.velocity.x < upperbound.x &&
    rb.velocity.y < upperbound.y && rb.velocity.z < upperbound.z && collision.gameObject.CompareTag("replaceHand"))
        {
            storage.transform.position = golfball.transform.position;
        }
            if (collision.gameObject.tag == "inHole")
        {
            timecounter = 0;
        }

        if(collision.gameObject.tag == "replacehand")
        {
            hitCounter++;
        }
    }


    void OnCollisionStay(Collision theCollision)
    {
       

        if (theCollision.gameObject.tag == "inHole")
        {
            timecounter++;

            if (timecounter >= timeTillMove)
            {
                if (hitCounter < minhits)
                {
                    minhits = hitCounter;
                }
                hitCounter = 0;
                
                golfball.transform.position = initialpos;
                rb.velocity = Vector3.zero;
            }
        }

    }


}
