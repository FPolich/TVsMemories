using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.UIElements;
using static MadamBoss;

public class CasinoMan : EntityEnemys, INavMeshAgent, IAnimator, IDamagable
{
    public Transform puntoA;
    public Transform puntoB;
    public Transform destinoActual;
    private NavMeshAgent navMeshAgent;
    public float distanciaUmbral = 1f;  // Distancia umbral para cambiar de destino
    public float velocidadAgente = 10f;  // Velocidad del NavMeshAgent
    private Animator animator;
    public GameObject instan;
    public float maxLife = 100;
    public GameObject soundDie;

    delegate void myDelegate();
    myDelegate callDelegate;

    public GameObject bullet;
    public LayerMask layerM;
    public Transform positionSp;

    public float shootDelay;
    float lastShootTime;
    

    public Transform target;
    float dist;
    public float minDist;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = velocidadAgente;
        destinoActual = puntoA;
        Mover(destinoActual.position);
        
        _life = maxLife;
    }
    private void Update()
    {
        CambiarDestino();
       
        dist= Vector3.Distance(target.position, transform.position);
        
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

      
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
        if (dist < minDist)
        {
            Atack();
            
        }
        else if (Vector3.Distance(transform.position, destinoActual.position) < distanciaUmbral)
        {
           

            destinoActual = (destinoActual == puntoA) ? puntoB : puntoA;
        Mover(destinoActual.position);       
        }
       
    }

    public void Caminar()
    {
    }

    public void Stop()
    {
        animator.speed = 0f;
    }
    protected override void Muerte() 
    {
        Instantiate(soundDie);
    Destroy(gameObject);
    }
    public void Morir()
    {

    }
    public void Disparar() { }
    public void Idle()
    {
    }
    protected override void Atack()
    {
        transform.LookAt(target); 
        if (Time.time - lastShootTime >= shootDelay)
        {
        StartCoroutine(SecAtck());
        lastShootTime = Time.time;                          
        }
        
    }

    private IEnumerator SecAtck()
    {
        shootDelay = 0.4f;
        instantiateBullet();
        yield return null;

    }

    void instantiateBullet()
    {
        Instantiate(bullet, positionSp.position, positionSp.rotation);
        bullet.GetComponent<EnemyBullet>().Initialize(layerM);
        _bulletCount--;
    }

    protected override void AudioEnemy()
    {
        
    }
}
