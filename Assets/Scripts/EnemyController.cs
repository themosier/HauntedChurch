using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityMovementAI;

public class EnemyController : MonoBehaviour
{
    private Vector3 lastKnownPlayerPos;
    private float moveTime = 0.0f;
    private float maxMoveTime = 0.0f;
    private Vector3 direction;
    private Vector3 targetPoint;
    private PlayerDetection hearing;
    private MovementUnitInterface moveComponent;
    //private PursueUnit movePursue;
    //private Wander2Unit moveWander;

    public static PursueUnit movePursue { get; private set; }
    public static Wander2Unit moveWander { get; private set; }


    private Rigidbody2D rb;

    //public GameObject player;
    //public float moveSpeed;
   // public float rotSpeed;

    //private Wander2Unit moveBehavior;

    // Start is called before the first frame update
    void Start()
    {
        // Hack lol
        lastKnownPlayerPos = Vector3.zero;
        direction = Vector3.zero;
        targetPoint = Vector3.zero;
        rb = GetComponentInParent<Rigidbody2D>();
        //moveBehavior = GetComponent<Wander2Unit>();
        hearing = GetComponentInChildren<PlayerDetection>();


        // Add movement modes
        movePursue = gameObject.AddComponent<PursueUnit>();
        movePursue.enabled = false;
        moveWander = gameObject.AddComponent<Wander2Unit>();
        moveWander.enabled = true;

        // generate new target
        float x = UnityEngine.Random.Range(-10.0f, 10.0f);
        float y = UnityEngine.Random.Range(-5.0f, 5.0f);

        targetPoint.x = x;
        targetPoint.y = y;
        // reset moveTime
        moveTime = 0;

        // generate new maxMoveTime
        maxMoveTime = UnityEngine.Random.Range(2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hearing.isInHearingRange)
        {
            //lastKnownPlayerPos = player.transform.position;
            movePursue.enabled = true;
            moveWander.enabled = false;
            Debug.Log("PURSUE");
        }
        else
        {
            moveWander.enabled = true;
            movePursue.enabled = false;
            //Debug.Log("WANDER");
        }
    }


    void MoveRandom()
    {
       

        if (moveTime > 2.0f)
        {
        }

        // STOP DELETING THIS LINE IDIONT
        moveTime += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Destroy(other.gameObject);
        }
    }

    

    // WHEN RADIUS' INTERSECT
    // Enemy moves directly toward last known position of player (last point of intersection)
    // If player continues to move in radius adjust direction accordingly

    // WHEN ENEMY REACHES LAST KNOWN POSITION
    // Enemy will "search" around the area
    // Travel in random direction for x seconds, generate new direction, repeat
    // If enemy reaches bounding walls, change direction

    // Enemy can move unimpeded through walls

    // COLLISION
    // Box collider on enemy sprite
    // Attach empty child with trigger circle collider

}
