using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerhealth;
    [SerializeField] private Image totalhealth;
    [SerializeField] private Image currentHealth;

    private void Start()
    {
        totalhealth.fillAmount = playerhealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealth.fillAmount = playerhealth.currentHealth/10;
    }
}
