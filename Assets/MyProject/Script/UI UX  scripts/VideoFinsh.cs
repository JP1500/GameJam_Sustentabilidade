using UnityEngine;
using UnityEngine.Video;

public class VideoFinish : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] ChangeScene changeScene;

    void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;
    }

    void VideoFinished(VideoPlayer vp)
    {
        changeScene.StartFade();
    }

    void OnDestroy()
    {
        videoPlayer.loopPointReached -= VideoFinished;
    }
}