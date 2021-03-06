﻿using LCL;
using LCL.ComponentModel;
using LCL.Repositories;
using LCL.Repositories.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;

namespace UIShell.RbacPermissionService
{
    public class PluginActivator : LCLPlugin
    {
        public override void Initialize(IApp app)
        {
            app.ModuleOperations += app_ModuleOperations;
            app.AllPluginsIntialized += app_AllPluginsIntialized;
        }
        void app_ModuleOperations(object sender, AppInitEventArgs e)
        {

        }
        void app_AllPluginsIntialized(object sender, System.EventArgs e)
        {
            //DatabaseInitializer.Initialize();
            //设置权限提供程序为本模块中实体类
            PermissionMgr.Provider = new LCLPermissionProvider();

            //ServiceLocator.Instance.Register<DbContext, RbacDbContext>();
            //ServiceLocator.Instance.Register<ILCLIdentity, LCLIdentity>();
            ServiceLocator.Instance.Register<IRepositoryContext, EntityFrameworkRepositoryContext>();
            ServiceLocator.Instance.RegisterType(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

            #region 扩展仓库
            ServiceLocator.Instance.Register<IDepartmentRepository, DepartmentRepository>();
            ServiceLocator.Instance.Register<IDictionaryRepository, DictionaryRepository>();
            ServiceLocator.Instance.Register<IDictTypeRepository, DictTypeRepository>();
            ServiceLocator.Instance.Register<IRoleRepository, RoleRepository>();
            ServiceLocator.Instance.Register<IRoleAuthorityRepository, RoleAuthorityRepository>();
            ServiceLocator.Instance.Register<IScheduledEventsRepository, ScheduledEventsRepository>();
            ServiceLocator.Instance.Register<ITLogRepository, TLogRepository>();
            ServiceLocator.Instance.Register<IUserRepository, UserRepository>();
            ServiceLocator.Instance.Register<IXzqyRepository, XzqyRepository>();
            //ServiceLocator.Instance.Register<ILCLIdentityRepository, LCLIdentityRepository>();

            ServiceLocator.Instance.Register<IWFActorRepository, WFActorRepository>();
            ServiceLocator.Instance.Register<IWFActorUserRepository, WFActorUserRepository>();
            ServiceLocator.Instance.Register<IWFItemRepository, WFItemRepository>();
            ServiceLocator.Instance.Register<IWFRoutRepository, WFRoutRepository>();
            ServiceLocator.Instance.Register<IWFTaskHistoryRepository, WFTaskHistoryRepository>();
            ServiceLocator.Instance.Register<IWFTaskListRepository, WFTaskListRepository>();

            ServiceLocator.Instance.Register<IEDMSRepairsBillRepository, EDMSRepairsBillRepository>();
            ServiceLocator.Instance.Register<IEDMSMaintenanceBillRepository, EDMSMaintenanceBillRepository>();
            ServiceLocator.Instance.Register<IEDMSPartsCostRepository, EDMSPartsCostRepository>();
        
            #endregion
        }
    }
}
