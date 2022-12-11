using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToLoad = 4f;
    public int currentCoins;
    public string nextLevel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIController.instance.coinText.text = currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LevelEnd()
    {
        PlayerController.instance.canMove = false;
        UIController.instance.StartFadeToBlack();
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(nextLevel);

        
    }

    public void GetCoins(int amount)
    {
        currentCoins += amount;
        UIController.instance.coinText.text = currentCoins.ToString();
    }

    public void SpendCoins(int amount)
    {
        currentCoins -= amount;

        if(currentCoins < 0)
        {
            currentCoins = 0;
        }
        UIController.instance.coinText.text = currentCoins.ToString();
    }
}
