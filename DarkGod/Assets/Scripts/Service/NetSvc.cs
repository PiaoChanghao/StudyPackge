/****************************************************
    文件：NetSrv.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/8 16:49:45
	功能：网络服务
*****************************************************/


using PEProtocol;
using UnityEngine;

public class NetSvc : MonoBehaviour 
{
    public static NetSvc Instance = null;

    PENet.PESocket<ClientSession,GameMsg> client = null;

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
        if(client.session != null)
        {
            client.session.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("服务器未连接");
            InitSvc();
        }
    }

    private void Update()
    {
   
    }

}