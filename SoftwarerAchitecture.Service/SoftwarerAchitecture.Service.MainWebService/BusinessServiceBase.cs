using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Framework;
using Common.Framework.CommonDAL;
using Common.Framework.EntityMaster;
using SoftwarerAchitecture.Models.DbMainInterface;

namespace SoftwarerAchitecture.Service.MainWebService
{
    /// <summary>
    /// 业务数据实体基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessServiceBase<T>
        where T : class, new()
    {
        /// <summary>
        /// 所有业务数据库操作对象  如需执行事务  请调用 SvcAdapter.ExecuteService()委托方法 
        /// </summary>
        [Import]
        public ServiceBase<SoftwarerEntities, T> SvcAdapter { get { return new ServiceBase<SoftwarerEntities, T>(); } }
         

    }
}
