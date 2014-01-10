
using System;
using System.Collections.Generic;

using Com.BaseLibrary.Utility;
using Com.BaseLibrary.Entity;
using Com.BaseLibrary.ExceptionHandle;
using Jufine.Backend.BaseData.DataContracts;
using Jufine.Backend.BaseData.ServiceContracts;
using Jufine.Backend.BaseData.DataAccess;

namespace Jufine.Backend.BaseData.Business
{
	public class AreaGroupBL :IAreaGroupService
	{
       
		public AreaGroup Get(Int32 id)
        {
            try
            {
                return AreaGroupDA.DAO.Get(id);
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
                 AreaGroupDA.DAO.Delete(id);
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
                AreaGroupDA.DAO.BatchDelete(keyList);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
       }
    
        public List<AreaGroup> GetAll()
        {
            try
            {
                return AreaGroupDA.DAO.GetAll();
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public void Create(AreaGroup areaGroup)
        {
            try
            {
                AreaGroupDA.DAO.Create(areaGroup);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public void Update(AreaGroup areaGroup)
        {
            try
            {
                AreaGroupDA.DAO.Update(areaGroup);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }
       public QueryResultInfo<AreaGroup> Query(QueryConditionInfo<AreaGroup> queryCondition)
       {
           try
            {
               return AreaGroupDA.DAO.Query(queryCondition);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            } 
       }
    
       

    }
}
