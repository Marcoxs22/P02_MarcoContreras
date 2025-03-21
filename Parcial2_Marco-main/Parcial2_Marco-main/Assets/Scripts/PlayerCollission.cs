using UnityEngine;
using UnityEngine.Events;

public class PlayerCollission : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerLose;
    private Dash dash;

    private int obstacleCollisions = 0; // Contador de colisiones con obstáculos


    private void Start()
    {
        dash = GetComponent<Dash>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                if (obstacleCollisions < 2)
                {
                    obstacleCollisions++; // Incrementa el contador, pero no pierde aún
                }
                else
                {
                    onPlayerLose?.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            onPlayerLose?.Invoke();
            SoundManager.instance.Play("smash");
        }
    }
}
