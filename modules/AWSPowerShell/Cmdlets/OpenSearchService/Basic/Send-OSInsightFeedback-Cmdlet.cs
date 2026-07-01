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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Submits feedback for an existing insight in an Amazon OpenSearch Service domain. Allows
    /// users to provide a thumbs up or thumbs down rating and optional text feedback for
    /// a specific insight.
    /// </summary>
    [Cmdlet("Send", "OSInsightFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.InsightResponseStatus")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service InsightFeedback API operation.", Operation = new[] {"InsightFeedback"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.InsightFeedbackResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.InsightResponseStatus or Amazon.OpenSearchService.Model.InsightFeedbackResponse",
        "This cmdlet returns an Amazon.OpenSearchService.InsightResponseStatus object.",
        "The service call response (type Amazon.OpenSearchService.Model.InsightFeedbackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendOSInsightFeedbackCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FeedbackText
        /// <summary>
        /// <para>
        /// <para>Optional text feedback providing additional details about the insight. Maximum length
        /// is 1000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackText { get; set; }
        #endregion
        
        #region Parameter InsightId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the insight for which to submit feedback.</para>
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
        public System.String InsightId { get; set; }
        #endregion
        
        #region Parameter Thumb
        /// <summary>
        /// <para>
        /// <para>The thumbs up or thumbs down feedback for the insight. Possible values are <c>Up</c>
        /// and <c>Down</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Thumbs")]
        [AWSConstantClassSource("Amazon.OpenSearchService.InsightFeedbackThumbs")]
        public Amazon.OpenSearchService.InsightFeedbackThumbs Thumb { get; set; }
        #endregion
        
        #region Parameter Entity_Type
        /// <summary>
        /// <para>
        /// <para>The type of the entity. Possible values are <c>DomainName</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchService.InsightFeedbackEntityType")]
        public Amazon.OpenSearchService.InsightFeedbackEntityType Entity_Type { get; set; }
        #endregion
        
        #region Parameter Entity_Value
        /// <summary>
        /// <para>
        /// <para>The value of the entity, such as a domain name.</para>
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
        public System.String Entity_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.InsightFeedbackResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.InsightFeedbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InsightId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-OSInsightFeedback (InsightFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.InsightFeedbackResponse, SendOSInsightFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Entity_Type = this.Entity_Type;
            #if MODULAR
            if (this.Entity_Type == null && ParameterWasBound(nameof(this.Entity_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Entity_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Entity_Value = this.Entity_Value;
            #if MODULAR
            if (this.Entity_Value == null && ParameterWasBound(nameof(this.Entity_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Entity_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FeedbackText = this.FeedbackText;
            context.InsightId = this.InsightId;
            #if MODULAR
            if (this.InsightId == null && ParameterWasBound(nameof(this.InsightId)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Thumb = this.Thumb;
            #if MODULAR
            if (this.Thumb == null && ParameterWasBound(nameof(this.Thumb)))
            {
                WriteWarning("You are passing $null as a value for parameter Thumb which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.InsightFeedbackRequest();
            
            
             // populate Entity
            var requestEntityIsNull = true;
            request.Entity = new Amazon.OpenSearchService.Model.InsightFeedbackEntity();
            Amazon.OpenSearchService.InsightFeedbackEntityType requestEntity_entity_Type = null;
            if (cmdletContext.Entity_Type != null)
            {
                requestEntity_entity_Type = cmdletContext.Entity_Type;
            }
            if (requestEntity_entity_Type != null)
            {
                request.Entity.Type = requestEntity_entity_Type;
                requestEntityIsNull = false;
            }
            System.String requestEntity_entity_Value = null;
            if (cmdletContext.Entity_Value != null)
            {
                requestEntity_entity_Value = cmdletContext.Entity_Value;
            }
            if (requestEntity_entity_Value != null)
            {
                request.Entity.Value = requestEntity_entity_Value;
                requestEntityIsNull = false;
            }
             // determine if request.Entity should be set to null
            if (requestEntityIsNull)
            {
                request.Entity = null;
            }
            if (cmdletContext.FeedbackText != null)
            {
                request.FeedbackText = cmdletContext.FeedbackText;
            }
            if (cmdletContext.InsightId != null)
            {
                request.InsightId = cmdletContext.InsightId;
            }
            if (cmdletContext.Thumb != null)
            {
                request.Thumbs = cmdletContext.Thumb;
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
        
        private Amazon.OpenSearchService.Model.InsightFeedbackResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.InsightFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "InsightFeedback");
            try
            {
                return client.InsightFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.OpenSearchService.InsightFeedbackEntityType Entity_Type { get; set; }
            public System.String Entity_Value { get; set; }
            public System.String FeedbackText { get; set; }
            public System.String InsightId { get; set; }
            public Amazon.OpenSearchService.InsightFeedbackThumbs Thumb { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.InsightFeedbackResponse, SendOSInsightFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
