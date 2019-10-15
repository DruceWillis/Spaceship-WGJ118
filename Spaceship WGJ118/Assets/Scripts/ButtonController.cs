using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Button retryButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Camera mainCamera;
    [SerializeField] Color32 newColor;

    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OfferRetryIfPlayerDied();
        HandlePause();
    }

    private void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            retryButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            retryButton.gameObject.SetActive(false);
            mainMenuButton.gameObject.SetActive(false);
        }
    }

    private void OfferRetryIfPlayerDied()
    {
        if (player == null)
        {
            retryButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            //mainCamera.backgroundColor = newColor;
        }
    }
}
