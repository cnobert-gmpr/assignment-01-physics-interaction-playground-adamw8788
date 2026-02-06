using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [SerializeField] private Color _hitColour = Color.darkTurquoise;
    [SerializeField] private float _hideDelay = 0.1f, _resetDelay = 2f;

    private bool _isDown = false;
    private SpriteRenderer _renderer;
    private Color _originalColour;

    void Awake()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        _originalColour = _renderer.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Ball") && !_isDown)
        {
            _isDown = true;
            _renderer.color = _hitColour;
            // "nameof" returns a string that represents the name of what is passed
            Invoke(nameof(HideTarget), _hideDelay); // call the named method in _hideDelay seconds
        }
    }

    void HideTarget()
    {
        gameObject.SetActive(false);
        Invoke(nameof(ResetTarget), _resetDelay);
    }
        
    void ResetTarget()
    {
        _renderer.color = _originalColour;
        gameObject.SetActive(true);
        _isDown = false;
    }
}
