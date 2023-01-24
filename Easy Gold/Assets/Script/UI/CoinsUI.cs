using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    CoinPrefabBehaviour coinPrefab;
    public TextMeshProUGUI amountText;
    public int coinAmount = 0;
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin Prefab")){
            coinPrefab = other.gameObject.GetComponent<CoinPrefabBehaviour>();
            coinAmount = coinAmount + coinPrefab.amount;
            amountText.text = coinAmount.ToString();
            Destroy(other.gameObject);
        }

    }
}
