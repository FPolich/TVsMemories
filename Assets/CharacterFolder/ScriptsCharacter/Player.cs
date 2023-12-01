using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Movement movement;
    Controller controller;
    Pause pause;
    public EmpathyManager empathy;
    public LifeManager lifeM;

    public AimDirection aim;

    private Animator _animator;

    [SerializeField]
    float maxLife = 100;

    [SerializeField]
    float maxEmpathy = 100;
    // public Slider sld;
    public bool playable = true;

    public Camera _cam;
    public GameObject canvas;
    public float speed;
    void Start()
    {
        Time.timeScale = 1.0f;
        _animator = GetComponent<Animator>();
        Rigidbody _rb = GetComponent<Rigidbody>();
        movement = new Movement(_rb, speed, _cam, transform);
        pause = new Pause();
        lifeM.initialize(this);

        controller = new Controller(movement, pause, canvas, empathy, _animator, speed);
        lifeM.maxLife = maxLife;
        empathy.maxEmpathy = maxEmpathy;
    }

    void Update()
    {
       
        aim.ForwardShooting(_cam);
        controller.Artificialupdate();
        empathy.RestEmpathy();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDialogable x = other.GetComponent<IDialogable>();
        if (x != null)
        {
            controller.dialogo = other.GetComponent<NPCScript>();
            controller.action += controller.ArtificialOnTrigger;
        }
        ICollectible y = other.GetComponent<ICollectible>();
        if (y != null)
        {
            other.GetComponent<ICollectible>().Plus();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        IDialogable x = other.GetComponent<IDialogable>();
        if (x != null)
        {
            controller.dialogo = null;
            controller.action-=controller.ArtificialOnTrigger;
            playable= true;
        }
    }

}
