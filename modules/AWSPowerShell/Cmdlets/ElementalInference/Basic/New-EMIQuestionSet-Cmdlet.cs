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
    /// Creates a question set. Use a question set to get answers about content that's specific
    /// to your business, in addition to the built-in contextual metadata classifications.
    /// A question set contains your own questions. You ask Elemental Inference these questions
    /// about each shot or scene of the media in a contextual metadata output, and Elemental
    /// Inference answers each question with scores. To use a question set, reference it in
    /// the customQuestions property of the contextual metadata configuration of a feed output.
    /// 
    /// 
    ///  
    /// <para>
    /// CreateQuestionSet creates the question set with a DRAFT version that contains the
    /// questions in the request. To change DRAFT, use UpdateQuestionSet. To publish DRAFT
    /// as a numbered version, use CreateQuestionSetVersion. You can't change a published
    /// version. 
    /// </para><para>
    /// A question set can contain the following types of questions. You must specify at least
    /// one question. 
    /// </para><ul><li><para>
    /// yesNo – Elemental Inference answers yes or no.
    /// </para></li><li><para>
    /// yesNoPerOption – Elemental Inference answers yes or no for each option.
    /// </para></li><li><para>
    /// chooseOne – Elemental Inference chooses one of the options.
    /// </para></li></ul><para>
    /// A version can contain up to 100 scored items, where each yesNo question, each option
    /// of a yesNoPerOption question, and each chooseOne question counts as one item. The
    /// name of each question must be unique across all three types. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EMIQuestionSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.CreateQuestionSetResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference CreateQuestionSet API operation.", Operation = new[] {"CreateQuestionSet"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.CreateQuestionSetResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.CreateQuestionSetResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.CreateQuestionSetResponse object containing multiple properties."
    )]
    public partial class NewEMIQuestionSetCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChooseOne
        /// <summary>
        /// <para>
        /// <para>An array of questions that Elemental Inference answers by choosing one of their options.
        /// You can specify up to 10 chooseOne questions. An empty array is the same as omitting
        /// this property. </para><para />
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for this question set.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags to associate with the question set. You can also add tags later, using
        /// TagResource. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter YesNo
        /// <summary>
        /// <para>
        /// <para>An array of questions that Elemental Inference answers with yes or no. You can specify
        /// up to 50 yesNo questions. An empty array is the same as omitting this property. </para><para />
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
        /// <para>An array of questions that you ask about each of their options. Elemental Inference
        /// answers yes or no for each option. You can specify up to 10 yesNoPerOption questions.
        /// An empty array is the same as omitting this property. </para><para />
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.CreateQuestionSetResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.CreateQuestionSetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMIQuestionSet (CreateQuestionSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.CreateQuestionSetResponse, NewEMIQuestionSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ChooseOne != null)
            {
                context.ChooseOne = new List<Amazon.ElementalInference.Model.ChooseOneQuestion>(this.ChooseOne);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.ElementalInference.Model.CreateQuestionSetRequest();
            
            if (cmdletContext.ChooseOne != null)
            {
                request.ChooseOne = cmdletContext.ChooseOne;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElementalInference.Model.CreateQuestionSetResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.CreateQuestionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "CreateQuestionSet");
            try
            {
                return client.CreateQuestionSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.ElementalInference.Model.YesNoQuestion> YesNo { get; set; }
            public List<Amazon.ElementalInference.Model.YesNoPerOptionQuestion> YesNoPerOption { get; set; }
            public System.Func<Amazon.ElementalInference.Model.CreateQuestionSetResponse, NewEMIQuestionSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
