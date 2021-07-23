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
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        goldAmount = Player.GetComponent<PlayerMovement>().Gold;
    }

    private void Start()
    {
        CreateItemButton(Items.ItemType.Outfit_2, Items.GetSprite(Items.ItemType.Outfit_2), "Outfit_2", Items.GetCost(Items.ItemType.Outfit_2), 0);
        CreateItemButton(Items.ItemType.Outfit_3, Items.GetSprite(Items.ItemType.Outfit_3), "Outfit_3", Items.GetCost(Items.ItemType.Outfit_3), 1);
        //Hide();
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
    }

   private void BuyItem(Items.ItemType itemType)
    {
        //Debug.Log(itemType + "yeah I bought it");
        TrySpendGoldAmount(Items.GetCost(itemType), itemType);
    }

    public bool TrySpendGoldAmount(int spendGoldAmount, Items.ItemType itemType)
    {
        if (goldAmount >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            Player.GetComponent<PlayerMovement>().Gold = goldAmount;
            addOutfit.options.Add(Items.GetSprite(itemType));
            return true;
        } else
        {
            return false;
        }
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
