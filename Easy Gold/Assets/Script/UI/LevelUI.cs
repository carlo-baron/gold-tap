using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelUI : MonoBehaviour
{
    TextMeshProUGUI thisTMP;
    public MainCoin mainCoin;
    
    void Start()
    {
        thisTMP = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        thisTMP.text = mainCoin.currentLevel.ToString();
    }
}
