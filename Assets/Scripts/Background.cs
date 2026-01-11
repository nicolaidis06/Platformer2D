using UnityEngine;

public class Background : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Moving");
    }
}
