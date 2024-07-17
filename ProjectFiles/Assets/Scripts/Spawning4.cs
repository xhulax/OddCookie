using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning4 : MonoBehaviour
{
    int WaypointNum;
    public GameObject CurrentWaypoint, G4;
    Transform Position;
    public GameManager game;
    public Game4 g4;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        G4 = GameObject.Find("Game4");
        g4 = G4.GetComponent<Game4>();
        WaypointNum = G4.GetComponent<Game4>().WaypointNum;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "game4")
        {
            if (this.name == WaypointNum.ToString())
            {
                CurrentWaypoint = GameObject.Find(WaypointNum.ToString());
                Position = CurrentWaypoint.GetComponent<Transform>();
                transform.position = new Vector3(Position.position.x, Position.position.y);
            }
        }
        if (g4.state == "complete") Destroy(this.gameObject);
    }
}