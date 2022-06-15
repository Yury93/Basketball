using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInventory : MonoBehaviour
{
    public static ItemsInventory instance;
    [Tooltip("��� ���� �������� ���� (Item) - ���� � ����")]
    /// <summary>
    /// ��� ��������� �������� ���� Item
    /// </summary>
    public List<Item> allItems;

    private void Awake()
    {
        instance = this;
    }


    /// <summary>
    /// ���������� ��������� ��������
    /// </summary>
    /// <returns></returns>
    public List<Item> GetBuyedItems()
    {
        List<Item> items = new List<Item>();
        foreach (var item in allItems)
        {
            if (item.buyed)
            {
                items.Add(item);
            }
        }
        return items;
    }

    /// <summary>
    /// ��������� ��������� � ��������� ������� �� (�������)
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(Item item)
    {
        Debug.Log("Set buy param to item "+item.itemName);
        foreach (var i in allItems)
        {
            if (i == item)
            {
                i.buyed = true;
            }
        }
    }
    [ContextMenu("Reset all items")]
    /// <summary>
    /// ������ ��� �������� �� ����������
    /// </summary>
    public void ResetItemBuy()
    {
        foreach (var item in allItems)
        {
            item.buyed = false;
        }
    }
    [ContextMenu("Buy all items")]
    /// <summary>
    /// ������� ��� �������� ����������(��� ������)
    /// </summary>
    public void BuyAllItems()
    {
        foreach (var item in allItems)
        {
            item.buyed = true;
        }
    }

    /// <summary>
    /// ������ �������� ���������� ��� "������"
    /// </summary>
    /// <param name="item"></param>
    public void SelectThatItem(Item item)
    {
        foreach (var i in allItems)
        {
            if (i == item)
            {
                i.selected = true;
                break;
            }
        }
    }
    /// <summary>
    /// ������ �������� ���������� ��� "�� ������"
    /// </summary>
    /// <param name="item"></param>
    public void DeelectThatItem(Item item)
    {
        foreach (var i in allItems)
        {
            if (i == item)
            {
                i.selected = false;
                break;
            }
        }
    }

}
