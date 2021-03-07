using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }
}
