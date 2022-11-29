using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;

    float currentY;
    float oldY;
    public float distance;
    public float percent;
    public float scale;
    private GameObject inserted;
    float horizonPointY;
    float foregroundPointY;
    private Vector3 minScale;
    private Vector3 maxScale;
    private RegEx regex;
    

    // Start is called before the first frame update
    void Start()
    {
        root = transform.root;
        inserted = GameObject.Find("ChipInserted");
        minScale = new Vector3(0.4f, 0.4f, 1);
        maxScale = new Vector3(1.25f, 1.25f, 1f);
        horizonPointY = this.transform.position.y;
        foregroundPointY = inserted.transform.position.y; ;
        distance = Mathf.Abs(foregroundPointY - horizonPointY);
        Debug.Log("H point: " + horizonPointY + " F point: " + foregroundPointY);
        regex = GameObject.Find("DisplayText").GetComponent<RegEx>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
        oldY = currentY;
        Debug.Log(oldY);
        currentY = this.transform.position.y;
        percent = this.transform.position.y / distance;
        if (currentY != oldY)
        {
            this.transform.localScale = Vector3.Lerp(maxScale, minScale, percent);
            scale = this.transform.localScale.y;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        regex.UpdateDisplay();
    }
}
