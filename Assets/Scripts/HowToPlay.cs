using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI BackButton;

    [SerializeField]
    TextMeshProUGUI NextButton;

    [SerializeField]
    private GameObject[] pages;
    private int curr = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //pages = new List<TextMeshProUGUI>();
        pages = GameObject.FindGameObjectsWithTag("Page");

        BackButton.enabled = false;
        NextButton.enabled = true;
    }

    public void NextClick()
    {
        curr++;
        if (curr == pages.Length - 1)
        {
            NextButton.enabled = false;
        }
        if (curr > 0)
        {
            BackButton.enabled = true;
        }

        pages[curr - 1].gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        pages[curr].gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void BackClick()
    {
        curr--;
        if (curr <= 0)
        {
            BackButton.enabled = false;
        }
        if (curr < pages.Length - 1)
        {
            NextButton.enabled = true;
        }

        pages[curr + 1].gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        pages[curr].gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
    }
}
