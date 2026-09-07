using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batteryUI : MonoBehaviour
{
    [Header("Componentes externos")]
    [SerializeField] Timer timer;
    [SerializeField] Image batteryImage;

    [Header("Sprites da bateria (Coloque da maior para menor)")]
    [SerializeField] List<Sprite> batterySprites;

    void Update()
    {
        float percentage = timer.currentTime / timer.playerController.lifeTime;

        if (percentage > 0.75f)
        {
            batteryImage.sprite = batterySprites[0];
        }
        else if (percentage > 0.50f)
        {
            batteryImage.sprite = batterySprites[1];
        }
        else if (percentage > 0.25f)
        {
            batteryImage.sprite = batterySprites[2];
        }
        else if (percentage > 0f)
        {
            batteryImage.sprite = batterySprites[3];
        }
        else
        {
            batteryImage.sprite = batterySprites[4];
        }
    }
}
