using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Objects;
using Com.BaseLibrary.Utility;
using Com.BaseLibrary.Common.Cryptography;

namespace Jufine.Backend.BaseData.DataAccess
{
    #region 上下文

    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class BaseDataEntities : ObjectContext
    {
        private static string connectionstring;
        static BaseDataEntities()
        {
            connectionstring = ConfigurationHelper.GetConnectionString("BaseDataEntities");
            if (!connectionstring.StartsWith("metadata="))
            {
                connectionstring = Encryptor.Decrypt(connectionstring);
            }
        }

        /// <summary>
        /// 请使用应用程序配置文件的“SecurityEntities”部分中的连接字符串初始化新 SecurityEntities 对象。
        /// </summary>
        public BaseDataEntities()
            : base(new EntityConnection(connectionstring),"BaseDataEntities")
        {

        }

      
    }


    #endregion
}
