using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool isInHearingRange { get; private set; }

    [SerializeField]
    float radiusIncrease;

    CircleCollider2D hearingRadius;

    // Start is called before the first frame update
    void Start()
    {
        isInHearingRange = false;
        hearingRadius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameController.Enemy.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInHearingRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInHearingRange = false;
        }
    }

    public void IncreaseHearing()
    {
        hearingRadius.radius += radiusIncrease;
    }
}
