using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explote : MonoBehaviour
{

    public float dmg;
    private void OnTriggerEnter(Collider other)
    {
        IDamagable x = other.GetComponent<IDamagable>();
        if (x!=null)
        {
            other.GetComponent<IDamagable>().TakeDmg(dmg);
        }
        Destroy(gameObject);

    }
}
