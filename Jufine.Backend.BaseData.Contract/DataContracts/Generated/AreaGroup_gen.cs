using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Com.BaseLibrary.Contract;

namespace Jufine.Backend.BaseData.DataContracts
{
	[Serializable]
	public partial class AreaGroup: DataContractBase
	{	
		public string GroupCode{get;set;}
		public string GroupName{get;set;}
		public Int32 AreaID{get;set;}
		public Int32 Status{get;set;}
		public Int32 DisplayOrder{get;set;}
		public string CreateUser{get;set;}
		public DateTime ? CreateDate{get;set;}
        public DateTime? CreateDateTo{get;set;}
		public string EditUser{get;set;}
		public DateTime ? EditDate{get;set;}
        public DateTime? EditDateTo{get;set;}
		
	}
}