using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(5, 5)]
    public string description;
    public int price = 10;
    public bool buyed = false;
    /// <summary>
    /// Если например это предмет выберается в магазине а в игре одевается
    /// </summary>
    public bool selected = false;
    [Space(20)]
    public Sprite sprite;

   
}
