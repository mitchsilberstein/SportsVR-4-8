using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour {
    public float speed = 5.0f;
    private float zmax = 7.5f;
    private float zmin = -7.5f;
    private int direction = 1;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        float znew = transform.position.z + direction * speed * Time.deltaTime;
        if(znew >= zmax)
        {
            znew = zmax;
            direction *= -1;
        }
        else if (znew <= zmin)
        {
            znew = zmin;
            direction *= -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, znew);
    }
}
