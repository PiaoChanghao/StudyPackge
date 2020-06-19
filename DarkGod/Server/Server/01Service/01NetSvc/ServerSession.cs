/****************************************************
	文件：ServerSession.cs
	作者：凌云月
	邮箱: piaoch001@163.com
	日期：2020/06/08 16:24   	
	功能：网络会话连接
*****************************************************/




using PENet;
using PEProtocol;

public class ServerSession:PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PECommon.Log("Client Connect");
        
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("RcvPack CMD:"+((CMD)msg.cmd).ToString());
        NetSvc.Instance.AddMsgQue(this,msg);

        
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Client DisConnect");
    }
}
