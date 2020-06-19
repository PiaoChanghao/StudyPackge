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
    public void Init()
    {
        PECommon.Log("LoginSys Init Peone.");
    }

    public void ReqLogin(GameMsg msg)
    {
        //判断账号是否已经上线
        //已上线：返回错误信息
        //未上线：账号是否存在
        //存在，检测密码
        //不存在，创建默认的账号密码


        //回应客户端 
        //
    }
}
