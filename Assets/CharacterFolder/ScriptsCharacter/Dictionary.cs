using System.Collections.Generic;

public class Dictionary
{
    Dictionary<string, int> Weapons = new Dictionary<string, int>();
    private int index = 1;
    public void AddWeapon(string weapon)
    {
        Weapons.Add(weapon.ToLower(), index++);
    }

    public void RemoveWeapon(string weapon)
    {
        if (Weapons.ContainsKey(weapon.ToLower())) Weapons.Remove(weapon.ToLower());
    }

    //Si el arma no existe en el diccionario, devuelve cero.
    public int ShowWeapon(string weapon)
    {
        int key = 0;
        foreach (var item in Weapons)
        {
            if (item.Key == weapon) key = index;
        }
        return key;
    }
}
