using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float startHealth = 100;
    float maxHealth;
    public float currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = startHealth;
        maxHealth = startHealth;
        onLostHealth.AddListener(LoseHealth);
        onDeath.AddListener(Die);
        onGainedHealth.AddListener(GainHealth);
        UpdateHealth();
    }

    public FloatEvent onLostHealth = new FloatEvent();
    public FloatEvent onGainedHealth = new FloatEvent();

    /// <summary>
    /// Parameters: Current health, Max health. 
    /// </summary>
    public FloatFloatEvent onHealthChanged = new FloatFloatEvent();
    public UnityEvent onDeath = new UnityEvent();

    /// <summary>
    /// Don't call this, rather the event related to it. 
    /// </summary>
    void LoseHealth(float amountLost)
    {
        currentHealth -= amountLost;
        if (currentHealth < 0)
        {
            onDeath.Invoke();
        }
        UpdateHealth();
    }
    /// <summary>
    /// Don't call this, rather the event related to it. 
    /// </summary>
    void GainHealth(float amountGained)
    {
        currentHealth += amountGained;
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        UpdateHealth();
    }


    protected virtual void Die()
    {
        //Todo: Implement death
    }

    void UpdateHealth()
    {
        onHealthChanged.Invoke(currentHealth, maxHealth);
    }
}
