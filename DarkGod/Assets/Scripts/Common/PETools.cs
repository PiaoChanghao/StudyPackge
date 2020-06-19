/****************************************************
    文件：PETools.cs
	作者：凌云月
    邮箱: piaoch001@163.com
    日期：2020/6/5 14:38:33
	功能：工具类
*****************************************************/

public class PETools 
{
    public static int RDInt(int min,int max,System.Random rd = null)
    {
        if(rd == null)
        {
            rd = new System.Random();
        }
        int val = rd.Next(min, max + 1);
        return val;
    }
}