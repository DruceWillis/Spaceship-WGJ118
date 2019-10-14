using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerController>() == null)
            GetComponent<Image>().fillAmount = 0f;
        else 
        {
            float health = FindObjectOfType<PlayerController>().health;
            GetComponent<Image>().fillAmount = health / 100;
        }    
        
    }
}
