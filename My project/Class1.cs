using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for user input to play a specific animation clip
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Play the "Test" animation directly
            animator.Play("test");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Play the "Test2" animation directly
            animator.Play("test2");
        }
        // Add more conditions as needed for other clips
    }
}
