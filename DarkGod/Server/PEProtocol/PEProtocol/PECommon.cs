/****************************************************
	文件：PECommon.cs
	作者：凌云月
	邮箱: piaoch001@163.com
	日期：2020/06/18 13:35   	
	功能：客户端服务端共用工具类
*****************************************************/
using PENet;

public enum LogType
{
    Log = 0,
    Warn = 1,
    Error = 2,
    Info = 3
}

public class PECommon
{


    public static void Log(string msg = "", LogType tp = LogType.Log)
    {
        LogLevel lv = (LogLevel)tp;
        PETool.LogMsg(msg, lv);
    }
}
