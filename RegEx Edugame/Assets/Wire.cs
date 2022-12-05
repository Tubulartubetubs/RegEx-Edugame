using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool _isLeftWire;
    public bool _isRightWire;
    public Color customColor;

    private Image _image;

    private LineRenderer _lineRenderer;

    private Canvas _canvas;

    private bool _isDragStarted = false;

    private WireTask _wireTask;

    public bool isSuccess = false;

    public SpriteRenderer wireEnd;
    //public GameObject wireEnd;
    public string wireText;

    //public int textPos;

    public DisplayText displayText;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();

        wireText = GetComponent<WireText>().wireText.text;
        //Debug.Log(wireText);
        displayText = GameObject.Find("DisplayText").GetComponent<DisplayText>();
        //Debug.Log(displayText);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }

        else
        {
            if (!isSuccess)
            {
                _lineRenderer.SetPosition(0, Vector2.zero);
                _lineRenderer.SetPosition(1, Vector2.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);

        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }
    }
    public void SetColor(Color color) // can be replaced to set Text
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        customColor = color;
    }

    public void SetText(string text)
    {
        wireText = text;

    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_isLeftWire)
        { 
            return;
        }
        isSuccess = false;
        _isDragStarted = true;
        _wireTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(_wireTask.CurrentHoveredWire != null)
        {
            //if(_wireTask.CurrentHoveredWire.customColor == customColor && !_wireTask.CurrentHoveredWire._isLeftWire) // condition
            if(_wireTask.CurrentHoveredWire._isRightWire && !_wireTask.CurrentHoveredWire._isLeftWire) // condition
            {
                isSuccess = true;

                _wireTask.CurrentHoveredWire.isSuccess = true;
            }
        }
        _isDragStarted = false;
        _wireTask.CurrentDraggedWire = null;

    }
}
