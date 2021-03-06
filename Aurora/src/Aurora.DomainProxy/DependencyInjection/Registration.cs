﻿using Aurora.DomainProxy.Proxies;
using Aurora.DomainProxy.Proxies.Interfaces;
using Autofac;

namespace Aurora.DomainProxy.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Domain.DependencyInjection.Registration());

            builder.RegisterType<UserAuthDomainServiceProxy>().As<IUserAuthDomainServiceProxy>();
            builder.RegisterType<UserDomainServiceProxy>().As<IUserDomainServiceProxy>();
            builder.RegisterType<ProjectDomainServiceProxy>().As<IProjectDomainServiceProxy>();
            builder.RegisterType<SprintDomainServiceProxy>().As<ISprintDomainServiceProxy>();
            builder.RegisterType<BacklogItemDomainServiceProxy>().As<IBacklogItemDomainServiceProxy>();
            builder.RegisterType<TaskDomainServiceProxy>().As<ITaskDomainServiceProxy>();
        }
    }
}
