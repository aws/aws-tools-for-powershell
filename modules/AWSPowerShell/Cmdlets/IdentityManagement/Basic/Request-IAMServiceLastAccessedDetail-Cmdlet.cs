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
    /// Generates a report that includes details about when an IAM resource (user, group,
    /// role, or policy) was last used in an attempt to access Amazon Web Services services.
    /// Recent activity usually appears within four hours. IAM reports activity for at least
    /// the last 400 days, or less if your Region began supporting this feature within the
    /// last year. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html#access-advisor_tracking-period">Regions
    /// where data is tracked</a>. For more information about services and actions for which
    /// action last accessed information is displayed, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor-action-last-accessed.html">IAM
    /// action last accessed information services and actions</a>.
    /// 
    ///  <important><para>
    /// The service last accessed data includes all attempts to access an Amazon Web Services
    /// API, not just the successful ones. This includes all attempts that were made using
    /// the Amazon Web Services Management Console, the Amazon Web Services API through any
    /// of the SDKs, or any of the command line tools. An unexpected entry in the service
    /// last accessed data does not mean that your account has been compromised, because the
    /// request might have been denied. Refer to your CloudTrail logs as the authoritative
    /// source for information about all API calls and whether they were successful or denied
    /// access. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/cloudtrail-integration.html">Logging
    /// IAM events with CloudTrail</a> in the <i>IAM User Guide</i>.
    /// </para></important><para>
    /// The <c>GenerateServiceLastAccessedDetails</c> operation returns a <c>JobId</c>. Use
    /// this parameter in the following operations to retrieve the following details from
    /// your report: 
    /// </para><ul><li><para><a>GetServiceLastAccessedDetails</a> – Use this operation for users, groups, roles,
    /// or policies to list every Amazon Web Services service that the resource could access
    /// using permissions policies. For each service, the response includes information about
    /// the most recent access attempt.
    /// </para><para>
    /// The <c>JobId</c> returned by <c>GenerateServiceLastAccessedDetail</c> must be used
    /// by the same role within a session, or by the same user when used to call <c>GetServiceLastAccessedDetail</c>.
    /// </para></li><li><para><a>GetServiceLastAccessedDetailsWithEntities</a> – Use this operation for groups
    /// and policies to list information about the associated entities (users or roles) that
    /// attempted to access a specific Amazon Web Services service. 
    /// </para></li></ul><para>
    /// To check the status of the <c>GenerateServiceLastAccessedDetails</c> request, use
    /// the <c>JobId</c> parameter in the same operations and test the <c>JobStatus</c> response
    /// parameter.
    /// </para><para>
    /// For additional information about the permissions policies that allow an identity (user,
    /// group, or role) to access specific services, use the <a>ListPoliciesGrantingServiceAccess</a>
    /// operation.
    /// </para><note><para>
    /// Service last accessed data does not use other policy types when determining whether
    /// a resource could access a service. These other policy types include resource-based
    /// policies, access control lists, Organizations policies, IAM permissions boundaries,
    /// and STS assume role policies. It only applies permissions policy logic. For more about
    /// the evaluation of policy types, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-basics">Evaluating
    /// policies</a> in the <i>IAM User Guide</i>.
    /// </para></note><para>
    /// For more information about service and action last accessed data, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html">Reducing
    /// permissions using service last accessed data</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "IAMServiceLastAccessedDetail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GenerateServiceLastAccessedDetails API operation.", Operation = new[] {"GenerateServiceLastAccessedDetails"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestIAMServiceLastAccessedDetailCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM resource (user, group, role, or managed policy) used to generate
        /// information about when the resource was last used in an attempt to access an Amazon
        /// Web Services service.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The level of detail that you want to generate. You can specify whether you want to
        /// generate information about the last attempt to access services or actions. If you
        /// specify service-level granularity, this operation generates only service data. If
        /// you specify action-level granularity, it generates service and action data. If you
        /// don't include this optional parameter, the operation generates service data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IdentityManagement.AccessAdvisorUsageGranularityType")]
        public Amazon.IdentityManagement.AccessAdvisorUsageGranularityType Granularity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-IAMServiceLastAccessedDetail (GenerateServiceLastAccessedDetails)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse, RequestIAMServiceLastAccessedDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Granularity = this.Granularity;
            
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
            var request = new Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
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
        
        private Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GenerateServiceLastAccessedDetails");
            try
            {
                #if DESKTOP
                return client.GenerateServiceLastAccessedDetails(request);
                #elif CORECLR
                return client.GenerateServiceLastAccessedDetailsAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public Amazon.IdentityManagement.AccessAdvisorUsageGranularityType Granularity { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse, RequestIAMServiceLastAccessedDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
