using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : TitleMenu
{
    [SerializeField]
    private Collider endGameTriggerCollider;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("UITestingScene");
            ShowCredits();
        }
    }
}
