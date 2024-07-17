using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int timer1, frameCount,frameCount2, WaypointNumbers;
    public int timer2;
    bool timerStart;
        
    public int score,GameCookies;
    public TextMesh Timer,Score,Counter;
    public string state;
    public Camera camera;

    public GameObject Detector,G1,G2,G3,G4,G5,G6, AcceptButton,Letter2;
    //G2,G3,G4,G5,G6;
    public Game1 g1;
    public Game2 g2;
    public Game3 g3;
    public Game4 g4;
    public Game5 g5;
    public Game6 g6;

    SpriteRenderer detector, accept;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        timer1 = 12;
        timer2 = 3;
        score = 0;
        state = "letter";
        GameCookies = 0;
        timerStart = false;

        g1 = G1.GetComponent<Game1>();
        g2 = G2.GetComponent<Game2>();
        g3 = G3.GetComponent<Game3>();
        g4 = G4.GetComponent<Game4>();
        g5 = G5.GetComponent<Game5>();
        g6 = G6.GetComponent<Game6>();

        detector = Detector.GetComponent<SpriteRenderer>();
        accept = AcceptButton.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Detector.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

        Score.text = "Points: " + score.ToString();
        Timer.text = "Time: " + timer1;

        if (state == "letter")
        {
            camera.transform.position = new Vector3(80f, 0, -10);
            if (detector.bounds.Intersects(accept.bounds) && Input.GetKeyDown(KeyCode.Mouse0)) state = "countDown";
        }

        if (state == "reset")
        {
            timer1 = 12;
            timer2 = 3;
            score = 0;
            state = "countDown";
        }

        if (state == "countDown")
        {
            camera.transform.position = new Vector3(0, 0,-10);
            if (timer2 >= 0)
            {
                frameCount2 -= 1;
                if (frameCount2 <= 0)
                {
                    Counter.text = timer2.ToString();
                    timer2 -= 1;
                    frameCount2 = 60;
                }
            }
            if (timer2 < 0)
            {
                timerStart = true;
                timer2 = 0;
                Counter.transform.position = new Vector3(80, 0);
                state = "game1";
                
            }
            
        }

        if (timerStart == true)
        {
            Timer.text = "Time: " + timer1;
            if (timer1 >= 0)
            {
                frameCount -= 1;
                if (frameCount <= 0)
                {
                    Timer.text = "Time: " + timer1;
                    timer1 -= 1;
                    frameCount = 60;
                } 
            }
            if (timer1 < 0)
            {
                timer1 = 0;
                state = "gameover";
            }
        }

        if (state == "game1")
        {
            g1.state = "show";
            Debug.Log("Game 1");
        }
        if (state == "game2")
        {
            g2.state = "show";
            Debug.Log("Game 2");
        }
        if (state == "game3")
        {
            g3.state = "show";
            Debug.Log("Game 3");
        }
        if (state == "game4")
        {
            g4.state = "show";
            Debug.Log("Game 4");
        }
        if (state == "game5")
        {
            g5.state = "show";
            Debug.Log("Game 5");
        }
        if (state == "game6")
        {
            g6.state = "show";
            Debug.Log("Game 6");
        }

        if (score == 9)
        {
            state = "gameover";
            timerStart = false;
        }

        if (state == "gameover")
        {
            timerStart = false;
            Counter.transform.position = new Vector3(0, 0);
            Letter2.transform.position = new Vector3(0, 0);
            AcceptButton.transform.position = new Vector3(0, -10.5f,-0.13f);
            if (score == 6)
            {
                Counter.text = "Congratulations! \n You got them all.\n Enjoy a cookie :)";
            }
            if (score < 6)
            {
                Counter.text = "Almost! Try again :)";
            }
            if (score == 0)
            {
                Counter.text = "Always room for improvement :)";
            }
            if (detector.bounds.Intersects(accept.bounds) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(state);
                //state = "reset";
                SceneManager.LoadScene(0);
            }
        }
        
    }
}
