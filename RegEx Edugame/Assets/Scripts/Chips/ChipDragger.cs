using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class ChipDragger : MonoBehaviour
{
    public bool isDragging;
    Vector2 mousePos;
    Vector2 offset;
    public Vector2 originalPos;
    public Vector2 destination;

    public float closestPos;

    public List<GameObject> slots;
    List<ChipSlot> slotPos;

    ChipManager chipManager;

    public bool isPlaced;

    public string regex;

    GameObject eventSystem;

    private void Start()
    {
        closestPos = 100000000;
        originalPos = transform.position;
        destination = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //foreach(GameObject slot in slots)
        //{
        //    slotPos.Add(slot.GetComponent<ChipSlot>());
        //}
        chipManager = GetComponent<ChipManager>();
        eventSystem = GameObject.FindGameObjectWithTag("EventSystem");
    }

    private void Update()
    {
        //foreach (Transform slot in slots)
        //{
        //    if(Vector2.Distance(transform.position, slot.position) < closestPos)
        //    {
        //        closestPos = Vector2.Distance(transform.position, slot.position);
        //        destination = slot.position;
        //    }

        //}

        //if (Vector2.Distance(transform.position, slots[0].transform.position) < closestPos && Vector2.Distance(transform.position, slots[0].transform.position) < 1f)
        //{
        //    closestPos = Vector2.Distance(transform.position, slots[0].transform.position);
        //    destination = slots[0].transform.position;
        //    //slots[0].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        //}
        //else if (slots[1] != null && Vector2.Distance(transform.position, slots[1].transform.position) < closestPos && Vector2.Distance(transform.position, slots[1].transform.position) < 1f)
        //{
        //    closestPos = Vector2.Distance(transform.position, slots[1].transform.position);
        //    destination = slots[1].transform.position;
        //    //slots[1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        //}
        //else if (slots[2] != null && Vector2.Distance(transform.position, slots[2].transform.position) < closestPos && Vector2.Distance(transform.position, slots[2].transform.position) < 1f)
        //{
        //    closestPos = Vector2.Distance(transform.position, slots[2].transform.position);
        //    destination = slots[2].transform.position;
        //    //slots[2].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        //}
        //else
        //{
        //    closestPos = float.MaxValue;
        //    destination = originalPos;
        //}

        foreach(GameObject slot in slots)
        {
            if(Vector2.Distance(transform.position, slot.transform.position) < 1f)
            {
                closestPos = Vector2.Distance(transform.position, slot.transform.position);
                destination = slot.transform.position;
                //isPlaced = true;
            }
            else
            {
                closestPos = float.MaxValue;
                destination = originalPos;
                //isPlaced = false;
            }
        }

        //foreach (GameObject slot in slots)
        //{
        //    if (Vector2.Distance(transform.position, slot.transform.position) < closestPos && Vector2.Distance(transform.position, slot.transform.position) < .5f)
        //    {
        //        closestPos = Vector2.Distance(transform.position, slot.transform.position);
        //        destination = slot.transform.position;
        //        slot.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        //    }
        //    else
        //    {
        //        closestPos = float.MaxValue;
        //        destination = originalPos;
        //        slot.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //    }
        //}

        //foreach (ChipSlot slot in slotPos)
        //{
        //    if (slot.closest)
        //        transform.position = slot.transform.position;
        //}

        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos - offset;
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        eventSystem.GetComponent<MatchChecker>().setCurrChip(gameObject);
    }

    private void OnMouseUp()
    {
        //if (Vector2.Distance(transform.position, slot.position) < 2f)
        //{
        //    closestPos = Vector2.Distance(transform.position, slot.position);
        //    destination = slot.position;
        //}
        //else
        //    destination = originalPos;

        transform.position = destination;
        if (destination != originalPos)
            isPlaced = true;
        else
            isPlaced = false;
        //eventSystem.GetComponent<MatchChecker>().resetCurrChip();
        isDragging = false;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
