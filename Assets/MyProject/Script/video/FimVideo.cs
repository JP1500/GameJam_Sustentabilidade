using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FimVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] string cena;
    void Start()
    {
        videoPlayer.loopPointReached += AoTerminar;
    }


    void AoTerminar(VideoPlayer vp)
    {
        SceneManager.LoadScene(cena);
    }

    void OnDestroy()
    {
        videoPlayer.loopPointReached -= AoTerminar;
    }
}

   
