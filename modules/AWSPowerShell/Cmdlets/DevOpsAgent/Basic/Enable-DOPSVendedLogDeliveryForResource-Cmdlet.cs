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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Authorize Ingestion Hub subscription operation. Looks to see if the derived accountId
    /// from FAS has an AgentSpace.
    /// </summary>
    [Cmdlet("Enable", "DOPSVendedLogDeliveryForResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service AllowVendedLogDeliveryForResource API operation.", Operation = new[] {"AllowVendedLogDeliveryForResource"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableDOPSVendedLogDeliveryForResourceCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliverySourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the delivery source for vended log delivery.</para>
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
        public System.String DeliverySourceArn { get; set; }
        #endregion
        
        #region Parameter LogType
        /// <summary>
        /// <para>
        /// <para>The type of log to be delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogType { get; set; }
        #endregion
        
        #region Parameter ResourceArnBeingAuthorized
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource being authorized for vended log delivery.</para>
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
        public System.String ResourceArnBeingAuthorized { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Message'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Message";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliverySourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DOPSVendedLogDeliveryForResource (AllowVendedLogDeliveryForResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse, EnableDOPSVendedLogDeliveryForResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliverySourceArn = this.DeliverySourceArn;
            #if MODULAR
            if (this.DeliverySourceArn == null && ParameterWasBound(nameof(this.DeliverySourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliverySourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogType = this.LogType;
            context.ResourceArnBeingAuthorized = this.ResourceArnBeingAuthorized;
            #if MODULAR
            if (this.ResourceArnBeingAuthorized == null && ParameterWasBound(nameof(this.ResourceArnBeingAuthorized)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArnBeingAuthorized which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceRequest();
            
            if (cmdletContext.DeliverySourceArn != null)
            {
                request.DeliverySourceArn = cmdletContext.DeliverySourceArn;
            }
            if (cmdletContext.LogType != null)
            {
                request.LogType = cmdletContext.LogType;
            }
            if (cmdletContext.ResourceArnBeingAuthorized != null)
            {
                request.ResourceArnBeingAuthorized = cmdletContext.ResourceArnBeingAuthorized;
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
        
        private Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "AllowVendedLogDeliveryForResource");
            try
            {
                return client.AllowVendedLogDeliveryForResourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeliverySourceArn { get; set; }
            public System.String LogType { get; set; }
            public System.String ResourceArnBeingAuthorized { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.AllowVendedLogDeliveryForResourceResponse, EnableDOPSVendedLogDeliveryForResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Message;
        }
        
    }
}
