/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Generates a session URL and authorization code that you can use to embed the Amazon
    /// QuickSight console in your web server code. Use <code>GetSessionEmbedUrl</code> where
    /// you want to provide an authoring portal that allows users to create data sources,
    /// datasets, analyses, and dashboards. The users who access an embedded QuickSight console
    /// need belong to the author or admin security cohort. If you want to restrict permissions
    /// to some of these features, add a custom permissions profile to the user with the <code><a>UpdateUser</a></code> API operation. Use <code><a>RegisterUser</a></code> API
    /// operation to add a new user with a custom permission profile attached. For more information,
    /// see the following sections in the <i>Amazon QuickSight User Guide</i>:
    /// 
    ///  <ul><li><para><a href="https://docs.aws.amazon.com/quicksight/latest/user/embedding-the-quicksight-console.html">Embedding
    /// the Amazon QuickSight Console</a></para></li><li><para><a href="https://docs.aws.amazon.com/quicksight/latest/user/customizing-permissions-to-the-quicksight-console.html">Customizing
    /// Access to the Amazon QuickSight Console</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "QSSessionEmbedUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GetSessionEmbedUrl API operation.", Operation = new[] {"GetSessionEmbedUrl"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GetSessionEmbedUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GetSessionEmbedUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GetSessionEmbedUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetQSSessionEmbedUrlCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the AWS account associated with your QuickSight subscription.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter EntryPoint
        /// <summary>
        /// <para>
        /// <para>The URL you use to access the embedded session. The entry point URL is constrained
        /// to the following paths:</para><ul><li><para><code>/start</code></para></li><li><para><code>/start/analyses</code></para></li><li><para><code>/start/dashboards</code></para></li><li><para><code>/start/favorites</code></para></li><li><para><code>/dashboards/<i>DashboardId</i></code> - where <code>DashboardId</code> is
        /// the actual ID key from the QuickSight console URL of the dashboard</para></li><li><para><code>/analyses/<i>AnalysisId</i></code> - where <code>AnalysisId</code> is the
        /// actual ID key from the QuickSight console URL of the analysis</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntryPoint { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>How many minutes the session is valid. The session lifetime must be 15-600 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64? SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user's Amazon Resource Name (ARN), for use with <code>QUICKSIGHT</code>
        /// identity type. You can use this for any type of Amazon QuickSight users in your account
        /// (readers, authors, or admins). They need to be authenticated as one of the following:</para><ol><li><para>Active Directory (AD) users or group members</para></li><li><para>Invited nonfederated users</para></li><li><para>IAM users and IAM role-based sessions authenticated through Federated Single Sign-On
        /// using SAML, OpenID Connect, or IAM federation</para></li></ol><para>Omit this parameter for users in the third group – IAM users and IAM role-based sessions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmbedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GetSessionEmbedUrlResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GetSessionEmbedUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmbedUrl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GetSessionEmbedUrlResponse, GetQSSessionEmbedUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntryPoint = this.EntryPoint;
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            context.UserArn = this.UserArn;
            
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
            var request = new Amazon.QuickSight.Model.GetSessionEmbedUrlRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.EntryPoint != null)
            {
                request.EntryPoint = cmdletContext.EntryPoint;
            }
            if (cmdletContext.SessionLifetimeInMinute != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinute.Value;
            }
            if (cmdletContext.UserArn != null)
            {
                request.UserArn = cmdletContext.UserArn;
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
        
        private Amazon.QuickSight.Model.GetSessionEmbedUrlResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GetSessionEmbedUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GetSessionEmbedUrl");
            try
            {
                #if DESKTOP
                return client.GetSessionEmbedUrl(request);
                #elif CORECLR
                return client.GetSessionEmbedUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String EntryPoint { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public System.String UserArn { get; set; }
            public System.Func<Amazon.QuickSight.Model.GetSessionEmbedUrlResponse, GetQSSessionEmbedUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
