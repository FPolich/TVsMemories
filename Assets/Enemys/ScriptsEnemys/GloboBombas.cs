using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GloboBombas : MonoBehaviour
{
    //TP2 Marques Polich
    public Transform puntoA;
    public Transform puntoB;
    public Transform destinoActual;
    private NavMeshAgent navMeshAgent;
    public float distanciaUmbral = 1f;  // Distancia umbral para cambiar de destino
    public float velocidadAgente = 10f;  // Velocidad del NavMeshAgent
 
  
    public GameObject bullet;
   
    public Transform positionSp;



    public Transform target;
    float dist;
    public float minDist;
    void Start()
    {
        StartCoroutine(Atack());
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = velocidadAgente;
        destinoActual = puntoA;
        Mover(destinoActual.position);
    }
    private void Update()
    {
       // CambiarDestino();

        //dist = Vector3.Distance(target.position, transform.position);



    }
    public void Mover(Vector3 destino)
    {

     //   navMeshAgent.SetDestination(destino);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == destinoActual)
        {
           // CambiarDestino();
        }
    }

    void CambiarDestino()
    {
      
        
           
            if (Vector3.Distance(transform.position, destinoActual.position) < distanciaUmbral)
            {
                destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
                Mover(destinoActual.position);
            }
        

    }

    IEnumerator Atack()
    {
        while(true)
        {       
        Instantiate(bullet, positionSp.position, positionSp.rotation);
        yield return new WaitForSeconds(2f);
        }
    }
}
