using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WireMovement : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public string wireText;

    Vector3 startPoint;
    Vector3 startPos;

    Vector3 mouseposition;

    public bool isPlaced = false;

    //public int textPos;

    public DisplayText displayText;


    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPos = transform.position;
        wireText = transform.parent.gameObject.GetComponent<WireText>().wireText.text;
        displayText = GameObject.Find("DisplayText").GetComponent<DisplayText>();
    }

    private void OnMouseDrag()
    {
        //mouse pos to world point
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;

        Debug.Log("Dragging");

        UpdateWire(mouseposition);
    }

    private void OnMouseUp()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mouseposition, .1f);

        //Debug.Log(colliders[0].gameObject.name);
        //Debug.Log(colliders[1].gameObject.name);
        //Debug.Log(colliders[2].gameObject.name);
        
        foreach (Collider2D collider in colliders)
        {
            //make sure not self and is port
            if (collider.gameObject.tag.Equals("Port"))
            {
                if (!collider.gameObject.GetComponent<PlugChecker>().GetIsConnected())
                {
                    collider.gameObject.GetComponent<PlugChecker>().SetIsConnected(true);
                    collider.gameObject.GetComponent<PlugChecker>().text = wireText;
                    UpdateWire(collider.transform.position);
                    displayText.UpdateString();
                    return;
                }
            }
            else
            {
                //reset position
                UpdateWire(startPos);
                displayText.UpdateString();
            }
        }

    }

    void UpdateWire(Vector3 newPosition)
    {
        //update wire position
        transform.position = newPosition;

        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.up = direction * transform.lossyScale.y;

        //update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
