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
using System.Threading;
using Amazon.AppStream;
using Amazon.AppStream.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a stack to start streaming applications to users. A stack consists of an associated
    /// fleet, user access policies, and storage configurations.
    /// </summary>
    [Cmdlet("New", "APSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Stack")]
    [AWSCmdlet("Calls the Amazon AppStream CreateStack API operation.", Operation = new[] {"CreateStack"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateStackResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Stack or Amazon.AppStream.Model.CreateStackResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Stack object.",
        "The service call response (type Amazon.AppStream.Model.CreateStackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAPSStackCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>The list of interface VPC endpoint (interface endpoint) objects. Users of the stack
        /// can connect to AppStream 2.0 only through the specified endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessEndpoints")]
        public Amazon.AppStream.Model.AccessEndpoint[] AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The stack name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EmbedHostDomain
        /// <summary>
        /// <para>
        /// <para>The domains where AppStream 2.0 streaming sessions can be embedded in an iframe. You
        /// must approve the domains that you want to host embedded AppStream 2.0 streaming sessions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmbedHostDomains")]
        public System.String[] EmbedHostDomain { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables persistent application settings for users during their streaming
        /// sessions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplicationSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter FeedbackURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after they click the Send Feedback link. If no
        /// URL is specified, no Send Feedback link is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackURL { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the stack.</para>
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
        
        #region Parameter StreamingExperienceSettings_PreferredProtocol
        /// <summary>
        /// <para>
        /// <para>The preferred protocol that you want to use while streaming your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.PreferredProtocol")]
        public Amazon.AppStream.PreferredProtocol StreamingExperienceSettings_PreferredProtocol { get; set; }
        #endregion
        
        #region Parameter RedirectURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after their streaming session ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectURL { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_SettingsGroup
        /// <summary>
        /// <para>
        /// <para>The path prefix for the S3 bucket where users’ persistent application settings are
        /// stored. You can allow the same persistent application settings to be used across multiple
        /// stacks by specifying the same settings group for each stack. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationSettings_SettingsGroup { get; set; }
        #endregion
        
        #region Parameter StorageConnector
        /// <summary>
        /// <para>
        /// <para>The storage connectors to enable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConnectors")]
        public Amazon.AppStream.Model.StorageConnector[] StorageConnector { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the stack. A tag is a key-value pair, and the value is
        /// optional. For example, Environment=Test. If you do not specify a value, Environment=.
        /// </para><para>If you do not specify a value, the value is set to an empty string.</para><para>Generally allowed characters are: letters, numbers, and spaces representable in UTF-8,
        /// and the following special characters: </para><para>_ . : / = + \ - @</para><para>For more information about tags, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UserSetting
        /// <summary>
        /// <para>
        /// <para>The actions that are enabled or disabled for users during their streaming sessions.
        /// By default, these actions are enabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserSettings")]
        public Amazon.AppStream.Model.UserSetting[] UserSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stack'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateStackResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stack";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSStack (CreateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateStackResponse, NewAPSStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessEndpoint != null)
            {
                context.AccessEndpoint = new List<Amazon.AppStream.Model.AccessEndpoint>(this.AccessEndpoint);
            }
            context.ApplicationSettings_Enabled = this.ApplicationSettings_Enabled;
            context.ApplicationSettings_SettingsGroup = this.ApplicationSettings_SettingsGroup;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            if (this.EmbedHostDomain != null)
            {
                context.EmbedHostDomain = new List<System.String>(this.EmbedHostDomain);
            }
            context.FeedbackURL = this.FeedbackURL;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedirectURL = this.RedirectURL;
            if (this.StorageConnector != null)
            {
                context.StorageConnector = new List<Amazon.AppStream.Model.StorageConnector>(this.StorageConnector);
            }
            context.StreamingExperienceSettings_PreferredProtocol = this.StreamingExperienceSettings_PreferredProtocol;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.UserSetting != null)
            {
                context.UserSetting = new List<Amazon.AppStream.Model.UserSetting>(this.UserSetting);
            }
            
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
            var request = new Amazon.AppStream.Model.CreateStackRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoints = cmdletContext.AccessEndpoint;
            }
            
             // populate ApplicationSettings
            var requestApplicationSettingsIsNull = true;
            request.ApplicationSettings = new Amazon.AppStream.Model.ApplicationSettings();
            System.Boolean? requestApplicationSettings_applicationSettings_Enabled = null;
            if (cmdletContext.ApplicationSettings_Enabled != null)
            {
                requestApplicationSettings_applicationSettings_Enabled = cmdletContext.ApplicationSettings_Enabled.Value;
            }
            if (requestApplicationSettings_applicationSettings_Enabled != null)
            {
                request.ApplicationSettings.Enabled = requestApplicationSettings_applicationSettings_Enabled.Value;
                requestApplicationSettingsIsNull = false;
            }
            System.String requestApplicationSettings_applicationSettings_SettingsGroup = null;
            if (cmdletContext.ApplicationSettings_SettingsGroup != null)
            {
                requestApplicationSettings_applicationSettings_SettingsGroup = cmdletContext.ApplicationSettings_SettingsGroup;
            }
            if (requestApplicationSettings_applicationSettings_SettingsGroup != null)
            {
                request.ApplicationSettings.SettingsGroup = requestApplicationSettings_applicationSettings_SettingsGroup;
                requestApplicationSettingsIsNull = false;
            }
             // determine if request.ApplicationSettings should be set to null
            if (requestApplicationSettingsIsNull)
            {
                request.ApplicationSettings = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EmbedHostDomain != null)
            {
                request.EmbedHostDomains = cmdletContext.EmbedHostDomain;
            }
            if (cmdletContext.FeedbackURL != null)
            {
                request.FeedbackURL = cmdletContext.FeedbackURL;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RedirectURL != null)
            {
                request.RedirectURL = cmdletContext.RedirectURL;
            }
            if (cmdletContext.StorageConnector != null)
            {
                request.StorageConnectors = cmdletContext.StorageConnector;
            }
            
             // populate StreamingExperienceSettings
            var requestStreamingExperienceSettingsIsNull = true;
            request.StreamingExperienceSettings = new Amazon.AppStream.Model.StreamingExperienceSettings();
            Amazon.AppStream.PreferredProtocol requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol = null;
            if (cmdletContext.StreamingExperienceSettings_PreferredProtocol != null)
            {
                requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol = cmdletContext.StreamingExperienceSettings_PreferredProtocol;
            }
            if (requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol != null)
            {
                request.StreamingExperienceSettings.PreferredProtocol = requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol;
                requestStreamingExperienceSettingsIsNull = false;
            }
             // determine if request.StreamingExperienceSettings should be set to null
            if (requestStreamingExperienceSettingsIsNull)
            {
                request.StreamingExperienceSettings = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserSetting != null)
            {
                request.UserSettings = cmdletContext.UserSetting;
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
        
        private Amazon.AppStream.Model.CreateStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateStack");
            try
            {
                return client.CreateStackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.AppStream.Model.AccessEndpoint> AccessEndpoint { get; set; }
            public System.Boolean? ApplicationSettings_Enabled { get; set; }
            public System.String ApplicationSettings_SettingsGroup { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<System.String> EmbedHostDomain { get; set; }
            public System.String FeedbackURL { get; set; }
            public System.String Name { get; set; }
            public System.String RedirectURL { get; set; }
            public List<Amazon.AppStream.Model.StorageConnector> StorageConnector { get; set; }
            public Amazon.AppStream.PreferredProtocol StreamingExperienceSettings_PreferredProtocol { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.AppStream.Model.UserSetting> UserSetting { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateStackResponse, NewAPSStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stack;
        }
        
    }
}
