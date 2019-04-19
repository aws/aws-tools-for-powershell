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
    /// Creates an IAM role that is linked to a specific AWS service. The service controls
    /// the attached policies and when the role can be deleted. This helps ensure that the
    /// service is not broken by an unexpectedly changed or deleted role, which could put
    /// your AWS resources into an unknown state. Allowing the service to control the role
    /// helps improve service stability and proper cleanup when a service and its role are
    /// no longer needed. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/using-service-linked-roles.html">Using
    /// Service-Linked Roles</a> in the <i>IAM User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// To attach a policy to this service-linked role, you must make the request using the
    /// AWS service that depends on this role.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMServiceLinkedRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.Role")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateServiceLinkedRole API operation.", Operation = new[] {"CreateServiceLinkedRole"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.Role",
        "This cmdlet returns a Role object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateServiceLinkedRoleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIAMServiceLinkedRoleCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AWSServiceName
        /// <summary>
        /// <para>
        /// <para>The service principal for the AWS service to which this role is attached. You use
        /// a string similar to a URL but without the http:// in front. For example: <code>elasticbeanstalk.amazonaws.com</code>.
        /// </para><para>Service principals are unique and case-sensitive. To find the exact service principal
        /// for your service-linked role, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-services-that-work-with-iam.html">AWS
        /// Services That Work with IAM</a> in the <i>IAM User Guide</i> and look for the services
        /// that have <b>Yes </b>in the <b>Service-Linked Role</b> column. Choose the <b>Yes</b>
        /// link to view the service-linked role documentation for that service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String AWSServiceName { get; set; }
        #endregion
        
        #region Parameter CustomSuffix
        /// <summary>
        /// <para>
        /// <para>A string that you provide, which is combined with the service-provided prefix to form
        /// the complete role name. If you make multiple requests for the same service, then you
        /// must supply a different <code>CustomSuffix</code> for each request. Otherwise the
        /// request fails with a duplicate role name error. For example, you could add <code>-1</code>
        /// or <code>-debug</code> to the suffix.</para><para>Some services do not support the <code>CustomSuffix</code> parameter. If you provide
        /// an optional suffix and the operation fails, try the operation again without the suffix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomSuffix { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AWSServiceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMServiceLinkedRole (CreateServiceLinkedRole)"))
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
            
            context.AWSServiceName = this.AWSServiceName;
            context.CustomSuffix = this.CustomSuffix;
            context.Description = this.Description;
            
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
            var request = new Amazon.IdentityManagement.Model.CreateServiceLinkedRoleRequest();
            
            if (cmdletContext.AWSServiceName != null)
            {
                request.AWSServiceName = cmdletContext.AWSServiceName;
            }
            if (cmdletContext.CustomSuffix != null)
            {
                request.CustomSuffix = cmdletContext.CustomSuffix;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Role;
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
        
        private Amazon.IdentityManagement.Model.CreateServiceLinkedRoleResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateServiceLinkedRoleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateServiceLinkedRole");
            try
            {
                #if DESKTOP
                return client.CreateServiceLinkedRole(request);
                #elif CORECLR
                return client.CreateServiceLinkedRoleAsync(request).GetAwaiter().GetResult();
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
            public System.String AWSServiceName { get; set; }
            public System.String CustomSuffix { get; set; }
            public System.String Description { get; set; }
        }
        
    }
}
