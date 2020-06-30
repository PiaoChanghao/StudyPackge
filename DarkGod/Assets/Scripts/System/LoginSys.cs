/****************************************************
    文件：LoginSys.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2020/6/4 11:51:6
	功能：登入系统
*****************************************************/

using PEProtocol;
using UnityEngine;

public class LoginSys : SystemRoot
{
    public static LoginSys Instance = null;

    public LoginWnd loginWnd;
    public CreateWnd createWnd;

    public override void InitSys()
    {
        base.InitSys();

        Instance = this;
        PECommon.Log("Init LoginSys...");
    }

    /// <summary>
    /// 进入登录场景
    /// </summary>
    public void EnterLogin()
    {
        //TODO
        //异步加载登陆场景
        //并显示加载的进度条
        resSvc.AsyncLoadScene(Constants.SceneLogin,()=>
        {
            //加载完成后再打开注册登录界面
            loginWnd.SetWndState();
            audioSvc.PlayBGMusic(Constants.BGLogin);
        });
    }

    public void RspLogin(GameMsg msg)
    {
        GameRoot.AddTips("登入成功");
        GameRoot.Instance.SetPlayerData(msg.rspLogin);
        if (msg.rspLogin.playerData.name == "")
        {
            //打开角色创建界面
            createWnd.SetWndState();
        }
        else
        {
            //进入主城
        }
        //关闭登录界面
        loginWnd.SetWndState(false);
    }

}
