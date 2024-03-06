using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : MonoBehaviour, INavMeshAgent, IAnimator, IParticles
{
    //TP2 Polich
    public Transform puntoA;
    public Transform puntoB;
    public Transform destinoActual;
    private NavMeshAgent navMeshAgent;
    public float distanciaUmbral = 1f;  // Distancia umbral para cambiar de destino
    public float velocidadAgente = 10f;  // Velocidad del NavMeshAgent
    private Animator animator;
    public GameObject instan;
    private AudioSource _audioSource;
    public GameObject explosion;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = velocidadAgente;
        destinoActual = puntoA;
        Mover(destinoActual.position);

    }

    private void Update()
    {
        // Verificar la distancia entre el objeto y el destino actual
        if (Vector3.Distance(transform.position, destinoActual.position) < distanciaUmbral)
        {
            CambiarDestino();
        }

        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }

    private void OnCollisionEnter(Collision other)
    {
        IDamagable x = other.gameObject.GetComponent<IDamagable>();
        if (x!= null)
        {
            ActivarParticulas();
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }

    public void ActivarParticulas()
    {
        Instantiate(instan, transform.position, transform.rotation);
        ParticleSystem exp = GetComponentInChildren<ParticleSystem>();
        Stop();
        exp.Play();
        navMeshAgent.isStopped = true;
        _audioSource.Play();
        Destroy(gameObject, exp.main.duration);
    }
    private void OnDestroy()
    {
        

    }
    public void Mover(Vector3 destino)
    {
        navMeshAgent.SetDestination(destino);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == destinoActual)
        {
            CambiarDestino();
        }
    }

    void CambiarDestino()
    {
        destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
        Mover(destinoActual.position);
    }

    public void Caminar () 
    {
        animator.Play("Walk");
    }

    public void Stop()
    {
        animator.speed = 0f;
    }
    public void Morir () {  }
    public void Disparar () { }
    public void Idle () 
    {
        animator.Play("Idle");
    }

}
