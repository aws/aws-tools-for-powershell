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
    /// Updates a private DNS namespace.
    /// </summary>
    [Cmdlet("Update", "SDPrivateDnsNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cloud Map UpdatePrivateDnsNamespace API operation.", Operation = new[] {"UpdatePrivateDnsNamespace"}, SelectReturnType = typeof(Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSDPrivateDnsNamespaceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Namespace_Description
        /// <summary>
        /// <para>
        /// <para>An updated description for the private DNS namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace_Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the namespace that you want to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter SOA_TTL
        /// <summary>
        /// <para>
        /// <para>The updated time to live (TTL) for purposes of negative caching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Namespace_Properties_DnsProperties_SOA_TTL")]
        public System.Int64? SOA_TTL { get; set; }
        #endregion
        
        #region Parameter UpdaterRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <c>UpdatePrivateDnsNamespace</c>
        /// requests to be retried without the risk of running the operation twice. <c>UpdaterRequestId</c>
        /// can be any unique string (for example, a date/timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdaterRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse).
        /// Specifying the name of a property of type Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SDPrivateDnsNamespace (UpdatePrivateDnsNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse, UpdateSDPrivateDnsNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace_Description = this.Namespace_Description;
            context.SOA_TTL = this.SOA_TTL;
            context.UpdaterRequestId = this.UpdaterRequestId;
            
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
            var request = new Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate Namespace
            request.Namespace = new Amazon.ServiceDiscovery.Model.PrivateDnsNamespaceChange();
            System.String requestNamespace_namespace_Description = null;
            if (cmdletContext.Namespace_Description != null)
            {
                requestNamespace_namespace_Description = cmdletContext.Namespace_Description;
            }
            if (requestNamespace_namespace_Description != null)
            {
                request.Namespace.Description = requestNamespace_namespace_Description;
            }
            Amazon.ServiceDiscovery.Model.PrivateDnsNamespacePropertiesChange requestNamespace_namespace_Properties = null;
            
             // populate Properties
            var requestNamespace_namespace_PropertiesIsNull = true;
            requestNamespace_namespace_Properties = new Amazon.ServiceDiscovery.Model.PrivateDnsNamespacePropertiesChange();
            Amazon.ServiceDiscovery.Model.PrivateDnsPropertiesMutableChange requestNamespace_namespace_Properties_namespace_Properties_DnsProperties = null;
            
             // populate DnsProperties
            var requestNamespace_namespace_Properties_namespace_Properties_DnsPropertiesIsNull = true;
            requestNamespace_namespace_Properties_namespace_Properties_DnsProperties = new Amazon.ServiceDiscovery.Model.PrivateDnsPropertiesMutableChange();
            Amazon.ServiceDiscovery.Model.SOAChange requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA = null;
            
             // populate SOA
            var requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOAIsNull = true;
            requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA = new Amazon.ServiceDiscovery.Model.SOAChange();
            System.Int64? requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA_sOA_TTL = null;
            if (cmdletContext.SOA_TTL != null)
            {
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA_sOA_TTL = cmdletContext.SOA_TTL.Value;
            }
            if (requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA_sOA_TTL != null)
            {
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA.TTL = requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA_sOA_TTL.Value;
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOAIsNull = false;
            }
             // determine if requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA should be set to null
            if (requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOAIsNull)
            {
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA = null;
            }
            if (requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA != null)
            {
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties.SOA = requestNamespace_namespace_Properties_namespace_Properties_DnsProperties_namespace_Properties_DnsProperties_SOA;
                requestNamespace_namespace_Properties_namespace_Properties_DnsPropertiesIsNull = false;
            }
             // determine if requestNamespace_namespace_Properties_namespace_Properties_DnsProperties should be set to null
            if (requestNamespace_namespace_Properties_namespace_Properties_DnsPropertiesIsNull)
            {
                requestNamespace_namespace_Properties_namespace_Properties_DnsProperties = null;
            }
            if (requestNamespace_namespace_Properties_namespace_Properties_DnsProperties != null)
            {
                requestNamespace_namespace_Properties.DnsProperties = requestNamespace_namespace_Properties_namespace_Properties_DnsProperties;
                requestNamespace_namespace_PropertiesIsNull = false;
            }
             // determine if requestNamespace_namespace_Properties should be set to null
            if (requestNamespace_namespace_PropertiesIsNull)
            {
                requestNamespace_namespace_Properties = null;
            }
            if (requestNamespace_namespace_Properties != null)
            {
                request.Namespace.Properties = requestNamespace_namespace_Properties;
            }
            if (cmdletContext.UpdaterRequestId != null)
            {
                request.UpdaterRequestId = cmdletContext.UpdaterRequestId;
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
        
        private Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Map", "UpdatePrivateDnsNamespace");
            try
            {
                #if DESKTOP
                return client.UpdatePrivateDnsNamespace(request);
                #elif CORECLR
                return client.UpdatePrivateDnsNamespaceAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String Namespace_Description { get; set; }
            public System.Int64? SOA_TTL { get; set; }
            public System.String UpdaterRequestId { get; set; }
            public System.Func<Amazon.ServiceDiscovery.Model.UpdatePrivateDnsNamespaceResponse, UpdateSDPrivateDnsNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
