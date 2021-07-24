using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mini Database of the items you can use.
public class Items
{
    public enum ItemType
    {
        Outfit_1,
        Outfit_2,
        Outfit_3,
        Outfit_4,
        Outfit_5
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Outfit_1: return 50;
            case ItemType.Outfit_2: return 20;
            case ItemType.Outfit_3: return 30;
            case ItemType.Outfit_4: return 50;
            case ItemType.Outfit_5: return 70;
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
            case ItemType.Outfit_4: return GameAssets.i.s_Outfit4;
            case ItemType.Outfit_5: return GameAssets.i.s_Outfit5;
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
            case ItemType.Outfit_4: return "IdleOutfit4";
            case ItemType.Outfit_5: return "IdleOutfit5";
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
            case ItemType.Outfit_4: return "Hoodie";
            case ItemType.Outfit_5: return "Pajama";
        }

    }
}