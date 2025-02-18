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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Modifies an Amazon OpenSearch Service-managed interface VPC endpoint.
    /// </summary>
    [Cmdlet("Update", "ESVpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.VpcEndpoint")]
    [AWSCmdlet("Calls the Amazon Elasticsearch UpdateVpcEndpoint API operation.", Operation = new[] {"UpdateVpcEndpoint"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.VpcEndpoint or Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.VpcEndpoint object.",
        "The service call response (type Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateESVpcEndpointCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VpcOptions_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the security groups for VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SecurityGroupIds")]
        public System.String[] VpcOptions_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>Specifies the subnets for VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SubnetIds")]
        public System.String[] VpcOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the VPC endpoint to be updated.</para>
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
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcEndpoint";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ESVpcEndpoint (UpdateVpcEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse, UpdateESVpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VpcEndpointId = this.VpcEndpointId;
            #if MODULAR
            if (this.VpcEndpointId == null && ParameterWasBound(nameof(this.VpcEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.UpdateVpcEndpointRequest();
            
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
            }
            
             // populate VpcOptions
            var requestVpcOptionsIsNull = true;
            request.VpcOptions = new Amazon.Elasticsearch.Model.VPCOptions();
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
        
        private Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.UpdateVpcEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "UpdateVpcEndpoint");
            try
            {
                return client.UpdateVpcEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String VpcEndpointId { get; set; }
            public List<System.String> VpcOptions_SecurityGroupId { get; set; }
            public List<System.String> VpcOptions_SubnetId { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.UpdateVpcEndpointResponse, UpdateESVpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcEndpoint;
        }
        
    }
}
