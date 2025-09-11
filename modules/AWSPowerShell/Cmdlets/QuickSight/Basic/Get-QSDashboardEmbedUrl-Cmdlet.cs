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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Generates a temporary session URL and authorization code(bearer token) that you can
    /// use to embed an QuickSight read-only dashboard in your website or application. Before
    /// you use this command, make sure that you have configured the dashboards and permissions.
    /// 
    /// 
    ///  
    /// <para>
    /// Currently, you can use <c>GetDashboardEmbedURL</c> only from the server, not from
    /// the user's browser. The following rules apply to the generated URL:
    /// </para><ul><li><para>
    /// They must be used together.
    /// </para></li><li><para>
    /// They can be used one time only.
    /// </para></li><li><para>
    /// They are valid for 5 minutes after you run this command.
    /// </para></li><li><para>
    /// You are charged only when the URL is used or there is interaction with QuickSight.
    /// </para></li><li><para>
    /// The resulting user session is valid for 15 minutes (default) up to 10 hours (maximum).
    /// You can use the optional <c>SessionLifetimeInMinutes</c> parameter to customize session
    /// duration.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/embedded-analytics-deprecated.html">Embedding
    /// Analytics Using GetDashboardEmbedUrl</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// For more information about the high-level steps for embedding and for an interactive
    /// demo of the ways you can customize embedding, visit the <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-portal.html">Amazon
    /// QuickSight Developer Portal</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "QSDashboardEmbedUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GetDashboardEmbedUrl API operation.", Operation = new[] {"GetDashboardEmbedUrl"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetQSDashboardEmbedUrlCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalDashboardId
        /// <summary>
        /// <para>
        /// <para>A list of one or more dashboard IDs that you want anonymous users to have tempporary
        /// access to. Currently, the <c>IdentityType</c> parameter must be set to <c>ANONYMOUS</c>
        /// because other identity types authenticate as QuickSight or IAM users. For example,
        /// if you set "<c>--dashboard-id dash_id1 --dashboard-id dash_id2 dash_id3 identity-type
        /// ANONYMOUS</c>", the session can access all three dashboards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalDashboardIds")]
        public System.String[] AdditionalDashboardId { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that contains the dashboard that you're
        /// embedding.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID for the dashboard, also added to the Identity and Access Management (IAM) policy.</para>
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
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>The authentication method that the user uses to sign in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.EmbeddingIdentityType")]
        public Amazon.QuickSight.EmbeddingIdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The QuickSight namespace that contains the dashboard IDs in this request. If you're
        /// not using a custom namespace, set <c>Namespace = default</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter ResetDisabled
        /// <summary>
        /// <para>
        /// <para>Remove the reset button on the embedded dashboard. The default is FALSE, which enables
        /// the reset button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResetDisabled { get; set; }
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
        
        #region Parameter StatePersistenceEnabled
        /// <summary>
        /// <para>
        /// <para>Adds persistence of state for the user session in an embedded dashboard. Persistence
        /// applies to the sheet and the parameter settings. These are control settings that the
        /// dashboard subscriber (QuickSight reader) chooses while viewing the dashboard. If this
        /// is set to <c>TRUE</c>, the settings are the same when the subscriber reopens the same
        /// dashboard URL. The state is stored in QuickSight, not in a browser cookie. If this
        /// is set to FALSE, the state of the user session is not persisted. The default is <c>FALSE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StatePersistenceEnabled { get; set; }
        #endregion
        
        #region Parameter UndoRedoDisabled
        /// <summary>
        /// <para>
        /// <para>Remove the undo/redo button on the embedded dashboard. The default is FALSE, which
        /// enables the undo/redo button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UndoRedoDisabled { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user's Amazon Resource Name (ARN), for use with <c>QUICKSIGHT</c>
        /// identity type. You can use this for any Amazon QuickSight users in your account (readers,
        /// authors, or admins) authenticated as one of the following:</para><ul><li><para>Active Directory (AD) users or group members</para></li><li><para>Invited nonfederated users</para></li><li><para>IAM users and IAM role-based sessions authenticated through Federated Single Sign-On
        /// using SAML, OpenID Connect, or IAM federation.</para></li></ul><para>Omit this parameter for users in the third group – IAM users and IAM role-based sessions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmbedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmbedUrl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DashboardId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DashboardId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DashboardId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse, GetQSDashboardEmbedUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DashboardId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalDashboardId != null)
            {
                context.AdditionalDashboardId = new List<System.String>(this.AdditionalDashboardId);
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityType = this.IdentityType;
            #if MODULAR
            if (this.IdentityType == null && ParameterWasBound(nameof(this.IdentityType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            context.ResetDisabled = this.ResetDisabled;
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            context.StatePersistenceEnabled = this.StatePersistenceEnabled;
            context.UndoRedoDisabled = this.UndoRedoDisabled;
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
            var request = new Amazon.QuickSight.Model.GetDashboardEmbedUrlRequest();
            
            if (cmdletContext.AdditionalDashboardId != null)
            {
                request.AdditionalDashboardIds = cmdletContext.AdditionalDashboardId;
            }
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
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.ResetDisabled != null)
            {
                request.ResetDisabled = cmdletContext.ResetDisabled.Value;
            }
            if (cmdletContext.SessionLifetimeInMinute != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinute.Value;
            }
            if (cmdletContext.StatePersistenceEnabled != null)
            {
                request.StatePersistenceEnabled = cmdletContext.StatePersistenceEnabled.Value;
            }
            if (cmdletContext.UndoRedoDisabled != null)
            {
                request.UndoRedoDisabled = cmdletContext.UndoRedoDisabled.Value;
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
            public List<System.String> AdditionalDashboardId { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String DashboardId { get; set; }
            public Amazon.QuickSight.EmbeddingIdentityType IdentityType { get; set; }
            public System.String Namespace { get; set; }
            public System.Boolean? ResetDisabled { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public System.Boolean? StatePersistenceEnabled { get; set; }
            public System.Boolean? UndoRedoDisabled { get; set; }
            public System.String UserArn { get; set; }
            public System.Func<Amazon.QuickSight.Model.GetDashboardEmbedUrlResponse, GetQSDashboardEmbedUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
