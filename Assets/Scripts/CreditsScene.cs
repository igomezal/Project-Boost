using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("gameManager is not defined");
        }

        StartCoroutine(FinishEndCredits());
    }

    IEnumerator FinishEndCredits()
    {
        yield return new WaitForSeconds(13f);
        gameManager.LoadMenu();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.LoadMenu();
        }
    }
}
