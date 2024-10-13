using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWSPowerShellGenerator.ServiceConfig;

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
        /// <param name="awsSignerAttributeTypeValue"></param>
        public static void Write(IndentedTextWriter writer, ConfigModel serviceConfig, string clientName, string serviceApiVersion, string awsSignerAttributeTypeValue)
        {
            WriteSourceLicenseHeader(writer);
            WriteNamespaces(writer, serviceConfig.ServiceNamespace);
            writer.WriteLine();

            var prefix = serviceConfig.ServiceNounPrefix;
            writer.WriteLine("namespace Amazon.PowerShell.Cmdlets.{0}", prefix);
            writer.OpenRegion();
            {
                WriteServiceCmdletClass(writer, serviceConfig, clientName, prefix, serviceApiVersion, false, awsSignerAttributeTypeValue);

                if (serviceConfig.RequiresAnonymousServiceCmdletClass)
                {
                    writer.WriteLine();
                    WriteServiceCmdletClass(writer, serviceConfig, clientName, prefix, serviceApiVersion, true, awsSignerAttributeTypeValue);
                }
            }
            writer.CloseRegion();
        }

        private static void WriteServiceCmdletClass(IndentedTextWriter writer, 
                                                    ConfigModel serviceConfig, 
                                                    string clientName, 
                                                    string prefix, 
                                                    string serviceApiVersion, 
                                                    bool useAnonymousServiceCmdletBase,
                                                    string awsSignerAttributeTypeValue)
        {
            var serviceCmdletBaseClass = useAnonymousServiceCmdletBase ? AnonymousServiceCmdletBaseClassName : AuthenticatedServiceCmdletBaseClassName;
            var serviceCmdletClass = serviceConfig.GetServiceCmdletClassName(useAnonymousServiceCmdletBase);
                
            writer.WriteLine("[AWSClientCmdlet(\"{0}\", \"{1}\", \"{2}\", \"{3}\")]", clientName, prefix, serviceApiVersion, serviceConfig.AssemblyName);
            writer.WriteLine("public abstract partial class {0}Cmdlet : {1}", serviceCmdletClass, serviceCmdletBaseClass);
            writer.OpenRegion();
            {
                writer.WriteLine("protected {0} Client {{ get; private set; }}", serviceConfig.ServiceClientInterface);

                writer.WriteLine();
                writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
                writer.WriteLine("public {0} ClientConfig", serviceConfig.ServiceClientConfig);
                writer.OpenRegion();
                {
                    writer.WriteLine("get");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("return base._ClientConfig as {0};", serviceConfig.ServiceClientConfig);
                    }
                    writer.CloseRegion();

                    writer.WriteLine("set");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("base._ClientConfig = value;");
                    }
                    writer.CloseRegion();

                }
                writer.CloseRegion();

                writer.WriteLine();

                if (!string.IsNullOrEmpty(serviceConfig.DefaultRegion))
                {
                    writer.WriteLine("protected override string _DefaultRegion");
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
                    writer.WriteLine("var config = this.ClientConfig ?? new {0}();", serviceConfig.ServiceClientConfig);

                    /* By default, creating a new service ClientConfig object would probe the regions in .NET SDK if ServiceURL is not set. 
                     * So we cannot determine if region was explicitly set by user while initializing the ClientConfig parameter. Hence, we replace 
                     * it with the non-null region parameter which is earlier resolved in TryGetRegion() from explicitly passed region, session parameter, etc. */
                    writer.WriteLine("if (region != null) config.RegionEndpoint = region;");

                    if(awsSignerAttributeTypeValue == "bearer")
                    {
                        writer.WriteLine("if (!string.IsNullOrEmpty(ProfileName))");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("config.AWSTokenProvider = new ProfileTokenProvider(ProfileName);");
                        }
                        writer.CloseRegion();
                    }

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
                writer.WriteLine("protected override void BeginProcessing()");
                writer.OpenRegion();
                {
                    writer.WriteLine("base.AWSServiceId = {0}.ServiceId.ToString();", serviceConfig.ServiceClientConfig);
                    writer.WriteLine();
                    writer.WriteLine("base.BeginProcessing();");
                }
                writer.CloseRegion();
                writer.WriteLine();
                writer.WriteLine("protected override void ProcessRecord()");
                writer.OpenRegion();
                {
                    writer.WriteLine("base.ProcessRecord();");
                    writer.WriteLine();
                    if (useAnonymousServiceCmdletBase)
                        writer.WriteLine("Client = CreateClient(_RegionEndpoint);");
                    else
                        writer.WriteLine("Client = CreateClient(_CurrentCredentials, _RegionEndpoint);");
                }
                writer.CloseRegion();
            }
            writer.CloseRegion();
        }
    }
}
