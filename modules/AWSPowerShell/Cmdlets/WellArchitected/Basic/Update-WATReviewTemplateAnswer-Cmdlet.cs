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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Update a review template answer.
    /// </summary>
    [Cmdlet("Update", "WATReviewTemplateAnswer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool UpdateReviewTemplateAnswer API operation.", Operation = new[] {"UpdateReviewTemplateAnswer"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse object containing multiple properties."
    )]
    public partial class UpdateWATReviewTemplateAnswerCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChoiceUpdate
        /// <summary>
        /// <para>
        /// <para>A list of choices to be updated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChoiceUpdates")]
        public System.Collections.Hashtable ChoiceUpdate { get; set; }
        #endregion
        
        #region Parameter IsApplicable
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsApplicable { get; set; }
        #endregion
        
        #region Parameter LensAlias
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String LensAlias { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter QuestionId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String QuestionId { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>The update reason.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.AnswerReason")]
        public Amazon.WellArchitected.AnswerReason Reason { get; set; }
        #endregion
        
        #region Parameter SelectedChoice
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectedChoices")]
        public System.String[] SelectedChoice { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>The review template ARN.</para>
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
        public System.String TemplateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WATReviewTemplateAnswer (UpdateReviewTemplateAnswer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse, UpdateWATReviewTemplateAnswerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ChoiceUpdate != null)
            {
                context.ChoiceUpdate = new Dictionary<System.String, Amazon.WellArchitected.Model.ChoiceUpdate>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChoiceUpdate.Keys)
                {
                    context.ChoiceUpdate.Add((String)hashKey, (Amazon.WellArchitected.Model.ChoiceUpdate)(this.ChoiceUpdate[hashKey]));
                }
            }
            context.IsApplicable = this.IsApplicable;
            context.LensAlias = this.LensAlias;
            #if MODULAR
            if (this.LensAlias == null && ParameterWasBound(nameof(this.LensAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter LensAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Note = this.Note;
            context.QuestionId = this.QuestionId;
            #if MODULAR
            if (this.QuestionId == null && ParameterWasBound(nameof(this.QuestionId)))
            {
                WriteWarning("You are passing $null as a value for parameter QuestionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            if (this.SelectedChoice != null)
            {
                context.SelectedChoice = new List<System.String>(this.SelectedChoice);
            }
            context.TemplateArn = this.TemplateArn;
            #if MODULAR
            if (this.TemplateArn == null && ParameterWasBound(nameof(this.TemplateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerRequest();
            
            if (cmdletContext.ChoiceUpdate != null)
            {
                request.ChoiceUpdates = cmdletContext.ChoiceUpdate;
            }
            if (cmdletContext.IsApplicable != null)
            {
                request.IsApplicable = cmdletContext.IsApplicable.Value;
            }
            if (cmdletContext.LensAlias != null)
            {
                request.LensAlias = cmdletContext.LensAlias;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            if (cmdletContext.QuestionId != null)
            {
                request.QuestionId = cmdletContext.QuestionId;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.SelectedChoice != null)
            {
                request.SelectedChoices = cmdletContext.SelectedChoice;
            }
            if (cmdletContext.TemplateArn != null)
            {
                request.TemplateArn = cmdletContext.TemplateArn;
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
        
        private Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "UpdateReviewTemplateAnswer");
            try
            {
                return client.UpdateReviewTemplateAnswerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.WellArchitected.Model.ChoiceUpdate> ChoiceUpdate { get; set; }
            public System.Boolean? IsApplicable { get; set; }
            public System.String LensAlias { get; set; }
            public System.String Note { get; set; }
            public System.String QuestionId { get; set; }
            public Amazon.WellArchitected.AnswerReason Reason { get; set; }
            public List<System.String> SelectedChoice { get; set; }
            public System.String TemplateArn { get; set; }
            public System.Func<Amazon.WellArchitected.Model.UpdateReviewTemplateAnswerResponse, UpdateWATReviewTemplateAnswerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
