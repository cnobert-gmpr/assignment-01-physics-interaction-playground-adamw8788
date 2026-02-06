using System.Collections;
using UnityEditor.UI;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _otherPortal;

    private bool isCooldown = false;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Ball") && !isCooldown)
        {
            collider2D.gameObject.transform.position = _otherPortal.position;
            isCooldown = true;
            _otherPortal.GetComponent<Portal>().isCooldown = true;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        isCooldown = false;
        _otherPortal.GetComponent<Portal>().isCooldown = false;

    }
}
