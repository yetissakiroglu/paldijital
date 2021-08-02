using Autofac;
using Eticaret.Core.Services.FileManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.DependencyResolvers.Autofac
{
    public class FileManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileManager>().As<IFileManager>();
        }
    }
}
