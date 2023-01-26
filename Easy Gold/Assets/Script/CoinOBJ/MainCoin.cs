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
    public GameObject damagePrefab;

    #endregion

    #region integers
    public int currentLevel = 1;
    public int health;
    public int maxHealth;
    public int damage;
    [HideInInspector]
    public int minDamage;
    public int maxDamage;
    public int critChance;
    public int coinAmount;
    [HideInInspector]
    public int minCoins = 1;
    [HideInInspector]
    public int maxCoins = 5;
    public int coinMultiplyer = 1;
    public int healthLevelMultiplier;
    public int damageMultiplier;

    private int prevLevel;

    #endregion

    #region booleans
    [HideInInspector]
    public bool isCrit = false;

    #endregion

    void Start()
    {
        prevLevel = currentLevel;
        health = maxHealth;
    }


    void Update()
    {
        TouchSystem();
        LevelSystem();
    }

    void TouchSystem()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPos);
                if (thisCollider == touchedCollider)
                {
                    anim.SetTrigger("hit");
                    Instantiate(coinPrefab, new Vector2(touchPos.x + Random.Range(-1, 2), touchPos.y), Quaternion.identity);
                    Instantiate(damagePrefab, touchPos, Quaternion.identity);

                    int randomChance = (int)Random.Range(0, 100);
                    maxDamage = minDamage + 10;

                    if (randomChance < critChance)
                    {
                        isCrit = true;
                        damage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage) * 1.5f);
                        coinAmount = (int)Random.Range(minCoins, maxCoins) + damage * 2;
                    }
                    else{
                        damage = (int)Random.Range(minDamage, maxDamage);
                        isCrit = false;
                    }
                        health -= damage;

                    
                    coinAmount = (int)Random.Range(minCoins, maxCoins) + damage;
                }
            }
        }
    }

    void LevelSystem()
    {
        if (currentLevel == 1)
        {
            minCoins = 1 * coinMultiplyer;
            maxCoins = 5 * coinMultiplyer;
        }
        else if (currentLevel > prevLevel)
        {
            minCoins = minCoins * 2 * coinMultiplyer;
            maxCoins = maxCoins * 2 * coinMultiplyer;
            minDamage *= damageMultiplier;
            prevLevel = currentLevel;
        }

        if(health <= 0){
            currentLevel ++;
            maxHealth *= healthLevelMultiplier;
            health = maxHealth;
        }
    }
}
