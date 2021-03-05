using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _maxDeltaVolume = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
            StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        _sound.volume = 0;

        float targetVolume = 1;

        _sound.Play();

        for (int i = 0; i < 100; i++)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, _maxDeltaVolume);

            yield return null;
        }
    }

    private IEnumerator StopSound()
    {
        float targetVolume = 0;

        for (int i = 0; i < 100; i++)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, _maxDeltaVolume);

            yield return null;
        }

        _sound.Stop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
            StartCoroutine(StopSound());
    }
}
