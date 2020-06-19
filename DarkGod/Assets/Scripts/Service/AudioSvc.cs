/****************************************************
    文件：AudioSvc.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/4 16:54:53
	功能：声音播放服务
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour 
{
    public static AudioSvc Instance = null;
    public AudioSource bgAudio;
    public AudioSource uiAudio;

    public void InitSvc()
    {
        Instance = this;
        PECommon.Log("Init AudioSvc...");
    }

    public void PlayBGMusic(string name,bool isLoop = true)
    {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/"+name,true);
        if(bgAudio.clip == null||bgAudio.clip.name != audio.name)
        {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    public void PlayUIAudio(string name)
    {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name,true);
        uiAudio.clip = audio;
        uiAudio.Play();
    }

}