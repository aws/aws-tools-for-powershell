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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Creates an assessment in Audit Manager.
    /// </summary>
    [Cmdlet("New", "AUDMAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.Assessment")]
    [AWSCmdlet("Calls the AWS Audit Manager CreateAssessment API operation.", Operation = new[] {"CreateAssessment"}, SelectReturnType = typeof(Amazon.AuditManager.Model.CreateAssessmentResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.Assessment or Amazon.AuditManager.Model.CreateAssessmentResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.Assessment object.",
        "The service call response (type Amazon.AuditManager.Model.CreateAssessmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAUDMAssessmentCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The optional description of the assessment to be created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter FrameworkId
        /// <summary>
        /// <para>
        /// <para> The identifier for the framework that the assessment will be created from. </para>
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
        public System.String FrameworkId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the assessment to be created. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para> The list of roles for the assessment. </para>
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
        [Alias("Roles")]
        public Amazon.AuditManager.Model.Role[] Role { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tags that are associated with the assessment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.CreateAssessmentResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.CreateAssessmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Assessment";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AUDMAssessment (CreateAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.CreateAssessmentResponse, NewAUDMAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentReportsDestination_Destination = this.AssessmentReportsDestination_Destination;
            context.AssessmentReportsDestination_DestinationType = this.AssessmentReportsDestination_DestinationType;
            context.Description = this.Description;
            context.FrameworkId = this.FrameworkId;
            #if MODULAR
            if (this.FrameworkId == null && ParameterWasBound(nameof(this.FrameworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter FrameworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Role != null)
            {
                context.Role = new List<Amazon.AuditManager.Model.Role>(this.Role);
            }
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.AuditManager.Model.CreateAssessmentRequest();
            
            
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FrameworkId != null)
            {
                request.FrameworkId = cmdletContext.FrameworkId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Role != null)
            {
                request.Roles = cmdletContext.Role;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.AuditManager.Model.Scope();
            List<Amazon.AuditManager.Model.AWSAccount> requestScope_scope_AwsAccount = null;
            if (cmdletContext.Scope_AwsAccount != null)
            {
                requestScope_scope_AwsAccount = cmdletContext.Scope_AwsAccount;
            }
            if (requestScope_scope_AwsAccount != null)
            {
                request.Scope.AwsAccounts = requestScope_scope_AwsAccount;
                requestScopeIsNull = false;
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
                requestScopeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
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
        
        private Amazon.AuditManager.Model.CreateAssessmentResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.CreateAssessmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "CreateAssessment");
            try
            {
                return client.CreateAssessmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentReportsDestination_Destination { get; set; }
            public Amazon.AuditManager.AssessmentReportDestinationType AssessmentReportsDestination_DestinationType { get; set; }
            public System.String Description { get; set; }
            public System.String FrameworkId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.AuditManager.Model.Role> Role { get; set; }
            public List<Amazon.AuditManager.Model.AWSAccount> Scope_AwsAccount { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.AuditManager.Model.AWSService> Scope_AwsService { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AuditManager.Model.CreateAssessmentResponse, NewAUDMAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Assessment;
        }
        
    }
}
