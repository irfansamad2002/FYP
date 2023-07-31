using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClickSound(int index)
    {
        AudioPlayer.Instance.PlayAudioOneShot(index);
    }
}
