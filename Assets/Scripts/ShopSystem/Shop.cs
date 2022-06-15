using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public static Shop instance;

    [Header("Drag & Drop")]
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text moneyCostText;
    [SerializeField] private Image selectedItemImage;
    [SerializeField] private Button buyButton;

    [SerializeField] private Transform contentField;
    [SerializeField] private GameObject itemCellPrefab;

    [Header("SomeParams")]
    public int mainMoney = 0;
    Item currentSelectedItem = null;
    ItemCell currentSelectedCell = null;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadMoney();
        FillItemContent(ItemsInventory.instance.allItems);
       
    }
    [ContextMenu("Open shop")]
    public void OpenShop()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        OnItemSelected(contentField.GetChild(0).GetComponent<ItemCell>());
    }
    public void CloseChop()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void BuyThatItem(Item item)
    {
        buyButton.interactable = false;
        ItemsInventory.instance.BuyItem(item);
        currentSelectedCell.IsBuyCheck();
        TakeMoney(item.price);
    }

    public void OnBuyButtonClick()
    {
        if (mainMoney >= currentSelectedItem.price)
        {
            BuyThatItem(currentSelectedItem);
        }
        else Debug.Log("NO MONEY");
    }
    private void FillItemContent(List<Item> fillItems)
    {
        foreach (var item in fillItems)
        {
            GameObject go = Instantiate(itemCellPrefab, contentField);
            FillTheCell(item, go);
           // AddContentRectWidth();
        }
    }
    private void FillTheCell(Item item, GameObject cell)
    {
        cell.GetComponent<ItemCell>().Init(item);
    }
    public void OnItemSelected(ItemCell cell)
    {
        currentSelectedCell = cell;
        currentSelectedItem = cell.item;
        ShowDescription();
    }
    private void ShowDescription()
    {
        itemNameText.text = currentSelectedItem.itemName;
        descriptionText.text = currentSelectedItem.description;
        moneyCostText.text = currentSelectedItem.price + "$";
        selectedItemImage.sprite = currentSelectedItem.sprite;

        if (currentSelectedItem.price > mainMoney || currentSelectedItem.buyed)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }
    public void AddMoney(int money)
    {
        mainMoney += money;
        PlayerPrefs.SetInt("Money", mainMoney);
    }
    private void TakeMoney(int money)
    {
        mainMoney -= money;
        
        PlayerPrefs.SetInt("Money", mainMoney);
    }
    private void LoadMoney()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            mainMoney = PlayerPrefs.GetInt("Money");
        }else
        {
            Debug.Log("Default money load"); 
        }
    }
}
