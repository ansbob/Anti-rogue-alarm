using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _maxDeltaVolume = 0.01f;

    private bool _switchSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _switchSound = true;
        SelectAction(collision, _switchSound);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _switchSound = false;
        SelectAction(collision, _switchSound);
    }

    private IEnumerator PlaySound()
    {
        float targetVolume = 1;
        float startVolume = 0;

        _sound.Play();

        for (float i = startVolume; i <= targetVolume; i += _maxDeltaVolume)
        {
            _sound.volume = i;

            yield return null;
        }
    }

    private IEnumerator StopSound()
    {
        float targetVolume = 0;
        float startVolume = 1;

        for (float i = startVolume; i >= targetVolume; i -= _maxDeltaVolume)
        {
            _sound.volume = i;

            yield return null;
        }

        _sound.Stop();
    }

    private void SelectAction(Collider2D collision, bool switchSound)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            if (switchSound)
                StartCoroutine(PlaySound());
            else
                StartCoroutine(StopSound());
        }
    }
}
