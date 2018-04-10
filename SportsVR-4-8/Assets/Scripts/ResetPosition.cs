using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetPosition : MonoBehaviour {
    public GameObject obj;
    private Rigidbody rb;
    Vector3 startpoint;
    // Use this for initialization
    void Start () {
        startpoint = obj.transform.position;
        rb = obj.GetComponent<Rigidbody>();
    }
	
// Update is called once per frame
void Update () {
        if (transform.position.y <= -150)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startpoint;
        }
    }
}
