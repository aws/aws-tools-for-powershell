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
using Amazon.Artifact;
using Amazon.Artifact.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ART
{
    /// <summary>
    /// Submits feedback on a compliance inquiry response.
    /// </summary>
    [Cmdlet("Write", "ARTComplianceInquiryFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Artifact PutComplianceInquiryFeedback API operation.", Operation = new[] {"PutComplianceInquiryFeedback"}, SelectReturnType = typeof(Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse",
        "This cmdlet returns a collection of System.DateTime objects.",
        "The service call response (type Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteARTComplianceInquiryFeedbackCmdlet : AmazonArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment for the feedback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ComplianceInquiryId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the compliance inquiry.</para>
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
        public System.String ComplianceInquiryId { get; set; }
        #endregion
        
        #region Parameter QueryIdentifier
        /// <summary>
        /// <para>
        /// <para>The sequential identifier of the query to provide feedback on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? QueryIdentifier { get; set; }
        #endregion
        
        #region Parameter Rating
        /// <summary>
        /// <para>
        /// <para>The rating for the feedback. Valid values are THUMBS_UP and THUMBS_DOWN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Artifact.FeedbackRating")]
        public Amazon.Artifact.FeedbackRating Rating { get; set; }
        #endregion
        
        #region Parameter ReasonCode
        /// <summary>
        /// <para>
        /// <para>The reason codes that describe why you rated the response. Valid values are OTHER,
        /// PARTIAL_RESPONSE, and IRRELEVANT_RESPONSE.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReasonCodes")]
        public System.String[] ReasonCode { get; set; }
        #endregion
        
        #region Parameter ResponseRevisionId
        /// <summary>
        /// <para>
        /// <para>The response revision ID. Use this value to prevent submitting feedback on a stale
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResponseRevisionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the service ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubmittedAt'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse).
        /// Specifying the name of a property of type Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubmittedAt";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComplianceInquiryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ARTComplianceInquiryFeedback (PutComplianceInquiryFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse, WriteARTComplianceInquiryFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Comment = this.Comment;
            context.ComplianceInquiryId = this.ComplianceInquiryId;
            #if MODULAR
            if (this.ComplianceInquiryId == null && ParameterWasBound(nameof(this.ComplianceInquiryId)))
            {
                WriteWarning("You are passing $null as a value for parameter ComplianceInquiryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryIdentifier = this.QueryIdentifier;
            context.Rating = this.Rating;
            #if MODULAR
            if (this.Rating == null && ParameterWasBound(nameof(this.Rating)))
            {
                WriteWarning("You are passing $null as a value for parameter Rating which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReasonCode != null)
            {
                context.ReasonCode = new List<System.String>(this.ReasonCode);
            }
            context.ResponseRevisionId = this.ResponseRevisionId;
            
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
            var request = new Amazon.Artifact.Model.PutComplianceInquiryFeedbackRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.ComplianceInquiryId != null)
            {
                request.ComplianceInquiryId = cmdletContext.ComplianceInquiryId;
            }
            if (cmdletContext.QueryIdentifier != null)
            {
                request.QueryIdentifier = cmdletContext.QueryIdentifier.Value;
            }
            if (cmdletContext.Rating != null)
            {
                request.Rating = cmdletContext.Rating;
            }
            if (cmdletContext.ReasonCode != null)
            {
                request.ReasonCodes = cmdletContext.ReasonCode;
            }
            if (cmdletContext.ResponseRevisionId != null)
            {
                request.ResponseRevisionId = cmdletContext.ResponseRevisionId.Value;
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
        
        private Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse CallAWSServiceOperation(IAmazonArtifact client, Amazon.Artifact.Model.PutComplianceInquiryFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Artifact", "PutComplianceInquiryFeedback");
            try
            {
                return client.PutComplianceInquiryFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public System.String ComplianceInquiryId { get; set; }
            public System.Int32? QueryIdentifier { get; set; }
            public Amazon.Artifact.FeedbackRating Rating { get; set; }
            public List<System.String> ReasonCode { get; set; }
            public System.Int32? ResponseRevisionId { get; set; }
            public System.Func<Amazon.Artifact.Model.PutComplianceInquiryFeedbackResponse, WriteARTComplianceInquiryFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubmittedAt;
        }
        
    }
}
