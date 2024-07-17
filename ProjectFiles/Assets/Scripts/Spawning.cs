using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint,G1;
    public GameManager game;
    Transform Position;

    public Game1 g1;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G1 = GameObject.Find("Game1");
        g1 = G1.GetComponent<Game1>();
        WaypointNum = G1.GetComponent<Game1>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game1")
        {
            if (this.name == WaypointNum.ToString())
            {
                CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                Position = CurrentWaypoint.GetComponent<Transform>();
                transform.position = new Vector3(Position.position.x, Position.position.y);
            }
            
        }
        if (g1.state == "complete") Destroy(this.gameObject);
    }
}
