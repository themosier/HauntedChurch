using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update position from input
        float hPos = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;
        pos.x += speed * hPos * Time.deltaTime;

        float vPos = Input.GetAxis("Vertical");
        pos.y += speed * vPos * Time.deltaTime;
        transform.position = pos;
    }
}
