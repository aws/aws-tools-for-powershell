/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Creates an Amazon OpenSearch Service-managed VPC endpoint.
    /// </summary>
    [Cmdlet("New", "OSVpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.VpcEndpoint")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service CreateVpcEndpoint API operation.", Operation = new[] {"CreateVpcEndpoint"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.CreateVpcEndpointResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.VpcEndpoint or Amazon.OpenSearchService.Model.CreateVpcEndpointResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.VpcEndpoint object.",
        "The service call response (type Amazon.OpenSearchService.Model.CreateVpcEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOSVpcEndpointCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DomainArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the domain to grant access to.</para>
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
        public System.String DomainArn { get; set; }
        #endregion
        
        #region Parameter VpcOptions_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The list of security group IDs associated with the VPC endpoints for the domain. If
        /// you do not provide a security group ID, OpenSearch Service uses the default security
        /// group for the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SecurityGroupIds")]
        public System.String[] VpcOptions_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs associated with the VPC endpoints for the domain. If your domain
        /// uses multiple Availability Zones, you need to provide two subnet IDs, one per zone.
        /// Otherwise, provide only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SubnetIds")]
        public System.String[] VpcOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.CreateVpcEndpointResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.CreateVpcEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSVpcEndpoint (CreateVpcEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.CreateVpcEndpointResponse, NewOSVpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DomainArn = this.DomainArn;
            #if MODULAR
            if (this.DomainArn == null && ParameterWasBound(nameof(this.DomainArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcOptions_SecurityGroupId != null)
            {
                context.VpcOptions_SecurityGroupId = new List<System.String>(this.VpcOptions_SecurityGroupId);
            }
            if (this.VpcOptions_SubnetId != null)
            {
                context.VpcOptions_SubnetId = new List<System.String>(this.VpcOptions_SubnetId);
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
            var request = new Amazon.OpenSearchService.Model.CreateVpcEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainArn != null)
            {
                request.DomainArn = cmdletContext.DomainArn;
            }
            
             // populate VpcOptions
            var requestVpcOptionsIsNull = true;
            request.VpcOptions = new Amazon.OpenSearchService.Model.VPCOptions();
            List<System.String> requestVpcOptions_vpcOptions_SecurityGroupId = null;
            if (cmdletContext.VpcOptions_SecurityGroupId != null)
            {
                requestVpcOptions_vpcOptions_SecurityGroupId = cmdletContext.VpcOptions_SecurityGroupId;
            }
            if (requestVpcOptions_vpcOptions_SecurityGroupId != null)
            {
                request.VpcOptions.SecurityGroupIds = requestVpcOptions_vpcOptions_SecurityGroupId;
                requestVpcOptionsIsNull = false;
            }
            List<System.String> requestVpcOptions_vpcOptions_SubnetId = null;
            if (cmdletContext.VpcOptions_SubnetId != null)
            {
                requestVpcOptions_vpcOptions_SubnetId = cmdletContext.VpcOptions_SubnetId;
            }
            if (requestVpcOptions_vpcOptions_SubnetId != null)
            {
                request.VpcOptions.SubnetIds = requestVpcOptions_vpcOptions_SubnetId;
                requestVpcOptionsIsNull = false;
            }
             // determine if request.VpcOptions should be set to null
            if (requestVpcOptionsIsNull)
            {
                request.VpcOptions = null;
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
        
        private Amazon.OpenSearchService.Model.CreateVpcEndpointResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.CreateVpcEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "CreateVpcEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateVpcEndpoint(request);
                #elif CORECLR
                return client.CreateVpcEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DomainArn { get; set; }
            public List<System.String> VpcOptions_SecurityGroupId { get; set; }
            public List<System.String> VpcOptions_SubnetId { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.CreateVpcEndpointResponse, NewOSVpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcEndpoint;
        }
        
    }
}
