using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour // Singleton class holding references to significant static objects
{
    public static GameController game { get; private set; }
    public PlayerController Player { get; private set; }

    

    private void Awake()
    {
        if (game != null && game != this)
        {
            Destroy(this);
            return;
        }
        game = this;
        Player = game.GetComponentInChildren<PlayerController>();

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
