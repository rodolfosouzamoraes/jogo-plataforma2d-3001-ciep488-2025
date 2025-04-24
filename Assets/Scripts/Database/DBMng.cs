using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";//Endereço da memória para salvar os itens coletados no level
    private const string HABILITA_LEVEL = "habilita-level-";//Endereço da memória para salvar os níveis habilitados para jogar
    private const string MEDALHA_LEVEL = "medalha-level-";//Endereço da memória para salvar as medalhas dos niveis

    /// <summary>
    /// Método para retornar a quantidade de itens coletado do level salvo na memória
    /// </summary>
    public static int BuscarItensColetaveisLevel(int idLevel)
    {
        return PlayerPrefs.GetInt(LEVEL_DATA+idLevel);
    }

    public static void SalvarDadosLevel(int idLevel, int totalColetaveis, int idMedalha)
    {
        //Buscar a quantidade de coletaveis salvos do level
        int qtdColetaveis = BuscarItensColetaveisLevel(idLevel);

        //Verificar se o total atual é maior que o que já estava salvo na memória
        if (totalColetaveis > qtdColetaveis) { 
            //Salvar a quantidade atualizada
            PlayerPrefs.SetInt(LEVEL_DATA + idLevel, totalColetaveis);

            //Salvar o identificador da medalha
            PlayerPrefs.SetInt(MEDALHA_LEVEL+idLevel, idMedalha);
        }
    }

}
