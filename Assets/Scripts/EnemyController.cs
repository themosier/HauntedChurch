using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private bool isInHearingRange = false;
    private Vector3 lastKnownPlayerPos;
    private float moveDuration = 0.0f;
    private Vector3 direction;

    public GameObject player;
    public float speed;
    public float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        // Hack lol
        lastKnownPlayerPos = Vector3.zero;
        direction = Vector3.zero;
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
            pos.x += speed * hPos * Time.deltaTime;

            float vPos = direction.y;
            pos.y += speed * vPos * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            MoveRandom();
        }
    }

    void MoveRandom()
    {
        if (moveDuration < moveTime)
        {
            // keep moving in direction
            float hPos = direction.x;
            Vector3 pos = transform.position;
            pos.x += speed * hPos * Time.deltaTime;

            float vPos = direction.y;
            pos.y += speed * vPos * Time.deltaTime;
            transform.position = pos;
            moveDuration += Time.deltaTime;
        }
        else
        {
            // calculate new direction
            direction = Random.insideUnitCircle.normalized;
            moveDuration = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
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
}
