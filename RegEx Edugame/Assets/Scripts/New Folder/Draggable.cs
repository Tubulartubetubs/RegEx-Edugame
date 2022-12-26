using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    private RegEx regex;
    

    // Start is called before the first frame update
    void Start()
    {
        root = transform.root;
        regex = GameObject.Find("DisplayText").GetComponent<RegEx>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(gameObject.GetComponent<RectTransform>(), Input.mousePosition) && Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            regex.UpdateDisplay();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        regex.UpdateDisplay();
    }
}
