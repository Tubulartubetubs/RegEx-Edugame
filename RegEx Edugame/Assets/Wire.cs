using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wire : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetColor(Color color)
    {
        _image.color = color;
    }
}
