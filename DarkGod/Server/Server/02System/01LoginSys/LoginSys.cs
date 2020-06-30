/*************************************************************
    文件：LoginSys
    作者：凌云月
    邮箱：piaoch001@163.com
    日期：2020/6/8 13:54:52
    功能：登录业务系统
 *************************************************************/



using PEProtocol;

public class LoginSys
{
    private static LoginSys instance = null;
    public static LoginSys Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginSys();
            }
            return instance;
        }
    }

    private CacheSvc cacheSvc = null;


    public void Init()
    {
        cacheSvc = CacheSvc.Instance;
        PECommon.Log("LoginSys Init Peone.");
    }

    public void ReqLogin(MsgPack pack)
    {
        ReqLogin data = pack.msg.reqLogin;
        //当前账号是否已经上线
        GameMsg msg = new GameMsg
        {
            cmd = (int)CMD.RsqLogin
        };

        //已上线：返回错误信息
        if (cacheSvc.isAcctOnLine(data.acct))
        {
            msg.err = (int)ErrorCode.AcctIsOnline;
        }
        else
        //未上线：账号是否存在

        {
            PlayerData pd = cacheSvc.GetplayerData(data.acct, data.pass);
            if (pd == null)
            {
                //存在，密码错误
                msg.err = (int)ErrorCode.WrongPass;
            }
            else
            {
                //不存在，创建默认的账号密码

                msg.rspLogin = new RspLogin
                {
                    playerData = pd
                };

                cacheSvc.AcctOnline(data.acct,pack.session,pd);
            }
        }
        //回应客户端 
        pack.session.SendMsg(msg);
    }
}
