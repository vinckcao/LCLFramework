﻿using LCL;
using LCL.ComponentModel;
using LCL.MetaModel;
using LCL.MvcExtensions;
using System.Diagnostics;
using UIShell.RbacManagementPlugin.Controllers;

namespace UIShell.RbacManagementPlugin
{
    public class BundleActivator : LCLPlugin
    {
        public override void Initialize(IApp app)
        {
            app.ModuleOperations += app_ModuleOperations;
        }
        void app_ModuleOperations(object sender, System.EventArgs e)
        {
            PageFlowService.PageNodes.AddPageNode(new PageNode
            {
                Name = "LayoutLogin",
                Bundle = this,
                Value = @"UIShell.RbacManagementPlugin\Account\Login",
                Priority = 1
            });
          
            CommonModel.Modules.AddRoot(new MvcModuleMeta
            {
                Label = "与我有关",
                Image = "icon-user",
                Bundle = this,
                Children =
                {
                    new MvcModuleMeta{ Image="icon-user-edit32", Label = "我的任务", CustomUI="/UIShell.RbacManagementPlugin/WFTaskList/Index",EntityType=typeof(DepartmentController)},
                    new MvcModuleMeta{ Image="icon-user-key", Label = "我的审批", CustomUI="/UIShell.RbacManagementPlugin/Role/Index",EntityType=typeof(RoleController)},
                }
            });
            CommonModel.Modules.AddRoot(new MvcModuleMeta
            {
                Label = "组织机构",
                Image = "icon-organ",
                Bundle = this,
                Children =
                {
                    new MvcModuleMeta{ Image="icon-cmy", Label = "单位管理", CustomUI="/UIShell.RbacManagementPlugin/Department/Index",EntityType=typeof(DepartmentController)},
                    new MvcModuleMeta{ Image="icon-group", Label = "角色管理", CustomUI="/UIShell.RbacManagementPlugin/Role/Index",EntityType=typeof(RoleController)},
                    new MvcModuleMeta{ Image="icon-user", Label = "用户管理", CustomUI="/UIShell.RbacManagementPlugin/User/Index",EntityType=typeof(RoleController)},
                    new MvcModuleMeta{ Image="icon-user-group", Label = "群组管理", CustomUI="/UIShell.RbacManagementPlugin/Group/Index",EntityType=typeof(GroupController)},
                    new MvcModuleMeta{ Image="icon-user-group", Label = "用户群组", CustomUI="/UIShell.RbacManagementPlugin/UserGroup/Index",EntityType=typeof(GroupController)},
                    new MvcModuleMeta{ Image="icon-user-group", Label = "角色群组", CustomUI="/UIShell.RbacManagementPlugin/RoleGroup/Index",EntityType=typeof(GroupController)},
                    new MvcModuleMeta{ Image="icon-user-group", Label = "一键导入", CustomUI="/UIShell.RbacManagementPlugin/User/ImportUser"},
                    new MvcModuleMeta{ Image="icon-chart-organisation", Label = "流程定义", CustomUI="/UIShell.RbacManagementPlugin/WFRout/Index",EntityType=typeof(WFRoutController)},
                }
            });
            CommonModel.Modules.AddRoot(new MvcModuleMeta
            {
                Label = "系统管理",
                Image = "icon-wrench",
                Bundle = this,
                Children =
                {
                    new MvcModuleMeta{ Image="icon-cog", Label = "系统设置", CustomUI="/UIShell.RbacManagementPlugin/GeneralConfigInfo/Index",EntityType=typeof(GeneralConfigInfoController)},
                    new MvcModuleMeta{ Image="icon-organ", Label = "行政区域", CustomUI="/UIShell.RbacManagementPlugin/Xzqy/Index",EntityType=typeof(XzqyController)},
                    new MvcModuleMeta{ Image="icon-book", Label = "字典管理", CustomUI="/UIShell.RbacManagementPlugin/DictType/Index",EntityType=typeof(DictTypeController)},
                    new MvcModuleMeta{ Image="icon-time", Label = "计划任务", CustomUI="/UIShell.RbacManagementPlugin/Schedule/Index",EntityType=typeof(ScheduleController)},   
                    new MvcModuleMeta{ Image="icon-server", Label = "文件服务器", CustomUI="/UIShell.RbacManagementPlugin/HostConfig/Index",EntityType=typeof(HostConfigController)},   
                    new MvcModuleMeta{ Image="icon-book", Label = "日志管理", CustomUI="/UIShell.RbacManagementPlugin/TLog/Index",EntityType=typeof(TLogController)},
                }
            });
        }
    }
}
