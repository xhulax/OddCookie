using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1 : MonoBehaviour
{
    public int CookieNum, RandomCount,WaypointNum;
    public string CookieArray, state;

    public GameObject CurrentWaypoint;
    Transform Position;

    public GameObject cookie, oddCookie,game1,detector;
    SpriteRenderer Cookie, OddCookie,Detector;

    public GameManager game;
    //public GameManager ;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = "baking";
        RandomCount = Random.Range(1, 17);

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game1 = GameObject.Find("Game1");
        detector = GameObject.Find("Detector");
        Detector = detector.GetComponent<SpriteRenderer>();
        Cookie = cookie.GetComponent<SpriteRenderer>();
        OddCookie = oddCookie.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "show")
        {
            if (CookieNum != 16)
            {
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
                game.state = "game2";
                state = "complete";
            }

            if (OddCookie == null) OddCookie = oddCookie.GetComponent<SpriteRenderer>();
        }
    }
}
