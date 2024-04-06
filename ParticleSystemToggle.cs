using UnityEngine;
using System.Collections;

public class ParticleSystemToggle : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public AudioSource SoundRain;

    public float activationDuration = 5f;

    // Массив с тремя цветами: красный, синий и зеленый
    public Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

    private void Start()
    {
        StartCoroutine(ToggleParticleSystem());
    }

    private IEnumerator ToggleParticleSystem()
    {
        while (true)
        {
            SetRandomColor(); // Устанавливаем случайный цвет перед запуском Particle System

            particleSystem.Play();
            SoundRain.Play();

            yield return new WaitForSeconds(activationDuration);

            particleSystem.Stop();
            SoundRain.Stop();

            yield return new WaitForSeconds(activationDuration);
        }
    }

    private void SetRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Length);
        Color randomColor = colors[randomIndex];

        var mainModule = particleSystem.main;
        mainModule.startColor = randomColor;
    }
}
