using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    [Header("Configurações Painel Niveis")]
    public GameObject[] paineis;
    public GameObject[] cadeadosLevel;
    public GameObject[] pnlsQtdLevel;
    public GameObject[] medalhasLevel;
    public TextMeshProUGUI[] txtsItensColetadosLevel;
    public Sprite[] spritesMedalha;

    [Header("Configurações Painel Audio")]
    public Slider sldVFX;
    public Slider sldMusica;
    private Volume volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Exibir o painel menu ao iniciar o jogo
        ExibirPainel(0);

        //Configurar painel niveis
        ConfigurarPainelNiveis();

        //Configurar painel audio
        ConfigurarPainelAudio();

        //Tocar o audio do menu
        AudioMng.Instance.PlayAudioMenu();

        //Ocultar a tela de loading
        CanvasLoadingMng.Instance.OcultarPainelLoading();
    }

    public void ExibirPainel(int id)
    {
        //Ocultar todos os outros paineis
        foreach (var painel in paineis)
        {
            //Desativar o painel
            painel.SetActive(false);
        }

        //Exibir o painel desejado
        paineis[id].SetActive(true);
    }

    private void ConfigurarPainelNiveis()
    {
        //Exibir a quantidade de itens de cada level
        for(int i = 1; i < txtsItensColetadosLevel.Length; i++)
        {
            //Buscar os itens coletados do level
            int totalItens = DBMng.BuscarItensColetaveisLevel(i);

            //Atualizar o texto de cada level
            txtsItensColetadosLevel[i].text = $"x{totalItens}";
        }

        //Habilitar ou desabilitar os levels
        for(int i = 2; i < cadeadosLevel.Length; i++)
        {
            //Verificar se o level atual está habilitado
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;

            //Exibir ou não o cadeado do level
            cadeadosLevel[i].SetActive(!estaHabilitado);

            //Exibir ou não os itens do level
            pnlsQtdLevel[i].SetActive(estaHabilitado);
        }

        //Definir as medalhas de cada level
        for (int i = 1; i < medalhasLevel.Length; i++)
        {
            //Obter a medalha do level
            int medalhaLevel = DBMng.BuscarMedalhaLevel(i);

            //Verificar se há alguma medalha salva no level
            if (medalhaLevel == 0)
            {
                medalhasLevel[i].SetActive(false);
            }
            else
            {
                //Alterar a imagem da medalha para a medalha atual do level
                medalhasLevel[i].GetComponent<Image>().sprite = spritesMedalha[medalhaLevel];
            }
        }
    }

    public void IniciarLevel1()
    {
        //Exibir tela de loading
        CanvasLoadingMng.Instance.ExibirPainelLoading();

        //Carregar o level 1
        SceneManager.LoadScene(1);
    }

    public void IniciarLevel(int idLevel)
    {
        //Verificar se o cadeado está habilitado
        if (cadeadosLevel[idLevel].activeSelf == false)
        {
            //Exibir tela de loading
            CanvasLoadingMng.Instance.ExibirPainelLoading();

            //Carregar o level solicitado
            SceneManager.LoadScene(idLevel);
        }
    }

    private void ConfigurarPainelAudio()
    {
        //Obter os volumes salvos na memória
        volume = DBMng.ObterVolume();

        //Atualizar os values dos slides dos volumes
        sldVFX.value = volume.vfx;
        sldMusica.value = volume.musica;

        //Atualizar os volumes no AudioMng
        AudioMng.Instance.MudarVolume(volume);
    }

    private void AtualizarVolumes()
    {
        //Obter o volume salvo
        volume = DBMng.ObterVolume();

        //Atualizar no AudioMng
        AudioMng.Instance.MudarVolume(volume);
    }

    /// <summary>
    /// Método utilizado no slider do volume vfx
    /// </summary>
    public void MudarVolumeVFX()
    {
        //Salvar o novo volume
        DBMng.SalvarVolume(sldVFX.value, volume.musica);

        //Atualizar os volumes no audio mng
        AtualizarVolumes();
    }

    public void MudarVolumeMusica()
    {
        //Salvar o novo volume
        DBMng.SalvarVolume(volume.vfx, sldMusica.value);

        //Atualizar os volumes no audio mng
        AtualizarVolumes();
    }

    /// <summary>
    /// Método utilizado nos botões do menu
    /// </summary>
    public void PlayAudioClick()
    {
        //Tocar o audio do click do mouse
        AudioMng.Instance.PlayAudioClick();
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
