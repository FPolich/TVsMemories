using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public LifeManager lifeRef;
    public Slider lifeSlider;
    public NormalGun firstGun;

    public EmpathyManager empathyRef;
    public Slider empathySlider;


    public TMP_Text bullets;
    public TMP_Text charger;

    void Update()
    {
        lifeSlider.value = lifeRef.Life;
        empathySlider.value = empathyRef.Empathy;

        bullets.text = "Balas:" + firstGun.bulletCount;
        charger.text = "(R)ecargas: " + firstGun.chargeCount;
    }
}
