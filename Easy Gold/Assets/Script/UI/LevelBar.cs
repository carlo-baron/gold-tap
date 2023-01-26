using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    Slider slider;
    MainCoin mainCoin;
    void Start()
    {
        slider = GetComponent<Slider>();
        mainCoin = GameObject.Find("COIN").GetComponent<MainCoin>();
    }
    void Update()
    {
        slider.maxValue = mainCoin.maxHealth;
        slider.value = mainCoin.health;
    }
}
