using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public AudioSource audioVFX;
    public AudioSource audioMusica;

    public AudioClip clipGame;
    public AudioClip clipMenu;
    public AudioClip clipClik;
    public AudioClip clipFruta;
    public AudioClip[] clipsDano;
    public AudioClip clipPular;
    public AudioClip clipCorrer;
    public AudioClip clipChave;
    public AudioClip clipChefe;
    public AudioClip clipSurgir;
    public AudioClip clipProjetil;
    public AudioClip clipDanoInimigo;
    public AudioClip clipItemFinal;
    public AudioClip clipMortePlayer;
    public AudioClip clipPortao;
    public AudioClip clipMorteChefe;

    public void MudarVolume(Volume volume)
    {
        //Mudar os volumes dos audio source
        audioVFX.volume = volume.vfx;
        audioMusica.volume = volume.musica;
    }

    public void PlayAudioMenu()
    {
        //Verificar se a musica atual é diferente da do menu
        if (audioMusica.clip != clipMenu)
        {
            //Parar o audio
            audioMusica.Stop();

            //Vou trocar "Fita"
            audioMusica.clip = clipMenu;

            //Tocar o audio
            audioMusica.Play();
        }
    }

    public void PlayAudioLevel()
    {
        //Verificar se a musica atual é diferente da do menu
        if (audioMusica.clip != clipGame)
        {
            //Parar o audio
            audioMusica.Stop();

            //Vou trocar "Fita"
            audioMusica.clip = clipGame;

            //Tocar o audio
            audioMusica.Play();
        }
    }

    public void PlayAudioClick()
    {
        audioVFX.PlayOneShot(clipClik);
    }
    public void PlayAudioFruta()
    {
        audioVFX.PlayOneShot(clipFruta);
    }

    public void PlayAudioDanos()
    {
        //Sortear o audio de dano do player
        var audioSorteado = new System.Random().Next(0,clipsDano.Length);

        //Emitir o audio sorteado
        audioVFX.PlayOneShot(clipsDano[audioSorteado]);
    }

    public void PlayAudioPular()
    {
        audioVFX.PlayOneShot(clipPular);
    }

    public void PlayAudioCorrer()
    {
        audioVFX.PlayOneShot(clipCorrer);
    }

    public void PlayAudioChave()
    {
        audioVFX.PlayOneShot(clipChave);
    }

    public void PlayAudioChefe()
    {
        audioVFX.PlayOneShot(clipChefe);
    }

    public void PlayAudioSurgir()
    {
        audioVFX.PlayOneShot(clipSurgir);
    }

    public void PlayAudioProjetil()
    {
        audioVFX.PlayOneShot(clipProjetil);
    }
    public void PlayAudioDanoInimigo()
    {
        audioVFX.PlayOneShot(clipDanoInimigo);
    }
    public void PlayAudioItemFinal()
    {
        audioVFX.PlayOneShot(clipItemFinal);
    }
    public void PlayAudioMortePlayer()
    {
        audioVFX.PlayOneShot(clipMortePlayer);
    }
    public void PlayAudioPortao()
    {
        audioVFX.PlayOneShot(clipPortao);
    }
    public void PlayAudioMorteChefe()
    {
        audioVFX.PlayOneShot(clipMorteChefe);
    }
}
