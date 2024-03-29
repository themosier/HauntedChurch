using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    //private PlayerController Player;
    public float offset = 1.0f;

    float camVertExtent;
    float camHorzExtent;

    // Bounds
    float leftBound;
    float rightBound;
    float topBound;
    float bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        camVertExtent = GameController.MainCamera.orthographicSize;
        camHorzExtent = GameController.MainCamera.aspect * camVertExtent;

        leftBound = GameController.minBounds.x + camHorzExtent;
        rightBound = GameController.maxBounds.x - camHorzExtent;
        bottomBound = GameController.minBounds.y + camVertExtent;
        topBound = GameController.maxBounds.y - camVertExtent;
    }

    // Update is called once per frame
    void Update()
    {
        float camX = Mathf.Clamp(GameController.Player.transform.position.x, leftBound, rightBound);
        float camY = Mathf.Clamp(GameController.Player.transform.position.y, bottomBound, topBound);

        transform.position = new Vector3(camX, camY, transform.position.z);
    }
}
