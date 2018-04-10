using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {
    GameObject player;
    PlayerControler pc;
   
    public Transform target;
    public float speed;
    private void Start()
    {
        player = GameObject.Find("Cube");
        pc = player.GetComponent<PlayerControler>();
    }

    void OnTriggerEnter(Collider target)
    {

        if (target.gameObject.CompareTag("pickup"))
        {
            target.gameObject.SetActive(false);
            pc.count--;
            pc.updateText(pc.count);
        }

    }
    void FixedUpdate()
    {
        float pace = speed * Time.deltaTime;
        Vector3 heading = (target.position - transform.position).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(heading * pace);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, pace);
    }
}

