using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipNextLevel : MonoBehaviour
{
    public GameObject StarParticle;
    public UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void StarCoinParticle()
    {
        GameObject spawnedObject = Instantiate(StarParticle, transform.position, Quaternion.identity, null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StarCoinParticle();
            StartCoroutine(LoadLevel());
        }
    }
    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(0.5f);

        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            uiManager.OpenWinScreen();
        }
    }
}
