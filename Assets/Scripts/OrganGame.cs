using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OrganGame : MonoBehaviour
{
    Dictionary<GameObject, GameObject> slotMap;
    [SerializeField]
    List<GameObject> slots;
    [SerializeField]
    List<GameObject> pages;

    GameObject selectedObject = null;
    Vector3 originalPos = Vector3.zero;
    Vector3 offset = Vector3.zero;
    int filled = 0;

    void Awake()
    {
        slotMap = new Dictionary<GameObject, GameObject>();
        foreach (GameObject slot in slots)
        {
            slotMap.Add(slot, null);
        }
    }

    void Update()
    {
        if (selectedObject != null)
        {           
            selectedObject.transform.position = Input.mousePosition + offset;
        }
        if (filled >= 4)
        {
            if (CheckOrder())
            {
                WonGame();
            }
            else
            {
                ResetSlots();
            }
        }
    }

    public void ClickAndDrag(Image image)
    {
        Debug.Log("Click and Drag");
        selectedObject = image.gameObject;
        originalPos = selectedObject.transform.position;
        offset = selectedObject.transform.position - Input.mousePosition;
    }

    public void EndDrag()
    {       
        Collider2D selectedCol = selectedObject.GetComponent<Collider2D>();
        List<Collider2D> overlap = new List<Collider2D>();
        selectedCol.OverlapCollider(new ContactFilter2D().NoFilter(), overlap);

        if (overlap.Count > 0)
        {
            if (slots.Contains(overlap[0].gameObject))
            {
                Image slotImage = slots[slots.IndexOf(overlap[0].gameObject)].GetComponent<Image>();
                if (slotImage.gameObject.tag == "FilledSlot")
                {
                    selectedObject.transform.position = originalPos;
                }
                else
                {
                    slotImage.enabled = true;

                    slotImage.sprite = selectedObject.GetComponent<Image>().sprite;
                    slotImage.transform.localScale = new Vector3(4, 4, 1);
                    slotImage.gameObject.tag = "FilledSlot";
                    slotMap[slotImage.gameObject] = selectedObject;
                    filled++;
                    selectedObject.transform.position = originalPos;
                    selectedObject.SetActive(false);
                }
            }
            else
            {
                selectedObject.transform.position = originalPos;
            }
        }
        else
        {
            selectedObject.transform.position = originalPos;
        }

        selectedObject = null;
        offset = Vector3.zero;
    }

    private bool CheckOrder()
    {
        foreach (GameObject slot in slots)
        {
            Debug.Log(slotMap[slot].tag);
            Debug.Log(slot.name);
           if (slotMap[slot].tag != slot.name)
            {
                return false;
            }
        }
        return true;
    }

    private void WonGame()
    {
        GameController.uiManager.WonGame();
    }

    private void ResetSlots()
    {
        // Clear dictionary and slot images
        foreach (GameObject slot in slots)
        {
            slotMap.Remove(slot);
            slotMap.Add(slot, null);
            slot.GetComponent<Image>().sprite = null;
            slot.tag = "EmptySlot";
        }

        // Enable pieces
        foreach (var page in pages)
        {
            page.gameObject.SetActive(true);
        }
        filled = 0;

    }
}
