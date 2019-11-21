using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSReleaseNotesGenerator
{
    public class Cmdlet
    {
        internal const string AWSCmdletAttribute = "Amazon.PowerShell.Common.AWSCmdletAttribute";
        internal const string AWSCmdletAttribute_Operation = "Operation";

        internal const string AWSClientCmdletAttribute = "Amazon.PowerShell.Common.AWSClientCmdletAttribute";
        internal const string AWSClientCmdletAttribute_ServiceName = "ServiceName";
        internal const string AWSClientCmdletAttribute_ServicePrefix = "ServicePrefix";

        private static readonly object[] NoParameters = new object[0];

        public readonly Type Type;
        public readonly string Name;
        public readonly IEnumerable<string> OutputTypes;
        public readonly IEnumerable<string> Operations;
        public readonly string ServiceName;
        public readonly string ServicePrefix;
        public readonly string DefaultParameterSet;
        public readonly bool SupportsShouldProcess;
        public readonly ConfirmImpact ConfirmImpact;
        public readonly IEnumerable<CmdletParameter> Parameters;

        public Cmdlet(Type type)
        {
            Type = type;

            Name = GetName();
            OutputTypes = GetOutputTypes();
            Operations = GetOperations();
            ServiceName = GetServiceName();
            ServicePrefix = GetServicePrefix();
            DefaultParameterSet = GetDefaultParameterSet();
            SupportsShouldProcess = GetSupportsShouldProcess();
            ConfirmImpact = GetConfirmImpact();
            Parameters = GetParameters();
        }

        private string GetName()
        {
            var cmdletAttribute = Type.GetCustomAttribute<CmdletAttribute>();
            return $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";
        }

        private IEnumerable<string> GetOutputTypes()
        {
            var outputTypes = Type.GetCustomAttributes<OutputTypeAttribute>()
                .SelectMany(attribute => attribute.Type)
                .Select(psTypeName => psTypeName.Name ?? psTypeName.Type?.FullName)
                .ToArray();
            return new ReadOnlyCollection<string>(outputTypes);
        }

        private IEnumerable<string> GetOperations()
        {
            var operations = Type.GetCustomAttributes()
                .Where(attribute => attribute.GetType().FullName == AWSCmdletAttribute)
                .Select(attribute => GetProperty<string[]>(attribute, AWSCmdletAttribute_Operation))
                .Where(operation => operation != null)
                .SelectMany(operation => operation)
                .ToArray();
            return new ReadOnlyCollection<string>(operations);
        }

        private string GetServiceName()
        {
            var awsClientCmdletAttribute = RecursiveGetCustomAttributes(Type).FirstOrDefault(attribute => attribute.GetType().FullName == AWSClientCmdletAttribute);
            if (awsClientCmdletAttribute == null)
                return null;
            return FixServiceName(GetProperty<string>(awsClientCmdletAttribute, AWSClientCmdletAttribute_ServiceName));
        }

        private string GetServicePrefix()
        {
            var awsClientCmdletAttribute = RecursiveGetCustomAttributes(Type).FirstOrDefault(attribute => attribute.GetType().FullName == AWSClientCmdletAttribute);
            if (awsClientCmdletAttribute == null)
                return null;
            return GetProperty<string>(awsClientCmdletAttribute, AWSClientCmdletAttribute_ServicePrefix);
        }

        private string GetDefaultParameterSet()
        {
            var cmdletAttribute = Type.GetCustomAttribute<CmdletAttribute>();
            return cmdletAttribute.DefaultParameterSetName;
        }

        private bool GetSupportsShouldProcess()
        {
            var cmdletAttribute = Type.GetCustomAttribute<CmdletAttribute>();
            return cmdletAttribute.SupportsShouldProcess;
        }

        private ConfirmImpact GetConfirmImpact()
        {
            var cmdletAttribute = Type.GetCustomAttribute<CmdletAttribute>();
            return cmdletAttribute.ConfirmImpact;
        }

        private IEnumerable<CmdletParameter> GetParameters()
        {
            var parameters = Type.GetProperties()
                .Where(property => property.GetCustomAttributes().Any(attribute => attribute.GetType().FullName == CmdletParameter.ParameterAttribute))
                .Select(property => new CmdletParameter(property))
                .ToList();
            return new ReadOnlyCollection<CmdletParameter>(parameters);
        }

        internal static T GetProperty<T>(object o, string propertyName)
        {
            return (T) o.GetType().GetProperty(propertyName).GetGetMethod().Invoke(o, NoParameters);
        }

        private static IEnumerable<object> RecursiveGetCustomAttributes(Type type)
        {
            while (type != null)
            {
                foreach (var attribute in type.GetCustomAttributes())
                {
                    yield return attribute;
                }
                type = type.BaseType;
            }
        }

        private static string FixServiceName(string name)
        {
            const string serviceNamePrefix = "Amazon ";

            if (name == null)
                return null;
            if (name.StartsWith("AWS ", StringComparison.OrdinalIgnoreCase))
                return serviceNamePrefix + name.Substring(4);
            if (!name.StartsWith(serviceNamePrefix))
                return serviceNamePrefix + name;
            return name;
        }
    }
}
