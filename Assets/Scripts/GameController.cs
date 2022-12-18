using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityMovementAI;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour // Singleton class holding references to significant static objects
{
    public static GameController game { get; private set; }
    public static PlayerController Player { get; private set; }
    //public static PursueUnit movePursue { get; private set; }
    //public static Wander2Unit moveWander { get; private set; }

    public static Vector2 maxBounds { get; private set; }
    public static Vector2 minBounds { get; private set; }

    

    private void Awake()
    {
        if (game != null && game != this)
        {
            Destroy(this);
            return;
        }
        game = this;
        Player = game.GetComponentInChildren<PlayerController>();

        GameObject walls = GameObject.Find("Walls");
        Assert.IsNotNull(walls);
        
        minBounds = walls.GetComponent<Renderer>().bounds.min;
        maxBounds = walls.GetComponent<Renderer>().bounds.max;

        Debug.Log("min: " + minBounds);
        Debug.Log("max: " + maxBounds);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
