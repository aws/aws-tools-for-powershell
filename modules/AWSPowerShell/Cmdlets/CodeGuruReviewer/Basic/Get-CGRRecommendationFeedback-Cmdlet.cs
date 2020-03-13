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
using Amazon.CodeGuruReviewer;
using Amazon.CodeGuruReviewer.Model;

namespace Amazon.PowerShell.Cmdlets.CGR
{
    /// <summary>
    /// Describes the customer feedback for a CodeGuru Reviewer recommendation.
    /// </summary>
    [Cmdlet("Get", "CGRRecommendationFeedback")]
    [OutputType("Amazon.CodeGuruReviewer.Model.RecommendationFeedback")]
    [AWSCmdlet("Calls the Amazon CodeGuru Reviewer DescribeRecommendationFeedback API operation.", Operation = new[] {"DescribeRecommendationFeedback"}, SelectReturnType = typeof(Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruReviewer.Model.RecommendationFeedback or Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse",
        "This cmdlet returns an Amazon.CodeGuruReviewer.Model.RecommendationFeedback object.",
        "The service call response (type Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCGRRecommendationFeedbackCmdlet : AmazonCodeGuruReviewerClientCmdlet, IExecutor
    {
        
        #region Parameter CodeReviewArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that identifies the code review. </para>
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
        public System.String CodeReviewArn { get; set; }
        #endregion
        
        #region Parameter RecommendationId
        /// <summary>
        /// <para>
        /// <para> The recommendation ID that can be used to track the provided recommendations and
        /// then to collect the feedback. </para>
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
        public System.String RecommendationId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para> Optional parameter to describe the feedback for a given user. If this is not supplied,
        /// it defaults to the user making the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendationFeedback'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendationFeedback";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecommendationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecommendationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecommendationId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse, GetCGRRecommendationFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecommendationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CodeReviewArn = this.CodeReviewArn;
            #if MODULAR
            if (this.CodeReviewArn == null && ParameterWasBound(nameof(this.CodeReviewArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeReviewArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommendationId = this.RecommendationId;
            #if MODULAR
            if (this.RecommendationId == null && ParameterWasBound(nameof(this.RecommendationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            
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
            var request = new Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackRequest();
            
            if (cmdletContext.CodeReviewArn != null)
            {
                request.CodeReviewArn = cmdletContext.CodeReviewArn;
            }
            if (cmdletContext.RecommendationId != null)
            {
                request.RecommendationId = cmdletContext.RecommendationId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse CallAWSServiceOperation(IAmazonCodeGuruReviewer client, Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Reviewer", "DescribeRecommendationFeedback");
            try
            {
                #if DESKTOP
                return client.DescribeRecommendationFeedback(request);
                #elif CORECLR
                return client.DescribeRecommendationFeedbackAsync(request).GetAwaiter().GetResult();
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
            public System.String CodeReviewArn { get; set; }
            public System.String RecommendationId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.CodeGuruReviewer.Model.DescribeRecommendationFeedbackResponse, GetCGRRecommendationFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendationFeedback;
        }
        
    }
}
