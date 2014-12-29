using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace PayBook.Composition
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DesignTimeExportAttribute : ExportAttribute
    {
        #region Constructors

        public DesignTimeExportAttribute()
        {
            DesignTime = false;
        }

        public DesignTimeExportAttribute(Type contractType)
            : base(contractType)
        {
            DesignTime = false;
        }

        public DesignTimeExportAttribute(string contractName)
            : base(contractName)
        {
            DesignTime = false;
        }

        public DesignTimeExportAttribute(string contractName, Type contractType)
            : base(contractName, contractType)
        {
            DesignTime = false;
        }

        #endregion

        [DefaultValue(false)]
        public bool DesignTime
        {
            get; set;
        }
    }
}