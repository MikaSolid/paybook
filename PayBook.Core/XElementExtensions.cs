using System.Xml.Linq;

namespace PayBook
{
    public static class XElementExtensions
    {

        public static void SetAttributeValue(this XElement element, string name, object value)
        {
            if (element.Attribute(name) != null)
                element.Attribute(name).SetValue(value);
            else
                element.Add(new XAttribute(name, value));
        }

        public static string GetAttributeValue(this XElement element, string attributeName)
        {
            var xAttribute = element.Attribute(attributeName);

            return xAttribute != null ? xAttribute.Value : null;
        }
    }
}