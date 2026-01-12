using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterShop : MonoBehaviour
{

    public TextMeshProUGUI coins;

    public GameObject[] solds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coins != null)
        {
            coins.SetText(Gen.coins.ToString());
        }
    }

    public void BackButton()
    {
        //load prev scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        //currently not work
       // SceneManager.LoadScene(Gen.lastScene.ToString());  // SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.LoadScene(Gen.previousSceneName);
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("CharacterBuy");
    }

    public void GoToChars()
    {
        SceneManager.LoadScene("CharacterChange");
    }

    public void BuyCharacter(GameObject button)
    {
        //if name of button is whale

        //buy whale
        if (button.name == "Whale")
        {
            // Code for Button1

            Debug.Log("whale");

            //enable whale sold Icon?
            solds[0].SetActive(true);

            Chars.whale = true;
        }
        else if (button.name != "Whale")
        {
            // Code for Button2

            Debug.Log("no whale");
        }

        Gen.coins -= Gen.buyPrice;

        //Instantiate on UI elements?

        Destroy(button);
    }
}
