using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning5 : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint, G5;
    int PositionX,PositionY;
    public GameManager game;
    public Game5 g5;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G5 = GameObject.Find("Game5");
        g5 = G5.GetComponent<Game5>();
        WaypointNum = G5.GetComponent<Game5>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        PositionX = Random.Range(-6, 6);
        PositionY = Random.Range(-3, -16);

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game5")
        {
            if (this.name == WaypointNum.ToString())
            {
                this.transform.position = new Vector3(PositionX, PositionY);
                //CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                //Position = CurrentWaypoint.GetComponent<Transform>();
                //transform.position = new Vector3(Position.position.x, Position.position.y);
            }
        }
        if (g5.state == "complete") Destroy(this.gameObject);
    }
}
