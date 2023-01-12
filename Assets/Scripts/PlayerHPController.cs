using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour
{
    public static PlayerHPController instance;
    
    
    public int currentHealth;
    public int maxHealth;
    public float damageInvincLength = 1f;
    private float invincCount;
    
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCount > 0)
        {
            invincCount -= Time.deltaTime;

            if(invincCount <= 0)
            {
                PlayerController.instance.bodySR.color = new Color(1, 1, 1, 1);
            }
        }
    }
    public void DamagePlayer()
    {
        if (invincCount <= 0)
        {


            currentHealth--;

            invincCount = damageInvincLength;

            PlayerController.instance.bodySR.color = new Color(1, 1, 1, 0.5f);

            if (currentHealth <= 0)
            {
                PlayerController.instance.gameObject.SetActive(false);
                UIController.instance.deathScreen.SetActive(true);

                AudioManager.instance.PlayGameOver();
            }
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }
     public void MakeInvincible(float length)
    {
        invincCount = length;
        PlayerController.instance.bodySR.color = new Color(1, 1, 1, 0.5f);
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
