using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimator
{
    void Caminar();
    void Morir();

    void Disparar ();

    void Idle ();

    void Stop ();
}
