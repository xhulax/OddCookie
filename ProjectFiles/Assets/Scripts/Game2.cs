using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{
    public int CookieNum, RandomCount, WaypointNum;
    public string state;

    public GameObject CurrentWaypoint;
    Transform Position;

    public GameObject cookie, oddCookie,game2, detector;
    SpriteRenderer Cookie, OddCookie, Detector;

    //public Game1 g1;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //state = "baking";
        RandomCount = Random.Range(17, 33);

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game2 = GameObject.Find("Game2");
        detector = GameObject.Find("Detector");
        Detector = detector.GetComponent<SpriteRenderer>();
        //cookie = GameObject.Find("")
        Cookie = cookie.GetComponent<SpriteRenderer>();
        OddCookie = oddCookie.GetComponent<SpriteRenderer>();
        CookieNum = 16;
        WaypointNum = 16;
    }
    // Update is called once per frame
    void Update()
    {

        if (game.state == "game2")
        {
            //Debug.Log("Hello");
            if (CookieNum != 32)
            {
                //Debug.Log("Hello");
                CookieNum++;
                WaypointNum = CookieNum;
                if (CookieNum != RandomCount)
                {
                    cookie = Instantiate(cookie, transform.position, Quaternion.identity);
                    cookie.name = CookieNum.ToString();
                }
                else if (CookieNum == RandomCount)
                {
                    oddCookie = Instantiate(oddCookie, transform.position, Quaternion.identity);
                    oddCookie.name = CookieNum.ToString();
                    OddCookie = oddCookie.GetComponent<SpriteRenderer>();
                }
            }

            if (Detector.bounds.Intersects(OddCookie.bounds) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                game.score += 1;
                game.state = "game3";
                state = "complete";
            }

            if (OddCookie == null) OddCookie = oddCookie.GetComponent<SpriteRenderer>();
        }
    }
}
