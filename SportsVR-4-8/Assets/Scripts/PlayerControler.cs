using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {
    
	public float speed;
	public Text countText;
    public Text timertext;
	public Text winText;
    bool isgrounded;
    bool onramp;
    Vector3 startingpoint;
    public GameObject player;
    public int count;
	private Rigidbody rb;
    float timeout;
    float timer=0;
    bool starttimer = false;
    GameObject cake;
    bool timerstop = false;

	void Awake()
	{
        player = GameObject.Find("Cube");
        startingpoint = new Vector3(0,5,0);
		rb = GetComponent<Rigidbody>();
		count = 0;
		updateText (count);
        cake = GameObject.Find("Cake");
        
	}

	void FixedUpdate ()
	{
        if (timerstop == true)
        {
            timer = timer;
        }
        else
        {
            timer += Time.deltaTime;
        }
        timertext.text = "Time: " + timer.ToString();
        if (isgrounded == true || onramp == true)
        {
            float moveHorizontail = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontail, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
        if (transform.position.y <= -150)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startingpoint;
        }
        if(starttimer == true)
        {
            timeout += Time.deltaTime;
        }
        
        if (timeout >= 5.0f)
        {
            print("should be changing");
            SceneManager.LoadScene("loserscreen");
        }

    }


    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = false;   
        }
        if (collision.gameObject.CompareTag("ramp"))
        {
            onramp = false;
        }
    }

    //checks if touching ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            
        }
        if (collision.gameObject.CompareTag("ramp"))
        {
            onramp = true;
        }
        if(collision.gameObject.CompareTag("cake"))
        {
            winText.text = "Congratulations!" +
                " write down your time and try again" +
                " you super hacker you!";
            timerstop = true;
        }
    }

   

    void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
			updateText (count);
		}

	}

	public void updateText(int counter){
		countText.text = "Count: " + count.ToString ();
		
        if(count ==-50)
		{
			winText.text = "Wasted!";
            starttimer = true;  
		}
        
        
	}
}
