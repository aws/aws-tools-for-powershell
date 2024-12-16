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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Updates the configuration of an existing app monitor. When you use this operation,
    /// only the parts of the app monitor configuration that you specify in this operation
    /// are changed. For any parameters that you omit, the existing values are kept.
    /// 
    ///  
    /// <para>
    /// You can't use this operation to change the tags of an existing app monitor. To change
    /// the tags of an existing app monitor, use <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// </para><para>
    /// To create a new app monitor, use <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_CreateAppMonitor.html">CreateAppMonitor</a>.
    /// </para><para>
    /// After you update an app monitor, sign in to the CloudWatch RUM console to get the
    /// updated JavaScript code snippet to add to your web application. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-RUM-find-code-snippet.html">How
    /// do I find a code snippet that I've already generated?</a></para>
    /// </summary>
    [Cmdlet("Update", "CWRUMAppMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch RUM UpdateAppMonitor API operation.", Operation = new[] {"UpdateAppMonitor"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWRUMAppMonitorCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppMonitorConfiguration_AllowCookie
        /// <summary>
        /// <para>
        /// <para>If you set this to <c>true</c>, the RUM web client sets two cookies, a session cookie
        /// and a user cookie. The cookies allow the RUM web client to collect data relating to
        /// the number of users an application has and the behavior of the application across
        /// a sequence of events. Cookies are stored in the top-level domain of the current page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppMonitorConfiguration_AllowCookies")]
        public System.Boolean? AppMonitorConfiguration_AllowCookie { get; set; }
        #endregion
        
        #region Parameter CwLogEnabled
        /// <summary>
        /// <para>
        /// <para>Data collected by RUM is kept by RUM for 30 days and then deleted. This parameter
        /// specifies whether RUM sends a copy of this telemetry data to Amazon CloudWatch Logs
        /// in your account. This enables you to keep the telemetry data for more than 30 days,
        /// but it does incur Amazon CloudWatch Logs charges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CwLogEnabled { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The top-level internet domain name for which your application has administrative authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_EnableXRay
        /// <summary>
        /// <para>
        /// <para>If you set this to <c>true</c>, RUM enables X-Ray tracing for the user sessions that
        /// RUM samples. RUM adds an X-Ray trace header to allowed HTTP requests. It also records
        /// an X-Ray segment for allowed HTTP requests. You can see traces and segments from these
        /// user sessions in the X-Ray console and the CloudWatch ServiceLens console. For more
        /// information, see <a href="https://docs.aws.amazon.com/xray/latest/devguide/aws-xray.html">What
        /// is X-Ray?</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AppMonitorConfiguration_EnableXRay { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_ExcludedPage
        /// <summary>
        /// <para>
        /// <para>A list of URLs in your website or application to exclude from RUM data collection.</para><para>You can't include both <c>ExcludedPages</c> and <c>IncludedPages</c> in the same operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppMonitorConfiguration_ExcludedPages")]
        public System.String[] AppMonitorConfiguration_ExcludedPage { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_FavoritePage
        /// <summary>
        /// <para>
        /// <para>A list of pages in your application that are to be displayed with a "favorite" icon
        /// in the CloudWatch RUM console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppMonitorConfiguration_FavoritePages")]
        public System.String[] AppMonitorConfiguration_FavoritePage { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_GuestRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the guest IAM role that is attached to the Amazon Cognito identity pool
        /// that is used to authorize the sending of data to RUM.</para><note><para>It is possible that an app monitor does not have a value for <c>GuestRoleArn</c>.
        /// For example, this can happen when you use the console to create an app monitor and
        /// you allow CloudWatch RUM to create a new identity pool for Authorization. In this
        /// case, <c>GuestRoleArn</c> is not present in the <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_GetAppMonitor.html">GetAppMonitor</a>
        /// response because it is not stored by the service.</para><para>If this issue affects you, you can take one of the following steps:</para><ul><li><para>Use the Cloud Development Kit (CDK) to create an identity pool and the associated
        /// IAM role, and use that for your app monitor.</para></li><li><para>Make a separate <a href="https://docs.aws.amazon.com/cognitoidentity/latest/APIReference/API_GetIdentityPoolRoles.html">GetIdentityPoolRoles</a>
        /// call to Amazon Cognito to retrieve the <c>GuestRoleArn</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppMonitorConfiguration_GuestRoleArn { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito identity pool that is used to authorize the sending of
        /// data to RUM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppMonitorConfiguration_IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_IncludedPage
        /// <summary>
        /// <para>
        /// <para>If this app monitor is to collect data from only certain pages in your application,
        /// this structure lists those pages. </para><para>You can't include both <c>ExcludedPages</c> and <c>IncludedPages</c> in the same operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppMonitorConfiguration_IncludedPages")]
        public System.String[] AppMonitorConfiguration_IncludedPage { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the app monitor to update.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_SessionSampleRate
        /// <summary>
        /// <para>
        /// <para>Specifies the portion of user sessions to use for RUM data collection. Choosing a
        /// higher portion gives you more data but also incurs more costs.</para><para>The range for this value is 0 to 1 inclusive. Setting this to 1 means that 100% of
        /// user sessions are sampled, and setting it to 0.1 means that 10% of user sessions are
        /// sampled.</para><para>If you omit this parameter, the default of 0.1 is used, and 10% of sessions will be
        /// sampled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AppMonitorConfiguration_SessionSampleRate { get; set; }
        #endregion
        
        #region Parameter CustomEvents_Status
        /// <summary>
        /// <para>
        /// <para>Specifies whether this app monitor allows the web client to define and send custom
        /// events. The default is for custom events to be <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchRUM.CustomEventsStatus")]
        public Amazon.CloudWatchRUM.CustomEventsStatus CustomEvents_Status { get; set; }
        #endregion
        
        #region Parameter AppMonitorConfiguration_Telemetry
        /// <summary>
        /// <para>
        /// <para>An array that lists the types of telemetry data that this app monitor is to collect.</para><ul><li><para><c>errors</c> indicates that RUM collects data about unhandled JavaScript errors
        /// raised by your application.</para></li><li><para><c>performance</c> indicates that RUM collects performance data about how your application
        /// and its resources are loaded and rendered. This includes Core Web Vitals.</para></li><li><para><c>http</c> indicates that RUM collects data about HTTP errors thrown by your application.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppMonitorConfiguration_Telemetries")]
        public System.String[] AppMonitorConfiguration_Telemetry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWRUMAppMonitor (UpdateAppMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse, UpdateCWRUMAppMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppMonitorConfiguration_AllowCookie = this.AppMonitorConfiguration_AllowCookie;
            context.AppMonitorConfiguration_EnableXRay = this.AppMonitorConfiguration_EnableXRay;
            if (this.AppMonitorConfiguration_ExcludedPage != null)
            {
                context.AppMonitorConfiguration_ExcludedPage = new List<System.String>(this.AppMonitorConfiguration_ExcludedPage);
            }
            if (this.AppMonitorConfiguration_FavoritePage != null)
            {
                context.AppMonitorConfiguration_FavoritePage = new List<System.String>(this.AppMonitorConfiguration_FavoritePage);
            }
            context.AppMonitorConfiguration_GuestRoleArn = this.AppMonitorConfiguration_GuestRoleArn;
            context.AppMonitorConfiguration_IdentityPoolId = this.AppMonitorConfiguration_IdentityPoolId;
            if (this.AppMonitorConfiguration_IncludedPage != null)
            {
                context.AppMonitorConfiguration_IncludedPage = new List<System.String>(this.AppMonitorConfiguration_IncludedPage);
            }
            context.AppMonitorConfiguration_SessionSampleRate = this.AppMonitorConfiguration_SessionSampleRate;
            if (this.AppMonitorConfiguration_Telemetry != null)
            {
                context.AppMonitorConfiguration_Telemetry = new List<System.String>(this.AppMonitorConfiguration_Telemetry);
            }
            context.CustomEvents_Status = this.CustomEvents_Status;
            context.CwLogEnabled = this.CwLogEnabled;
            context.Domain = this.Domain;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchRUM.Model.UpdateAppMonitorRequest();
            
            
             // populate AppMonitorConfiguration
            var requestAppMonitorConfigurationIsNull = true;
            request.AppMonitorConfiguration = new Amazon.CloudWatchRUM.Model.AppMonitorConfiguration();
            System.Boolean? requestAppMonitorConfiguration_appMonitorConfiguration_AllowCookie = null;
            if (cmdletContext.AppMonitorConfiguration_AllowCookie != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_AllowCookie = cmdletContext.AppMonitorConfiguration_AllowCookie.Value;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_AllowCookie != null)
            {
                request.AppMonitorConfiguration.AllowCookies = requestAppMonitorConfiguration_appMonitorConfiguration_AllowCookie.Value;
                requestAppMonitorConfigurationIsNull = false;
            }
            System.Boolean? requestAppMonitorConfiguration_appMonitorConfiguration_EnableXRay = null;
            if (cmdletContext.AppMonitorConfiguration_EnableXRay != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_EnableXRay = cmdletContext.AppMonitorConfiguration_EnableXRay.Value;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_EnableXRay != null)
            {
                request.AppMonitorConfiguration.EnableXRay = requestAppMonitorConfiguration_appMonitorConfiguration_EnableXRay.Value;
                requestAppMonitorConfigurationIsNull = false;
            }
            List<System.String> requestAppMonitorConfiguration_appMonitorConfiguration_ExcludedPage = null;
            if (cmdletContext.AppMonitorConfiguration_ExcludedPage != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_ExcludedPage = cmdletContext.AppMonitorConfiguration_ExcludedPage;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_ExcludedPage != null)
            {
                request.AppMonitorConfiguration.ExcludedPages = requestAppMonitorConfiguration_appMonitorConfiguration_ExcludedPage;
                requestAppMonitorConfigurationIsNull = false;
            }
            List<System.String> requestAppMonitorConfiguration_appMonitorConfiguration_FavoritePage = null;
            if (cmdletContext.AppMonitorConfiguration_FavoritePage != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_FavoritePage = cmdletContext.AppMonitorConfiguration_FavoritePage;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_FavoritePage != null)
            {
                request.AppMonitorConfiguration.FavoritePages = requestAppMonitorConfiguration_appMonitorConfiguration_FavoritePage;
                requestAppMonitorConfigurationIsNull = false;
            }
            System.String requestAppMonitorConfiguration_appMonitorConfiguration_GuestRoleArn = null;
            if (cmdletContext.AppMonitorConfiguration_GuestRoleArn != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_GuestRoleArn = cmdletContext.AppMonitorConfiguration_GuestRoleArn;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_GuestRoleArn != null)
            {
                request.AppMonitorConfiguration.GuestRoleArn = requestAppMonitorConfiguration_appMonitorConfiguration_GuestRoleArn;
                requestAppMonitorConfigurationIsNull = false;
            }
            System.String requestAppMonitorConfiguration_appMonitorConfiguration_IdentityPoolId = null;
            if (cmdletContext.AppMonitorConfiguration_IdentityPoolId != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_IdentityPoolId = cmdletContext.AppMonitorConfiguration_IdentityPoolId;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_IdentityPoolId != null)
            {
                request.AppMonitorConfiguration.IdentityPoolId = requestAppMonitorConfiguration_appMonitorConfiguration_IdentityPoolId;
                requestAppMonitorConfigurationIsNull = false;
            }
            List<System.String> requestAppMonitorConfiguration_appMonitorConfiguration_IncludedPage = null;
            if (cmdletContext.AppMonitorConfiguration_IncludedPage != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_IncludedPage = cmdletContext.AppMonitorConfiguration_IncludedPage;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_IncludedPage != null)
            {
                request.AppMonitorConfiguration.IncludedPages = requestAppMonitorConfiguration_appMonitorConfiguration_IncludedPage;
                requestAppMonitorConfigurationIsNull = false;
            }
            System.Double? requestAppMonitorConfiguration_appMonitorConfiguration_SessionSampleRate = null;
            if (cmdletContext.AppMonitorConfiguration_SessionSampleRate != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_SessionSampleRate = cmdletContext.AppMonitorConfiguration_SessionSampleRate.Value;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_SessionSampleRate != null)
            {
                request.AppMonitorConfiguration.SessionSampleRate = requestAppMonitorConfiguration_appMonitorConfiguration_SessionSampleRate.Value;
                requestAppMonitorConfigurationIsNull = false;
            }
            List<System.String> requestAppMonitorConfiguration_appMonitorConfiguration_Telemetry = null;
            if (cmdletContext.AppMonitorConfiguration_Telemetry != null)
            {
                requestAppMonitorConfiguration_appMonitorConfiguration_Telemetry = cmdletContext.AppMonitorConfiguration_Telemetry;
            }
            if (requestAppMonitorConfiguration_appMonitorConfiguration_Telemetry != null)
            {
                request.AppMonitorConfiguration.Telemetries = requestAppMonitorConfiguration_appMonitorConfiguration_Telemetry;
                requestAppMonitorConfigurationIsNull = false;
            }
             // determine if request.AppMonitorConfiguration should be set to null
            if (requestAppMonitorConfigurationIsNull)
            {
                request.AppMonitorConfiguration = null;
            }
            
             // populate CustomEvents
            var requestCustomEventsIsNull = true;
            request.CustomEvents = new Amazon.CloudWatchRUM.Model.CustomEvents();
            Amazon.CloudWatchRUM.CustomEventsStatus requestCustomEvents_customEvents_Status = null;
            if (cmdletContext.CustomEvents_Status != null)
            {
                requestCustomEvents_customEvents_Status = cmdletContext.CustomEvents_Status;
            }
            if (requestCustomEvents_customEvents_Status != null)
            {
                request.CustomEvents.Status = requestCustomEvents_customEvents_Status;
                requestCustomEventsIsNull = false;
            }
             // determine if request.CustomEvents should be set to null
            if (requestCustomEventsIsNull)
            {
                request.CustomEvents = null;
            }
            if (cmdletContext.CwLogEnabled != null)
            {
                request.CwLogEnabled = cmdletContext.CwLogEnabled.Value;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.UpdateAppMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "UpdateAppMonitor");
            try
            {
                #if DESKTOP
                return client.UpdateAppMonitor(request);
                #elif CORECLR
                return client.UpdateAppMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AppMonitorConfiguration_AllowCookie { get; set; }
            public System.Boolean? AppMonitorConfiguration_EnableXRay { get; set; }
            public List<System.String> AppMonitorConfiguration_ExcludedPage { get; set; }
            public List<System.String> AppMonitorConfiguration_FavoritePage { get; set; }
            public System.String AppMonitorConfiguration_GuestRoleArn { get; set; }
            public System.String AppMonitorConfiguration_IdentityPoolId { get; set; }
            public List<System.String> AppMonitorConfiguration_IncludedPage { get; set; }
            public System.Double? AppMonitorConfiguration_SessionSampleRate { get; set; }
            public List<System.String> AppMonitorConfiguration_Telemetry { get; set; }
            public Amazon.CloudWatchRUM.CustomEventsStatus CustomEvents_Status { get; set; }
            public System.Boolean? CwLogEnabled { get; set; }
            public System.String Domain { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.UpdateAppMonitorResponse, UpdateCWRUMAppMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
