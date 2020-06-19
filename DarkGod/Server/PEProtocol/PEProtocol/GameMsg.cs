/****************************************************
	文件：GameMsg.cs
	作者：凌云月
	邮箱: piaoch001@163.com
	日期：2020/06/08 16:08   	
	功能：网络通信协议（客户端服务端共用）
*****************************************************/

using PENet;
using System;

namespace PEProtocol
{
    [Serializable]
    public class GameMsg : PEMsg
    {
        public ReqLogin reqLogin;


    }
    
    [Serializable]
    public class ReqLogin
    {
        public string acct;
        public string pass;
    }

    public enum CMD
    {
        None = 0,
        //登录相关100
        ReqLogin = 101,
        RsqLogin = 102,


    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666; 
    }


}
