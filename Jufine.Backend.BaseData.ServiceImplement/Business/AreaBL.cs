
using System;
using System.Linq;
using System.Collections.Generic;

using Com.BaseLibrary.Utility;
using Com.BaseLibrary.Entity;
using Com.BaseLibrary.ExceptionHandle;
using Jufine.Backend.BaseData.DataContracts;
using Jufine.Backend.BaseData.ServiceContracts;
using Jufine.Backend.BaseData.DataAccess;

namespace Jufine.Backend.BaseData.Business
{
	public class AreaBL : IAreaService
	{

		public AreaInfo Get(Int32 id)
		{
			try
			{
				return AreaDA.DAO.Get(id);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}
		public void Delete(Int32 id)
		{
			try
			{
				AreaDA.DAO.Delete(id);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}
		public void BatchDelete(List<Int32> keyList)
		{
			try
			{
				AreaDA.DAO.BatchDelete(keyList);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}

		public List<AreaInfo> GetAll()
		{
			try
			{
				return AreaDA.DAO.GetAll();
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}

		public void Create(AreaInfo area)
		{
			try
			{
				AreaDA.DAO.Create(area);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}

		public void Update(AreaInfo area)
		{
			try
			{
				AreaDA.DAO.Update(area);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}
		public QueryResultInfo<AreaInfo> Query(QueryConditionInfo<AreaInfo> queryCondition)
		{
			try
			{
				return AreaDA.DAO.Query(queryCondition);
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}





		public void GenerateArea()
		{
			try
			{
				AreaDA.DAO.GenerateArea();
				
			}
			catch (Exception ex)
			{

				throw ExceptionFactory.BuildException(ex);
			}
		}

        public List<AreaInfo> GetAreaByParentID(int parentID)
        {
            try
            {
                return AreaDA.DAO.GetAreaByParentID(parentID);

            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public List<UVAreaInfo> GetAllUVAreaInfo()
        {
            try
            {
                return AreaDA.DAO.GetAllUVAreaInfo();
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public UVAreaInfo GetAreaByName(string provinceName, string cityName, string areaName)
        {
            try
            {
                return AreaDA.DAO.GetAreaByName(provinceName, cityName,areaName);

            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }
	}
}
