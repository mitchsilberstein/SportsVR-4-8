using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reanimate : MonoBehaviour {

    public GameObject pickup;
    private Vector3 Position;
    
    // Update is called once per frame
    void Update () {
		if(pickup.activeInHierarchy == false)
        {
            
            
            Position = new Vector3(Random.Range(-5.0f, 5.0f), 1, Random.Range(-5.0f, 5.0f));
            pickup.transform.position = Position;
            pickup.SetActive(true);
        }
    }
}
