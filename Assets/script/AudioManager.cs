using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    private static AudioManager m_Instance;

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AudioManager GetInstance()
    {
        return m_Instance;
    }

    #endregion

    [SerializeField] private AudioClip m_footstep;
    [SerializeField] private AudioPool m_pool;


    public void PlaySound(string SoundToPlay, Vector3 pos)
    {
        switch (SoundToPlay)
        {
            case "footstep":
                m_pool.GetAvailableAudio(pos).PlayOneShot(m_footstep);
                break;
        }
    }
}
