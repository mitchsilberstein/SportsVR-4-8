using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fwdback : MonoBehaviour {
    public float speed = 5.0f;
    private float initialx;
    private float xmax = 7.5f;
    private float xmin = -7.5f;
   
    private int direction = 1;
    // Use this for initialization
    private void Start()
    {
        initialx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        float xnew = transform.position.x + direction * speed * Time.deltaTime;
        
        if (xnew >= xmax+initialx)
        {
            xnew = xmax+initialx;
            direction *= -1;
        }
        else if (xnew <= xmin+initialx)
        {
            xnew = xmin+initialx;
            direction *= -1;
        }
        transform.position = new Vector3(xnew, transform.position.y, transform.position.z);
    }
}
