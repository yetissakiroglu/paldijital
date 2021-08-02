using Autofac;
using Castle.DynamicProxy;
using Eticaret.Core.Utilities.Interceptors;
using Autofac.Extras.DynamicProxy;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore;
using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Concrete.Managers;
using Pal.Core.EmailServices.Concrete;
using Pal.Core.EmailServices;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Business.Abstract.UI;
using Eticaret.Business.Concrete.Managers.UI;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.UI;
using Eticaret.Business.Concrete.Managers.Admin;

namespace Eticaret.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Web Kısmı
            //Haber Kısmı
            builder.RegisterType<NewsWebManager>().As<INewsWebService>();
            builder.RegisterType<EfNewsWebDal>().As<INewsWebDal>();

        
            //Radio Api Kısmı
            builder.RegisterType<RadioApiWebManager>().As<IRadioApiWebService>();
            builder.RegisterType<EfRadioApiWebDal>().As<IRadioApiWebDal>();

            //Radio Kısmı
            builder.RegisterType<RadioWebManager>().As<IRadioWebService>();
            builder.RegisterType<EfRadioWebDal>().As<IRadioWebDal>();

            //Bildir Kısmı
            builder.RegisterType<BildirWebManager>().As<IBildirWebService>();
            builder.RegisterType<EfBildirWebDal>().As<IBildirWebDal>();

            //İletişim kısmı
            builder.RegisterType<ContactsWebManager>().As<IContactsWebService>();
            builder.RegisterType<EfContactsWebDal>().As<IContactsWebDal>();
          
            //Podcast kısmı
            builder.RegisterType<PodcastWebManager>().As<IPodcastWebService>();
            builder.RegisterType<EfPodcastWebDal>().As<IPodcastWebDal>();

            

            //Ayarlar Kısmı
            builder.RegisterType<SettingManager>().As<ISettingService>();
            builder.RegisterType<EfSettingDal>().As<ISettingDal>();

            //Radyo Kısmı
            builder.RegisterType<RadioManager>().As<IRadioService>();
            builder.RegisterType<EfRadioDal>().As<IRadioDal>();

            //Radyo Kategori Kısmı
            builder.RegisterType<RadioCategoryManager>().As<IRadioCategoryService>();
            builder.RegisterType<EfRadioCategoryDal>().As<IRadioCategoryDal>();

            builder.RegisterType<RadioApiManager>().As<IRadioApiService>();
            builder.RegisterType<EfRadioApiDal>().As<IRadioApiDal>();

            //Banner Kısmı
            builder.RegisterType<BannerManager>().As<IBannerService>();
            builder.RegisterType<EfBannerDal>().As<IBannerDal>();

            //Haber Kısmı
            builder.RegisterType<NewsManager>().As<INewsService>();
            builder.RegisterType<EfNewsDal>().As<INewsDal>();

            //Haber Kategori Kısmı
            builder.RegisterType<NewsCategoryManager>().As<INewsCategoryService>();
            builder.RegisterType<EfNewsCategoryDal>().As<INewsCategoryDal>();

            //Program
            builder.RegisterType<ProgramManager>().As<IProgramService>();
            builder.RegisterType<EfProgramDal>().As<IProgramDal>();

            //Dj
            builder.RegisterType<DjManager>().As<IDjService>();
            builder.RegisterType<EfDjDal>().As<IDjDal>();
           
            //Listeler
            builder.RegisterType<TopMusicListManager>().As<ITopMusicListService>();
            builder.RegisterType<EfTopMusicListDal>().As<ITopMusicListDal>();

            //Listeler Müzik
            builder.RegisterType<MusicListManager>().As<IMusicListService>();
            builder.RegisterType<EfMusicListDal>().As<IMusicListDal>();


            //Frekanslar
            builder.RegisterType<FrequencyManager>().As<IFrequencyService>();
            builder.RegisterType<EfFrequencyDal>().As<IFrequencyDal>();

            //Podcasts
            builder.RegisterType<PodcastMusicListManager>().As<IPodcastMusicListService>();
            builder.RegisterType<EfPodcastMusicListDal>().As<IPodcastMusicListDal>();

            //Page
            builder.RegisterType<PageManager>().As<IPageService>();
            builder.RegisterType<EfPageDal>().As<IPageDal>();

            //Seo
            builder.RegisterType<SeoManager>().As<ISeoService>();
            builder.RegisterType<EfSeoDal>().As<ISeoDal>();

            //Yayın Akışı
            builder.RegisterType<BroadcastManager>().As<IBroadcastService>();
            builder.RegisterType<EfBroadcastDal>().As<IBroadcastDal>();


            //Role Bağlı Claims
            builder.RegisterType<RoleClaimsManager>().As<IRoleClaimsService>();
            builder.RegisterType<EfRoleClaimsDal>().As<IRoleClaimsDal>();




            //E-Mail Gönderme
            builder.RegisterType<StmpMailSender>().As<IEmailSender>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
