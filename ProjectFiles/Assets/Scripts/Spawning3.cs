using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning3 : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint, G3;
    Transform Position;
    public GameManager game;
    public Game3 g3;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G3 = GameObject.Find("Game3");
        g3 = G3.GetComponent<Game3>();
        WaypointNum = G3.GetComponent<Game3>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game3")
        {
            if (this.name == WaypointNum.ToString())
            {
                CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                Position = CurrentWaypoint.GetComponent<Transform>();
                transform.position = new Vector3(Position.position.x, Position.position.y);
            }
        }
        if (g3.state == "complete") Destroy(this.gameObject);
    }
}
