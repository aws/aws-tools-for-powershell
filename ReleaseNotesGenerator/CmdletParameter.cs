using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSReleaseNotesGenerator
{
    public class CmdletParameter
    {
        internal const string ParameterAttribute = "System.Management.Automation.ParameterAttribute";
        private const string ParameterAttribute_Mandatory = "Mandatory";
        private const string ParameterAttribute_Position = "Position";
        private const string ParameterAttribute_ValueFromPipeline = "ValueFromPipeline";
        private const string ParameterAttribute_ValueFromPipelineByPropertyName = "ValueFromPipelineByPropertyName";
        private const string ParameterAttribute_ValueFromRemainingArguments = "ValueFromRemainingArguments";
        private const string ParameterAttribute_ParameterSetName = "ParameterSetName";
        private const string AliasAttribute = "System.Management.Automation.AliasAttribute";
        private const string AliasAttribute_AliasNames = "AliasNames";

        private PropertyInfo Property;
        public readonly string Name;
        public readonly string Type;
        public readonly bool Nullable;
        public readonly bool Mandatory;
        public readonly int Position;
        public readonly bool ValueFromPipeline;
        public readonly bool ValueFromPipelineByPropertyName;
        public readonly bool ValueFromRemainingArguments;
        public readonly string ParameterSet;
        public readonly List<string> NameAndAliases;

        public CmdletParameter(PropertyInfo property)
        {
            Property = property;

            Name = property.Name;
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(System.Nullable<>))
            {
                Type = property.PropertyType.GenericTypeArguments[0].FullName;
                Nullable = true;
            }
            else
            {
                Type = property.PropertyType.FullName;
                Nullable = !property.PropertyType.IsValueType;
            }

            var parameterAttribute = Property.GetCustomAttributes().FirstOrDefault(attribute => attribute.GetType().FullName == ParameterAttribute);

            Mandatory = Cmdlet.GetProperty<bool>(parameterAttribute, ParameterAttribute_Mandatory);
            Position = Cmdlet.GetProperty<int>(parameterAttribute, ParameterAttribute_Position);
            ValueFromPipeline = Cmdlet.GetProperty<bool>(parameterAttribute, ParameterAttribute_ValueFromPipeline);
            ValueFromPipelineByPropertyName = Cmdlet.GetProperty<bool>(parameterAttribute, ParameterAttribute_ValueFromPipelineByPropertyName);
            ValueFromRemainingArguments = Cmdlet.GetProperty<bool>(parameterAttribute, ParameterAttribute_ValueFromRemainingArguments);
            ParameterSet = Cmdlet.GetProperty<string>(parameterAttribute, ParameterAttribute_ParameterSetName);

            NameAndAliases = new List<string> { Name };

            var aliasAttribute = Property.GetCustomAttributes().FirstOrDefault(attribute => attribute.GetType().FullName == AliasAttribute);

            if (aliasAttribute != null)
            {
                NameAndAliases.AddRange(Cmdlet.GetProperty<IList<string>>(aliasAttribute, AliasAttribute_AliasNames));
            }
        }
    }
}
