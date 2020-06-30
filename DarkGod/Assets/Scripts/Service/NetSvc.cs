/****************************************************
    文件：NetSrv.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/8 16:49:45
	功能：网络服务
*****************************************************/


using PEProtocol;
using System.Collections.Generic;
using UnityEngine;

public class NetSvc : MonoBehaviour
{
    public static NetSvc Instance = null;

    private static readonly string obj = "lock";
    PENet.PESocket<ClientSession, GameMsg> client = null;
    private Queue<GameMsg> msgQue = new Queue<GameMsg>();

    public void InitSvc()
    {
        Instance = this;

        client = new PENet.PESocket<ClientSession, GameMsg>();
        client.SetLog(true, (string msg, int lv) =>
         {
             switch (lv)
             {
                 case 0:
                     msg = "Log:" + msg;
                     Debug.Log(msg);
                     break;
                 case 1:
                     msg = "Warn:" + msg;
                     Debug.LogWarning(msg);
                     break;
                 case 2:
                     msg = "Error:" + msg;
                     Debug.LogError(msg);
                     break;
                 case 3:
                     msg = "Info:" + msg;
                     Debug.Log(msg);
                     break;
             }
         });
        client.StartAsClient(SrvCfg.srvIP, SrvCfg.srvPort);

        PECommon.Log("Init NetSvc...");
    }

    public void SendMsg(GameMsg msg)
    {
        if (client.session != null)
        {
            client.session.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("服务器未连接");
            InitSvc();
        }
    }
    public void AddNetPkg(GameMsg msg)
    {
        lock (obj)
        {
            msgQue.Enqueue(msg);
        }
    }

    public void Update()
    {
        if (msgQue.Count > 0)
        {
            lock (obj)
            {
                GameMsg msg = msgQue.Dequeue();
                ProcessMsg(msg);
            }
        }
    }

    private void ProcessMsg(GameMsg msg)
    {
        if (msg.err != (int)ErrorCode.None)
        {
            switch ((ErrorCode)msg.err)
            {
                case ErrorCode.AcctIsOnline:
                    GameRoot.AddTips("当前帐号已经上线");
                    break;
                case ErrorCode.WrongPass:
                    GameRoot.AddTips("密码错误");
                    break;
            }
            return;
        }
        switch ((CMD)msg.cmd)
        {
            case CMD.RsqLogin:
                LoginSys.Instance.RspLogin(msg);
                break;

        }
    }

}