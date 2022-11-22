using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        alternation,
        single,
        character,
        combined,
        digits,
        escape,
        groupings,
        literals,
        quantifiers,
        ranges,
        startend,
        blue,
        green,
        orange,
        pink,
        purple,
        red,
        turquoise,
        white,
        yellow,
    }

    public ItemType itemType;
    public string text;
    public int number;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.alternation:
                return ItemAssets.Instance.alternationSprite;
            case ItemType.single:
                return ItemAssets.Instance.singleSprite;
            case ItemType.character:
                return ItemAssets.Instance.characterSprite;
            case ItemType.combined:
                return ItemAssets.Instance.combinedSprite;
            case ItemType.digits:
                return ItemAssets.Instance.digitsSprite;
            case ItemType.escape:
                return ItemAssets.Instance.escapeSprite;
            case ItemType.groupings:
                return ItemAssets.Instance.groupingsSprite;
            case ItemType.literals:
                return ItemAssets.Instance.literalsSprite;
            case ItemType.quantifiers:
                return ItemAssets.Instance.quantifiersSprite;
            case ItemType.ranges:
                return ItemAssets.Instance.rangesSprite;
            case ItemType.startend:
                return ItemAssets.Instance.startendSprite;
            case ItemType.blue:
                return ItemAssets.Instance.blueSprite;
            case ItemType.green:
                return ItemAssets.Instance.greenSprite;
            case ItemType.orange:
                return ItemAssets.Instance.orangeSprite;
            case ItemType.pink:
                return ItemAssets.Instance.pinkSprite;
            case ItemType.purple:
                return ItemAssets.Instance.purpleSprite;
            case ItemType.red:
                return ItemAssets.Instance.redSprite;
            case ItemType.turquoise:
                return ItemAssets.Instance.turquoiseSprite;
            case ItemType.white:
                return ItemAssets.Instance.whiteSprite;
            case ItemType.yellow:
                return ItemAssets.Instance.yellowSprite;
        }
    }
}
