using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    public Item item;
    public void Init(Item item)
    {
        transform.GetChild(1).GetComponent<Image>().sprite = item.sprite;
        this.item = item;
        IsBuyCheck();
    }
    public void OnClick()
    {
        Shop.instance.OnItemSelected(this);
    }

    public void IsBuyCheck()
    {
        if (item.buyed)
        {
            transform.GetChild(2).GetComponent<Image>().color = new Color(0, 1, 0, 1);
        }
        else
        {
            transform.GetChild(2).GetComponent<Image>().color = Color.white;
        }
    }
}
