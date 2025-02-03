using UnityEngine;
using UnityEngine.UI;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private float mSpeed = 5;
    [SerializeField] private float mAngularSpeed = 50;
    [SerializeField] private Text dirtRemainingText;
    [SerializeField] private Transform dirtParent;

    private int total_dirt;

    private void Awake()
    {
        total_dirt = dirtParent.childCount;
        
        // TODO: update dirtRemainingText
        dirtRemainingText.text = "Dirt Remaining: "+ total_dirt;
    }

    private void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!Mathf.Approximately (vertical, 0.0f) || !Mathf.Approximately (horizontal, 0.0f))
        {
            Vector3 direction = new Vector3 (0.0f, 0.0f, vertical);
            direction = Vector3.ClampMagnitude (direction, 1.0f);
            transform.Translate(direction * mSpeed * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.up, horizontal * mAngularSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dirt")
        {
            // we've collided with a dirt object
            Destroy(collision.gameObject);
            total_dirt--;

            // TODO: update dirtRemainingText
            dirtRemainingText.text = "Dirt Remaining: "+ total_dirt;
        }
    }
}
