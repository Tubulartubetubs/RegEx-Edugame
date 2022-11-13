using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    // Start is called before the first frame update
    public static ItemAssets Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite alternationSprite;
    public Sprite singleSprite;
    public Sprite characterSprite;
    public Sprite combinedSprite;
    public Sprite digitsSprite;
    public Sprite escapeSprite;
    public Sprite groupingsSprite;
    public Sprite literalsSprite;
    public Sprite quantifiersSprite;
    public Sprite rangesSprite;
    public Sprite startendSprite;
}
