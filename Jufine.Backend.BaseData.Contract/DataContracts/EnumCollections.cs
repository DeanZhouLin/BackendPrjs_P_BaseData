using System;
using System.ComponentModel;

namespace Jufine.Backend.BaseData.DataContracts
{
    /// <summary>
    /// 平台枚举（适用平台，来源平台）
    /// Description指定
    /// </summary>
    [Flags]
    public enum PlatformsType
    {
        Empty = 0,//程序运算使用，无实际意义

        [Description("WWW")]
        WWW = 1,
        [Description("WAP")]
        WAP = 2,
        [Description("iOS")]
        iOS = 4,
        [Description("Android")]
        Android = 8
    }
}