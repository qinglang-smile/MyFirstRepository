using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    /// <summary>
    /// 背景：（老师：刷牙,洗脸,吃东西,交通工具） & (学生：刷牙,洗脸,吃东西,交通工具)
    /// </summary>
    public abstract class Person
    {
        public void EatProcess()
        {
            //第一步:角色
            Role();
            //第二步:刷牙
            BrushingTeeth();
            //第三步:洗脸
            WashFace();
            //第四步:吃东西
            EatBreakfast();
            //第五步:上班工具
            Transportation();
        }
        //第一步:不同角色
        public abstract void Role();
        
        //第二步:刷牙一样,直接实现
        private void BrushingTeeth()
        {
            Console.WriteLine("刷牙");
        }
        //第三步:洗脸一样,直接实现
        private void WashFace()
        {
            Console.WriteLine("洗脸");
        }
        //第四步:吃东西不一样,一个吃三明治,一个吃包子
        public abstract void EatBreakfast();

        //第五步:上班工具不一样,一个开车,一个坐校车
        public abstract void Transportation();

    }
}
