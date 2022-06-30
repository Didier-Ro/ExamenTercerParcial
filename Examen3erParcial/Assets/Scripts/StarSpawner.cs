using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float forceUp = default;
    [SerializeField] private float delayTime = default;

    public void Spawn()
    {
        StartCoroutine(Spawning());
    }
    
    IEnumerator Spawning()
    {
        for(int i = 0; i<20; i++)
        {
            GameObject star = Instantiate(starPrefab, transform.position, Quaternion.identity);
            star.GetComponent<Rigidbody2D>().AddForce(transform.up * forceUp, ForceMode2D.Impulse);
            star.GetComponent<Rigidbody2D>().AddForce(transform.right * -0.5f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
