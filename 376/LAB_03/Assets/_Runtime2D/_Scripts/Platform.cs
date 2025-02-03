using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] [Min(0)] private float movement_speed = 3f;
    [SerializeField] [Min(0.01f)] private float movement_range = 300f;
    [SerializeField] [Range(0,1)] private float position_in_path = 1f;
    [SerializeField] private bool moving_right = true;

    private float path_max;

    private void Awake()
    {
        path_max = transform.position.x + (1 - position_in_path) * movement_range;
    }

    private void Update()
    {
        position_in_path = Mathf.Clamp((movement_range - (path_max - transform.position.x)) / movement_range, 0f, 1f);

        if (position_in_path >= 1f)
            moving_right = false;
        else if (position_in_path <= 0f)
            moving_right = true;

        if (moving_right)
            transform.Translate(new Vector3(movement_speed * Time.deltaTime, 0, 0));
        else
            transform.Translate(new Vector3(-movement_speed * Time.deltaTime, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.transform.SetParent(null);
        }
    }
}
