using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityMovementAI;

public class EnemyController : MonoBehaviour
{
    private PlayerDetection hearing;
    public static PursueUnit movePursue { get; private set; }
    public static Wander2Unit moveWander { get; private set; }


    private Rigidbody2D rb;
    Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        hearing = GetComponentInChildren<PlayerDetection>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        // Add movement modes
        movePursue = gameObject.AddComponent<PursueUnit>();
        movePursue.enabled = false;
        moveWander = gameObject.AddComponent<Wander2Unit>();
        moveWander.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        anim.SetFloat("X", rb.velocity.x);
        anim.SetFloat("Y", rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            // GAME OVER
            //Destroy(other.gameObject);
            
            StartCoroutine(GameOver());
            Time.timeScale = 0;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1);

        Time.timeScale = 1;
        GameController.uiManager.GameOver();
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
