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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Create an IPAM scope. In IPAM, a scope is the highest-level container within IPAM.
    /// An IPAM contains two default scopes. Each scope represents the IP space for a single
    /// network. The private scope is intended for all private IP address space. The public
    /// scope is intended for all public IP address space. Scopes enable you to reuse IP addresses
    /// across multiple unconnected networks without causing IP address overlap or conflict.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/add-scope-ipam.html">Add
    /// a scope</a> in the <i>Amazon VPC IPAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2IpamScope", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamScope")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateIpamScope API operation.", Operation = new[] {"CreateIpamScope"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateIpamScopeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamScope or Amazon.EC2.Model.CreateIpamScopeResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamScope object.",
        "The service call response (type Amazon.EC2.Model.CreateIpamScopeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IpamScopeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the scope you're creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ExternalAuthorityConfiguration_ExternalResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the external resource managing this scope. For Infoblox integrations,
        /// this is the Infoblox resource identifier in the format <c>&lt;version&gt;.identity.account.&lt;entity_realm&gt;.&lt;entity_id&gt;</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalAuthorityConfiguration_ExternalResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter IpamId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM for which you're creating this scope.</para>
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
        public System.String IpamId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key/value combination of a tag assigned to the resource. Use the tag key in the
        /// filter name and the tag value as the filter value. For example, to find all resources
        /// that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>, specify <c>tag:Owner</c>
        /// for the filter name and <c>TeamA</c> for the filter value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ExternalAuthorityConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of external authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamScopeExternalAuthorityType")]
        public Amazon.EC2.IpamScopeExternalAuthorityType ExternalAuthorityConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamScope'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateIpamScopeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateIpamScopeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamScope";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IpamScope (CreateIpamScope)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateIpamScopeResponse, NewEC2IpamScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.ExternalAuthorityConfiguration_ExternalResourceIdentifier = this.ExternalAuthorityConfiguration_ExternalResourceIdentifier;
            context.ExternalAuthorityConfiguration_Type = this.ExternalAuthorityConfiguration_Type;
            context.IpamId = this.IpamId;
            #if MODULAR
            if (this.IpamId == null && ParameterWasBound(nameof(this.IpamId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            
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
            var request = new Amazon.EC2.Model.CreateIpamScopeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate ExternalAuthorityConfiguration
            var requestExternalAuthorityConfigurationIsNull = true;
            request.ExternalAuthorityConfiguration = new Amazon.EC2.Model.ExternalAuthorityConfiguration();
            System.String requestExternalAuthorityConfiguration_externalAuthorityConfiguration_ExternalResourceIdentifier = null;
            if (cmdletContext.ExternalAuthorityConfiguration_ExternalResourceIdentifier != null)
            {
                requestExternalAuthorityConfiguration_externalAuthorityConfiguration_ExternalResourceIdentifier = cmdletContext.ExternalAuthorityConfiguration_ExternalResourceIdentifier;
            }
            if (requestExternalAuthorityConfiguration_externalAuthorityConfiguration_ExternalResourceIdentifier != null)
            {
                request.ExternalAuthorityConfiguration.ExternalResourceIdentifier = requestExternalAuthorityConfiguration_externalAuthorityConfiguration_ExternalResourceIdentifier;
                requestExternalAuthorityConfigurationIsNull = false;
            }
            Amazon.EC2.IpamScopeExternalAuthorityType requestExternalAuthorityConfiguration_externalAuthorityConfiguration_Type = null;
            if (cmdletContext.ExternalAuthorityConfiguration_Type != null)
            {
                requestExternalAuthorityConfiguration_externalAuthorityConfiguration_Type = cmdletContext.ExternalAuthorityConfiguration_Type;
            }
            if (requestExternalAuthorityConfiguration_externalAuthorityConfiguration_Type != null)
            {
                request.ExternalAuthorityConfiguration.Type = requestExternalAuthorityConfiguration_externalAuthorityConfiguration_Type;
                requestExternalAuthorityConfigurationIsNull = false;
            }
             // determine if request.ExternalAuthorityConfiguration should be set to null
            if (requestExternalAuthorityConfigurationIsNull)
            {
                request.ExternalAuthorityConfiguration = null;
            }
            if (cmdletContext.IpamId != null)
            {
                request.IpamId = cmdletContext.IpamId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateIpamScopeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateIpamScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateIpamScope");
            try
            {
                return client.CreateIpamScopeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String ExternalAuthorityConfiguration_ExternalResourceIdentifier { get; set; }
            public Amazon.EC2.IpamScopeExternalAuthorityType ExternalAuthorityConfiguration_Type { get; set; }
            public System.String IpamId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateIpamScopeResponse, NewEC2IpamScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamScope;
        }
        
    }
}
