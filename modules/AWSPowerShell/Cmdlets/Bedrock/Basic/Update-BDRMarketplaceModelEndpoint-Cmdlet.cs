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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates the configuration of an existing endpoint for a model from Amazon Bedrock
    /// Marketplace.
    /// </summary>
    [Cmdlet("Update", "BDRMarketplaceModelEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.MarketplaceModelEndpoint")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateMarketplaceModelEndpoint API operation.", Operation = new[] {"UpdateMarketplaceModelEndpoint"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.MarketplaceModelEndpoint or Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.MarketplaceModelEndpoint object.",
        "The service call response (type Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBDRMarketplaceModelEndpointCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. This token is listed as not required because Amazon Web Services SDKs
        /// automatically generate it for you and set this parameter. If you're not using the
        /// Amazon Web Services SDK or the CLI, you must provide this token or the action will
        /// fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter EndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the endpoint you want to update.</para>
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
        public System.String EndpointArn { get; set; }
        #endregion
        
        #region Parameter SageMaker_ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Amazon SageMaker can assume to access model artifacts
        /// and docker image for deployment on Amazon EC2 compute instances or for batch transform
        /// jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_ExecutionRole")]
        public System.String SageMaker_ExecutionRole { get; set; }
        #endregion
        
        #region Parameter SageMaker_InitialInstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of Amazon EC2 compute instances to deploy for initial endpoint creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_InitialInstanceCount")]
        public System.Int32? SageMaker_InitialInstanceCount { get; set; }
        #endregion
        
        #region Parameter SageMaker_InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 compute instance type to deploy for hosting the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_InstanceType")]
        public System.String SageMaker_InstanceType { get; set; }
        #endregion
        
        #region Parameter SageMaker_KmsEncryptionKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key that Amazon SageMaker uses to encrypt data on the
        /// storage volume attached to the Amazon EC2 compute instance that hosts the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_KmsEncryptionKey")]
        public System.String SageMaker_KmsEncryptionKey { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each security group in the VPC to use.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_Vpc_SecurityGroupIds")]
        public System.String[] Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Vpc_SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each subnet in the VPC to use.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_SageMaker_Vpc_SubnetIds")]
        public System.String[] Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MarketplaceModelEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MarketplaceModelEndpoint";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRMarketplaceModelEndpoint (UpdateMarketplaceModelEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse, UpdateBDRMarketplaceModelEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.EndpointArn = this.EndpointArn;
            #if MODULAR
            if (this.EndpointArn == null && ParameterWasBound(nameof(this.EndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SageMaker_ExecutionRole = this.SageMaker_ExecutionRole;
            context.SageMaker_InitialInstanceCount = this.SageMaker_InitialInstanceCount;
            context.SageMaker_InstanceType = this.SageMaker_InstanceType;
            context.SageMaker_KmsEncryptionKey = this.SageMaker_KmsEncryptionKey;
            if (this.Vpc_SecurityGroupId != null)
            {
                context.Vpc_SecurityGroupId = new List<System.String>(this.Vpc_SecurityGroupId);
            }
            if (this.Vpc_SubnetId != null)
            {
                context.Vpc_SubnetId = new List<System.String>(this.Vpc_SubnetId);
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
            var request = new Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.EndpointArn != null)
            {
                request.EndpointArn = cmdletContext.EndpointArn;
            }
            
             // populate EndpointConfig
            var requestEndpointConfigIsNull = true;
            request.EndpointConfig = new Amazon.Bedrock.Model.EndpointConfig();
            Amazon.Bedrock.Model.SageMakerEndpoint requestEndpointConfig_endpointConfig_SageMaker = null;
            
             // populate SageMaker
            var requestEndpointConfig_endpointConfig_SageMakerIsNull = true;
            requestEndpointConfig_endpointConfig_SageMaker = new Amazon.Bedrock.Model.SageMakerEndpoint();
            System.String requestEndpointConfig_endpointConfig_SageMaker_sageMaker_ExecutionRole = null;
            if (cmdletContext.SageMaker_ExecutionRole != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_sageMaker_ExecutionRole = cmdletContext.SageMaker_ExecutionRole;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_sageMaker_ExecutionRole != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker.ExecutionRole = requestEndpointConfig_endpointConfig_SageMaker_sageMaker_ExecutionRole;
                requestEndpointConfig_endpointConfig_SageMakerIsNull = false;
            }
            System.Int32? requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InitialInstanceCount = null;
            if (cmdletContext.SageMaker_InitialInstanceCount != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InitialInstanceCount = cmdletContext.SageMaker_InitialInstanceCount.Value;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InitialInstanceCount != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker.InitialInstanceCount = requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InitialInstanceCount.Value;
                requestEndpointConfig_endpointConfig_SageMakerIsNull = false;
            }
            System.String requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InstanceType = null;
            if (cmdletContext.SageMaker_InstanceType != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InstanceType = cmdletContext.SageMaker_InstanceType;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InstanceType != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker.InstanceType = requestEndpointConfig_endpointConfig_SageMaker_sageMaker_InstanceType;
                requestEndpointConfig_endpointConfig_SageMakerIsNull = false;
            }
            System.String requestEndpointConfig_endpointConfig_SageMaker_sageMaker_KmsEncryptionKey = null;
            if (cmdletContext.SageMaker_KmsEncryptionKey != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_sageMaker_KmsEncryptionKey = cmdletContext.SageMaker_KmsEncryptionKey;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_sageMaker_KmsEncryptionKey != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker.KmsEncryptionKey = requestEndpointConfig_endpointConfig_SageMaker_sageMaker_KmsEncryptionKey;
                requestEndpointConfig_endpointConfig_SageMakerIsNull = false;
            }
            Amazon.Bedrock.Model.VpcConfig requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc = null;
            
             // populate Vpc
            var requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_VpcIsNull = true;
            requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc = new Amazon.Bedrock.Model.VpcConfig();
            List<System.String> requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SecurityGroupId = null;
            if (cmdletContext.Vpc_SecurityGroupId != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SecurityGroupId = cmdletContext.Vpc_SecurityGroupId;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SecurityGroupId != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc.SecurityGroupIds = requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SecurityGroupId;
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_VpcIsNull = false;
            }
            List<System.String> requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SubnetId = null;
            if (cmdletContext.Vpc_SubnetId != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SubnetId = cmdletContext.Vpc_SubnetId;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SubnetId != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc.SubnetIds = requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc_vpc_SubnetId;
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_VpcIsNull = false;
            }
             // determine if requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc should be set to null
            if (requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_VpcIsNull)
            {
                requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc = null;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc != null)
            {
                requestEndpointConfig_endpointConfig_SageMaker.Vpc = requestEndpointConfig_endpointConfig_SageMaker_endpointConfig_SageMaker_Vpc;
                requestEndpointConfig_endpointConfig_SageMakerIsNull = false;
            }
             // determine if requestEndpointConfig_endpointConfig_SageMaker should be set to null
            if (requestEndpointConfig_endpointConfig_SageMakerIsNull)
            {
                requestEndpointConfig_endpointConfig_SageMaker = null;
            }
            if (requestEndpointConfig_endpointConfig_SageMaker != null)
            {
                request.EndpointConfig.SageMaker = requestEndpointConfig_endpointConfig_SageMaker;
                requestEndpointConfigIsNull = false;
            }
             // determine if request.EndpointConfig should be set to null
            if (requestEndpointConfigIsNull)
            {
                request.EndpointConfig = null;
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
        
        private Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateMarketplaceModelEndpoint");
            try
            {
                return client.UpdateMarketplaceModelEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String EndpointArn { get; set; }
            public System.String SageMaker_ExecutionRole { get; set; }
            public System.Int32? SageMaker_InitialInstanceCount { get; set; }
            public System.String SageMaker_InstanceType { get; set; }
            public System.String SageMaker_KmsEncryptionKey { get; set; }
            public List<System.String> Vpc_SecurityGroupId { get; set; }
            public List<System.String> Vpc_SubnetId { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateMarketplaceModelEndpointResponse, UpdateBDRMarketplaceModelEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MarketplaceModelEndpoint;
        }
        
    }
}
