using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBarHandler : MonoBehaviour
{
    private static Image HealthBarImage;

    public PlayerController playerController;

    public void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        playerController.EnemyTouchedEvent.AddListener(EnemyTouchedEvent);
    }

    public void OnDisable()
    {
        playerController.EnemyTouchedEvent.RemoveListener(EnemyTouchedEvent);
    }

    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        SetHealthBarValue(1);
    }

    public void EnemyTouchedEvent()
    {
        SetHealthBarValue(GetHealthBarValue() - 0.1f);
        if (GetHealthBarValue() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
