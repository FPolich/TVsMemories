using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Controller : IAnimator
{
    
    public Movement _movement;
    public Pause _pause;
    public GameObject canvas;
    public bool _ispaused = false;

    EmpathyManager _empathy;

    private Animator _animator;
    private float speed;

    public Controller (Movement movement, Pause pause, GameObject _canvas, EmpathyManager empathy, Animator _anim, float _speed)

    {
        _movement = movement;
        _pause = pause;
        canvas = _canvas;
        _empathy= empathy;
        _animator = _anim;
        speed = _speed;
    }

    public void ArtificialOnTrigger(Collider other)
    {
        other.GetComponent<NPCScript>().npcs.gameObject.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E))
        {
            other.GetComponent<NPCScript>().dialogues();
            other.GetComponent<NPCScript>().reference = _empathy;
        }
    }

    public void Artificialupdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (h != 0 || v != 0)
        {
            Caminar();
            _movement.move(h, v);
        }
        else
        {
            Idle();
            _movement.stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pused();
        }
    }
    public void Pused()
    {
        float time;
        if (_ispaused == false)
        {
            _ispaused = true;
            time = 0;
            _pause.PausedGame(canvas, _ispaused, time);
            return;
        }
        else
        {
            _ispaused = false;
            time = 1;
            _pause.PausedGame(canvas, _ispaused, time);
        }
    }

    public void Caminar() 
    {
        _animator.SetBool("Walk",true);
        _animator.SetBool("Idle", false);
        _animator.SetFloat("Speed", speed);
    }
    public void Morir() { }
    public void Disparar () { }
    public void Idle()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Walk", false);
    }
    public void Stop () { } 
}
