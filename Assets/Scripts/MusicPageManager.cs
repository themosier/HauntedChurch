using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPageManager : MonoBehaviour
{
    private Color defaultColor;
    //private SpriteRenderer renderer = new SpriteRenderer();

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = new Color32(195, 160, 64, 255);
        GetComponent<SpriteRenderer>().material.color = defaultColor;

        //defaultColor = GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameController.Player.CollectObject(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().material.color = defaultColor;
    }

}
