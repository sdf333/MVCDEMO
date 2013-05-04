using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using Contract;
using DataBase;
using SDF.Core.Caching;
using SDF.Core.Fakes;
using SDF.Core.Infrastructure;
using SDF.Core.Infrastructure.DependencyManagement;
using SDFAuth.Data;
using SDFAuth.Services;

//using SDF.Core.Plugins;
//using SDF.Data;

namespace SDFAuthV2.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(SDFEngine.Container));
            //DependencyResolver.SetResolver(new SDFDependencyResolver());
            
            //HTTP context and other related stuff
            builder.Register(c => 
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();

            //web helper
            //builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();

            //Register Model Binders
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

           
            var contextList = typeFinder.FindClassesOfType<BaseDbContext>(true);
            foreach (var type in contextList)
            {
                var dbname = type.Name.Replace("Entities","");
                if (ConfigurationManager.ConnectionStrings[dbname] == null)
                {
                    continue;
                    
                }
                RegisterDB(builder, type, typeFinder);
            }
            
            ////plugins
            ////builder.RegisterType<PluginFinder>().As<IPluginFinder>().InstancePerHttpRequest();

            //cache manager
            builder.RegisterType<CacheManager>().As<ICacheManager>().Named<ICacheManager>("sdf_cache_static").SingleInstance();
            //builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("sdf_cache_per_request").InstancePerHttpRequest();

            //wcf service 
            RegisterWCFService<IAccount>(builder);

            ////work context
            //builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();


          //  builder.RegisterType<ApplicationService>().As<IApplicationService>().InstancePerHttpRequest();
            //services
            var services = typeFinder.FindClassesOfType<BaseService>().ToList();
            services.ForEach(s => builder.RegisterType(s).AsImplementedInterfaces().InstancePerHttpRequest().PropertiesAutowired());
            


            //builder.RegisterType<BackInStockSubscriptionService>().As<IBackInStockSubscriptionService>().InstancePerHttpRequest();
            //builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerHttpRequest();
            //builder.RegisterType<CompareProductsService>().As<ICompareProductsService>().InstancePerHttpRequest();
            //builder.RegisterType<RecentlyViewedProductsService>().As<IRecentlyViewedProductsService>().InstancePerHttpRequest();
            //builder.RegisterType<ManufacturerService>().As<IManufacturerService>().InstancePerHttpRequest();
            //builder.RegisterType<PriceCalculationService>().As<IPriceCalculationService>().InstancePerHttpRequest();
            //builder.RegisterType<PriceCalculationService>().As<IPriceCalculationService>().InstancePerHttpRequest();
            //builder.RegisterType<PriceFormatter>().As<IPriceFormatter>().InstancePerHttpRequest();
            //builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductAttributeParser>().As<IProductAttributeParser>().InstancePerHttpRequest();
            //builder.RegisterType<ProductAttributeService>().As<IProductAttributeService>().InstancePerHttpRequest();
            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();
            //builder.RegisterType<CopyProductService>().As<ICopyProductService>().InstancePerHttpRequest();
            //builder.RegisterType<ProductTagService>().As<IProductTagService>().InstancePerHttpRequest();
            //builder.RegisterType<SpecificationAttributeService>().As<ISpecificationAttributeService>().InstancePerHttpRequest();
            //builder.RegisterType<ProductTemplateService>().As<IProductTemplateService>().InstancePerHttpRequest();
            //builder.RegisterType<CategoryTemplateService>().As<ICategoryTemplateService>().InstancePerHttpRequest();
            //builder.RegisterType<ManufacturerTemplateService>().As<IManufacturerTemplateService>().InstancePerHttpRequest();

            //builder.RegisterType<AffiliateService>().As<IAffiliateService>().InstancePerHttpRequest();
            //builder.RegisterType<AddressService>().As<IAddressService>().InstancePerHttpRequest();
            //builder.RegisterType<GenericAttributeService>().As<IGenericAttributeService>().InstancePerHttpRequest();
            //builder.RegisterType<FulltextService>().As<IFulltextService>().InstancePerHttpRequest();


            //builder.RegisterGeneric(typeof(ConfigurationProvider<>)).As(typeof(IConfigurationProvider<>));
            //builder.RegisterSource(new SettingsSource());

            //builder.RegisterType<CustomerContentService>().As<ICustomerContentService>().InstancePerHttpRequest();
            //builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerHttpRequest();
            //builder.RegisterType<CustomerRegistrationService>().As<ICustomerRegistrationService>().InstancePerHttpRequest();
            //builder.RegisterType<CustomerReportService>().As<ICustomerReportService>().InstancePerHttpRequest();

            ////pass MemoryCacheManager to SettingService as cacheManager (cache settngs between requests)
            //builder.RegisterType<PermissionService>().As<IPermissionService>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"))
            //    .InstancePerHttpRequest();

            //builder.RegisterType<GeoCountryLookup>().As<IGeoCountryLookup>().InstancePerHttpRequest();
            //builder.RegisterType<CountryService>().As<ICountryService>().InstancePerHttpRequest();
            //builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerHttpRequest();
            //builder.RegisterType<MeasureService>().As<IMeasureService>().InstancePerHttpRequest();
            //builder.RegisterType<StateProvinceService>().As<IStateProvinceService>().InstancePerHttpRequest();

            //builder.RegisterType<DiscountService>().As<IDiscountService>().InstancePerHttpRequest();


            ////pass MemoryCacheManager to SettingService as cacheManager (cache settngs between requests)
            //builder.RegisterType<SettingService>().As<ISettingService>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"))
            //    .InstancePerHttpRequest();
            ////pass MemoryCacheManager to LocalizationService as cacheManager (cache locales between requests)
            //builder.RegisterType<LocalizationService>().As<ILocalizationService>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"))
            //    .InstancePerHttpRequest();

            ////pass MemoryCacheManager to LocalizedEntityService as cacheManager (cache locales between requests)
            //builder.RegisterType<LocalizedEntityService>().As<ILocalizedEntityService>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static" +
            //                                                             "" +
            //                                                             ""))
            //    .InstancePerHttpRequest();
            //builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerHttpRequest();

            //builder.RegisterType<DownloadService>().As<IDownloadService>().InstancePerHttpRequest();
            //builder.RegisterType<PictureService>().As<IPictureService>().InstancePerHttpRequest();

            //builder.RegisterType<MessageTemplateService>().As<IMessageTemplateService>().InstancePerHttpRequest();
            //builder.RegisterType<QueuedEmailService>().As<IQueuedEmailService>().InstancePerHttpRequest();
            //builder.RegisterType<NewsLetterSubscriptionService>().As<INewsLetterSubscriptionService>().InstancePerHttpRequest();
            //builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerHttpRequest();
            //builder.RegisterType<EmailAccountService>().As<IEmailAccountService>().InstancePerHttpRequest();
            //builder.RegisterType<WorkflowMessageService>().As<IWorkflowMessageService>().InstancePerHttpRequest();
            //builder.RegisterType<MessageTokenProvider>().As<IMessageTokenProvider>().InstancePerHttpRequest();
            //builder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerHttpRequest();
            //builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();

            //builder.RegisterType<CheckoutAttributeFormatter>().As<ICheckoutAttributeFormatter>().InstancePerHttpRequest();
            //builder.RegisterType<CheckoutAttributeParser>().As<ICheckoutAttributeParser>().InstancePerHttpRequest();
            //builder.RegisterType<CheckoutAttributeService>().As<ICheckoutAttributeService>().InstancePerHttpRequest();
            //builder.RegisterType<GiftCardService>().As<IGiftCardService>().InstancePerHttpRequest();
            //builder.RegisterType<OrderService>().As<IOrderService>().InstancePerHttpRequest();
            //builder.RegisterType<OrderReportService>().As<IOrderReportService>().InstancePerHttpRequest();
            //builder.RegisterType<OrderProcessingService>().As<IOrderProcessingService>().InstancePerHttpRequest();
            //builder.RegisterType<OrderTotalCalculationService>().As<IOrderTotalCalculationService>().InstancePerHttpRequest();
            //builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>().InstancePerHttpRequest();

            //builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerHttpRequest();

            //builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerHttpRequest();
            //builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerHttpRequest();

            //builder.RegisterType<ShipmentService>().As<IShipmentService>().InstancePerHttpRequest();
            //builder.RegisterType<ShippingService>().As<IShippingService>().InstancePerHttpRequest();

            //builder.RegisterType<TaxCategoryService>().As<ITaxCategoryService>().InstancePerHttpRequest();
            //builder.RegisterType<TaxService>().As<ITaxService>().InstancePerHttpRequest();
            //builder.RegisterType<TaxCategoryService>().As<ITaxCategoryService>().InstancePerHttpRequest();

            //builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerHttpRequest();
            //builder.RegisterType<CustomerActivityService>().As<ICustomerActivityService>().InstancePerHttpRequest();

            //builder.RegisterType<InstallationService>().As<IInstallationService>().InstancePerHttpRequest();

            //builder.RegisterType<ForumService>().As<IForumService>().InstancePerHttpRequest();

            //builder.RegisterType<PollService>().As<IPollService>().InstancePerHttpRequest();
            //builder.RegisterType<BlogService>().As<IBlogService>().InstancePerHttpRequest();
            //builder.RegisterType<WidgetService>().As<IWidgetService>().InstancePerHttpRequest();
            //builder.RegisterType<TopicService>().As<ITopicService>().InstancePerHttpRequest();
            //builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();

            //builder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerHttpRequest();
            //builder.RegisterType<SitemapGenerator>().As<ISitemapGenerator>().InstancePerHttpRequest();
            //builder.RegisterType<PageTitleBuilder>().As<IPageTitleBuilder>().InstancePerHttpRequest();

            //builder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().InstancePerHttpRequest();

            //builder.RegisterType<TelerikLocalizationServiceFactory>().As<Telerik.Web.Mvc.Infrastructure.ILocalizationServiceFactory>().InstancePerHttpRequest();

            //builder.RegisterType<ExportManager>().As<IExportManager>().InstancePerHttpRequest();
            //builder.RegisterType<ImportManager>().As<IImportManager>().InstancePerHttpRequest();
            //builder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerHttpRequest();
            //builder.RegisterType<PdfService>().As<IPdfService>().InstancePerHttpRequest();
            //builder.RegisterType<ThemeProvider>().As<IThemeProvider>().InstancePerHttpRequest();
            //builder.RegisterType<ThemeContext>().As<IThemeContext>().InstancePerHttpRequest();


            //builder.RegisterType<ExternalAuthorizer>().As<IExternalAuthorizer>().InstancePerHttpRequest();
            //builder.RegisterType<OpenAuthenticationService>().As<IOpenAuthenticationService>().InstancePerHttpRequest();


            //builder.RegisterType<EmbeddedViewResolver>().As<IEmbeddedViewResolver>().SingleInstance();
            //builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            ////HTML Editor services
            //builder.RegisterType<NetAdvDirectoryService>().As<INetAdvDirectoryService>().InstancePerHttpRequest();
            //builder.RegisterType<NetAdvImageService>().As<INetAdvImageService>().InstancePerHttpRequest();

            ////Register event consumers
            //var consumers = typeFinder.FindClassesOfType(typeof(IConsumer<>)).ToList();
            //foreach (var consumer in consumers)
            //{
            //    builder.RegisterType(consumer)
            //        .As(consumer.FindInterfaces((type, criteria) =>
            //        {
            //            var isMatch = type.IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
            //            return isMatch;
            //        }, typeof(IConsumer<>)))
            //        .InstancePerHttpRequest();
            //}
            //builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            //builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().SingleInstance();

        }

        private void RegisterDB(ContainerBuilder builder, Type type, ITypeFinder typeFinder)
        {
            var entityAssembly = Assembly.Load(type.Namespace);
            builder.RegisterType(type).As(type).Named<DbContext>(type.FullName).InstancePerHttpRequest();
            var a = new Assembly[] {entityAssembly};

            var typeList = typeFinder.FindClassesOfType<BaseEntity>(a,true);
            var tRepository = typeof(EfRepository<>);
            foreach (Type t in typeList)
            {
                var t2 = tRepository.MakeGenericType(t);
                builder.RegisterType(t2).AsImplementedInterfaces().WithParameter(ResolvedParameter.ForNamed<DbContext>(type.FullName)).InstancePerHttpRequest();
            }
        }

        private void RegisterWCFService<T>(ContainerBuilder builder)
        {
            builder.Register(c => new ChannelFactory<T>(typeof(T).FullName)).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel()).UseWcfSafeRelease();
        }

        public int Order
        {
            get { return 0; }
        }
    }


    //public class SettingsSource : IRegistrationSource
    //{
    //    static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
    //        "BuildRegistration",
    //        BindingFlags.Static | BindingFlags.NonPublic);

    //    public IEnumerable<IComponentRegistration> RegistrationsFor(
    //            Service service,
    //            Func<Service, IEnumerable<IComponentRegistration>> registrations)
    //    {
    //        var ts = service as TypedService;
    //        if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
    //        {
    //            var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
    //            yield return (IComponentRegistration)buildMethod.Invoke(null, null);
    //        }
    //    }

    //    static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
    //    {
    //        return RegistrationBuilder
    //            .ForDelegate((c, p) => c.Resolve<IConfigurationProvider<TSettings>>().Settings)
    //            .InstancePerHttpRequest()
    //            .CreateRegistration();
    //    }

    //    public bool IsAdapterForIndividualComponents { get { return false; } }
    //}

}
