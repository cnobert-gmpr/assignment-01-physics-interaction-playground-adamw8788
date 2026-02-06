using System.Collections;
using UnityEngine;

public class Bumper : MonoBehaviour
    {
        [SerializeField] float _bumperForce = 10, _litDuration = 0.2f;
        [SerializeField] private Color _litColour = Color.yellow; 
        private bool _isLit = false;
        private Color _originalColour;
        private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColour = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 normal = Vector2.zero;
            // .collider will be the ball, .otherCollider will be the bumper
            if(collision.collider.gameObject.CompareTag("Ball"))
            {
                if(collision.rigidbody != null)
                {
                    if(collision.contactCount > 0)
                    {
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;
                    }
                    // if for some reason we didn't get a contact normal
                    else if(normal == Vector2.zero)
                    {
                        Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    Vector2 impulse = -(normal * _bumperForce);
                    collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse);
                }

                if(!_isLit)
                {
                    StartCoroutine(LightUp());
                }

            }
        }

        private IEnumerator LightUp()
        {
            //runs before the pause
            _isLit = true;
            _spriteRenderer.color = _litColour;
            yield return new WaitForSeconds(_litDuration);

            // runs after the pause
            _spriteRenderer.color = _originalColour;
            _isLit = false;
        }
    }