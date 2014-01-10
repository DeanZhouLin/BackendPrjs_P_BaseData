using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.BaseLibrary.Entity;
using Com.BaseLibrary.Contract;

using Jufine.Backend.BaseData.DataContracts;

namespace Jufine.Backend.BaseData.ServiceContracts
{
	public interface IAreaGroupService: IServiceBase
	{
		
        
        AreaGroup Get(Int32 id);
        List<AreaGroup> GetAll();
        void Create(AreaGroup areaGroup);
        void Update(AreaGroup areaGroup);
        void Delete(Int32 id);
        void BatchDelete(List<Int32> keyList);
        QueryResultInfo<AreaGroup> Query(QueryConditionInfo<AreaGroup> queryCondition);
    }
}
