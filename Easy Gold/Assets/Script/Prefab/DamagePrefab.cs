using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePrefab : MonoBehaviour
{
    TextMeshPro thisTMP;
    MainCoin mainCoin;
    public float whenToFade;
    void Start()
    {
        thisTMP = GetComponent<TextMeshPro>();
        mainCoin = GameObject.Find("COIN").GetComponent<MainCoin>();

        if(mainCoin.isCrit){
            thisTMP.fontSize *= 1.5f;
            mainCoin.isCrit = false;
        }

        thisTMP.text = mainCoin.damage.ToString();
        Invoke("StartFading", whenToFade);
    }

    IEnumerator FadeOut(){
        for(float f = 1f; f >= -0.05f; f -= 0.05f){
            Color color = thisTMP.color;
            color.a = f;
            thisTMP.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

    void StartFading(){
        StartCoroutine("FadeOut");
    }
}
