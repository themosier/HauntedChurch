using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    //private PlayerController Player;
    public float offset = 1.0f;

    [SerializeField]
    private Camera camera;

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
        camVertExtent = camera.orthographicSize;
        camHorzExtent = camera.aspect * camVertExtent;

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

        //transform.position = new Vector3(GameController.game.Player.transform.position.x, GameController.game.Player.transform.position.y + offset, transform.position.z);
        transform.position = new Vector3(camX, camY, transform.position.z);
    }
}
