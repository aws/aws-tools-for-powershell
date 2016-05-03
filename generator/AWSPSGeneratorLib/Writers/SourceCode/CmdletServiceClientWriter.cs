using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWSPowerShellGenerator.CmdletConfig;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    /// <summary>
    /// Writes the source code for the service client base class inherited
    /// by all cmdlets for a service.
    /// </summary>
    internal class CmdletServiceClientWriter : BaseSourceCodeWriter
    {
        const string AuthenticatedServiceCmdletBaseClassName = "ServiceCmdlet";
        const string AnonymousServiceCmdletBaseClassName = "AnonymousServiceCmdlet";

        /// <summary>
        /// Generate the source file for the abstract base 'client' class that the service operation cmdlets will 
        /// derive from, supplying them with the service client and default region handling, if any.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="serviceConfig"></param>
        /// <param name="clientName"></param>
        /// <param name="serviceApiVersion"></param>
        public static void Write(IndentedTextWriter writer, ConfigModel serviceConfig, string clientName, string serviceApiVersion)
        {
            WriteSourceLicenseHeader(writer);
            WriteNamespaces(writer, serviceConfig.ServiceNamespace, serviceConfig.AdditionalNamespaces);
            writer.WriteLine();

            var prefix = serviceConfig.ServiceNounPrefix;
            writer.WriteLine("namespace Amazon.PowerShell.Cmdlets.{0}", prefix);
            writer.OpenRegion();
            {
                WriteServiceCmdletClass(writer, serviceConfig, clientName, prefix, serviceApiVersion, false);

                if (serviceConfig.RequiresAnonymousServiceCmdletClass)
                {
                    writer.WriteLine();
                    WriteServiceCmdletClass(writer, serviceConfig, clientName, prefix, serviceApiVersion, true);
                }
            }
            writer.CloseRegion();
        }

        private static void WriteServiceCmdletClass(IndentedTextWriter writer, 
                                                    ConfigModel serviceConfig, 
                                                    string clientName, 
                                                    string prefix, 
                                                    string serviceApiVersion, 
                                                    bool useAnonymousServiceCmdletBase)
        {
            var serviceCmdletBaseClass = useAnonymousServiceCmdletBase ? AnonymousServiceCmdletBaseClassName : AuthenticatedServiceCmdletBaseClassName;
            var serviceCmdletClass = serviceConfig.GetServiceCmdletClassName(useAnonymousServiceCmdletBase);
                
            writer.WriteLine("[AWSClientCmdlet(\"{0}\", \"{1}\", \"{2}\")]", clientName, prefix, serviceApiVersion);
            writer.WriteLine("public abstract partial class {0}Cmdlet : {1}", serviceCmdletClass, serviceCmdletBaseClass);
            writer.OpenRegion();
            {
                writer.WriteLine("protected {0} Client {{ get; private set; }}", serviceConfig.ServiceClientInterface);
                if (!string.IsNullOrEmpty(serviceConfig.DefaultRegion))
                {
                    writer.WriteLine("protected override string DefaultRegion");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("get");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("return \"{0}\";", serviceConfig.DefaultRegion);
                        }
                        writer.CloseRegion();
                    }
                    writer.CloseRegion();
                }

                if (useAnonymousServiceCmdletBase)
                    writer.WriteLine("protected {0} CreateClient(RegionEndpoint region)", serviceConfig.ServiceClientInterface);
                else
                    writer.WriteLine("protected {0} CreateClient(AWSCredentials credentials, RegionEndpoint region)", serviceConfig.ServiceClientInterface);

                writer.OpenRegion();
                {
                    writer.WriteLine("var config = new {0} {{ RegionEndpoint = region }};", serviceConfig.ServiceClientConfig);
                    writer.WriteLine("Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);");
                    writer.WriteLine("this.CustomizeClientConfig(config);");

                    if (useAnonymousServiceCmdletBase)
                        writer.WriteLine("var client = new {0}(new AnonymousAWSCredentials(), config);", serviceConfig.ServiceClient);
                    else
                        writer.WriteLine("var client = new {0}(credentials, config);", serviceConfig.ServiceClient);

                    writer.WriteLine("client.BeforeRequestEvent += RequestEventHandler;");
                    writer.WriteLine("client.AfterResponseEvent += ResponseEventHandler;");
                    writer.WriteLine("return client;");
                }
                writer.CloseRegion();
                writer.WriteLine();
                writer.WriteLine("protected override void ProcessRecord()");
                writer.OpenRegion();
                {
                    writer.WriteLine("base.ProcessRecord();");
                    writer.WriteLine();
                    if (useAnonymousServiceCmdletBase)
                        writer.WriteLine("Client = CreateClient(Region);");
                    else
                        writer.WriteLine("Client = CreateClient(CurrentCredentials, Region);");
                }
                writer.CloseRegion();
            }
            writer.CloseRegion();
        }
    }
}
