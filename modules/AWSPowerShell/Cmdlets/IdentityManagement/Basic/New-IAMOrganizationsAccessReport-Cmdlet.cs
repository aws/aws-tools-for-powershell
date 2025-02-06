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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Generates a report for service last accessed data for Organizations. You can generate
    /// a report for any entities (organization root, organizational unit, or account) or
    /// policies in your organization.
    /// 
    ///  
    /// <para>
    /// To call this operation, you must be signed in using your Organizations management
    /// account credentials. You can use your long-term IAM user or root user credentials,
    /// or temporary credentials from assuming an IAM role. SCPs must be enabled for your
    /// organization root. You must have the required IAM and Organizations permissions. For
    /// more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html">Refining
    /// permissions using service last accessed data</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// You can generate a service last accessed data report for entities by specifying only
    /// the entity's path. This data includes a list of services that are allowed by any service
    /// control policies (SCPs) that apply to the entity.
    /// </para><para>
    /// You can generate a service last accessed data report for a policy by specifying an
    /// entity's path and an optional Organizations policy ID. This data includes a list of
    /// services that are allowed by the specified SCP.
    /// </para><para>
    /// For each service in both report types, the data includes the most recent account activity
    /// that the policy allows to account principals in the entity or the entity's children.
    /// For important information about the data, reporting period, permissions required,
    /// troubleshooting, and supported Regions see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html">Reducing
    /// permissions using service last accessed data</a> in the <i>IAM User Guide</i>.
    /// </para><important><para>
    /// The data includes all attempts to access Amazon Web Services, not just the successful
    /// ones. This includes all attempts that were made using the Amazon Web Services Management
    /// Console, the Amazon Web Services API through any of the SDKs, or any of the command
    /// line tools. An unexpected entry in the service last accessed data does not mean that
    /// an account has been compromised, because the request might have been denied. Refer
    /// to your CloudTrail logs as the authoritative source for information about all API
    /// calls and whether they were successful or denied access. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/cloudtrail-integration.html">Logging
    /// IAM events with CloudTrail</a> in the <i>IAM User Guide</i>.
    /// </para></important><para>
    /// This operation returns a <c>JobId</c>. Use this parameter in the <c><a>GetOrganizationsAccessReport</a></c> operation to check the status of the report generation. To check the status of
    /// this request, use the <c>JobId</c> parameter in the <c><a>GetOrganizationsAccessReport</a></c> operation and test the <c>JobStatus</c> response parameter. When the job is complete,
    /// you can retrieve the report.
    /// </para><para>
    /// To generate a service last accessed data report for entities, specify an entity path
    /// without specifying the optional Organizations policy ID. The type of entity that you
    /// specify determines the data returned in the report.
    /// </para><ul><li><para><b>Root</b> – When you specify the organizations root as the entity, the resulting
    /// report lists all of the services allowed by SCPs that are attached to your root. For
    /// each service, the report includes data for all accounts in your organization except
    /// the management account, because the management account is not limited by SCPs.
    /// </para></li><li><para><b>OU</b> – When you specify an organizational unit (OU) as the entity, the resulting
    /// report lists all of the services allowed by SCPs that are attached to the OU and its
    /// parents. For each service, the report includes data for all accounts in the OU or
    /// its children. This data excludes the management account, because the management account
    /// is not limited by SCPs.
    /// </para></li><li><para><b>management account</b> – When you specify the management account, the resulting
    /// report lists all Amazon Web Services services, because the management account is not
    /// limited by SCPs. For each service, the report includes data for only the management
    /// account.
    /// </para></li><li><para><b>Account</b> – When you specify another account as the entity, the resulting report
    /// lists all of the services allowed by SCPs that are attached to the account and its
    /// parents. For each service, the report includes data for only the specified account.
    /// </para></li></ul><para>
    /// To generate a service last accessed data report for policies, specify an entity path
    /// and the optional Organizations policy ID. The type of entity that you specify determines
    /// the data returned for each service.
    /// </para><ul><li><para><b>Root</b> – When you specify the root entity and a policy ID, the resulting report
    /// lists all of the services that are allowed by the specified SCP. For each service,
    /// the report includes data for all accounts in your organization to which the SCP applies.
    /// This data excludes the management account, because the management account is not limited
    /// by SCPs. If the SCP is not attached to any entities in the organization, then the
    /// report will return a list of services with no data.
    /// </para></li><li><para><b>OU</b> – When you specify an OU entity and a policy ID, the resulting report lists
    /// all of the services that are allowed by the specified SCP. For each service, the report
    /// includes data for all accounts in the OU or its children to which the SCP applies.
    /// This means that other accounts outside the OU that are affected by the SCP might not
    /// be included in the data. This data excludes the management account, because the management
    /// account is not limited by SCPs. If the SCP is not attached to the OU or one of its
    /// children, the report will return a list of services with no data.
    /// </para></li><li><para><b>management account</b> – When you specify the management account, the resulting
    /// report lists all Amazon Web Services services, because the management account is not
    /// limited by SCPs. If you specify a policy ID in the CLI or API, the policy is ignored.
    /// For each service, the report includes data for only the management account.
    /// </para></li><li><para><b>Account</b> – When you specify another account entity and a policy ID, the resulting
    /// report lists all of the services that are allowed by the specified SCP. For each service,
    /// the report includes data for only the specified account. This means that other accounts
    /// in the organization that are affected by the SCP might not be included in the data.
    /// If the SCP is not attached to the account, the report will return a list of services
    /// with no data.
    /// </para></li></ul><note><para>
    /// Service last accessed data does not use other policy types when determining whether
    /// a principal could access a service. These other policy types include identity-based
    /// policies, resource-based policies, access control lists, IAM permissions boundaries,
    /// and STS assume role policies. It only applies SCP logic. For more about the evaluation
    /// of policy types, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-basics">Evaluating
    /// policies</a> in the <i>IAM User Guide</i>.
    /// </para></note><para>
    /// For more information about service last accessed data, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html">Reducing
    /// policy scope by viewing user activity</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMOrganizationsAccessReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GenerateOrganizationsAccessReport API operation.", Operation = new[] {"GenerateOrganizationsAccessReport"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMOrganizationsAccessReportCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityPath
        /// <summary>
        /// <para>
        /// <para>The path of the Organizations entity (root, OU, or account). You can build an entity
        /// path using the known structure of your organization. For example, assume that your
        /// account ID is <c>123456789012</c> and its parent OU ID is <c>ou-rge0-awsabcde</c>.
        /// The organization root ID is <c>r-f6g7h8i9j0example</c> and your organization ID is
        /// <c>o-a1b2c3d4e5</c>. Your entity path is <c>o-a1b2c3d4e5/r-f6g7h8i9j0example/ou-rge0-awsabcde/123456789012</c>.</para>
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
        public System.String EntityPath { get; set; }
        #endregion
        
        #region Parameter OrganizationsPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Organizations service control policy (SCP). This parameter is
        /// optional.</para><para>This ID is used to generate information about when an account principal that is limited
        /// by the SCP attempted to access an Amazon Web Services service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationsPolicyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityPath), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMOrganizationsAccessReport (GenerateOrganizationsAccessReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse, NewIAMOrganizationsAccessReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EntityPath = this.EntityPath;
            #if MODULAR
            if (this.EntityPath == null && ParameterWasBound(nameof(this.EntityPath)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationsPolicyId = this.OrganizationsPolicyId;
            
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
            var request = new Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportRequest();
            
            if (cmdletContext.EntityPath != null)
            {
                request.EntityPath = cmdletContext.EntityPath;
            }
            if (cmdletContext.OrganizationsPolicyId != null)
            {
                request.OrganizationsPolicyId = cmdletContext.OrganizationsPolicyId;
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
        
        private Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GenerateOrganizationsAccessReport");
            try
            {
                #if DESKTOP
                return client.GenerateOrganizationsAccessReport(request);
                #elif CORECLR
                return client.GenerateOrganizationsAccessReportAsync(request).GetAwaiter().GetResult();
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
            public System.String EntityPath { get; set; }
            public System.String OrganizationsPolicyId { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GenerateOrganizationsAccessReportResponse, NewIAMOrganizationsAccessReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
