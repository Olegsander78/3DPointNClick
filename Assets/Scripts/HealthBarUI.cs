using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private Character character;

    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
    }
    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
    }

    private void Start()
    {
        UpdateHealthBar();
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    void UpdateHealthBar()
    {
        healthFill.fillAmount = (float)character.curHp / character.maxHp;
    }
}
