using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;

    public PlayerWeapon weapon;

    // Update is called once per frame
    public void SetMaxTime(int time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void SetTime(int time)
    {
        slider.value = weapon.countTimer;
    }
}
