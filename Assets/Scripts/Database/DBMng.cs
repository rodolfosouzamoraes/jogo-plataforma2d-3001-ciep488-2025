using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";//Endere�o da mem�ria para salvar os itens coletados no level
    private const string HABILITA_LEVEL = "habilita-level-";//Endere�o da mem�ria para salvar os n�veis habilitados para jogar
    private const string MEDALHA_LEVEL = "medalha-level-";//Endere�o da mem�ria para salvar as medalhas dos niveis

    /// <summary>
    /// M�todo para retornar a quantidade de itens coletado do level salvo na mem�ria
    /// </summary>
    public static int BuscarItensColetaveisLevel(int idLevel)
    {
        return PlayerPrefs.GetInt(LEVEL_DATA+idLevel);
    }

    public static void SalvarDadosLevel(int idLevel, int totalColetaveis, int idMedalha)
    {
        //Buscar a quantidade de coletaveis salvos do level
        int qtdColetaveis = BuscarItensColetaveisLevel(idLevel);

        //Verificar se o total atual � maior que o que j� estava salvo na mem�ria
        if (totalColetaveis > qtdColetaveis) { 
            //Salvar a quantidade atualizada
            PlayerPrefs.SetInt(LEVEL_DATA + idLevel, totalColetaveis);

            //Salvar o identificador da medalha
            PlayerPrefs.SetInt(MEDALHA_LEVEL+idLevel, idMedalha);
        }

        //Habilitar o proximo level
        PlayerPrefs.SetInt(HABILITA_LEVEL + (idLevel + 1), 1);
    }

    public static int BuscarLevelHabilitado(int idLevel)
    {
        //Retorna a infoma��o do level para saber se pode ser jogado
        return PlayerPrefs.GetInt(HABILITA_LEVEL+idLevel);
    }

    public static int BuscarMedalhaLevel(int idLevel)
    {
        //Retorna a informa��o da medalha obtida no level
        return PlayerPrefs.GetInt(MEDALHA_LEVEL+idLevel);
    }

}
