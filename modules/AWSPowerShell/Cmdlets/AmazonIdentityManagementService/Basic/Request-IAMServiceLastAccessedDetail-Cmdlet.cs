/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Generates a request for a report that includes details about when an IAM resource
    /// (user, group, role, or policy) was last used in an attempt to access AWS services.
    /// Recent activity usually appears within four hours. IAM reports activity for the last
    /// 365 days, or less if your region began supporting this feature within the last year.
    /// For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html#access-advisor_tracking-period">Regions
    /// Where Data Is Tracked</a>.
    /// 
    ///  <important><para>
    /// The service last accessed data includes all attempts to access an AWS API, not just
    /// the successful ones. This includes all attempts that were made using the AWS Management
    /// Console, the AWS API through any of the SDKs, or any of the command line tools. An
    /// unexpected entry in the service last accessed data does not mean that your account
    /// has been compromised, because the request might have been denied. Refer to your CloudTrail
    /// logs as the authoritative source for information about all API calls and whether they
    /// were successful or denied access. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/cloudtrail-integration.html">Logging
    /// IAM Events with CloudTrail</a> in the <i>IAM User Guide</i>.
    /// </para></important><para>
    /// The <code>GenerateServiceLastAccessedDetails</code> operation returns a <code>JobId</code>.
    /// Use this parameter in the following operations to retrieve the following details from
    /// your report: 
    /// </para><ul><li><para><a>GetServiceLastAccessedDetails</a> – Use this operation for users, groups, roles,
    /// or policies to list every AWS service that the resource could access using permissions
    /// policies. For each service, the response includes information about the most recent
    /// access attempt. 
    /// </para></li><li><para><a>GetServiceLastAccessedDetailsWithEntities</a> – Use this operation for groups
    /// and policies to list information about the associated entities (users or roles) that
    /// attempted to access a specific AWS service. 
    /// </para></li></ul><para>
    /// To check the status of the <code>GenerateServiceLastAccessedDetails</code> request,
    /// use the <code>JobId</code> parameter in the same operations and test the <code>JobStatus</code>
    /// response parameter.
    /// </para><para>
    /// For additional information about the permissions policies that allow an identity (user,
    /// group, or role) to access specific services, use the <a>ListPoliciesGrantingServiceAccess</a>
    /// operation.
    /// </para><note><para>
    /// Service last accessed data does not use other policy types when determining whether
    /// a resource could access a service. These other policy types include resource-based
    /// policies, access control lists, AWS Organizations policies, IAM permissions boundaries,
    /// and AWS STS assume role policies. It only applies permissions policy logic. For more
    /// about the evaluation of policy types, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-basics">Evaluating
    /// Policies</a> in the <i>IAM User Guide</i>.
    /// </para></note><para>
    /// For more information about service last accessed data, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_access-advisor.html">Reducing
    /// Policy Scope by Viewing User Activity</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "IAMServiceLastAccessedDetail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GenerateServiceLastAccessedDetails API operation.", Operation = new[] {"GenerateServiceLastAccessedDetails"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.IdentityManagement.Model.GenerateServiceLastAccessedDetailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestIAMServiceLastAccessedDetailCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM resource (user, group, role, or managed policy) used to generate
        /// information about when the resource was last used in an attempt to access an AWS service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Arn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-IAMServiceLastAccessedDetail (GenerateServiceLastAccessedDetails)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Arn = this.Arn;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.JobId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GenerateServiceLastAccessedDetailsAsync(request);
                return task.Result;
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
        }
        
    }
}
