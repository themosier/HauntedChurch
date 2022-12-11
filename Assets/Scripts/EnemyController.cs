using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityMovementAI;

public class EnemyController : MonoBehaviour
{

    private bool isInHearingRange = false;
    private Vector3 lastKnownPlayerPos;
    private float moveTime = 0.0f;
    private float maxMoveTime = 0.0f;
    private Vector3 direction;
    private Vector3 targetPoint;

    private Rigidbody2D rb;

    public GameObject player;
    public float moveSpeed;
    public float rotSpeed;

    private Wander2Unit moveBehavior;

    // Start is called before the first frame update
    void Start()
    {
        // Hack lol
        lastKnownPlayerPos = Vector3.zero;
        direction = Vector3.zero;
        targetPoint = Vector3.zero;
        rb = GetComponentInParent<Rigidbody2D>();
        moveBehavior = GetComponent<Wander2Unit>();
        

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
        if (isInHearingRange)
        {
            lastKnownPlayerPos = player.transform.position;
        }
        if (transform.position == lastKnownPlayerPos)
        {
            lastKnownPlayerPos = Vector3.zero;
        }
        if (lastKnownPlayerPos  != Vector3.zero)
        {
            direction = (transform.position - lastKnownPlayerPos).normalized;
            float hPos = direction.x;
            Vector3 pos = transform.position;
            pos.x += moveSpeed * hPos * Time.deltaTime;

            float vPos = direction.y;
            pos.y += moveSpeed * vPos * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            MoveRandom();
        }
    }

    void MoveRandom()
    {
        //if (moveDuration < moveTime)
        //{
        //    // keep moving in direction
        //    float hPos = direction.x;
        //    Vector3 pos = transform.position;
        //    pos.x += speed * hPos * Time.deltaTime;

        //    float vPos = direction.y;
        //    pos.y += speed * vPos * Time.deltaTime;
        //    transform.position = pos;
        //    moveDuration += Time.deltaTime;
        //}
        //else
        //{
        //    // calculate new direction
        //    direction = UnityEngine.Random.insideUnitCircle.normalized;
        //    moveDuration = 0.0f;
        //}

        //if (moveTime > maxMoveTime || Vector2.Distance(transform.position, targetPoint) < .0001)
        //{
        //    // generate new target
        //    float x = UnityEngine.Random.Range(-10.0f, 10.0f);
        //    float y = UnityEngine.Random.Range(-5.0f, 5.0f);

        //    targetPoint.x = x;
        //    targetPoint.y = y;
        //    // reset moveTime
        //    moveTime = 0;

        //    // generate new maxMoveTime
        //    maxMoveTime = UnityEngine.Random.Range(2.0f, 4.0f);
        //}

        //direction = targetPoint - transform.position;
        //direction.Normalize();

        //Quaternion rot = Quaternion.LookRotation(Vector3.forward, direction);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed * Time.deltaTime);

        //transform.position += transform.forward * moveSpeed * Time.deltaTime;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        isInHearingRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInHearingRange = false;
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
