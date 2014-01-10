
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
	public class CodeValueBL :ICodeValueService
	{
       
		public CodeValueInfo Get(Int32 id)
        {
            try
            {
                return CodeValueDA.DAO.Get(id);
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
                 CodeValueDA.DAO.Delete(id);
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
                CodeValueDA.DAO.BatchDelete(keyList);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
       }
    
        public List<CodeValueInfo> GetAll()
        {
            try
            {
                return CodeValueDA.DAO.GetAll();
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public void Create(CodeValueInfo codeValue)
        {
            try
            {
                CodeValueDA.DAO.Create(codeValue);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }

        public void Update(CodeValueInfo codeValue)
        {
            try
            {
                CodeValueDA.DAO.Update(codeValue);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            }
        }
       public QueryResultInfo<CodeValueInfo> Query(QueryConditionInfo<CodeValueInfo> queryCondition)
       {
           try
            {
               return CodeValueDA.DAO.Query(queryCondition);
            }
            catch (Exception ex)
            {

                throw ExceptionFactory.BuildException(ex);
            } 
       }

       public List<CodeValueInfo> GetCodeListByGroupCode(string groupCode)
       {
           try
           {
               return CodeValueDA.DAO.GetCodeListByGroupCode(groupCode);
           }
           catch (Exception ex)
           {

               throw ExceptionFactory.BuildException(ex);
           }
       }

       public List<CodeValueInfo> GetPartCodeListByGroupCode(string groupCode, int codeValue)
       {
           try
           {
               return CodeValueDA.DAO.GetPartCodeListByGroupCode(groupCode, codeValue);
           }
           catch (Exception ex)
           {

               throw ExceptionFactory.BuildException(ex);
           }
       }

       public CodeValueInfo GetByCode(string groupCode, string codeValue)
       {
           try
           {
               return CodeValueDA.DAO.GetByCode(groupCode, codeValue);
           }
           catch (Exception ex)
           {

               throw ExceptionFactory.BuildException(ex);
           }
       }
    }
}
