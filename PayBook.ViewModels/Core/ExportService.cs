using System;
using System.ComponentModel.Composition;

namespace PayBook.ViewModels
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ExportService : ExportAttribute
    {
        internal const string IsDesignTimeServiceProperty = "IsDesignTimeService";
        internal const string ServiceContractProperty = "ServiceContract";

        public ServiceType IsDesignTimeService { get; private set; }

        public Type ServiceContract { get; private set; }

        public ExportService(ServiceType serviceType, Type contractType)
            : base(contractType)
        {
            IsDesignTimeService = serviceType;
            ServiceContract = contractType;
        }
    }
}