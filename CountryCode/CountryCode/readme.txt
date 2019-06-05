

1、读取csv文件
https://segmentfault.com/a/1190000015396713

2、根据ip查国家编号
https://github.com/stulzq/IPTools/blob/master/README_zh-CN.md

3、判断ip地址是否正确
string ipStr="192.168.222.333";
IPAddress ip;
if(IPAddress.TryParse(ipStr,out ip))
{
   Console.WriterLine("合法IP");
}
else
{
   Console.WriterLine("非法IP");
}
