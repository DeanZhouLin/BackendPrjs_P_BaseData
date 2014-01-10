using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Com.BaseLibrary.Contract;

namespace Jufine.Backend.BaseData.DataContracts
{
	[Serializable]
	public partial class AreaInfo: DataContractBase
	{	
		public Int32 ParentID{get;set;}
		public string AreaName{get;set;}
		public string ShortName{get;set;}
		public string AreaCode{get;set;}
		public string AreaPath{get;set;}
		public Int32 DisplayOrder{get;set;}
		public Int32 Status{get;set;}
		public string CreateUser{get;set;}
		public DateTime ? CreateDate{get;set;}
        public DateTime? CreateDateTo{get;set;}
		public string EditUser{get;set;}
		public DateTime ? EditDate{get;set;}
        public DateTime? EditDateTo{get;set;}
		
	}
}