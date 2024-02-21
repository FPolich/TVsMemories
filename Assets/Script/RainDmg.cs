using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RainDmg : MonoBehaviour
{
    [SerializeField]
    float dmg = 0.5f;
    [SerializeField]
    float timeDMG = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {

            StartCoroutine(coroutine(other));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine("codoutine");
    }

    IEnumerator coroutine(Collider other)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeDMG);
            other.GetComponent<LifeManager>().TakeDmg(dmg);
        }
   
       


    }
}
