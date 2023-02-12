using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public RectTransform healthBar;
    public Transform player;
    public new Camera camera;

    private void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(player.position);
        transform.position = new Vector3(screenPos.x + 10, screenPos.y - 50, transform.position.z);
    }
   

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
