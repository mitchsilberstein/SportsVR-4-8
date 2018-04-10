using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directchase : MonoBehaviour
{
    

    public Transform target;
    public float speed;
    

    void OnTriggerEnter(Collider target)
    {

        if (target.gameObject.CompareTag("pickup"))
        {
            target.gameObject.SetActive(false);
            
        }

    }
    void FixedUpdate()
    {
        float pace = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, pace);

    }
}
