using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class BasketballGame : MonoBehaviour {
    public GameObject ballblocker;
    public GameObject scorecounter;
    public GameObject basketball;
    public GameObject basketball2;
    public GameObject basketball3;
    public GameObject basketball4;
    public GameObject basketball5;
    GameObject[] balls;
    Vector3[] ballpositions;
    public AudioClip gamemusic;
    Vector3 bb1pos;
    Vector3 bb2pos;
    Vector3 bb3pos;
    Vector3 bb4pos;
    Vector3 bb5pos;
    
    Rigidbody rb;
    Rigidbody rb2;
    Rigidbody rb3;
    Rigidbody rb4;
    Rigidbody rb5;
    Rigidbody[] rbs;
    public int score;
    public float countdown;
    public int highscore;
    public Text countdowntext;
    public Text scoretext;
    public Text highscoretext;
    public bool startcd= false;
    // Use this for initialization
    void Awake () {
        rbs = new Rigidbody[5];
        rb = basketball.GetComponent<Rigidbody>();
        rb2 = basketball2.GetComponent<Rigidbody>();
        rb3 = basketball3.GetComponent<Rigidbody>();
        rb4 = basketball4.GetComponent<Rigidbody>();
        rb5 = basketball5.GetComponent<Rigidbody>();
        rbs[0] = rb;
        rbs[1] = rb2;
        rbs[2] = rb3;
        rbs[3] = rb4;
        rbs[4] = rb5;
        balls = new GameObject[5];
        balls[0] = basketball;
        balls[1] = basketball2;
        balls[2] = basketball3;
        balls[3] = basketball4;
        balls[4] = basketball5;
        ballpositions = new Vector3[5];
        bb1pos = basketball.transform.position;
        bb2pos = basketball2.transform.position;
        bb3pos = basketball3.transform.position;
        bb4pos = basketball4.transform.position;
        bb5pos = basketball5.transform.position;
        ballpositions[0] = bb1pos;
        ballpositions[1] = bb2pos;
        ballpositions[2] = bb3pos;
        ballpositions[3] = bb4pos;
        ballpositions[4] = bb5pos;

        score = 0;
        highscore = 0;
        countdown = 45;
        
        
        countdowntext.text = "Time" + ((int)countdown).ToString();
        scoretext.text = "Sc. " + score.ToString();
        highscoretext.text = "High " + highscore.ToString();
    }
    void Restoreposition()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Vector3.Distance(ballpositions[i], balls[i].transform.position) >= 5)
            {
                rbs[i].velocity = Vector3.zero;
                balls[i].transform.position = ballpositions[i];
            }
        }
    }
    void updateText(int score, int highscore, float countdown)
    {
        if(startcd==true)
        countdowntext.text = "Time" + ((int)countdown).ToString();
        scoretext.text = "Score " + score.ToString();
        highscoretext.text = "High " + highscore.ToString();
        

        if (countdown <= 0 && startcd ==true)
        {
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            basketball.transform.position = bb1pos;

            rb2.velocity = Vector3.zero;
            rb2.angularVelocity = Vector3.zero;
            basketball2.transform.position = bb2pos;

            rb3.velocity = Vector3.zero;
            rb3.angularVelocity = Vector3.zero;
            basketball3.transform.position = bb3pos;

            rb4.velocity = Vector3.zero;
            rb4.angularVelocity = Vector3.zero;
            basketball4.transform.position = bb4pos;

            rb5.velocity = Vector3.zero;
            rb5.angularVelocity = Vector3.zero;
            basketball5.transform.position = bb5pos;
            
            
            
            
            
            
            ballblocker.SetActive(true);
            startcd = false;
            
        }


    }
    
    public void dropblocker()
    {
        ballblocker.SetActive(false);
        AudioSource.PlayClipAtPoint(gamemusic, GameObject.Find("basketballgamemodel").transform.position);
    }
    // Update is called once per frame
   
    void FixedUpdate () {
        if(startcd == true)
        {
            
            countdown -= Time.deltaTime;
            updateText(score, highscore, countdown);
            
        }
        Restoreposition();
        }
        

 
}
