using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    
    Text moneyAmountUI, basisHealthUI;
    int playerMoney = 0;
    int basisHealth = 100;


    void Start()
    {
        moneyAmountUI  = GameObject.Find("MoneyAmountUI").GetComponent<Text>();
        basisHealthUI = GameObject.Find("BasisHealthUI").GetComponent<Text>();

        moneyAmountUI.text = $"Money: {playerMoney}";
        basisHealthUI.text = $"BasisHealth: {basisHealth}";

    }

    public void changeMoney(int amount)
    {
        playerMoney += amount;

        moneyAmountUI.text = $"Money: {playerMoney}";
    }

    public void changeBasisHealth(int amount)
    {
        basisHealth += amount;

        basisHealthUI.text = $"BasisHealth: {basisHealth}";
    }

    public void enterLevel(int levelBuildIndex)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(levelBuildIndex))
        {
            SceneManager.LoadScene(levelBuildIndex);

            Debug.Log("Changing Scene");
        }
    }


    
}
