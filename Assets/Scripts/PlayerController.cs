using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public int pagesCollected { get; private set; } = 0;

    [SerializeField]
    TextMeshProUGUI pagesCollectedUI;

    private Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        pagesCollectedUI.text = pagesCollected.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //// Update position from input
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
         
    }

    private void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    public void CollectObject(GameObject obj)
    {
        pagesCollected++;
        pagesCollectedUI.text = pagesCollected.ToString();
        GameController.Enemy.PlayerCollectedPage();
        AudioController.instance.musicSource.volume += .1f;

        Destroy(obj);
    }

    private void OnInteract()
    {
        if (GameController.Organ.isInRange)
        {
            GameController.Organ.PlayOrgan();
        }
    }
}
