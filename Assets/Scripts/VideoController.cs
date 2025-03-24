using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer m_VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_VideoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo()
    {
        if (m_VideoPlayer.isPlaying)
        {
            m_VideoPlayer.Pause();
        }
        else
        {
            m_VideoPlayer.Play();
        }
    }
}
