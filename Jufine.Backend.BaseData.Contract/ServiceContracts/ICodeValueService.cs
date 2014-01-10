using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.BaseLibrary.Entity;
using Com.BaseLibrary.Contract;

using Jufine.Backend.BaseData.DataContracts;

namespace Jufine.Backend.BaseData.ServiceContracts
{
	public interface ICodeValueService: IServiceBase
	{
		
        
        CodeValueInfo Get(Int32 id);
        List<CodeValueInfo> GetAll();
        void Create(CodeValueInfo codeValue);
        void Update(CodeValueInfo codeValue);
        void Delete(Int32 id);
        void BatchDelete(List<Int32> keyList);
        QueryResultInfo<CodeValueInfo> Query(QueryConditionInfo<CodeValueInfo> queryCondition);

        List<CodeValueInfo> GetCodeListByGroupCode(string groupCode);

        List<CodeValueInfo> GetPartCodeListByGroupCode(string groupCode,int codeValue);
        
        CodeValueInfo GetByCode(string groupCode, string codeValue);
    }
}
