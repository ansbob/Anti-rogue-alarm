using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _maxDeltaVolume = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectAction(collision, "startSound");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SelectAction(collision, "stopSound");
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

    private void SelectAction(Collider2D collision, string coroutine)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            if (coroutine.Equals("startSound"))
                StartCoroutine(PlaySound());
            else
                StartCoroutine(StopSound());
        }
    }
}
