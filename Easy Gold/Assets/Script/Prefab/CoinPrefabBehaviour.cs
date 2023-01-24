using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefabBehaviour : MonoBehaviour
{
    MainCoin mainCoinScript;
    
    public Rigidbody2D rb;
    Transform toGoPos;
    public float startUpHeight;
    public int amount;
    public float movingSpeed;
    int distance;
    public float whenToFly;

    void Start()
    {
        rb.velocity = Vector2.up * startUpHeight;
        mainCoinScript = GameObject.Find("COIN").GetComponent<MainCoin>();
        toGoPos = GameObject.Find("CoinLogo").GetComponent<Transform>();

        amount = mainCoinScript.coinAmount;

    }
    void Update(){
        Invoke("Move", 5f);
        distance = (int)Vector2.Distance(transform.position, toGoPos.position);
        // if(distance <= 0){  
        //     Destroy(gameObject);
        // }
    }


    void Move(){
        if(distance > 0)
        rb.gravityScale = 0;
        transform.position = Vector2.MoveTowards(transform.position, toGoPos.position, movingSpeed * Time.deltaTime);
    }

}
