using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpathyManager : MonoBehaviour
{
    //TP2 Vintar
    [SerializeField, Range(0, 100)]
    float _empathy;

    public float maxEmpathy;

    float _timetoRest = 1.2f;
    float _timeTranscurred;


    void Start()
    {
        _empathy = maxEmpathy;
    }


    public void RestEmpathy()
    {
        _timeTranscurred += Time.deltaTime;
        if (_timeTranscurred > _timetoRest)
        {
            _empathy--;
            
            _timeTranscurred = 0;
        }
    }

    public void PlusEmpathy(float empathy)
    {
        _empathy += empathy;
        if (_empathy >= maxEmpathy)
        {
            _empathy = maxEmpathy;
        }
    }

    public float Empathy
    {
        get { return _empathy; }
    }



}
