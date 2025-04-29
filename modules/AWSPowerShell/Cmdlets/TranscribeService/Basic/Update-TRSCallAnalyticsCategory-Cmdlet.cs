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
    /// Updates the specified Call Analytics category with new rules. Note that the <c>UpdateCallAnalyticsCategory</c>
    /// operation overwrites all existing rules contained in the specified category. You cannot
    /// append additional rules onto an existing category.
    /// 
    ///  
    /// <para>
    /// To create a new category, see .
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TRSCallAnalyticsCategory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CategoryProperties")]
    [AWSCmdlet("Calls the Amazon Transcribe Service UpdateCallAnalyticsCategory API operation.", Operation = new[] {"UpdateCallAnalyticsCategory"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CategoryProperties or Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CategoryProperties object.",
        "The service call response (type Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTRSCallAnalyticsCategoryCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CategoryName
        /// <summary>
        /// <para>
        /// <para>The name of the Call Analytics category you want to update. Category names are case
        /// sensitive.</para>
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
        /// <para>Choose whether you want to update a real-time or a post-call category. The input type
        /// you specify must match the input type specified when the category was created. For
        /// example, if you created a category with the <c>POST_CALL</c> input type, you must
        /// use <c>POST_CALL</c> as the input type when updating this category.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.InputType")]
        public Amazon.TranscribeService.InputType InputType { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The rules used for the updated Call Analytics category. The rules you provide in this
        /// field replace the ones that are currently being used in the specified category.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CategoryProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TRSCallAnalyticsCategory (UpdateCallAnalyticsCategory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse, UpdateTRSCallAnalyticsCategoryCmdlet>(Select) ??
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
            var request = new Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryRequest();
            
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
        
        private Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "UpdateCallAnalyticsCategory");
            try
            {
                return client.UpdateCallAnalyticsCategoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.TranscribeService.Model.UpdateCallAnalyticsCategoryResponse, UpdateTRSCallAnalyticsCategoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CategoryProperties;
        }
        
    }
}
