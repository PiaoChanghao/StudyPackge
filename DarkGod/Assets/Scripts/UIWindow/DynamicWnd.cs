/****************************************************
    文件：DynamicWnd.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/5 12:27:22
	功能：动态UI元素界面
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot 
{
    public Animation tipsAni;
    public Text txtTips;

    private bool isTipsShow = false;
    private Queue<string> tipsQueue = new Queue<string>();

    protected void Init()
    {
        base.InitWnd();

        SetActive(txtTips, false);
    }

    public void AddTips(string tips)
    {
        lock (tipsQueue)
        {
            tipsQueue.Enqueue(tips);
        }
    }

    private void Update()
    {
        if(tipsQueue.Count > 0 && isTipsShow == false)
        {
            lock (tipsQueue)
            {
                string tips = tipsQueue.Dequeue();
                isTipsShow = true;
                SetTips(tips);
            }
        }
    }

    private void SetTips(string tips)
    {
        SetActive(txtTips);
        SetText(txtTips, tips);

        AnimationClip clip = tipsAni.GetClip("TipsShowAni");
        tipsAni.Play();
        //延时关闭激活状态
        StartCoroutine(AniPlayDone(clip.length, () =>
        {
            SetActive(txtTips, false);
            isTipsShow = false;
        }));


    }

    private IEnumerator AniPlayDone(float sec,Action cb)
    {
        yield return new WaitForSeconds(sec);
        if(cb != null)
        {
            cb();
        }
    }
 }