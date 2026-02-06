using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        // make sure its actually the ball falling into the death zone
        if(collider2D.CompareTag("Ball"))
        {
            // wait two seconds before doing something
            StartCoroutine(RespawnBall(collider2D.gameObject));
        }
    }

    // "StartCoroutine" must be passed a method that returns a IEnumerator
    private IEnumerator RespawnBall(GameObject ball)
    {
        yield return new WaitForSeconds(2);
        ball.transform.position = _spawnPoint.position;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}

