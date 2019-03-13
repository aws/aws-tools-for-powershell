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
    /// Generates a server-side embeddable URL and authorization code. Before this can work
    /// properly, first you need to configure the dashboards and user permissions. For more
    /// information, see <a href="https://docs.aws.amazon.com/en_us/quicksight/latest/user/embedding.html">
    /// Embedding Amazon QuickSight Dashboards</a>.
    /// 
    ///  
    /// <para>
    /// Currently, you can use <code>GetDashboardEmbedURL</code> only from the server, not
    /// from the user’s browser.
    /// </para><para><b>CLI Sample:</b></para><para>
    /// Assume the role with permissions enabled for actions: <code>quickSight:RegisterUser</code>
    /// and <code>quicksight:GetDashboardEmbedURL</code>. You can use assume-role, assume-role-with-web-identity,
    /// or assume-role-with-saml. 
    /// </para><para><code>aws sts assume-role --role-arn "arn:aws:iam::111122223333:role/embedding_quicksight_dashboard_role"
    /// --role-session-name embeddingsession</code></para><para>
    /// If the user does not exist in QuickSight, register the user:
    /// </para><para><code>aws quicksight register-user --aws-account-id 111122223333 --namespace default
    /// --identity-type IAM --iam-arn "arn:aws:iam::111122223333:role/embedding_quicksight_dashboard_role"
    /// --user-role READER --session-name "embeddingsession" --email user123@example.com --region
    /// us-east-1</code></para><para>
    /// Get the URL for the embedded dashboard
    /// </para><para><code>aws quicksight get-dashboard-embed-url --aws-account-id 111122223333 --dashboard-id
    /// 1a1ac2b2-3fc3-4b44-5e5d-c6db6778df89 --identity-type IAM</code></para>
    /// </summary>
    [Cmdlet("Get", "QSDashboardEmbedUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GetDashboardEmbedUrl API operation.", Operation = new[] {"GetDashboardEmbedUrl"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: RequestId (type System.String), Status (type System.Int32)"
    )]
    public partial class GetQSDashboardEmbedUrlCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>AWS account ID that contains the dashboard you are embedding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID for the dashboard, also added to IAM policy</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>The authentication method the user uses to sign in (IAM only).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.QuickSight.IdentityType")]
        public Amazon.QuickSight.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter ResetDisabled
        /// <summary>
        /// <para>
        /// <para>Remove the reset button on embedded dashboard. The default is FALSE, which allows
        /// the reset button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ResetDisabled { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>How many minutes the session is valid. The session lifetime must be between 15 and
        /// 600 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64 SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter UndoRedoDisabled
        /// <summary>
        /// <para>
        /// <para>Remove the undo/redo button on embedded dashboard. The default is FALSE, which enables
        /// the undo/redo button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UndoRedoDisabled { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AwsAccountId = this.AwsAccountId;
            context.DashboardId = this.DashboardId;
            context.IdentityType = this.IdentityType;
            if (ParameterWasBound("ResetDisabled"))
                context.ResetDisabled = this.ResetDisabled;
            if (ParameterWasBound("SessionLifetimeInMinute"))
                context.SessionLifetimeInMinutes = this.SessionLifetimeInMinute;
            if (ParameterWasBound("UndoRedoDisabled"))
                context.UndoRedoDisabled = this.UndoRedoDisabled;
            
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
            var request = new Amazon.QuickSight.Model.GetDashboardEmbedUrlRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.ResetDisabled != null)
            {
                request.ResetDisabled = cmdletContext.ResetDisabled.Value;
            }
            if (cmdletContext.SessionLifetimeInMinutes != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinutes.Value;
            }
            if (cmdletContext.UndoRedoDisabled != null)
            {
                request.UndoRedoDisabled = cmdletContext.UndoRedoDisabled.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EmbedUrl;
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
        
        private Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GetDashboardEmbedUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GetDashboardEmbedUrl");
            try
            {
                #if DESKTOP
                return client.GetDashboardEmbedUrl(request);
                #elif CORECLR
                return client.GetDashboardEmbedUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String DashboardId { get; set; }
            public Amazon.QuickSight.IdentityType IdentityType { get; set; }
            public System.Boolean? ResetDisabled { get; set; }
            public System.Int64? SessionLifetimeInMinutes { get; set; }
            public System.Boolean? UndoRedoDisabled { get; set; }
        }
        
    }
}
