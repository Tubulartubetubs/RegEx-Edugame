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
    }

    public ItemType itemType;
    public int amount;

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
        }
    }
}
