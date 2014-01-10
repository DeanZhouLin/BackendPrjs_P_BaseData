using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.BaseLibrary.Entity;
using Com.BaseLibrary.Contract;

using Jufine.Backend.BaseData.DataContracts;

namespace Jufine.Backend.BaseData.ServiceContracts
{
	public interface IAreaService: IServiceBase
	{
		
        
        AreaInfo Get(Int32 id);
        List<AreaInfo> GetAll();
        void Create(AreaInfo area);
        void Update(AreaInfo area);
        void Delete(Int32 id);
        void BatchDelete(List<Int32> keyList);
        QueryResultInfo<AreaInfo> Query(QueryConditionInfo<AreaInfo> queryCondition);

		void GenerateArea();

        List<AreaInfo> GetAreaByParentID(int parentID);

        List<UVAreaInfo> GetAllUVAreaInfo();


        UVAreaInfo GetAreaByName(string provinceName, string cityName, string areaName);
    }
}
