/****************************************************
    文件：CreateWnd.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/5 13:13:9
	功能：角色创建界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class CreateWnd : WindowRoot 
{
    public InputField iptName;


    protected override void InitWnd()
    {
        base.InitWnd();

        //显示随机名称
        iptName.text = resSvc.GetRDNameData(false);
    }

    public void ClickRandBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);

        string rdName = resSvc.GetRDNameData(false);
        iptName.text = rdName;
    }

    public void ClickEnterBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);
        
        if(iptName.text != "")
        {
            //TODO
            //发送名字数据到服务器，登录主城
        }
        else
        {
            GameRoot.AddTips("当前名字不符合规范");
        }
    }
}