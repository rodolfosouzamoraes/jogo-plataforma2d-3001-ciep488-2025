using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";//Endere�o da mem�ria para salvar os itens coletados no level
    private const string HABILITA_LEVEL = "habilita-level-";//Endere�o da mem�ria para salvar os n�veis habilitados para jogar
    private const string MEDALHA_LEVEL = "medalha-level-";//Endere�o da mem�ria para salvar as medalhas dos niveis
    private const string VOLUME = "volume";//Endere�o na mem�ria para salvar os volumes
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

    public static void SalvarVolume(float volumeVFX, float volumeMusica)
    {
        //Criar um objeto Volume para armazenar os dados
        Volume volume = new Volume();

        //Armazenar os valores dos parametros no objeto do volume
        volume.vfx = volumeVFX;
        volume.musica = volumeMusica;

        //Converter o objeto para uma estrutura em Json
        string json = JsonUtility.ToJson(volume);

        //Salvar json na memoria
        PlayerPrefs.SetString(VOLUME,json);
    }

    public static Volume ObterVolume()
    {
        //Pegar a estrutura salva do json na memoria
        string json = PlayerPrefs.GetString(VOLUME);

        //Converter a estrutura para o objeto Volume
        Volume volume = JsonUtility.FromJson<Volume>(json);

        //Verificar se o volume est� nulo
        if (volume == null) {
            //Salvar um volume inicial
            SalvarVolume(0.5f, 0.5f);

            //Atualizar a estrutura do json
            json = PlayerPrefs.GetString(VOLUME);

            //Converter a estrutura atualizada para o objeto volume
            volume = JsonUtility.FromJson<Volume>(json);
        }

        //Retornar o volume configurado
        return volume;
    }
}
