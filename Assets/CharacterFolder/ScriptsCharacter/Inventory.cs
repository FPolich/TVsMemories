using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();



}


[System.Serializable]
public struct Item
{
    public string name;
    public int count;
    public bool equipped;
}