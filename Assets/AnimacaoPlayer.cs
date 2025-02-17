using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    public Animator animator;

    public void PlayParado()
    {
        animator.SetBool("Parado", true);
        animator.SetBool("Correndo", false);
    }

    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
    }
}
