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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Creates a new Call Analytics category.
    /// 
    ///  
    /// <para>
    /// All categories are automatically applied to your Call Analytics transcriptions. Note
    /// that in order to apply categories to your transcriptions, you must create them before
    /// submitting your transcription request, as categories cannot be applied retroactively.
    /// </para><para>
    /// When creating a new category, you can use the <c>InputType</c> parameter to label
    /// the category as a <c>POST_CALL</c> or a <c>REAL_TIME</c> category. <c>POST_CALL</c>
    /// categories can only be applied to post-call transcriptions and <c>REAL_TIME</c> categories
    /// can only be applied to real-time transcriptions. If you do not include <c>InputType</c>,
    /// your category is created as a <c>POST_CALL</c> category by default.
    /// </para><para>
    /// Call Analytics categories are composed of rules. For each category, you must create
    /// between 1 and 20 rules. Rules can include these parameters: , , , and .
    /// </para><para>
    /// To update an existing category, see .
    /// </para><para>
    /// To learn more about Call Analytics categories, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tca-categories-batch.html">Creating
    /// categories for post-call transcriptions</a> and <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tca-categories-stream.html">Creating
    /// categories for real-time transcriptions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "TRSCallAnalyticsCategory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CategoryProperties")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateCallAnalyticsCategory API operation.", Operation = new[] {"CreateCallAnalyticsCategory"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CategoryProperties or Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CategoryProperties object.",
        "The service call response (type Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTRSCallAnalyticsCategoryCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CategoryName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your Call Analytics category. It's helpful to use
        /// a detailed naming system that will make sense to you in the future. For example, it's
        /// better to use <c>sentiment-positive-last30seconds</c> for a category over a generic
        /// name like <c>test-category</c>.</para><para>Category names are case sensitive.</para>
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
        public System.String CategoryName { get; set; }
        #endregion
        
        #region Parameter InputType
        /// <summary>
        /// <para>
        /// <para>Choose whether you want to create a real-time or a post-call category for your Call
        /// Analytics transcription.</para><para>Specifying <c>POST_CALL</c> assigns your category to post-call transcriptions; categories
        /// with this input type cannot be applied to streaming (real-time) transcriptions.</para><para>Specifying <c>REAL_TIME</c> assigns your category to streaming transcriptions; categories
        /// with this input type cannot be applied to post-call transcriptions.</para><para>If you do not include <c>InputType</c>, your category is created as a post-call category
        /// by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.InputType")]
        public Amazon.TranscribeService.InputType InputType { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>Rules define a Call Analytics category. When creating a new category, you must create
        /// between 1 and 20 rules for that category. For each rule, you specify a filter you
        /// want applied to the attributes of a call. For example, you can choose a sentiment
        /// filter that detects if a customer's sentiment was positive during the last 30 seconds
        /// of the call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Rules")]
        public Amazon.TranscribeService.Model.Rule[] Rule { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new call
        /// analytics category at the time you start this new job.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CategoryProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CategoryProperties";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CategoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSCallAnalyticsCategory (CreateCallAnalyticsCategory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse, NewTRSCallAnalyticsCategoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CategoryName = this.CategoryName;
            #if MODULAR
            if (this.CategoryName == null && ParameterWasBound(nameof(this.CategoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter CategoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputType = this.InputType;
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.TranscribeService.Model.Rule>(this.Rule);
            }
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
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
            var request = new Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryRequest();
            
            if (cmdletContext.CategoryName != null)
            {
                request.CategoryName = cmdletContext.CategoryName;
            }
            if (cmdletContext.InputType != null)
            {
                request.InputType = cmdletContext.InputType;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateCallAnalyticsCategory");
            try
            {
                return client.CreateCallAnalyticsCategoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CategoryName { get; set; }
            public Amazon.TranscribeService.InputType InputType { get; set; }
            public List<Amazon.TranscribeService.Model.Rule> Rule { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.TranscribeService.Model.CreateCallAnalyticsCategoryResponse, NewTRSCallAnalyticsCategoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CategoryProperties;
        }
        
    }
}
