using System;
using System.Text;
using System.Collections.Generic;

using Com.BaseLibrary.Contract;

namespace  Jufine.Backend.BaseData.DataContracts
{
    [Serializable]
    public class UVAreaInfo : DataContractBase
    {
        public Int32 ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public Int32 CityID { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }

		
    }
}