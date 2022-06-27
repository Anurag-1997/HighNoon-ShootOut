using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    //[SerializeField] GameObject player;
    PlayerCombat playerCombat1;
    private float maxHealth = 50;
    float currentHealth;
    private void Start()
    {
        playerCombat1 = FindObjectOfType<PlayerCombat>();
       
    }
    private void Update()
    {
        currentHealth = playerCombat1.Health;
        healthBarImage.fillAmount = currentHealth / maxHealth;

    }


}
