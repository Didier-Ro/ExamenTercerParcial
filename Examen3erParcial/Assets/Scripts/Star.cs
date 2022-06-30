using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanvasManager.Instance.Star();
            Destroy(gameObject);
        }
    }
}
