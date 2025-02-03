using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerInput2D : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // nothing to do here...
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Obtain input information (See "Horizontal" and "Vertical" in the Input Manager)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ALTERNATIVE
        //float horizontal = 0;
        //float vertical = 0;
        //vertical += Input.GetKey(KeyCode.W) ? 1 : 0;
        //vertical += Input.GetKey(KeyCode.S) ? -1 : 0;
        //horizontal += Input.GetKey(KeyCode.A) ? -1 : 0;
        //horizontal += Input.GetKey(KeyCode.D) ? 1 : 0;

        Vector3 direction = new Vector3(horizontal, vertical, 0.0f);
        direction = direction.normalized;

        // Translate the gameobject
        transform.position += direction * speed * Time.deltaTime;

        // Rotate the sprite
        if (direction != Vector3.zero)
        {
            if (direction.y > 0)
            {
                spriteRenderer.sprite = upSprite;
            }
            else if (direction.y < 0)
            {
                spriteRenderer.sprite = downSprite;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.sprite = rightSprite;
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.sprite = rightSprite;
                spriteRenderer.flipX = true;
            }
        }
    }
}
