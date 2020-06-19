/****************************************************
    文件：ClientSession.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/8 16:55:54
	功能：客户端网络会话
*****************************************************/


using PENet;
using PEProtocol;
using UnityEngine;

public class ClientSession : PESession<GameMsg>  
{
    

    protected override void OnConnected()
    {
        PECommon.Log("Server Connect.");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Server Rsp:");
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Server DisConnect.");
    }
}