using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChefeControlador : MonoBehaviour
{
    private Animator animator;
    private List<BoxCollider2D> colisores;//Listar todos os colisores do chefe
    private int vidaChefe = 4;
    private bool estaMovendo;//Habilitar o chefe a se mover
    public GameObject itemFinal; //Item final do jogo que ser� habilitado ap�s derrotar o chefe
    
    public bool EstaMovendo
    {
        get { return estaMovendo; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ocultar o item final
        itemFinal.SetActive(false);

        //Referenciar o animator
        animator = GetComponent<Animator>();

        //Referenciar os colisores internos
        colisores = GetComponentsInChildren<BoxCollider2D>().ToList();

        //Adicionar o colisor do objeto pai
        colisores.Add(GetComponent<BoxCollider2D>());
    }

    /// <summary>
    /// Ativa o item final ap�s o fim da anima��o de morte do chefe
    /// </summary>
    public void AtivarItemFinal()
    {
        //Habilita o item final
        itemFinal.SetActive(true);

        //Destroi o chefe
        Destroy(gameObject);
    }

    /// <summary>
    /// Permitir que o chefe se mova quando o player entrar na sua zona
    /// </summary>
    public void HabilitaMovimentacao()
    {
        //Habilita movimenta��o
        estaMovendo = true;

        //Ativa a anima��o de corrida
        animator.SetBool("Correndo", true);
    }

    public void DecrementarVidaChefe()
    {
        //Decrementar uma vida do chefe
        vidaChefe--;

        //Verificar se a vida do chefe acabou
        if (vidaChefe == 0) {
            //Tocar audio morte chefe
            AudioMng.Instance.PlayAudioMorteChefe();

            //Desabilitar a movimenta��o
            estaMovendo = false;

            //Destruir os colisores para n�o haver mais colis�o
            foreach(var colisor in colisores)
            {
                Destroy(colisor);
            }

            //Ativo a anima��o de morte
            animator.SetTrigger("Morte");
        }
        else
        {
            //Tocar audio do dano do inimigo
            AudioMng.Instance.PlayAudioDanoInimigo();

            //Ativar anima��o de dano
            animator.SetTrigger("Dano");
        }
    }
}
