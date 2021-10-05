using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text coinText;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + FindObjectOfType<PlayerController>().GetCoinCount() + " / 10";

        if  (FindObjectOfType<PlayerController>().GetCoinCount() > 9)
        {
            SceneManager.LoadScene("End");
        }
    }
}
