using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour {
    GameObject centerpoint; //object we will rotate around
    public float rotatespeed;
    public float radius;
    private Vector2 centerposition;
    private Vector3 pos1;
    
    private float angle;
    
	// Use this for initialization
	void Start () {
        centerpoint = GameObject.Find("reanimator");
        centerposition.x = centerpoint.transform.position.x;
        centerposition.y = centerpoint.transform.position.y;
        pos1 = centerpoint.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (centerpoint.transform.position != pos1 && centerpoint.activeInHierarchy ==true)
        {
            pos1 = centerpoint.transform.position;
            centerposition.x = centerpoint.transform.position.x;
            centerposition.y = centerpoint.transform.position.y;
            transform.position = centerpoint.transform.position;
        }
       
        angle += rotatespeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = new Vector3(centerposition.x + offset.x, centerposition.y + offset.y, + centerpoint.transform.position.z);
    }
}
