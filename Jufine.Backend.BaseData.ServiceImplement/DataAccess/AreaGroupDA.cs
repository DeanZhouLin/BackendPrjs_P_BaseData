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
	internal class AreaGroupDA: DataBase<AreaGroup, BaseDataEntities>
	{
        internal static AreaGroupDA DAO = new AreaGroupDA();
		private AreaGroupDA(){ }
        protected override void AttachValue(AreaGroup newEntity, AreaGroup oldEntity)
		{
            oldEntity.GroupCode = newEntity.GroupCode;
            oldEntity.GroupName = newEntity.GroupName;
            oldEntity.AreaID = newEntity.AreaID;
            oldEntity.Status = newEntity.Status;
            oldEntity.DisplayOrder = newEntity.DisplayOrder;
            oldEntity.CreateUser = newEntity.CreateUser;
            oldEntity.CreateDate = newEntity.CreateDate;
            oldEntity.EditUser = newEntity.EditUser;
            oldEntity.EditDate = newEntity.EditDate;
		}
        protected override IQueryable<AreaGroup> SetWhereClause(QueryConditionInfo<AreaGroup> queryCondition, IQueryable<AreaGroup> query)
		{
                        if(queryCondition.Condtion.ID > 0)
                        {
                            query = query.Where(c => c.ID==queryCondition.Condtion.ID);
                        }
                        if(!string.IsNullOrEmpty( queryCondition.Condtion.GroupCode ))
                        {
                           query = query.Where(c => c.GroupCode.StartsWith(queryCondition.Condtion.GroupCode));
                        }
                        if(!string.IsNullOrEmpty( queryCondition.Condtion.GroupName ))
                        {
                           query = query.Where(c => c.GroupName.StartsWith(queryCondition.Condtion.GroupName));
                        }
                        if(queryCondition.Condtion.AreaID > 0)
                        {
                            query = query.Where(c => c.AreaID==queryCondition.Condtion.AreaID);
                        }
                        if(queryCondition.Condtion.Status > 0)
                        {
                            query = query.Where(c => c.Status==queryCondition.Condtion.Status);
                        }
                        if(queryCondition.Condtion.DisplayOrder > 0)
                        {
                            query = query.Where(c => c.DisplayOrder==queryCondition.Condtion.DisplayOrder);
                        }
                        if(!string.IsNullOrEmpty( queryCondition.Condtion.CreateUser ))
                        {
                           query = query.Where(c => c.CreateUser.StartsWith(queryCondition.Condtion.CreateUser));
                        }
                        if(queryCondition.Condtion.CreateDate!=null)
                        {
                           query = query.Where(c => c.CreateDate>queryCondition.Condtion.CreateDate);
                        }
                        if(queryCondition.Condtion.CreateDateTo!=null)
                        {
                           query = query.Where(c => c.CreateDate <=queryCondition.Condtion.CreateDateTo);
                        }
                        if(!string.IsNullOrEmpty( queryCondition.Condtion.EditUser ))
                        {
                           query = query.Where(c => c.EditUser.StartsWith(queryCondition.Condtion.EditUser));
                        }
                        if(queryCondition.Condtion.EditDate!=null)
                        {
                           query = query.Where(c => c.EditDate>queryCondition.Condtion.EditDate);
                        }
                        if(queryCondition.Condtion.EditDateTo!=null)
                        {
                           query = query.Where(c => c.EditDate <=queryCondition.Condtion.EditDateTo);
                        }
                return query;
		}
        protected override IQueryable<AreaGroup> SetOrder(QueryConditionInfo<AreaGroup> queryCondition, IQueryable<AreaGroup> query)
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
					if (item.FieldName == "AreaID")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.AreaID);
						}
						else
						{
							query = query.OrderByDescending(c => c.AreaID);
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
        public void ChangeStatus(AreaGroup entity)
		{
			using ( BaseDataEntities entities = new  BaseDataEntities())
			{
				ObjectSet<AreaGroup> objectSet = entities.CreateObjectSet<AreaGroup>();
				AreaGroup AreaGroup = objectSet.FirstOrDefault(c => c.ID == entity.ID);
				if (AreaGroup != null)
				{
					AreaGroup.EditUser = entity.EditUser;
					AreaGroup.EditDate = DateTime.Now;
					AreaGroup.Status = entity.Status;
					entities.SaveChanges();
				}
			}
		}
    }
}
