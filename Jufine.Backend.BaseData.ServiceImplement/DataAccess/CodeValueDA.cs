using System;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Collections.Generic;

using Com.BaseLibrary.Service;
using Com.BaseLibrary.Data;
using Com.BaseLibrary.Entity;

using Jufine.Backend.BaseData.DataContracts;
using Jufine.Backend.BaseData.DataAccess;

namespace Jufine.Backend.BaseData.DataAccess
{
    internal class CodeValueDA : DataBase<CodeValueInfo, BaseDataEntities>
    {
        internal static CodeValueDA DAO = new CodeValueDA();
        private CodeValueDA() { }
        protected override void AttachValue(CodeValueInfo newEntity, CodeValueInfo oldEntity)
        {
            oldEntity.CodeValue = newEntity.CodeValue;
            oldEntity.CodeText = newEntity.CodeText;
            oldEntity.GroupCode = newEntity.GroupCode;
            oldEntity.GroupName = newEntity.GroupName;
            oldEntity.DisplayOrder = newEntity.DisplayOrder;
            oldEntity.Status = newEntity.Status;
            oldEntity.CreateUser = newEntity.CreateUser;
            oldEntity.CreateDate = newEntity.CreateDate;
            oldEntity.EditUser = newEntity.EditUser;
            oldEntity.EditDate = newEntity.EditDate;
        }
        protected override IQueryable<CodeValueInfo> SetWhereClause(QueryConditionInfo<CodeValueInfo> queryCondition, IQueryable<CodeValueInfo> query)
        {
            if (queryCondition.Condtion.ID > 0)
            {
                query = query.Where(c => c.ID == queryCondition.Condtion.ID);
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.CodeValue))
            {
                query = query.Where(c => c.CodeValue.StartsWith(queryCondition.Condtion.CodeValue));
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.CodeText))
            {
                query = query.Where(c => c.CodeText.StartsWith(queryCondition.Condtion.CodeText));
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.GroupCode))
            {
                query = query.Where(c => c.GroupCode.StartsWith(queryCondition.Condtion.GroupCode));
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.GroupName))
            {
                query = query.Where(c => c.GroupName.StartsWith(queryCondition.Condtion.GroupName));
            }
            if (queryCondition.Condtion.DisplayOrder > 0)
            {
                query = query.Where(c => c.DisplayOrder == queryCondition.Condtion.DisplayOrder);
            }
            if (queryCondition.Condtion.Status > 0)
            {
                query = query.Where(c => c.Status == queryCondition.Condtion.Status);
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.CreateUser))
            {
                query = query.Where(c => c.CreateUser.StartsWith(queryCondition.Condtion.CreateUser));
            }
            if (queryCondition.Condtion.CreateDate != null)
            {
                query = query.Where(c => c.CreateDate > queryCondition.Condtion.CreateDate);
            }
            if (queryCondition.Condtion.CreateDateTo != null)
            {
                query = query.Where(c => c.CreateDate <= queryCondition.Condtion.CreateDateTo);
            }
            if (!string.IsNullOrEmpty(queryCondition.Condtion.EditUser))
            {
                query = query.Where(c => c.EditUser.StartsWith(queryCondition.Condtion.EditUser));
            }
            if (queryCondition.Condtion.EditDate != null)
            {
                query = query.Where(c => c.EditDate > queryCondition.Condtion.EditDate);
            }
            if (queryCondition.Condtion.EditDateTo != null)
            {
                query = query.Where(c => c.EditDate <= queryCondition.Condtion.EditDateTo);
            }
            return query;
        }
        protected override IQueryable<CodeValueInfo> SetOrder(QueryConditionInfo<CodeValueInfo> queryCondition, IQueryable<CodeValueInfo> query)
        {
            int count = queryCondition.OrderFileds.Count;
            if (count > 0)
            {
                for (int i = count; i > 0; i--)
                {
                    OrderFiledInfo item = queryCondition.OrderFileds[i - i];
                    if (item.FieldName == "ID")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.ID);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.ID);
                        }
                    }
                    if (item.FieldName == "CodeValue")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.CodeValue);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.CodeValue);
                        }
                    }
                    if (item.FieldName == "CodeText")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.CodeText);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.CodeText);
                        }
                    }
                    if (item.FieldName == "GroupCode")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.GroupCode);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.GroupCode);
                        }
                    }
                    if (item.FieldName == "GroupName")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.GroupName);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.GroupName);
                        }
                    }
                    if (item.FieldName == "DisplayOrder")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.DisplayOrder);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.DisplayOrder);
                        }
                    }
                    if (item.FieldName == "Status")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.Status);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.Status);
                        }
                    }
                    if (item.FieldName == "CreateUser")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.CreateUser);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.CreateUser);
                        }
                    }
                    if (item.FieldName == "CreateDate")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.CreateDate);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.CreateDate);
                        }
                    }
                    if (item.FieldName == "EditUser")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.EditUser);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.EditUser);
                        }
                    }
                    if (item.FieldName == "EditDate")
                    {
                        if (item.OrderDirection == OrderDirection.ASC)
                        {
                            query = query.OrderBy(c => c.EditDate);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.EditDate);
                        }
                    }
                }
            }
            else
            {
                query = query.OrderByDescending(c => c.ID);
            }
            return query;
        }
        public void ChangeStatus(CodeValueInfo entity)
        {
            using (BaseDataEntities entities = new BaseDataEntities())
            {
                ObjectSet<CodeValueInfo> objectSet = entities.CreateObjectSet<CodeValueInfo>();
                CodeValueInfo CodeValueInfo = objectSet.FirstOrDefault(c => c.ID == entity.ID);
                if (CodeValueInfo != null)
                {
                    CodeValueInfo.EditUser = entity.EditUser;
                    CodeValueInfo.EditDate = DateTime.Now;
                    CodeValueInfo.Status = entity.Status;
                    entities.SaveChanges();
                }
            }
        }

        internal List<CodeValueInfo> GetCodeListByGroupCode(string groupCode)
        {
            using (BaseDataEntities entities = new BaseDataEntities())
            {
                ObjectSet<CodeValueInfo> objectSet = entities.CreateObjectSet<CodeValueInfo>();
                return objectSet.Where(c => c.GroupCode == groupCode && c.Status == 1).OrderBy(c => c.DisplayOrder).ToList();
            }
        }

        internal List<CodeValueInfo> GetPartCodeListByGroupCode(string groupCode, int codeValue)
        {
            using (BaseDataEntities entities = new BaseDataEntities())
            {
                ObjectSet<CodeValueInfo> CodeValueInfo = entities.CreateObjectSet<CodeValueInfo>();
                return CodeValueInfo.Where(c => c.GroupCode == groupCode && c.Status == 1 && int.Parse(c.CodeValue) < codeValue).OrderBy(c => c.DisplayOrder).ToList();
            }
        }
        internal CodeValueInfo GetByCode(string groupCode, string codeValue)
        {
            using (BaseDataEntities entities = new BaseDataEntities())
            {
                ObjectSet<CodeValueInfo> objectSet = entities.CreateObjectSet<CodeValueInfo>();
                return objectSet.FirstOrDefault(c => c.GroupCode == groupCode && c.CodeValue == codeValue);
            }
        }
    }
}
