using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if  (FindObjectOfType<PlayerController>().GetCoinCount() > 9)
        {
            SceneManager.LoadScene("End");
        }
    }
}