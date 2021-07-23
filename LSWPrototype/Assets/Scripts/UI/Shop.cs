using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private OutfitChanger addOutfit;

    private Transform container;
    private Transform shopItemTemplate;
    public float shopItemHeight = 100f;
    private int goldAmount;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        
    }

    private void Update()
    {
        goldAmount = Player.GetComponent<PlayerMovement>().Gold;
    }

    private void Start()
    {
        PopulateShop();
        
    }

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

    public bool TrySpendGoldAmount(int spendGoldAmount, Items.ItemType itemType)
    {
        if (goldAmount >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            Player.GetComponent<PlayerMovement>().Gold = goldAmount;

            addOutfit.options.Add(Items.GetSprite(itemType));

            return true;
        } 
        else
        {
            return false;
        }
    }

    public bool TrySellItem(Items.ItemType itemType)
    {
        if (addOutfit.options.Contains(Items.GetSprite(itemType)) && !Player.GetComponent<PlayerMovement>().AreYouTheSame(itemType)){

            goldAmount += Items.GetCost(itemType);
            Player.GetComponent<PlayerMovement>().Gold = goldAmount;

            addOutfit.options.Remove(Items.GetSprite(itemType));

            return true;
        }
        else
        {
            return false;
        }
    }

    public void PopulateShop()
    {
        CreateItemButton(Items.ItemType.Outfit_2, Items.GetSprite(Items.ItemType.Outfit_2), Items.GetName(Items.ItemType.Outfit_2), Items.GetCost(Items.ItemType.Outfit_2), 0);
        CreateItemButton(Items.ItemType.Outfit_3, Items.GetSprite(Items.ItemType.Outfit_3), Items.GetName(Items.ItemType.Outfit_3), Items.GetCost(Items.ItemType.Outfit_3), 1);
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
