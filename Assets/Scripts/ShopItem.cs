using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public GameObject buyMessage;
    private bool inBuyZone;
    public int healthUpgradeAmount;
    public bool isHealthRestore, isHealthUpgrade, isWeapon;

    public int itemCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inBuyZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(LevelManager.instance.currentCoins >= itemCost)
                {
                    LevelManager.instance.SpendCoins(itemCost);

                    if(isHealthRestore)
                    {
                        PlayerHPController.instance.HealPlayer(PlayerHPController.instance.maxHealth);
                    }

                    if (isHealthUpgrade)
                    {
                        PlayerHPController.instance.IncreaseMaxHealth(healthUpgradeAmount);
                    }


                    gameObject.SetActive(false);
                    inBuyZone = false;

                    AudioManager.instance.PlaySFX(18);
                }
                else
                {
                    AudioManager.instance.PlaySFX(19);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buyMessage.SetActive(true);

            inBuyZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buyMessage.SetActive(false);
            inBuyZone = false;
        }
    }
}
