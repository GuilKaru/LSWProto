using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
        Outfit_1,
        Outfit_2,
        Outfit_3
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Outfit_1: return 50;
            case ItemType.Outfit_2: return 50;
            case ItemType.Outfit_3: return 50;
        }

    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Outfit_1: return GameAssets.i.s_Outfit1;
            case ItemType.Outfit_2: return GameAssets.i.s_Outfit2;
            case ItemType.Outfit_3: return GameAssets.i.s_Outfit3;
        }
    }

    public static string GetAnimation(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Outfit_1: return "IdleOutfit1";
            case ItemType.Outfit_2: return "IdleOutfit2";
            case ItemType.Outfit_3: return "IdleOutfit3";
        }

    }

    public static string GetName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Outfit_1: return "DefaultOutfit";
            case ItemType.Outfit_2: return "Casual";
            case ItemType.Outfit_3: return "Formal";
        }

    }
}