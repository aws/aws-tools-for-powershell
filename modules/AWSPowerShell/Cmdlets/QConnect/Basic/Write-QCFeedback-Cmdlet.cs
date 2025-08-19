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
using Amazon.QConnect;
using Amazon.QConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Provides feedback against the specified assistant for the specified target. This API
    /// only supports generative targets.
    /// </summary>
    [Cmdlet("Write", "QCFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.PutFeedbackResponse")]
    [AWSCmdlet("Calls the Amazon Q Connect PutFeedback API operation.", Operation = new[] {"PutFeedback"}, SelectReturnType = typeof(Amazon.QConnect.Model.PutFeedbackResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.PutFeedbackResponse",
        "This cmdlet returns an Amazon.QConnect.Model.PutFeedbackResponse object containing multiple properties."
    )]
    public partial class WriteQCFeedbackCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter GenerativeContentFeedbackData_Relevance
        /// <summary>
        /// <para>
        /// <para>The relevance of the feedback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContentFeedback_GenerativeContentFeedbackData_Relevance")]
        [AWSConstantClassSource("Amazon.QConnect.Relevance")]
        public Amazon.QConnect.Relevance GenerativeContentFeedbackData_Relevance { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the feedback target.</para>
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
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>The type of the feedback target.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.TargetType")]
        public Amazon.QConnect.TargetType TargetType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.PutFeedbackResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.PutFeedbackResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-QCFeedback (PutFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.PutFeedbackResponse, WriteQCFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GenerativeContentFeedbackData_Relevance = this.GenerativeContentFeedbackData_Relevance;
            context.TargetId = this.TargetId;
            #if MODULAR
            if (this.TargetId == null && ParameterWasBound(nameof(this.TargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetType = this.TargetType;
            #if MODULAR
            if (this.TargetType == null && ParameterWasBound(nameof(this.TargetType)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.PutFeedbackRequest();
            
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            
             // populate ContentFeedback
            request.ContentFeedback = new Amazon.QConnect.Model.ContentFeedbackData();
            Amazon.QConnect.Model.GenerativeContentFeedbackData requestContentFeedback_contentFeedback_GenerativeContentFeedbackData = null;
            
             // populate GenerativeContentFeedbackData
            var requestContentFeedback_contentFeedback_GenerativeContentFeedbackDataIsNull = true;
            requestContentFeedback_contentFeedback_GenerativeContentFeedbackData = new Amazon.QConnect.Model.GenerativeContentFeedbackData();
            Amazon.QConnect.Relevance requestContentFeedback_contentFeedback_GenerativeContentFeedbackData_generativeContentFeedbackData_Relevance = null;
            if (cmdletContext.GenerativeContentFeedbackData_Relevance != null)
            {
                requestContentFeedback_contentFeedback_GenerativeContentFeedbackData_generativeContentFeedbackData_Relevance = cmdletContext.GenerativeContentFeedbackData_Relevance;
            }
            if (requestContentFeedback_contentFeedback_GenerativeContentFeedbackData_generativeContentFeedbackData_Relevance != null)
            {
                requestContentFeedback_contentFeedback_GenerativeContentFeedbackData.Relevance = requestContentFeedback_contentFeedback_GenerativeContentFeedbackData_generativeContentFeedbackData_Relevance;
                requestContentFeedback_contentFeedback_GenerativeContentFeedbackDataIsNull = false;
            }
             // determine if requestContentFeedback_contentFeedback_GenerativeContentFeedbackData should be set to null
            if (requestContentFeedback_contentFeedback_GenerativeContentFeedbackDataIsNull)
            {
                requestContentFeedback_contentFeedback_GenerativeContentFeedbackData = null;
            }
            if (requestContentFeedback_contentFeedback_GenerativeContentFeedbackData != null)
            {
                request.ContentFeedback.GenerativeContentFeedbackData = requestContentFeedback_contentFeedback_GenerativeContentFeedbackData;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
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
        
        private Amazon.QConnect.Model.PutFeedbackResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.PutFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "PutFeedback");
            try
            {
                return client.PutFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssistantId { get; set; }
            public Amazon.QConnect.Relevance GenerativeContentFeedbackData_Relevance { get; set; }
            public System.String TargetId { get; set; }
            public Amazon.QConnect.TargetType TargetType { get; set; }
            public System.Func<Amazon.QConnect.Model.PutFeedbackResponse, WriteQCFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
