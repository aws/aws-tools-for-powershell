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
    /// Generates an embed URL that you can use to embed an Amazon QuickSight experience in
    /// your website. This action can be used for any type of user registered in an Amazon
    /// QuickSight account. Before you use this action, make sure that you have configured
    /// the relevant Amazon QuickSight resource and permissions.
    /// 
    ///  
    /// <para>
    /// The following rules apply to the generated URL:
    /// </para><ul><li><para>
    /// It contains a temporary bearer token. It is valid for 5 minutes after it is generated.
    /// Once redeemed within this period, it cannot be re-used again.
    /// </para></li><li><para>
    /// The URL validity period should not be confused with the actual session lifetime that
    /// can be customized using the <code><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_GenerateEmbedUrlForRegisteredUser.html#QS-GenerateEmbedUrlForRegisteredUser-request-SessionLifetimeInMinutes">SessionLifetimeInMinutes</a></code> parameter.
    /// </para><para>
    /// The resulting user session is valid for 15 minutes (minimum) to 10 hours (maximum).
    /// The default session duration is 10 hours.
    /// </para></li><li><para>
    /// You are charged only when the URL is used or there is interaction with Amazon QuickSight.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/embedded-analytics.html">Embedded
    /// Analytics</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// For more information about the high-level steps for embedding and for an interactive
    /// demo of the ways you can customize embedding, visit the <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-portal.html">Amazon
    /// QuickSight Developer Portal</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSEmbedUrlForRegisteredUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GenerateEmbedUrlForRegisteredUser API operation.", Operation = new[] {"GenerateEmbedUrlForRegisteredUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQSEmbedUrlForRegisteredUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that contains the dashboard that you're
        /// embedding.</para>
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
        
        #region Parameter Dashboard_InitialDashboardId
        /// <summary>
        /// <para>
        /// <para>The dashboard ID for the dashboard that you want the user to see first. This ID is
        /// included in the output URL. When the URL in response is accessed, Amazon QuickSight
        /// renders this dashboard if the user has permissions to view it.</para><para>If the user does not have permission to view this dashboard, they see a permissions
        /// error message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_InitialDashboardId")]
        public System.String Dashboard_InitialDashboardId { get; set; }
        #endregion
        
        #region Parameter QuickSightConsole_InitialPath
        /// <summary>
        /// <para>
        /// <para>The initial URL path for the Amazon QuickSight console. <code>InitialPath</code> is
        /// required.</para><para>The entry point URL is constrained to the following paths:</para><ul><li><para><code>/start</code></para></li><li><para><code>/start/analyses</code></para></li><li><para><code>/start/dashboards</code></para></li><li><para><code>/start/favorites</code></para></li><li><para><code>/dashboards/DashboardId</code>. <i>DashboardId</i> is the actual ID key from
        /// the Amazon QuickSight console URL of the dashboard.</para></li><li><para><code>/analyses/AnalysisId</code>. <i>AnalysisId</i> is the actual ID key from the
        /// Amazon QuickSight console URL of the analysis.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_InitialPath")]
        public System.String QuickSightConsole_InitialPath { get; set; }
        #endregion
        
        #region Parameter QSearchBar_InitialTopicId
        /// <summary>
        /// <para>
        /// <para>The ID of the Q topic that you want to make the starting topic in the Q search bar.
        /// You can find a topic ID by navigating to the Topics pane in the Amazon QuickSight
        /// application and opening a topic. The ID is in the URL for the topic that you open.</para><para>If you don't specify an initial topic, a list of all shared topics is shown in the
        /// Q bar for your readers. When you select an initial topic, you can specify whether
        /// or not readers are allowed to select other topics from the available ones in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QSearchBar_InitialTopicId")]
        public System.String QSearchBar_InitialTopicId { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>How many minutes the session is valid. The session lifetime must be in [15-600] minutes
        /// range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64? SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name for the registered user.</para>
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
        public System.String UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmbedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSEmbedUrlForRegisteredUser (GenerateEmbedUrlForRegisteredUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse, NewQSEmbedUrlForRegisteredUserCmdlet>(Select) ??
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
            context.Dashboard_InitialDashboardId = this.Dashboard_InitialDashboardId;
            context.QSearchBar_InitialTopicId = this.QSearchBar_InitialTopicId;
            context.QuickSightConsole_InitialPath = this.QuickSightConsole_InitialPath;
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            context.UserArn = this.UserArn;
            #if MODULAR
            if (this.UserArn == null && ParameterWasBound(nameof(this.UserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate ExperienceConfiguration
            var requestExperienceConfigurationIsNull = true;
            request.ExperienceConfiguration = new Amazon.QuickSight.Model.RegisteredUserEmbeddingExperienceConfiguration();
            Amazon.QuickSight.Model.RegisteredUserDashboardEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            
             // populate Dashboard
            var requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard = new Amazon.QuickSight.Model.RegisteredUserDashboardEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = null;
            if (cmdletContext.Dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = cmdletContext.Dashboard_InitialDashboardId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.InitialDashboardId = requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_DashboardIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard != null)
            {
                request.ExperienceConfiguration.Dashboard = requestExperienceConfiguration_experienceConfiguration_Dashboard;
                requestExperienceConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.RegisteredUserQSearchBarEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_QSearchBar = null;
            
             // populate QSearchBar
            var requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QSearchBar = new Amazon.QuickSight.Model.RegisteredUserQSearchBarEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId = null;
            if (cmdletContext.QSearchBar_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId = cmdletContext.QSearchBar_InitialTopicId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar.InitialTopicId = requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId;
                requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QSearchBar should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBar != null)
            {
                request.ExperienceConfiguration.QSearchBar = requestExperienceConfiguration_experienceConfiguration_QSearchBar;
                requestExperienceConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.RegisteredUserQuickSightConsoleEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = null;
            
             // populate QuickSightConsole
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = new Amazon.QuickSight.Model.RegisteredUserQuickSightConsoleEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath = null;
            if (cmdletContext.QuickSightConsole_InitialPath != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath = cmdletContext.QuickSightConsole_InitialPath;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole.InitialPath = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole != null)
            {
                request.ExperienceConfiguration.QuickSightConsole = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole;
                requestExperienceConfigurationIsNull = false;
            }
             // determine if request.ExperienceConfiguration should be set to null
            if (requestExperienceConfigurationIsNull)
            {
                request.ExperienceConfiguration = null;
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
        
        private Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GenerateEmbedUrlForRegisteredUser");
            try
            {
                #if DESKTOP
                return client.GenerateEmbedUrlForRegisteredUser(request);
                #elif CORECLR
                return client.GenerateEmbedUrlForRegisteredUserAsync(request).GetAwaiter().GetResult();
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
            public System.String Dashboard_InitialDashboardId { get; set; }
            public System.String QSearchBar_InitialTopicId { get; set; }
            public System.String QuickSightConsole_InitialPath { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public System.String UserArn { get; set; }
            public System.Func<Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserResponse, NewQSEmbedUrlForRegisteredUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
