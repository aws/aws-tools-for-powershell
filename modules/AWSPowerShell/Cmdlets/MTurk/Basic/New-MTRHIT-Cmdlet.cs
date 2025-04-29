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
using Amazon.MTurk;
using Amazon.MTurk.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>CreateHIT</c> operation creates a new Human Intelligence Task (HIT). The new
    /// HIT is made available for Workers to find and accept on the Amazon Mechanical Turk
    /// website. 
    /// 
    ///  
    /// <para>
    ///  This operation allows you to specify a new HIT by passing in values for the properties
    /// of the HIT, such as its title, reward amount and number of assignments. When you pass
    /// these values to <c>CreateHIT</c>, a new HIT is created for you, with a new <c>HITTypeID</c>.
    /// The HITTypeID can be used to create additional HITs in the future without needing
    /// to specify common parameters such as the title, description and reward amount each
    /// time.
    /// </para><para>
    ///  An alternative way to create HITs is to first generate a HITTypeID using the <c>CreateHITType</c>
    /// operation and then call the <c>CreateHITWithHITType</c> operation. This is the recommended
    /// best practice for Requesters who are creating large numbers of HITs. 
    /// </para><para>
    /// CreateHIT also supports several ways to provide question data: by providing a value
    /// for the <c>Question</c> parameter that fully specifies the contents of the HIT, or
    /// by providing a <c>HitLayoutId</c> and associated <c>HitLayoutParameters</c>. 
    /// </para><note><para>
    ///  If a HIT is created with 10 or more maximum assignments, there is an additional fee.
    /// For more information, see <a href="https://requester.mturk.com/pricing">Amazon Mechanical
    /// Turk Pricing</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "MTRHIT", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MTurk.Model.HIT")]
    [AWSCmdlet("Calls the Amazon MTurk Service CreateHIT API operation.", Operation = new[] {"CreateHIT"}, SelectReturnType = typeof(Amazon.MTurk.Model.CreateHITResponse))]
    [AWSCmdletOutput("Amazon.MTurk.Model.HIT or Amazon.MTurk.Model.CreateHITResponse",
        "This cmdlet returns an Amazon.MTurk.Model.HIT object.",
        "The service call response (type Amazon.MTurk.Model.CreateHITResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMTRHITCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssignmentDurationInSecond
        /// <summary>
        /// <para>
        /// <para> The amount of time, in seconds, that a Worker has to complete the HIT after accepting
        /// it. If a Worker does not complete the assignment within the specified duration, the
        /// assignment is considered abandoned. If the HIT is still active (that is, its lifetime
        /// has not elapsed), the assignment becomes available for other users to find and accept.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AssignmentDurationInSeconds")]
        public System.Int64? AssignmentDurationInSecond { get; set; }
        #endregion
        
        #region Parameter AutoApprovalDelayInSecond
        /// <summary>
        /// <para>
        /// <para> The number of seconds after an assignment for the HIT has been submitted, after which
        /// the assignment is considered Approved automatically unless the Requester explicitly
        /// rejects it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoApprovalDelayInSeconds")]
        public System.Int64? AutoApprovalDelayInSecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A general description of the HIT. A description includes detailed information about
        /// the kind of task the HIT contains. On the Amazon Mechanical Turk web site, the HIT
        /// description appears in the expanded view of search results, and in the HIT and assignment
        /// screens. A good description gives the user enough information to evaluate the HIT
        /// before accepting it. </para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HITLayoutId
        /// <summary>
        /// <para>
        /// <para> The HITLayoutId allows you to use a pre-existing HIT design with placeholder values
        /// and create an additional HIT by providing those values as HITLayoutParameters. </para><para> Constraints: Either a Question parameter or a HITLayoutId parameter must be provided.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HITLayoutId { get; set; }
        #endregion
        
        #region Parameter HITLayoutParameter
        /// <summary>
        /// <para>
        /// <para> If the HITLayoutId is provided, any placeholder values must be filled in with values
        /// using the HITLayoutParameter structure. For more information, see HITLayout. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HITLayoutParameters")]
        public Amazon.MTurk.Model.HITLayoutParameter[] HITLayoutParameter { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para> One or more words or phrases that describe the HIT, separated by commas. These words
        /// are used in searches to find HITs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Keywords")]
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter LifetimeInSecond
        /// <summary>
        /// <para>
        /// <para> An amount of time, in seconds, after which the HIT is no longer available for users
        /// to accept. After the lifetime of the HIT elapses, the HIT no longer appears in HIT
        /// searches, even if not all of the assignments for the HIT have been accepted. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LifetimeInSeconds")]
        public System.Int64? LifetimeInSecond { get; set; }
        #endregion
        
        #region Parameter MaxAssignment
        /// <summary>
        /// <para>
        /// <para> The number of times the HIT can be accepted and completed before the HIT becomes
        /// unavailable. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxAssignments")]
        public System.Int32? MaxAssignment { get; set; }
        #endregion
        
        #region Parameter AssignmentReviewPolicy_Parameter
        /// <summary>
        /// <para>
        /// <para>Name of the parameter from the Review policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssignmentReviewPolicy_Parameters")]
        public Amazon.MTurk.Model.PolicyParameter[] AssignmentReviewPolicy_Parameter { get; set; }
        #endregion
        
        #region Parameter HITReviewPolicy_Parameter
        /// <summary>
        /// <para>
        /// <para>Name of the parameter from the Review policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HITReviewPolicy_Parameters")]
        public Amazon.MTurk.Model.PolicyParameter[] HITReviewPolicy_Parameter { get; set; }
        #endregion
        
        #region Parameter AssignmentReviewPolicy_PolicyName
        /// <summary>
        /// <para>
        /// <para> Name of a Review Policy: SimplePlurality/2011-09-01 or ScoreMyKnownAnswers/2011-09-01
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssignmentReviewPolicy_PolicyName { get; set; }
        #endregion
        
        #region Parameter HITReviewPolicy_PolicyName
        /// <summary>
        /// <para>
        /// <para> Name of a Review Policy: SimplePlurality/2011-09-01 or ScoreMyKnownAnswers/2011-09-01
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HITReviewPolicy_PolicyName { get; set; }
        #endregion
        
        #region Parameter QualificationRequirement
        /// <summary>
        /// <para>
        /// <para> Conditions that a Worker's Qualifications must meet in order to accept the HIT. A
        /// HIT can have between zero and ten Qualification requirements. All requirements must
        /// be met in order for a Worker to accept the HIT. Additionally, other actions can be
        /// restricted using the <c>ActionsGuarded</c> field on each <c>QualificationRequirement</c>
        /// structure. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QualificationRequirements")]
        public Amazon.MTurk.Model.QualificationRequirement[] QualificationRequirement { get; set; }
        #endregion
        
        #region Parameter Question
        /// <summary>
        /// <para>
        /// <para> The data the person completing the HIT uses to produce the results. </para><para> Constraints: Must be a QuestionForm data structure, an ExternalQuestion data structure,
        /// or an HTMLQuestion data structure. The XML question data must not be larger than 64
        /// kilobytes (65,535 bytes) in size, including whitespace. </para><para>Either a Question parameter or a HITLayoutId parameter must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Question { get; set; }
        #endregion
        
        #region Parameter RequesterAnnotation
        /// <summary>
        /// <para>
        /// <para> An arbitrary data field. The RequesterAnnotation parameter lets your application
        /// attach arbitrary data to the HIT for tracking purposes. For example, this parameter
        /// could be an identifier internal to the Requester's application that corresponds with
        /// the HIT. </para><para> The RequesterAnnotation parameter for a HIT is only visible to the Requester who
        /// created the HIT. It is not shown to the Worker, or any other Requester. </para><para> The RequesterAnnotation parameter may be different for each HIT you submit. It does
        /// not affect how your HITs are grouped. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequesterAnnotation { get; set; }
        #endregion
        
        #region Parameter Reward
        /// <summary>
        /// <para>
        /// <para> The amount of money the Requester will pay a Worker for successfully completing the
        /// HIT. </para>
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
        public System.String Reward { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para> The title of the HIT. A title should be short and descriptive about the kind of task
        /// the HIT contains. On the Amazon Mechanical Turk web site, the HIT title appears in
        /// search results, and everywhere the HIT is mentioned. </para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter UniqueRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for this request which allows you to retry the call on error
        /// without creating duplicate HITs. This is useful in cases such as network timeouts
        /// where it is unclear whether or not the call succeeded on the server. If the HIT already
        /// exists in the system from a previous call using the same UniqueRequestToken, subsequent
        /// calls will return a AWS.MechanicalTurk.HitAlreadyExists error with a message containing
        /// the HITId. </para><note><para> Note: It is your responsibility to ensure uniqueness of the token. The unique token
        /// expires after 24 hours. Subsequent calls using the same UniqueRequestToken made after
        /// the 24 hour limit could create duplicate HITs. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UniqueRequestToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HIT'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.CreateHITResponse).
        /// Specifying the name of a property of type Amazon.MTurk.Model.CreateHITResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HIT";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRHIT (CreateHIT)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.CreateHITResponse, NewMTRHITCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssignmentDurationInSecond = this.AssignmentDurationInSecond;
            #if MODULAR
            if (this.AssignmentDurationInSecond == null && ParameterWasBound(nameof(this.AssignmentDurationInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter AssignmentDurationInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssignmentReviewPolicy_Parameter != null)
            {
                context.AssignmentReviewPolicy_Parameter = new List<Amazon.MTurk.Model.PolicyParameter>(this.AssignmentReviewPolicy_Parameter);
            }
            context.AssignmentReviewPolicy_PolicyName = this.AssignmentReviewPolicy_PolicyName;
            context.AutoApprovalDelayInSecond = this.AutoApprovalDelayInSecond;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HITLayoutId = this.HITLayoutId;
            if (this.HITLayoutParameter != null)
            {
                context.HITLayoutParameter = new List<Amazon.MTurk.Model.HITLayoutParameter>(this.HITLayoutParameter);
            }
            if (this.HITReviewPolicy_Parameter != null)
            {
                context.HITReviewPolicy_Parameter = new List<Amazon.MTurk.Model.PolicyParameter>(this.HITReviewPolicy_Parameter);
            }
            context.HITReviewPolicy_PolicyName = this.HITReviewPolicy_PolicyName;
            context.Keyword = this.Keyword;
            context.LifetimeInSecond = this.LifetimeInSecond;
            #if MODULAR
            if (this.LifetimeInSecond == null && ParameterWasBound(nameof(this.LifetimeInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter LifetimeInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxAssignment = this.MaxAssignment;
            if (this.QualificationRequirement != null)
            {
                context.QualificationRequirement = new List<Amazon.MTurk.Model.QualificationRequirement>(this.QualificationRequirement);
            }
            context.Question = this.Question;
            context.RequesterAnnotation = this.RequesterAnnotation;
            context.Reward = this.Reward;
            #if MODULAR
            if (this.Reward == null && ParameterWasBound(nameof(this.Reward)))
            {
                WriteWarning("You are passing $null as a value for parameter Reward which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UniqueRequestToken = this.UniqueRequestToken;
            
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
            var request = new Amazon.MTurk.Model.CreateHITRequest();
            
            if (cmdletContext.AssignmentDurationInSecond != null)
            {
                request.AssignmentDurationInSeconds = cmdletContext.AssignmentDurationInSecond.Value;
            }
            
             // populate AssignmentReviewPolicy
            var requestAssignmentReviewPolicyIsNull = true;
            request.AssignmentReviewPolicy = new Amazon.MTurk.Model.ReviewPolicy();
            List<Amazon.MTurk.Model.PolicyParameter> requestAssignmentReviewPolicy_assignmentReviewPolicy_Parameter = null;
            if (cmdletContext.AssignmentReviewPolicy_Parameter != null)
            {
                requestAssignmentReviewPolicy_assignmentReviewPolicy_Parameter = cmdletContext.AssignmentReviewPolicy_Parameter;
            }
            if (requestAssignmentReviewPolicy_assignmentReviewPolicy_Parameter != null)
            {
                request.AssignmentReviewPolicy.Parameters = requestAssignmentReviewPolicy_assignmentReviewPolicy_Parameter;
                requestAssignmentReviewPolicyIsNull = false;
            }
            System.String requestAssignmentReviewPolicy_assignmentReviewPolicy_PolicyName = null;
            if (cmdletContext.AssignmentReviewPolicy_PolicyName != null)
            {
                requestAssignmentReviewPolicy_assignmentReviewPolicy_PolicyName = cmdletContext.AssignmentReviewPolicy_PolicyName;
            }
            if (requestAssignmentReviewPolicy_assignmentReviewPolicy_PolicyName != null)
            {
                request.AssignmentReviewPolicy.PolicyName = requestAssignmentReviewPolicy_assignmentReviewPolicy_PolicyName;
                requestAssignmentReviewPolicyIsNull = false;
            }
             // determine if request.AssignmentReviewPolicy should be set to null
            if (requestAssignmentReviewPolicyIsNull)
            {
                request.AssignmentReviewPolicy = null;
            }
            if (cmdletContext.AutoApprovalDelayInSecond != null)
            {
                request.AutoApprovalDelayInSeconds = cmdletContext.AutoApprovalDelayInSecond.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HITLayoutId != null)
            {
                request.HITLayoutId = cmdletContext.HITLayoutId;
            }
            if (cmdletContext.HITLayoutParameter != null)
            {
                request.HITLayoutParameters = cmdletContext.HITLayoutParameter;
            }
            
             // populate HITReviewPolicy
            var requestHITReviewPolicyIsNull = true;
            request.HITReviewPolicy = new Amazon.MTurk.Model.ReviewPolicy();
            List<Amazon.MTurk.Model.PolicyParameter> requestHITReviewPolicy_hITReviewPolicy_Parameter = null;
            if (cmdletContext.HITReviewPolicy_Parameter != null)
            {
                requestHITReviewPolicy_hITReviewPolicy_Parameter = cmdletContext.HITReviewPolicy_Parameter;
            }
            if (requestHITReviewPolicy_hITReviewPolicy_Parameter != null)
            {
                request.HITReviewPolicy.Parameters = requestHITReviewPolicy_hITReviewPolicy_Parameter;
                requestHITReviewPolicyIsNull = false;
            }
            System.String requestHITReviewPolicy_hITReviewPolicy_PolicyName = null;
            if (cmdletContext.HITReviewPolicy_PolicyName != null)
            {
                requestHITReviewPolicy_hITReviewPolicy_PolicyName = cmdletContext.HITReviewPolicy_PolicyName;
            }
            if (requestHITReviewPolicy_hITReviewPolicy_PolicyName != null)
            {
                request.HITReviewPolicy.PolicyName = requestHITReviewPolicy_hITReviewPolicy_PolicyName;
                requestHITReviewPolicyIsNull = false;
            }
             // determine if request.HITReviewPolicy should be set to null
            if (requestHITReviewPolicyIsNull)
            {
                request.HITReviewPolicy = null;
            }
            if (cmdletContext.Keyword != null)
            {
                request.Keywords = cmdletContext.Keyword;
            }
            if (cmdletContext.LifetimeInSecond != null)
            {
                request.LifetimeInSeconds = cmdletContext.LifetimeInSecond.Value;
            }
            if (cmdletContext.MaxAssignment != null)
            {
                request.MaxAssignments = cmdletContext.MaxAssignment.Value;
            }
            if (cmdletContext.QualificationRequirement != null)
            {
                request.QualificationRequirements = cmdletContext.QualificationRequirement;
            }
            if (cmdletContext.Question != null)
            {
                request.Question = cmdletContext.Question;
            }
            if (cmdletContext.RequesterAnnotation != null)
            {
                request.RequesterAnnotation = cmdletContext.RequesterAnnotation;
            }
            if (cmdletContext.Reward != null)
            {
                request.Reward = cmdletContext.Reward;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.UniqueRequestToken != null)
            {
                request.UniqueRequestToken = cmdletContext.UniqueRequestToken;
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
        
        private Amazon.MTurk.Model.CreateHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateHIT");
            try
            {
                return client.CreateHITAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? AssignmentDurationInSecond { get; set; }
            public List<Amazon.MTurk.Model.PolicyParameter> AssignmentReviewPolicy_Parameter { get; set; }
            public System.String AssignmentReviewPolicy_PolicyName { get; set; }
            public System.Int64? AutoApprovalDelayInSecond { get; set; }
            public System.String Description { get; set; }
            public System.String HITLayoutId { get; set; }
            public List<Amazon.MTurk.Model.HITLayoutParameter> HITLayoutParameter { get; set; }
            public List<Amazon.MTurk.Model.PolicyParameter> HITReviewPolicy_Parameter { get; set; }
            public System.String HITReviewPolicy_PolicyName { get; set; }
            public System.String Keyword { get; set; }
            public System.Int64? LifetimeInSecond { get; set; }
            public System.Int32? MaxAssignment { get; set; }
            public List<Amazon.MTurk.Model.QualificationRequirement> QualificationRequirement { get; set; }
            public System.String Question { get; set; }
            public System.String RequesterAnnotation { get; set; }
            public System.String Reward { get; set; }
            public System.String Title { get; set; }
            public System.String UniqueRequestToken { get; set; }
            public System.Func<Amazon.MTurk.Model.CreateHITResponse, NewMTRHITCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HIT;
        }
        
    }
}
