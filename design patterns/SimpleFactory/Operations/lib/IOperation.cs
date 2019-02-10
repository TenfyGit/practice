using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.lib
{
    public interface IOperation
    {
        /// <summary>
        /// 获取两个数的运算结果
        /// </summary>
        /// <param name="numberOne">第一个数</param>
        /// <param name="numberTwo">第二个数</param>
        /// <returns></returns>
        double GetResult(double numberOne,double numberTwo);
    }
}
