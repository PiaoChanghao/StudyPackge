/****************************************************
	文件：CacheSvc.cs
	作者：凌云月
	邮箱: piaoch001@163.com
	日期：2020/06/29 15:16   	
	功能：缓存层
*****************************************************/
using PEProtocol;
using System.Collections.Generic;

public class CacheSvc
{
    private static CacheSvc instance = null;
    public static CacheSvc Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CacheSvc();
            }
            return instance;
        }
    }

    private Dictionary<string, ServerSession> onLineAcctDic = new Dictionary<string, ServerSession>();
    private Dictionary<ServerSession, PlayerData> onLineSessionDic = new Dictionary<ServerSession, PlayerData>();

    public void init()
    {
        PECommon.Log("CacheSvc Init Done.00");
    }

    public bool isAcctOnLine(string acct)
    {

        return onLineAcctDic.ContainsKey(acct);
    }

    /// <summary>
    /// 根据账号密码返回对应的账号数据，密码错误返回null，账号不存在则默认创建账号
    /// </summary>
    public PlayerData GetplayerData(string acct,string pass)
    {
        //TODO
        //从数据库中查找账号数据
        return null;
    }

    /// <summary>
    /// 帐号上线，缓存数据
    /// </summary>
    public void AcctOnline(string acct,ServerSession session,PlayerData playerData)
    {
        onLineAcctDic.Add(acct, session);
        onLineSessionDic.Add(session, playerData);

    }
    
}
