using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfwindmill : MonoBehaviour {



    public float windmilldspeed = 25f;


    void Update()
    {
        transform.Rotate(0, 0, (Time.deltaTime * windmilldspeed));
    }
}
