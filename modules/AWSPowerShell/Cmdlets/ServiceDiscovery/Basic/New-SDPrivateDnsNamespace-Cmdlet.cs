/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace Amazon.PowerShell.Cmdlets.SD
{
    /// <summary>
    /// Creates a private namespace based on DNS, which is visible only inside a specified
    /// Amazon VPC. The namespace defines your service naming scheme. For example, if you
    /// name your namespace <c>example.com</c> and name your service <c>backend</c>, the resulting
    /// DNS name for the service is <c>backend.example.com</c>. Service instances that are
    /// registered using a private DNS namespace can be discovered using either a <c>DiscoverInstances</c>
    /// request or using DNS. For the current quota on the number of namespaces that you can
    /// create using the same Amazon Web Services account, see <a href="https://docs.aws.amazon.com/cloud-map/latest/dg/cloud-map-limits.html">Cloud
    /// Map quotas</a> in the <i>Cloud Map Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "SDPrivateDnsNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cloud Map CreatePrivateDnsNamespace API operation.", Operation = new[] {"CreatePrivateDnsNamespace"}, SelectReturnType = typeof(Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSDPrivateDnsNamespaceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <c>CreatePrivateDnsNamespace</c>
        /// requests to be retried without the risk of running the operation twice. <c>CreatorRequestId</c>
        /// can be any unique string (for example, a date/timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name that you want to assign to this namespace. When you create a private DNS
        /// namespace, Cloud Map automatically creates an Amazon Route 53 private hosted zone
        /// that has the same name as the namespace.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the namespace. Each tag consists of a key and an optional value
        /// that you define. Tags keys can be up to 128 characters in length, and tag values can
        /// be up to 256 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ServiceDiscovery.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SOA_TTL
        /// <summary>
        /// <para>
        /// <para>The time to live (TTL) for purposes of negative caching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Properties_DnsProperties_SOA_TTL")]
        public System.Int64? SOA_TTL { get; set; }
        #endregion
        
        #region Parameter Vpc
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC that you want to associate the namespace with.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Vpc { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse).
        /// Specifying the name of a property of type Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SDPrivateDnsNamespace (CreatePrivateDnsNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse, NewSDPrivateDnsNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreatorRequestId = this.CreatorRequestId;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SOA_TTL = this.SOA_TTL;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ServiceDiscovery.Model.Tag>(this.Tag);
            }
            context.Vpc = this.Vpc;
            #if MODULAR
            if (this.Vpc == null && ParameterWasBound(nameof(this.Vpc)))
            {
                WriteWarning("You are passing $null as a value for parameter Vpc which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Properties
            var requestPropertiesIsNull = true;
            request.Properties = new Amazon.ServiceDiscovery.Model.PrivateDnsNamespaceProperties();
            Amazon.ServiceDiscovery.Model.PrivateDnsPropertiesMutable requestProperties_properties_DnsProperties = null;
            
             // populate DnsProperties
            var requestProperties_properties_DnsPropertiesIsNull = true;
            requestProperties_properties_DnsProperties = new Amazon.ServiceDiscovery.Model.PrivateDnsPropertiesMutable();
            Amazon.ServiceDiscovery.Model.SOA requestProperties_properties_DnsProperties_properties_DnsProperties_SOA = null;
            
             // populate SOA
            var requestProperties_properties_DnsProperties_properties_DnsProperties_SOAIsNull = true;
            requestProperties_properties_DnsProperties_properties_DnsProperties_SOA = new Amazon.ServiceDiscovery.Model.SOA();
            System.Int64? requestProperties_properties_DnsProperties_properties_DnsProperties_SOA_sOA_TTL = null;
            if (cmdletContext.SOA_TTL != null)
            {
                requestProperties_properties_DnsProperties_properties_DnsProperties_SOA_sOA_TTL = cmdletContext.SOA_TTL.Value;
            }
            if (requestProperties_properties_DnsProperties_properties_DnsProperties_SOA_sOA_TTL != null)
            {
                requestProperties_properties_DnsProperties_properties_DnsProperties_SOA.TTL = requestProperties_properties_DnsProperties_properties_DnsProperties_SOA_sOA_TTL.Value;
                requestProperties_properties_DnsProperties_properties_DnsProperties_SOAIsNull = false;
            }
             // determine if requestProperties_properties_DnsProperties_properties_DnsProperties_SOA should be set to null
            if (requestProperties_properties_DnsProperties_properties_DnsProperties_SOAIsNull)
            {
                requestProperties_properties_DnsProperties_properties_DnsProperties_SOA = null;
            }
            if (requestProperties_properties_DnsProperties_properties_DnsProperties_SOA != null)
            {
                requestProperties_properties_DnsProperties.SOA = requestProperties_properties_DnsProperties_properties_DnsProperties_SOA;
                requestProperties_properties_DnsPropertiesIsNull = false;
            }
             // determine if requestProperties_properties_DnsProperties should be set to null
            if (requestProperties_properties_DnsPropertiesIsNull)
            {
                requestProperties_properties_DnsProperties = null;
            }
            if (requestProperties_properties_DnsProperties != null)
            {
                request.Properties.DnsProperties = requestProperties_properties_DnsProperties;
                requestPropertiesIsNull = false;
            }
             // determine if request.Properties should be set to null
            if (requestPropertiesIsNull)
            {
                request.Properties = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Vpc != null)
            {
                request.Vpc = cmdletContext.Vpc;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Map", "CreatePrivateDnsNamespace");
            try
            {
                #if DESKTOP
                return client.CreatePrivateDnsNamespace(request);
                #elif CORECLR
                return client.CreatePrivateDnsNamespaceAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String CreatorRequestId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Int64? SOA_TTL { get; set; }
            public List<Amazon.ServiceDiscovery.Model.Tag> Tag { get; set; }
            public System.String Vpc { get; set; }
            public System.Func<Amazon.ServiceDiscovery.Model.CreatePrivateDnsNamespaceResponse, NewSDPrivateDnsNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
