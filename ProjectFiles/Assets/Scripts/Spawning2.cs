using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning2 : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint, G2;
    Transform Position;
    public GameManager game;
    public Game2 g2;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G2 = GameObject.Find("Game2");
        g2 = G2.GetComponent<Game2>();
        WaypointNum = G2.GetComponent<Game2>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game2")
        {
            if (this.name == WaypointNum.ToString())
            {
                CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                Position = CurrentWaypoint.GetComponent<Transform>();
                transform.position = new Vector3(Position.position.x, Position.position.y);
            }
        }
        if (g2.state == "complete") Destroy(this.gameObject);
    }
}
