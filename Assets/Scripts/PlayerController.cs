using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    float speed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        Vector2 move = new Vector2(hPos, vPos);

        anim.SetFloat("speed", move.magnitude);
    }
}
