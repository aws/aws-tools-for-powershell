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

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Registers an existing Amazon SageMaker endpoint with Amazon Bedrock Marketplace, allowing
    /// it to be used with Amazon Bedrock APIs.
    /// </summary>
    [Cmdlet("Register", "BDRMarketplaceModelEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.MarketplaceModelEndpoint")]
    [AWSCmdlet("Calls the Amazon Bedrock RegisterMarketplaceModelEndpoint API operation.", Operation = new[] {"RegisterMarketplaceModelEndpoint"}, SelectReturnType = typeof(Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.MarketplaceModelEndpoint or Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.MarketplaceModelEndpoint object.",
        "The service call response (type Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterBDRMarketplaceModelEndpointCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon SageMaker endpoint you want to register with Amazon Bedrock
        /// Marketplace.</para>
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
        public System.String EndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter ModelSourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the model from Amazon Bedrock Marketplace that is deployed on the endpoint.</para>
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
        public System.String ModelSourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MarketplaceModelEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-BDRMarketplaceModelEndpoint (RegisterMarketplaceModelEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse, RegisterBDRMarketplaceModelEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndpointIdentifier = this.EndpointIdentifier;
            #if MODULAR
            if (this.EndpointIdentifier == null && ParameterWasBound(nameof(this.EndpointIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelSourceIdentifier = this.ModelSourceIdentifier;
            #if MODULAR
            if (this.ModelSourceIdentifier == null && ParameterWasBound(nameof(this.ModelSourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelSourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointRequest();
            
            if (cmdletContext.EndpointIdentifier != null)
            {
                request.EndpointIdentifier = cmdletContext.EndpointIdentifier;
            }
            if (cmdletContext.ModelSourceIdentifier != null)
            {
                request.ModelSourceIdentifier = cmdletContext.ModelSourceIdentifier;
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
        
        private Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "RegisterMarketplaceModelEndpoint");
            try
            {
                return client.RegisterMarketplaceModelEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EndpointIdentifier { get; set; }
            public System.String ModelSourceIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.RegisterMarketplaceModelEndpointResponse, RegisterBDRMarketplaceModelEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MarketplaceModelEndpoint;
        }
        
    }
}
