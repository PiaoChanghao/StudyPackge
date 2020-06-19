/****************************************************
    文件：LoopDragonAni.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/5 12:18:32
	功能：飞龙循环播放
*****************************************************/

using UnityEngine;

public class LoopDragonAni : MonoBehaviour 
{
    private Animation ani;
    private void Awake()
    {
        ani = transform.GetComponent<Animation>();

    }

    private void Start()
    {
        if (ani != null)
        {
            InvokeRepeating("PlayDragonAni",0,20);
        }
    }

    private void PlayDragonAni()
    {
        if (ani != null)
        {
            ani.Play();
        }
        
    }
}