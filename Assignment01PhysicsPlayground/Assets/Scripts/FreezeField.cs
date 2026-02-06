using System.Collections;
using UnityEngine;

public class FreezeField : MonoBehaviour
{
    [SerializeField] float _freezeDuration = 3;

    private Vector2 _previousVelocity;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Ball"))
            StartCoroutine(FreezeBall(collider2D.gameObject));
    }

    private IEnumerator FreezeBall(GameObject ball)
    {
        //freeze ball before the pause
        ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        _previousVelocity = ball.GetComponent<Rigidbody2D>().linearVelocity;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(_freezeDuration);
        //unfreeze ball after pause
        ball.GetComponent<Rigidbody2D>().gravityScale = 1;
        ball.GetComponent<Rigidbody2D>().linearVelocity = _previousVelocity;
    }
}
