/*************************************************************
    文件：ServerStart.cs
    作者：凌云月
    邮箱：piaoch001@163.com
    日期：2020/6/8 13:30
    功能：服务器初始化
 *************************************************************/
public class ServerRoot
{
    private static ServerRoot instance = null;
    public static ServerRoot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServerRoot();
            }
            return instance;
        }
    }
    public void Init()
    {
        //数据层TODO

        //服务层
        CacheSvc.Instance.init();
        NetSvc.Instance.Init();


        //业务系统层
        LoginSys.Instance.Init();

    }

    public void Update()
    {
        NetSvc.Instance.Update();
    }
}
