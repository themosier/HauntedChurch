using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    //private PlayerController Player;
    public float offset = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameController.game.Player;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(GameController.game.Player.transform.position.x, GameController.game.Player.transform.position.y + offset, transform.position.z);
        transform.position = new Vector3(GameController.Player.transform.position.x, GameController.Player.transform.position.y + offset, transform.position.z);
    }
}
