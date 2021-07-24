using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    //Objects to refer
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private OutfitChanger addOutfit;
    [SerializeField]
    private GameObject WarningBuy;
    [SerializeField]
    private GameObject WarningSell;
    [SerializeField]
    private GameObject WarningSellNaked;
    [SerializeField]
    private GameObject WarningBuyDuplicate;

    private Transform container;
    private Transform shopItemTemplate;

    public float shopItemHeight = 100f;
    private int goldAmount;

    private void Awake()
    {
        //Get the container and items template
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");

    }

    private void Update()
    {
        //get an update of the gold
        goldAmount = Player.GetComponent<PlayerMovement>().Gold;
    }

    private void Start()
    {
        PopulateShop();
    }

    //Instantiate items on the shop
    private void CreateItemButton(Items.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(delegate { BuyItem(itemType); });
        shopItemTransform.Find("SellButton").GetComponent<Button>().onClick.AddListener(delegate { SellItem(itemType); });
    }

    private void BuyItem(Items.ItemType itemType)
    {
        TrySpendGoldAmount(Items.GetCost(itemType), itemType);
    }

    private void SellItem(Items.ItemType itemType)
    {
        TrySellItem(itemType);
    }

    //see if you can buy the Outfit you want
    public bool TrySpendGoldAmount(int spendGoldAmount, Items.ItemType itemType)
    {
        if (goldAmount >= spendGoldAmount)
        {
            if (!addOutfit.options.Contains(Items.GetSprite(itemType)))
            {
                goldAmount -= spendGoldAmount;
                Player.GetComponent<PlayerMovement>().Gold = goldAmount;

                addOutfit.options.Add(Items.GetSprite(itemType));

                return true;
            } 
            else
            {
                WarningBuyDuplicate.SetActive(true);
                return false;
            }
        }
        else
        {
            WarningBuy.SetActive(true);
            return false;
        }
    }

    //see if you can sell the Outfits you've got
    public bool TrySellItem(Items.ItemType itemType)
    {
        if (addOutfit.options.Contains(Items.GetSprite(itemType))) {
            if (!Player.GetComponent<PlayerMovement>().AreYouTheSame(itemType))
            {
                goldAmount += Items.GetCost(itemType);
                Player.GetComponent<PlayerMovement>().Gold = goldAmount;

                addOutfit.options.Remove(Items.GetSprite(itemType));

                return true;
            } else
            {
                WarningSellNaked.SetActive(true);
                return false;
            }
        }
        else
        {
            WarningSell.SetActive(true);
            return false;
        }
    }

    public void PopulateShop()
    {
        CreateItemButton(Items.ItemType.Outfit_2, Items.GetSprite(Items.ItemType.Outfit_2), Items.GetName(Items.ItemType.Outfit_2), Items.GetCost(Items.ItemType.Outfit_2), 0);
        CreateItemButton(Items.ItemType.Outfit_3, Items.GetSprite(Items.ItemType.Outfit_3), Items.GetName(Items.ItemType.Outfit_3), Items.GetCost(Items.ItemType.Outfit_3), 1);
        CreateItemButton(Items.ItemType.Outfit_4, Items.GetSprite(Items.ItemType.Outfit_4), Items.GetName(Items.ItemType.Outfit_4), Items.GetCost(Items.ItemType.Outfit_4), 2);
        CreateItemButton(Items.ItemType.Outfit_5, Items.GetSprite(Items.ItemType.Outfit_5), Items.GetName(Items.ItemType.Outfit_5), Items.GetCost(Items.ItemType.Outfit_5), 3);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
