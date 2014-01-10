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
	internal class AreaDA : DataBase<AreaInfo, BaseDataEntities>
	{
		internal static AreaDA DAO = new AreaDA();
		private AreaDA() { }
		protected override void AttachValue(AreaInfo newEntity, AreaInfo oldEntity)
		{
			oldEntity.ParentID = newEntity.ParentID;
			oldEntity.AreaName = newEntity.AreaName;
			oldEntity.ShortName = newEntity.ShortName;
			oldEntity.AreaCode = newEntity.AreaCode;
			oldEntity.AreaPath = newEntity.AreaPath;
			oldEntity.DisplayOrder = newEntity.DisplayOrder;
			oldEntity.Status = newEntity.Status;
			oldEntity.CreateUser = newEntity.CreateUser;
			oldEntity.CreateDate = newEntity.CreateDate;
			oldEntity.EditUser = newEntity.EditUser;
			oldEntity.EditDate = newEntity.EditDate;
		}
		protected override IQueryable<AreaInfo> SetWhereClause(QueryConditionInfo<AreaInfo> queryCondition, IQueryable<AreaInfo> query)
		{
			if (queryCondition.Condtion.ID > 0)
			{
				query = query.Where(c => c.ID == queryCondition.Condtion.ID);
			}
			if (queryCondition.Condtion.ParentID >= 0)
			{
				query = query.Where(c => c.ParentID == queryCondition.Condtion.ParentID);
			}
			if (!string.IsNullOrEmpty(queryCondition.Condtion.AreaName))
			{
				query = query.Where(c => c.AreaName.StartsWith(queryCondition.Condtion.AreaName));
			}
			if (!string.IsNullOrEmpty(queryCondition.Condtion.ShortName))
			{
				query = query.Where(c => c.ShortName.StartsWith(queryCondition.Condtion.ShortName));
			}
			if (!string.IsNullOrEmpty(queryCondition.Condtion.AreaCode))
			{
				query = query.Where(c => c.AreaCode.StartsWith(queryCondition.Condtion.AreaCode));
			}
			if (!string.IsNullOrEmpty(queryCondition.Condtion.AreaPath))
			{
				query = query.Where(c => c.AreaPath.StartsWith(queryCondition.Condtion.AreaPath));
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
		protected override IQueryable<AreaInfo> SetOrder(QueryConditionInfo<AreaInfo> queryCondition, IQueryable<AreaInfo> query)
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
					if (item.FieldName == "ParentID")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.ParentID);
						}
						else
						{
							query = query.OrderByDescending(c => c.ParentID);
						}
					}
					if (item.FieldName == "AreaName")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.AreaName);
						}
						else
						{
							query = query.OrderByDescending(c => c.AreaName);
						}
					}
					if (item.FieldName == "ShortName")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.ShortName);
						}
						else
						{
							query = query.OrderByDescending(c => c.ShortName);
						}
					}
					if (item.FieldName == "AreaCode")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.AreaCode);
						}
						else
						{
							query = query.OrderByDescending(c => c.AreaCode);
						}
					}
					if (item.FieldName == "AreaPath")
					{
						if (item.OrderDirection == OrderDirection.ASC)
						{
							query = query.OrderBy(c => c.AreaPath);
						}
						else
						{
							query = query.OrderByDescending(c => c.AreaPath);
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
		public void ChangeStatus(AreaInfo entity)
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<AreaInfo> objectSet = entities.CreateObjectSet<AreaInfo>();
				objectSet.Update(c => c.ID == entity.ID, c => new AreaInfo
				{
					EditUser = entity.EditUser,
					EditDate = DateTime.Now,
					Status = entity.Status
				});

				//AreaInfo AreaInfo = objectSet.FirstOrDefault(c => c.ID == entity.ID);
				//if (AreaInfo != null)
				//{
				//    AreaInfo.EditUser = entity.EditUser;
				//    AreaInfo.EditDate = DateTime.Now;
				//    AreaInfo.Status = entity.Status;
				//    entities.SaveChanges();
				//}
			}
		}

		internal List<FlatAreaData> GetAllFlatAreaData()
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<FlatAreaData> objectSet = entities.CreateObjectSet<FlatAreaData>();
				return objectSet.ToList();
			}
		}

		public override void Create(AreaInfo area)
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<AreaInfo> objectSet = entities.CreateObjectSet<AreaInfo>();
				objectSet.AddObject(area);
				entities.SaveChanges();
				area.AreaCode = area.ID.ToString();
				area.AreaPath = area.AreaPath + "," + area.ID.ToString();
				entities.SaveChanges();
			}
		}

		//internal AreaInfo GetAreaByName(string areaName, int parentId)
		//{

		//    using (BaseDataEntities entities = new BaseDataEntities())
		//    {
		//        ObjectSet<AreaInfo> objectSet = entities.CreateObjectSet<AreaInfo>();
		//        return objectSet.FirstOrDefault(c => c.AreaName == areaName && c.ParentID == parentId);
		//    }
		//}
		internal void GenerateArea()
		{
			List<FlatAreaData> FlatAreaDataList = AreaDA.DAO.GetAllFlatAreaData();
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<AreaInfo> areaObjectSet = entities.CreateObjectSet<AreaInfo>();

				List<string> provinceNameList = FlatAreaDataList.GroupBy(c => c.ProvinceName).Select(c => c.Key).ToList();

				AreaInfo china = new AreaInfo { ID = 0, AreaPath = "0", AreaName = "China" };

				List<AreaInfo> provinceList = CreateChildrenAreaList(china, provinceNameList, entities, areaObjectSet);

				foreach (AreaInfo province in provinceList)
				{
					List<string> cityNameList = FlatAreaDataList
						.FindAll(c => c.ProvinceName == province.AreaName)
						.GroupBy(c => c.CityName)
						.Select(c => c.Key)
						.ToList();

					List<AreaInfo> cityList = CreateChildrenAreaList(province, cityNameList, entities, areaObjectSet);
					foreach (AreaInfo city in cityList)
					{
						List<string> distinctNameList = FlatAreaDataList
						        .FindAll(c => c.ProvinceName == province.AreaName && c.CityName == city.AreaName)
						        .GroupBy(c => c.DistinctName)
						        .Select(c => c.Key)
						        .ToList();

						List<AreaInfo> distinctList = CreateChildrenAreaList(city, distinctNameList, entities, areaObjectSet);

						foreach (AreaInfo distinct in distinctList)
						{
							List<string> townNameList = FlatAreaDataList
							.FindAll(c => c.ProvinceName == province.AreaName && c.CityName == city.AreaName && c.DistinctName == distinct.AreaName)
							.GroupBy(c => c.TownName)
							.Select(c => c.Key)
							.ToList();
							List<AreaInfo> townList = CreateChildrenAreaList(distinct, townNameList, entities, areaObjectSet);

						}
					}
				}
			}
		}
		private static List<AreaInfo> CreateChildrenAreaList(AreaInfo parentArea,
            List<string> childrenAreaNameList,
            BaseDataEntities entities,
            ObjectSet<AreaInfo> areaObjectSet)
		{
			List<AreaInfo> areaList = new List<AreaInfo>();
			foreach (string areaName in childrenAreaNameList)
			{
                //AreaInfo area = areaObjectSet.FirstOrDefault(c => c.AreaName == areaName && c.ParentID == parentArea.ID);
				AreaInfo area = null;
				if (area == null)
				{
					area = new AreaInfo();
					area.AreaName = areaName;
					area.ParentID = parentArea.ID;
					area.AreaPath = parentArea.AreaPath;
					areaObjectSet.AddObject(area);
					entities.SaveChanges();
					//area.AreaCode = area.ID.ToString();
					//area.AreaPath = area.AreaPath + "," + area.ID.ToString();
					//entities.SaveChanges();
				}
				areaList.Add(area);
			}
			return areaList;
		}

		internal List<AreaInfo> GetAreaByParentID(int parentID)
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<AreaInfo> objectSet = entities.CreateObjectSet<AreaInfo>();
				return objectSet.Where(c => c.ParentID == parentID).ToList();
			}
		}

		internal List<UVAreaInfo> GetAllUVAreaInfo()
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<UVAreaInfo> objectSet = entities.CreateObjectSet<UVAreaInfo>();
				return objectSet.ToList();
			}
		}

		internal UVAreaInfo GetAreaByName(string provinceName, string cityName, string areaName)
		{
			using (BaseDataEntities entities = new BaseDataEntities())
			{
				ObjectSet<UVAreaInfo> objectSet = entities.CreateObjectSet<UVAreaInfo>();
				return objectSet.FirstOrDefault(c => c.ProvinceName == provinceName && c.CityName == cityName && c.AreaName == areaName);
			}
		}
	}
}
