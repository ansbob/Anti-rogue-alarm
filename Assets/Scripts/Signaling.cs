using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(PlaySound());
        }
    }

    private IEnumerator PlaySound()
    {
        _sound.volume = 0;

        _sound.Play();

        for (int i = 0; i < 100; i++)
        {
            if (i%10 == 0)
                _sound.volume += 0.1f;

            yield return null;
        }
    }

    private IEnumerator StopSound()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 10 == 0)
                _sound.volume -= 0.1f;

            Debug.Log(_sound.volume);

            yield return null;
        }

        _sound.Stop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(StopSound());
        }
    }
}
