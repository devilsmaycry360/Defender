using System;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthElement;
    
    private PlayerHealth playerHealth;
    private List<GameObject> healthElements;
    private Action showHealthAction => ShowHealth;

    private void OnEnable()
    {
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();

        healthElements = new List<GameObject>();
        healthElements.Add(healthElement);
        
        playerHealth.OnHealthChanged += showHealthAction;

        ShowHealth();
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= showHealthAction;
    }

    private void ShowHealth()
    {
        DisableAllHealthElements();
        
        if (playerHealth.CurrentHealth > healthElements.Count)
            AddNewHealthElements();
        
        for (int elementCounter = 0; elementCounter < playerHealth.CurrentHealth; elementCounter++)
            healthElements[elementCounter].SetActive(true);
    }

    private void AddNewHealthElements()
    {
        int numberOfNewElements = playerHealth.CurrentHealth - healthElements.Count;

        for (int elementCounter = 0; elementCounter < numberOfNewElements; elementCounter++)
        {
            GameObject newElement = Instantiate(healthElement, transform);
            healthElements.Add(newElement);
        }

    }

    private void DisableAllHealthElements()
    {
        foreach (GameObject element in healthElements)
            element.SetActive(false);
    }
}
