using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCoin : MonoBehaviour
{
    #region Components
    public Collider2D thisCollider;
    public Animator anim;

    #endregion

    #region GameObjects
    public GameObject coinPrefab;

    #endregion

    #region public vars
    public int currentLevel = 1;

    public int coinAmount;
    public int minCoins = 1;
    public int maxCoins = 5;

    public int coinMultiplyer = 1;
    #endregion

    #region privat vars
    private int prevLevel;
    #endregion

    void Start()
    {
        prevLevel = currentLevel;
    }

    
    void Update()
    {
        if(currentLevel == 1){
            minCoins = 1;
            maxCoins = 5;
        }else if(currentLevel > prevLevel){
            minCoins = minCoins * 2 * coinMultiplyer;
            maxCoins = maxCoins * 2 * coinMultiplyer;
            prevLevel = currentLevel;
        }




        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){
                anim.SetTrigger("hit");
                Instantiate(coinPrefab,new Vector2(touchPos.x + Random.Range(-1, 2), touchPos.y), Quaternion.identity);

                coinAmount = (int)Random.Range(minCoins, maxCoins);
            }
            
        }
    }
}
