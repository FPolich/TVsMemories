using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudio
{
    void ShootPrimaryGun();
    void ShootSecondaryGun();
    void Death();

    void Hurt();

    void DetenerAudio();

}
