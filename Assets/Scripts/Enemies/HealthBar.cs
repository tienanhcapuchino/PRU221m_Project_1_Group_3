using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void SetHealth(float health, float maxhealth)
    {
        slider.gameObject.SetActive(true);
        //slider.gameObject.SetActive(health < maxhealth);
        slider.value = health;
        slider.maxValue= maxhealth;

        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    void Update()
    {
        //slider.transform.position = Camera.main.ScreenToWorldPoint(transform.parent.position + offset);
    }
}
