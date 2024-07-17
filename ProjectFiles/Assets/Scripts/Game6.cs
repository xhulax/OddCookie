using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6 : MonoBehaviour
{
    public int CookieNum, RandomCount1, WaypointNum, Counter;
    public string state;

    public GameObject CurrentWaypoint;
    Transform Position;

    public GameObject cookie, oddCookie, game6, detector;
    SpriteRenderer Cookie, OddCookie1, Detector;

    //public Game1 g1;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //state = "baking";
        RandomCount1 = Random.Range(81, 97);
        Counter = 0;

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game6 = GameObject.Find("Game6");
        detector = GameObject.Find("Detector");
        Detector = detector.GetComponent<SpriteRenderer>();
        //cookie = GameObject.Find("")
        //Cookie = cookie.GetComponent<SpriteRenderer>();
        OddCookie1 = oddCookie.GetComponent<SpriteRenderer>();
        CookieNum = 80;
        WaypointNum = 80;

    }
   
    // Update is called once per frame
    void Update()
    {
        if (game.state == "game6")
        {
            Debug.Log("Hello");
            if (CookieNum != 96)
            {
                Debug.Log("Hello");
                CookieNum++;
                WaypointNum = CookieNum;
                if (CookieNum != RandomCount1)
                {
                    cookie = Instantiate(cookie, transform.position, Quaternion.identity);
                    cookie.name = CookieNum.ToString();
                }
                if (CookieNum == RandomCount1)
                {
                    oddCookie = Instantiate(oddCookie, transform.position, Quaternion.identity);
                    oddCookie.name = CookieNum.ToString();
                    OddCookie1 = oddCookie.GetComponent<SpriteRenderer>();

                }

            }

            if (Detector.bounds.Intersects(OddCookie1.bounds) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                game.score += 1;
                game.state = "gameover";
                state = "complete";
            }


            if (OddCookie1 == null) OddCookie1 = oddCookie.GetComponent<SpriteRenderer>();
        }
    }
}
