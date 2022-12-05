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
    public Transform crateWorld;
    public RectTransform chip;

    public Sprite alternationSprite;
    public Sprite characterSprite;
    public Sprite combinedSprite;
    public Sprite digitsSprite;
    public Sprite escapeSprite;
    public Sprite groupingsSprite;
    public Sprite literalsSprite;
    public Sprite quantifiersSprite;
    public Sprite rangesSprite;
    public Sprite startendSprite;
    public Sprite wildSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;
    public Sprite orangeSprite;
    public Sprite pinkSprite;
    public Sprite purpleSprite;
    public Sprite redSprite;
    public Sprite turquoiseSprite;
    public Sprite whiteSprite;
    public Sprite yellowSprite;

}
