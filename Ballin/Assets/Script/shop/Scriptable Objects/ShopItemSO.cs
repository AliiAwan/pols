using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopMenu", menuName ="Scriptable Objects/New Shop Item siu", order =1)]
public class ShopItemSO : ScriptableObject
{
    public string name;
    public string description;
    public int coincost;
    public Material material;
}
