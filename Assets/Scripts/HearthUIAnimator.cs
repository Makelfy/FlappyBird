using UnityEngine;

public class HearthUIAnimator : MonoBehaviour
{
    private Animator animator;

    bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isActive = gameObject.activeInHierarchy;
        animator.SetBool("IsActive", isActive);
    }
}
