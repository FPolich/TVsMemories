using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory 
{
    public List<Item> items = new List<Item>();
    public int indexRef;
        Item secundaria;
        Item principal;
    public Inventory(Item secundaria, Item principal)
    {
        items.Add(principal);

        items.Add(secundaria);

        this.principal = items[0];
        this.secundaria = items[1];
    }

    public void changeWeapon()
    {
        if (secundaria.equipped && !principal.equipped)
        {
            secundaria.gun.SetActive(false);
            secundaria.equipped = false;
            principal.gun.SetActive(true);
            principal.equipped = true;
            indexRef = 0;
        }
        else if (!secundaria.equipped && principal.equipped)
        {
            secundaria.gun.SetActive(true);
            secundaria.equipped = true;
            principal.gun.SetActive(false);
            principal.equipped = false;
            indexRef = 1;
        }
    }

}


[System.Serializable]
public struct Item
{
    public GameObject gun;
    public string name;
    public bool equipped;
}