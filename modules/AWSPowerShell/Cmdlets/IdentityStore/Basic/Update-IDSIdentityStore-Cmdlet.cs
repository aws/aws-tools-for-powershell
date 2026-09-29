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
using System.Threading;
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// Updates the configuration of the specified identity store, including its network configuration.
    /// </summary>
    [Cmdlet("Update", "IDSIdentityStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityStore.Model.UpdateIdentityStoreResponse")]
    [AWSCmdlet("Calls the AWS Identity Store UpdateIdentityStore API operation.", Operation = new[] {"UpdateIdentityStore"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.UpdateIdentityStoreResponse))]
    [AWSCmdletOutput("Amazon.IdentityStore.Model.UpdateIdentityStoreResponse",
        "This cmdlet returns an Amazon.IdentityStore.Model.UpdateIdentityStoreResponse object containing multiple properties."
    )]
    public partial class UpdateIDSIdentityStoreCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NetworkConfiguration_ApiAllowSourceIp
        /// <summary>
        /// <para>
        /// <para>A list of IP address CIDR ranges that are allowed to access the identity store API
        /// operations. A request from an IP address in this list bypasses the identity store's
        /// other API network controls: it's permitted even if it doesn't come through a VPC endpoint
        /// required by <c>VpceAccessRequired</c>, and even if it doesn't originate from a VPC
        /// in <c>ApiRestrictSourceVpcs</c>. If you don't specify a value, no such IP address
        /// exception applies.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_ApiAllowSourceIps")]
        public System.String[] NetworkConfiguration_ApiAllowSourceIp { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_ApiRestrictSourceVpc
        /// <summary>
        /// <para>
        /// <para>A list of virtual private cloud (VPC) IDs that are allowed to access the identity
        /// store API operations. A request is denied unless it originates from a VPC in this
        /// list, or from an IP address in <c>ApiAllowSourceIps</c> if you specified one. If you
        /// don't specify a value, access isn't restricted to specific VPCs, but the VPC endpoint
        /// requirement set by <c>VpceAccessRequired</c> still applies.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_ApiRestrictSourceVpcs")]
        public System.String[] NetworkConfiguration_ApiRestrictSourceVpc { get; set; }
        #endregion
        
        #region Parameter IdentityStoreId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier for the identity store.</para><para>You can specify the identity store by ID or by Amazon Resource Name (ARN). For example,
        /// identity store ID <c>d-1234567890</c> or identity store ARN <c>arn:aws:identitystore::111122223333:identitystore/d-1234567890</c>.</para>
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
        public System.String IdentityStoreId { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_ScimAllowSourceIp
        /// <summary>
        /// <para>
        /// <para>A list of IP address CIDR ranges that are allowed to access the identity store through
        /// the System for Cross-domain Identity Management (SCIM) protocol. Requests from IP
        /// addresses outside these ranges are denied. If you don't specify a value, SCIM requests
        /// remain subject to the identity store's other network controls, such as the VPC endpoint
        /// requirement set by <c>VpceAccessRequired</c>.</para><para>For example, to allow SCIM traffic from the public internet while still requiring
        /// the identity store API operations to be accessed through a VPC endpoint, set <c>VpceAccessRequired</c>
        /// to <c>true</c> and set this value to <c>0.0.0.0/0</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_ScimAllowSourceIps")]
        public System.String[] NetworkConfiguration_ScimAllowSourceIp { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_VpceAccessRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether the identity store can be accessed only through a virtual private
        /// cloud (VPC) endpoint. When set to <c>true</c>, requests must originate from a VPC
        /// endpoint.</para><para>This value must be set to either <c>true</c> or <c>false</c> when you provide <c>NetworkConfiguration</c>
        /// in a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfiguration_VpceAccessRequired { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.UpdateIdentityStoreResponse).
        /// Specifying the name of a property of type Amazon.IdentityStore.Model.UpdateIdentityStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IDSIdentityStore (UpdateIdentityStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.UpdateIdentityStoreResponse, UpdateIDSIdentityStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NetworkConfiguration_ApiAllowSourceIp != null)
            {
                context.NetworkConfiguration_ApiAllowSourceIp = new List<System.String>(this.NetworkConfiguration_ApiAllowSourceIp);
            }
            if (this.NetworkConfiguration_ApiRestrictSourceVpc != null)
            {
                context.NetworkConfiguration_ApiRestrictSourceVpc = new List<System.String>(this.NetworkConfiguration_ApiRestrictSourceVpc);
            }
            if (this.NetworkConfiguration_ScimAllowSourceIp != null)
            {
                context.NetworkConfiguration_ScimAllowSourceIp = new List<System.String>(this.NetworkConfiguration_ScimAllowSourceIp);
            }
            context.NetworkConfiguration_VpceAccessRequired = this.NetworkConfiguration_VpceAccessRequired;
            
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
            var request = new Amazon.IdentityStore.Model.UpdateIdentityStoreRequest();
            
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.IdentityStore.Model.NetworkConfiguration();
            List<System.String> requestNetworkConfiguration_networkConfiguration_ApiAllowSourceIp = null;
            if (cmdletContext.NetworkConfiguration_ApiAllowSourceIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_ApiAllowSourceIp = cmdletContext.NetworkConfiguration_ApiAllowSourceIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_ApiAllowSourceIp != null)
            {
                request.NetworkConfiguration.ApiAllowSourceIps = requestNetworkConfiguration_networkConfiguration_ApiAllowSourceIp;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_ApiRestrictSourceVpc = null;
            if (cmdletContext.NetworkConfiguration_ApiRestrictSourceVpc != null)
            {
                requestNetworkConfiguration_networkConfiguration_ApiRestrictSourceVpc = cmdletContext.NetworkConfiguration_ApiRestrictSourceVpc;
            }
            if (requestNetworkConfiguration_networkConfiguration_ApiRestrictSourceVpc != null)
            {
                request.NetworkConfiguration.ApiRestrictSourceVpcs = requestNetworkConfiguration_networkConfiguration_ApiRestrictSourceVpc;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_ScimAllowSourceIp = null;
            if (cmdletContext.NetworkConfiguration_ScimAllowSourceIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_ScimAllowSourceIp = cmdletContext.NetworkConfiguration_ScimAllowSourceIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_ScimAllowSourceIp != null)
            {
                request.NetworkConfiguration.ScimAllowSourceIps = requestNetworkConfiguration_networkConfiguration_ScimAllowSourceIp;
                requestNetworkConfigurationIsNull = false;
            }
            System.Boolean? requestNetworkConfiguration_networkConfiguration_VpceAccessRequired = null;
            if (cmdletContext.NetworkConfiguration_VpceAccessRequired != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpceAccessRequired = cmdletContext.NetworkConfiguration_VpceAccessRequired.Value;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpceAccessRequired != null)
            {
                request.NetworkConfiguration.VpceAccessRequired = requestNetworkConfiguration_networkConfiguration_VpceAccessRequired.Value;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
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
        
        private Amazon.IdentityStore.Model.UpdateIdentityStoreResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.UpdateIdentityStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "UpdateIdentityStore");
            try
            {
                return client.UpdateIdentityStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IdentityStoreId { get; set; }
            public List<System.String> NetworkConfiguration_ApiAllowSourceIp { get; set; }
            public List<System.String> NetworkConfiguration_ApiRestrictSourceVpc { get; set; }
            public List<System.String> NetworkConfiguration_ScimAllowSourceIp { get; set; }
            public System.Boolean? NetworkConfiguration_VpceAccessRequired { get; set; }
            public System.Func<Amazon.IdentityStore.Model.UpdateIdentityStoreResponse, UpdateIDSIdentityStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
