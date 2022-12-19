using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrganManager : MonoBehaviour
{
    public bool isInRange { get; private set; }

    [SerializeField]
    GameObject OrganGame;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    public void PlayOrgan()
    {
        if (GameController.Player.pagesCollected == 4)
        {
            //OrganGame.SetActive(true);

            GameController.uiManager.WonGame();
        }
        else if (GameController.Player.pagesCollected > 4)
        {
            throw new System.Exception("How the fuck...");
        }
        else
        {
            StartCoroutine(NotEnoughMessage());
            
        }
    }

    IEnumerator NotEnoughMessage()
    {
        GameObject.Find("NotEnoughPages").GetComponent<TextMeshProUGUI>().enabled = true;

        yield return new WaitForSeconds(3);

        GameObject.Find("NotEnoughPages").GetComponent<TextMeshProUGUI>().enabled = false;
    }


}
