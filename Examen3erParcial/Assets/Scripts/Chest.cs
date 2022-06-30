using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private StarSpawner spawner = default;
    private Animator _animator = default;
    private bool isOpen = default;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenChestAnimation()
    {
        isOpen = true;
        _animator.SetBool("isOpen", isOpen);
        spawner.Spawn();
    }
}
