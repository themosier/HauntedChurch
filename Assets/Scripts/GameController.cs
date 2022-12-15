using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityMovementAI;

public class GameController : MonoBehaviour // Singleton class holding references to significant static objects
{
    public static GameController game { get; private set; }
    public static PlayerController Player { get; private set; }
    //public static PursueUnit movePursue { get; private set; }
    //public static Wander2Unit moveWander { get; private set; }

    

    private void Awake()
    {
        if (game != null && game != this)
        {
            Destroy(this);
            return;
        }
        game = this;
        Player = game.GetComponentInChildren<PlayerController>();
        //game.AddComponent<PursueUnit>();
        //movePursue = GetComponent<PursueUnit>();
        //movePursue.target = Player.GetComponent<MovementAIRigidbody>();

        //game.AddComponent<Wander2Unit>();
        //moveWander = GetComponent<Wander2Unit>();


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
