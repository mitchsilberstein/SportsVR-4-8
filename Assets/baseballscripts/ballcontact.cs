using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballcontact : MonoBehaviour {
    public GameObject ground;
    public GameObject OB;
    public GameObject PlayerBox;
    public GameObject initialpoint;
    public GameObject skeleton;
    public GameObject scoreboard;
    baseballscoreboard bsb;
    public int distancetraveled;
    Vector3 startspot;
    skeletonthrow st;
    
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject == OB)
        {
            bsb.distancetraveled = -1;
            bsb.updatescoreboard();
            if (st.count == 10)
            {
                st.count = 0;
                st.throwagain = false;

            }
            else
            {

                st.count += 1;
                st.throwagain = true;
            }
            Destroy(gameObject);
        }
        else if(other.gameObject == ground)
        {
            distancetraveled = (int)Vector3.Distance(gameObject.transform.position, startspot);
            bsb.distancetraveled = distancetraveled;

            bsb.updatescoreboard();
            if (st.count == 10)
            {
                st.count = 0;
                st.throwagain = false;
                
            }
            else
            {
                
                st.count += 1;
                st.throwagain = true;
            }
            Destroy(gameObject);
            
        }
        else if (other.gameObject == PlayerBox)
        {
            st.throwagain = true;
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        bsb = scoreboard.GetComponent<baseballscoreboard>();
        st = skeleton.GetComponent<skeletonthrow>();
        startspot = initialpoint.transform.position;
        
        
    }
    // Update is called once per frame
    void Update () {
       if(st.count ==0 && st.throwagain == true)
        {
            
        }
    }
}
