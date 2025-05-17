using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 target;

    private void Start()
    {
        target = transform.position;   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && target.x > -5)
        {
            target += new Vector3(-5, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && target.x < 5)
        {
            target += new Vector3(5, 0, 0);
        }

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            GameManager.Instance.EndGame();
            enabled = false;
        }
    }

}
