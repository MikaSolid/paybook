using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace PayBook.ViewModels
{
    public class MefResolver
    {
        private CompositionContainer _container;

        public MefResolver(CompositionContainer container)
        {
            _container = container;
        }

        public CompositionContainer Container
        {
            get
            {
                return _container;
            }
        }

        public void SatisfyImports(object attributedPart, object contextToInject)
        {
            SetContextToExportProvider(contextToInject);
            Container.SatisfyImportsOnce(attributedPart);
            SetContextToExportProvider(null);
        }


        public Export GetViewModelByContract(string vmContractName, object contextToInject, CreationPolicy policy)
        {
            if (Container == null)
                return null;

            var viewModelTypeIdentity = AttributedModelServices.GetTypeIdentity(typeof(object));
            var requiredMetadata = new Dictionary<string, Type>();
            requiredMetadata[ExportViewModel.NameProperty] = typeof(string);
            requiredMetadata[ExportViewModel.IsViewModelFirstProperty] = typeof(bool);


            var definition = new ContractBasedImportDefinition(vmContractName, viewModelTypeIdentity,
                                                               requiredMetadata, ImportCardinality.ExactlyOne, false,
                                                               false, policy);

            SetContextToExportProvider(contextToInject);
            var vmExports = Container.GetExports(definition);
            SetContextToExportProvider(null);

            var vmExport = vmExports.FirstOrDefault();
            if (vmExport != null)
                return vmExport;
            return null;
        }

        public object GetExportedValue(Export export)
        {
            return export.Value;
        }



        internal void SetContextToExportProvider(object contextToInject)
        {
            if (Container.Providers != null && Container.Providers.Count >= 1)
            {
                //try to find the MEFedMVVMExportProvider
                foreach (var item in Container.Providers)
                {
                    var mefedProvider = item as IMefExportProvider;
                    if (mefedProvider != null)
                        mefedProvider.SetContextToInject(contextToInject);
                }
            }
        }
    }
}