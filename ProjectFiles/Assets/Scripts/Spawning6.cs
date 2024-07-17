using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning6 : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint, G6;
    Transform Position;
    public GameManager game;
    public Game6 g6;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G6 = GameObject.Find("Game6");
        g6 = G6.GetComponent<Game6>();
        WaypointNum = G6.GetComponent<Game6>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game6")
        {
            if (this.name == WaypointNum.ToString())
            {
                CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                Position = CurrentWaypoint.GetComponent<Transform>();
                transform.position = new Vector3(Position.position.x, Position.position.y);
            }
        }
        if (g6.state == "complete") Destroy(this.gameObject);
    }
}
