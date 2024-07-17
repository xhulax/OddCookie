using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4 : MonoBehaviour
{
    public int CookieNum, RandomCount, WaypointNum;
    public string state;

    public GameObject CurrentWaypoint;
    Transform Position;

    public GameObject cookie, cookie2, oddCookie, game4, detector;
    SpriteRenderer Cookie, OddCookie, Detector;

    //public Game1 g1;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //state = "baking";
        RandomCount = Random.Range(49, 65);

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game4 = GameObject.Find("Game4");
        detector = GameObject.Find("Detector");
        Detector = detector.GetComponent<SpriteRenderer>();
        //cookie = GameObject.Find("")
        //Cookie = cookie.GetComponent<SpriteRenderer>();
        OddCookie = oddCookie.GetComponent<SpriteRenderer>();
        CookieNum = 48;
        WaypointNum = 48;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (game.state == "game4")
        {
            Debug.Log("Hello");
            if (CookieNum != 64)
            {
                Debug.Log("Hello");
                CookieNum++;
                WaypointNum = CookieNum;
                if (CookieNum != RandomCount)
                {
                    if (CookieNum == 49 || CookieNum == 50 || CookieNum == 51 || CookieNum == 52)
                    {
                        cookie = Instantiate(cookie, transform.position, Quaternion.identity);
                        cookie.name = CookieNum.ToString();
                    }
                    if (CookieNum == 53 || CookieNum == 54 || CookieNum == 55 || CookieNum == 56)
                    {
                        cookie2 = Instantiate(cookie2, transform.position, Quaternion.identity);
                        cookie2.name = CookieNum.ToString();
                    }
                    if (CookieNum == 57 || CookieNum == 58 || CookieNum == 59 || CookieNum == 60)
                    {
                        cookie = Instantiate(cookie, transform.position, Quaternion.identity);
                        cookie.name = CookieNum.ToString();
                    }
                    if (CookieNum == 61 || CookieNum == 62 || CookieNum == 63 || CookieNum == 64)
                    {
                        cookie2 = Instantiate(cookie2, transform.position, Quaternion.identity);
                        cookie2.name = CookieNum.ToString();
                    }
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
                game.state = "game5";
                state = "complete";
            }

            if (OddCookie == null) OddCookie = oddCookie.GetComponent<SpriteRenderer>();
        }
    }
}
