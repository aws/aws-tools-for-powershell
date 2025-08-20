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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Edits an Audit Manager assessment.
    /// </summary>
    [Cmdlet("Edit", "AUDMAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.Assessment")]
    [AWSCmdlet("Calls the AWS Audit Manager UpdateAssessment API operation.", Operation = new[] {"UpdateAssessment"}, SelectReturnType = typeof(Amazon.AuditManager.Model.UpdateAssessmentResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.Assessment or Amazon.AuditManager.Model.UpdateAssessmentResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.Assessment object.",
        "The service call response (type Amazon.AuditManager.Model.UpdateAssessmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditAUDMAssessmentCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssessmentDescription
        /// <summary>
        /// <para>
        /// <para> The description of the assessment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentDescription { get; set; }
        #endregion
        
        #region Parameter AssessmentId
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the assessment. </para>
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
        public System.String AssessmentId { get; set; }
        #endregion
        
        #region Parameter AssessmentName
        /// <summary>
        /// <para>
        /// <para> The name of the assessment to be updated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentName { get; set; }
        #endregion
        
        #region Parameter Scope_AwsAccount
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services accounts that are included in the scope of the assessment.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_AwsAccounts")]
        public Amazon.AuditManager.Model.AWSAccount[] Scope_AwsAccount { get; set; }
        #endregion
        
        #region Parameter AssessmentReportsDestination_Destination
        /// <summary>
        /// <para>
        /// <para> The destination bucket where Audit Manager stores assessment reports. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentReportsDestination_Destination { get; set; }
        #endregion
        
        #region Parameter AssessmentReportsDestination_DestinationType
        /// <summary>
        /// <para>
        /// <para> The destination type, such as Amazon S3. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AuditManager.AssessmentReportDestinationType")]
        public Amazon.AuditManager.AssessmentReportDestinationType AssessmentReportsDestination_DestinationType { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para> The list of roles for the assessment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Roles")]
        public Amazon.AuditManager.Model.Role[] Role { get; set; }
        #endregion
        
        #region Parameter Scope_AwsService
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services services that are included in the scope of the assessment.
        /// </para><important><para>This API parameter is no longer supported. If you use this parameter to specify one
        /// or more Amazon Web Services services, Audit Manager ignores this input. Instead, the
        /// value for <c>awsServices</c> will show as empty.</para></important>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("You can\u0027t specify services in scope when creating/updating an assessment. If you use the parameter to specify one or more AWS services, Audit Manager ignores the input. Instead the value of the parameter will show as empty indicating that the services are defined and managed by Audit Manager.")]
        [Alias("Scope_AwsServices")]
        public Amazon.AuditManager.Model.AWSService[] Scope_AwsService { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Assessment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.UpdateAssessmentResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.UpdateAssessmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Assessment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssessmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssessmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssessmentId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssessmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-AUDMAssessment (UpdateAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.UpdateAssessmentResponse, EditAUDMAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssessmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssessmentDescription = this.AssessmentDescription;
            context.AssessmentId = this.AssessmentId;
            #if MODULAR
            if (this.AssessmentId == null && ParameterWasBound(nameof(this.AssessmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssessmentName = this.AssessmentName;
            context.AssessmentReportsDestination_Destination = this.AssessmentReportsDestination_Destination;
            context.AssessmentReportsDestination_DestinationType = this.AssessmentReportsDestination_DestinationType;
            if (this.Role != null)
            {
                context.Role = new List<Amazon.AuditManager.Model.Role>(this.Role);
            }
            if (this.Scope_AwsAccount != null)
            {
                context.Scope_AwsAccount = new List<Amazon.AuditManager.Model.AWSAccount>(this.Scope_AwsAccount);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Scope_AwsService != null)
            {
                context.Scope_AwsService = new List<Amazon.AuditManager.Model.AWSService>(this.Scope_AwsService);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.AuditManager.Model.UpdateAssessmentRequest();
            
            if (cmdletContext.AssessmentDescription != null)
            {
                request.AssessmentDescription = cmdletContext.AssessmentDescription;
            }
            if (cmdletContext.AssessmentId != null)
            {
                request.AssessmentId = cmdletContext.AssessmentId;
            }
            if (cmdletContext.AssessmentName != null)
            {
                request.AssessmentName = cmdletContext.AssessmentName;
            }
            
             // populate AssessmentReportsDestination
            var requestAssessmentReportsDestinationIsNull = true;
            request.AssessmentReportsDestination = new Amazon.AuditManager.Model.AssessmentReportsDestination();
            System.String requestAssessmentReportsDestination_assessmentReportsDestination_Destination = null;
            if (cmdletContext.AssessmentReportsDestination_Destination != null)
            {
                requestAssessmentReportsDestination_assessmentReportsDestination_Destination = cmdletContext.AssessmentReportsDestination_Destination;
            }
            if (requestAssessmentReportsDestination_assessmentReportsDestination_Destination != null)
            {
                request.AssessmentReportsDestination.Destination = requestAssessmentReportsDestination_assessmentReportsDestination_Destination;
                requestAssessmentReportsDestinationIsNull = false;
            }
            Amazon.AuditManager.AssessmentReportDestinationType requestAssessmentReportsDestination_assessmentReportsDestination_DestinationType = null;
            if (cmdletContext.AssessmentReportsDestination_DestinationType != null)
            {
                requestAssessmentReportsDestination_assessmentReportsDestination_DestinationType = cmdletContext.AssessmentReportsDestination_DestinationType;
            }
            if (requestAssessmentReportsDestination_assessmentReportsDestination_DestinationType != null)
            {
                request.AssessmentReportsDestination.DestinationType = requestAssessmentReportsDestination_assessmentReportsDestination_DestinationType;
                requestAssessmentReportsDestinationIsNull = false;
            }
             // determine if request.AssessmentReportsDestination should be set to null
            if (requestAssessmentReportsDestinationIsNull)
            {
                request.AssessmentReportsDestination = null;
            }
            if (cmdletContext.Role != null)
            {
                request.Roles = cmdletContext.Role;
            }
            
             // populate Scope
            request.Scope = new Amazon.AuditManager.Model.Scope();
            List<Amazon.AuditManager.Model.AWSAccount> requestScope_scope_AwsAccount = null;
            if (cmdletContext.Scope_AwsAccount != null)
            {
                requestScope_scope_AwsAccount = cmdletContext.Scope_AwsAccount;
            }
            if (requestScope_scope_AwsAccount != null)
            {
                request.Scope.AwsAccounts = requestScope_scope_AwsAccount;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.AuditManager.Model.AWSService> requestScope_scope_AwsService = null;
            if (cmdletContext.Scope_AwsService != null)
            {
                requestScope_scope_AwsService = cmdletContext.Scope_AwsService;
            }
            if (requestScope_scope_AwsService != null)
            {
                request.Scope.AwsServices = requestScope_scope_AwsService;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.AuditManager.Model.UpdateAssessmentResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.UpdateAssessmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "UpdateAssessment");
            try
            {
                #if DESKTOP
                return client.UpdateAssessment(request);
                #elif CORECLR
                return client.UpdateAssessmentAsync(request).GetAwaiter().GetResult();
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
            public System.String AssessmentDescription { get; set; }
            public System.String AssessmentId { get; set; }
            public System.String AssessmentName { get; set; }
            public System.String AssessmentReportsDestination_Destination { get; set; }
            public Amazon.AuditManager.AssessmentReportDestinationType AssessmentReportsDestination_DestinationType { get; set; }
            public List<Amazon.AuditManager.Model.Role> Role { get; set; }
            public List<Amazon.AuditManager.Model.AWSAccount> Scope_AwsAccount { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.AuditManager.Model.AWSService> Scope_AwsService { get; set; }
            public System.Func<Amazon.AuditManager.Model.UpdateAssessmentResponse, EditAUDMAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Assessment;
        }
        
    }
}
