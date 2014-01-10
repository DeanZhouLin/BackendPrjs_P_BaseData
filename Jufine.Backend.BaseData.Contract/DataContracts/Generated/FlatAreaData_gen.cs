using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Com.BaseLibrary.Contract;

namespace Jufine.Backend.BaseData.DataContracts
{
	[Serializable]
	public partial class FlatAreaData : DataContractBase
	{
		public string AreaID { get; set; }
		public string ProvinceName { get; set; }
		public string CityName { get; set; }
		public string DistinctName { get; set; }
		public string TownName { get; set; }
	}
}