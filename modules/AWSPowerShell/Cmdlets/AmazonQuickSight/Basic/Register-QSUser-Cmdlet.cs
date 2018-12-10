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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an Amazon QuickSight user, whose identity is associated with the AWS Identity
    /// and Access Management (IAM) identity or role specified in the request. 
    /// 
    ///  
    /// <para>
    /// The permission resource is <code>arn:aws:quicksight:us-east-1:<i>&lt;aws-account-id&gt;</i>:user/default/<i>&lt;user-name&gt;</i></code>.
    /// </para><para>
    /// The condition resource is the Amazon Resource Name (ARN) for the IAM user or role,
    /// and the session name. 
    /// </para><para>
    /// The condition keys are <code>quicksight:IamArn</code> and <code>quicksight:SessionName</code>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Register", "QSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.User")]
    [AWSCmdlet("Calls the Amazon QuickSight RegisterUser API operation.", Operation = new[] {"RegisterUser"})]
    [AWSCmdletOutput("Amazon.QuickSight.Model.User",
        "This cmdlet returns a User object.",
        "The service call response (type Amazon.QuickSight.Model.RegisterUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: RequestId (type System.String), Status (type System.Int32)"
    )]
    public partial class RegisterQSUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the AWS account that the user is in. Currently, you use the ID for the
        /// AWS account that contains your Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the user that you want to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter IamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user or role that you are registering with Amazon QuickSight. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamArn { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>Amazon QuickSight supports several ways of managing the identity of users. This parameter
        /// accepts two values:</para><ul><li><para><code>IAM</code>: A user whose identity maps to an existing IAM user or role. </para></li><li><para><code>QUICKSIGHT</code>: A user whose identity is owned and managed internally by
        /// Amazon QuickSight. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.QuickSight.IdentityType")]
        public Amazon.QuickSight.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace. Currently, you should set this to <code>default</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionName
        /// <summary>
        /// <para>
        /// <para>The name of the session with the assumed IAM role. By using this parameter, you can
        /// register multiple users with the same IAM role, provided that each has a different
        /// session name. For more information on assuming IAM roles, see <a href="https://docs.aws.amazon.com/cli/latest/reference/sts/assume-role.html"><code>assume-role</code></a> in the <i>AWS CLI Reference.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SessionName { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user name that you want to create for the user you are registering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserRole
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight role of the user. The user role can be one of the following:</para><ul><li><para><code>READER</code>: A user who has read-only access to dashboards.</para></li><li><para><code>AUTHOR</code>: A user who can create data sources, data sets, analyses, and
        /// dashboards.</para></li><li><para><code>ADMIN</code>: A user who is an author, who can also manage Amazon QuickSight
        /// settings.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.QuickSight.UserRole")]
        public Amazon.QuickSight.UserRole UserRole { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Email", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-QSUser (RegisterUser)"))
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
            
            context.AwsAccountId = this.AwsAccountId;
            context.Email = this.Email;
            context.IamArn = this.IamArn;
            context.IdentityType = this.IdentityType;
            context.Namespace = this.Namespace;
            context.SessionName = this.SessionName;
            context.UserName = this.UserName;
            context.UserRole = this.UserRole;
            
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
            var request = new Amazon.QuickSight.Model.RegisterUserRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.IamArn != null)
            {
                request.IamArn = cmdletContext.IamArn;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionName != null)
            {
                request.SessionName = cmdletContext.SessionName;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserRole != null)
            {
                request.UserRole = cmdletContext.UserRole;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.User;
                notes = new Dictionary<string, object>();
                notes["RequestId"] = response.RequestId;
                notes["Status"] = response.Status;
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
        
        private Amazon.QuickSight.Model.RegisterUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.RegisterUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "RegisterUser");
            try
            {
                #if DESKTOP
                return client.RegisterUser(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterUserAsync(request);
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
            public System.String AwsAccountId { get; set; }
            public System.String Email { get; set; }
            public System.String IamArn { get; set; }
            public Amazon.QuickSight.IdentityType IdentityType { get; set; }
            public System.String Namespace { get; set; }
            public System.String SessionName { get; set; }
            public System.String UserName { get; set; }
            public Amazon.QuickSight.UserRole UserRole { get; set; }
        }
        
    }
}
