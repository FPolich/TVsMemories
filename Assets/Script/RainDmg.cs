using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RainDmg : MonoBehaviour
{

    [SerializeField] float dmg = 0.5f;
    [SerializeField] float timeDMG = 2f;

   
    private List<Collider> targets = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            
            targets.Add(other);
          
            if (targets.Count == 1)
                StartCoroutine(DamageCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            
            targets.Remove(other);
            
            if (targets.Count == 0)
                StopCoroutine(DamageCoroutine());
        }
    }

    IEnumerator DamageCoroutine()
    {
        while (targets.Count > 0)
        {
          
            foreach (Collider target in targets)
            {
                LifeManager lifeManager = target.GetComponent<LifeManager>();
                if (lifeManager != null)
                    lifeManager.TakeDmg(dmg);
            }
            yield return new WaitForSeconds(timeDMG);
        }
    }

}
