using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour
{

    public float speed = -.5f;
    public Vector3 dist = new Vector3(-.5f, 0f, 0f);
    private Vector3 holder;
    private Vector3 lengthawayholder;

    // Use this for initialization
    void Awake()
    {
        holder = gameObject.transform.position;
        lengthawayholder = (gameObject.transform.position) + dist;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.x <= lengthawayholder.x && speed < 0)
        {
            speed = speed * -1f;
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

            if (gameObject.transform.position.x >= holder.x)
            {
                speed = speed * -1f;
            }
        }
        else
        {
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

            if (gameObject.transform.position.x >= holder.x)
            {
                speed = speed * -1f;
            }
        }


    }

}
