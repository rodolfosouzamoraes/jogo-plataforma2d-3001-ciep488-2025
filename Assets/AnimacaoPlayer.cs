using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    public Animator animator;

    public void PlayParado()
    {
        animator.SetBool("Parado", true);
        animator.SetBool("Correndo", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
        animator.SetBool("Caindo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    public void PlayCaindo()
    {
        animator.SetBool("Caindo", true);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("Pulando", false);
        animator.SetBool("DeslizarParede", false);
    }

    public void PlayPulando()
    {
        animator.SetBool("Pulando", true);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("DeslizarParede", false);
    }

    public void PlayPuloDuplo()
    {
        animator.SetTrigger("PuloDuplo");
        animator.SetBool("Pulando", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("DeslizarParede", false);
    }

    public void PlayDeslizarParede()
    {
        animator.SetBool("DeslizarParede", true);
        animator.SetBool("Pulando", false);
        animator.SetBool("Caindo", false);
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
    }

    public void PlayDano()
    {
        animator.SetTrigger("Dano");
    }
}
