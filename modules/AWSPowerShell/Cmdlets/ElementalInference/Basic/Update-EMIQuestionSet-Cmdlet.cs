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
using Amazon.ElementalInference;
using Amazon.ElementalInference.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMI
{
    /// <summary>
    /// Updates the DRAFT version of the specified question set. UpdateQuestionSet doesn't
    /// create a version and doesn't change published versions. To publish the updated DRAFT
    /// as a new version, use CreateQuestionSetVersion. 
    /// 
    ///  
    /// <para>
    /// UpdateQuestionSet replaces questions one type at a time. For each of yesNo, yesNoPerOption,
    /// and chooseOne: if you omit the array, DRAFT keeps its questions of that type. If you
    /// include the array, it replaces all the questions of that type in DRAFT. If you include
    /// an empty array, DRAFT no longer has questions of that type. The updated DRAFT must
    /// follow the same rules as in CreateQuestionSet, and Elemental Inference applies those
    /// rules to the questions that DRAFT keeps as well as to the questions in the request.
    /// 
    /// </para><para>
    /// Feeds that reference the DRAFT version use the updated questions. To make sure that
    /// the questions for a feed don't change, reference a published version instead. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EMIQuestionSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.UpdateQuestionSetResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference UpdateQuestionSet API operation.", Operation = new[] {"UpdateQuestionSet"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.UpdateQuestionSetResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.UpdateQuestionSetResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.UpdateQuestionSetResponse object containing multiple properties."
    )]
    public partial class UpdateEMIQuestionSetCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChooseOne
        /// <summary>
        /// <para>
        /// <para>An array of questions that Elemental Inference answers by choosing one of their options,
        /// to replace all the chooseOne questions in DRAFT. You can specify up to 10 chooseOne
        /// questions. If not specified, the chooseOne questions are not changed. To remove all
        /// the chooseOne questions, specify an empty array. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElementalInference.Model.ChooseOneQuestion[] ChooseOne { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the question set to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the question set. If not specified, the name is not changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter YesNo
        /// <summary>
        /// <para>
        /// <para>An array of questions that Elemental Inference answers with yes or no, to replace
        /// all the yesNo questions in DRAFT. You can specify up to 50 yesNo questions. If not
        /// specified, the yesNo questions are not changed. To remove all the yesNo questions,
        /// specify an empty array. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElementalInference.Model.YesNoQuestion[] YesNo { get; set; }
        #endregion
        
        #region Parameter YesNoPerOption
        /// <summary>
        /// <para>
        /// <para>An array of questions that you ask about each of their options, to replace all the
        /// yesNoPerOption questions in DRAFT. You can specify up to 10 yesNoPerOption questions.
        /// If not specified, the yesNoPerOption questions are not changed. To remove all the
        /// yesNoPerOption questions, specify an empty array. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElementalInference.Model.YesNoPerOptionQuestion[] YesNoPerOption { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.UpdateQuestionSetResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.UpdateQuestionSetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMIQuestionSet (UpdateQuestionSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.UpdateQuestionSetResponse, UpdateEMIQuestionSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ChooseOne != null)
            {
                context.ChooseOne = new List<Amazon.ElementalInference.Model.ChooseOneQuestion>(this.ChooseOne);
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.YesNo != null)
            {
                context.YesNo = new List<Amazon.ElementalInference.Model.YesNoQuestion>(this.YesNo);
            }
            if (this.YesNoPerOption != null)
            {
                context.YesNoPerOption = new List<Amazon.ElementalInference.Model.YesNoPerOptionQuestion>(this.YesNoPerOption);
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
            var request = new Amazon.ElementalInference.Model.UpdateQuestionSetRequest();
            
            if (cmdletContext.ChooseOne != null)
            {
                request.ChooseOne = cmdletContext.ChooseOne;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.YesNo != null)
            {
                request.YesNo = cmdletContext.YesNo;
            }
            if (cmdletContext.YesNoPerOption != null)
            {
                request.YesNoPerOption = cmdletContext.YesNoPerOption;
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
        
        private Amazon.ElementalInference.Model.UpdateQuestionSetResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.UpdateQuestionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "UpdateQuestionSet");
            try
            {
                return client.UpdateQuestionSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ElementalInference.Model.ChooseOneQuestion> ChooseOne { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ElementalInference.Model.YesNoQuestion> YesNo { get; set; }
            public List<Amazon.ElementalInference.Model.YesNoPerOptionQuestion> YesNoPerOption { get; set; }
            public System.Func<Amazon.ElementalInference.Model.UpdateQuestionSetResponse, UpdateEMIQuestionSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
