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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates the specified fields for the specified stack.
    /// </summary>
    [Cmdlet("Update", "APSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Stack")]
    [AWSCmdlet("Calls the AWS AppStream UpdateStack API operation.", Operation = new[] {"UpdateStack"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.Stack",
        "This cmdlet returns a Stack object.",
        "The service call response (type Amazon.AppStream.Model.UpdateStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPSStackCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The stack attributes to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AttributesToDelete { get; set; }
        #endregion
        
        #region Parameter DeleteStorageConnector
        /// <summary>
        /// <para>
        /// <para>Deletes the storage connectors currently enabled for the stack.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This property is deprecated")]
        [Alias("DeleteStorageConnectors")]
        public System.Boolean DeleteStorageConnector { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The stack name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables persistent application settings for users during their streaming
        /// sessions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplicationSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter FeedbackURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after they choose the Send Feedback link. If
        /// no URL is specified, no Send Feedback link is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FeedbackURL { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RedirectURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after their streaming session ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String ApplicationSettings_SettingsGroup { get; set; }
        #endregion
        
        #region Parameter StorageConnector
        /// <summary>
        /// <para>
        /// <para>The storage connectors to enable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StorageConnectors")]
        public Amazon.AppStream.Model.StorageConnector[] StorageConnector { get; set; }
        #endregion
        
        #region Parameter UserSetting
        /// <summary>
        /// <para>
        /// <para>The actions that are enabled or disabled for users during their streaming sessions.
        /// By default, these actions are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserSettings")]
        public Amazon.AppStream.Model.UserSetting[] UserSetting { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSStack (UpdateStack)"))
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
            
            if (ParameterWasBound("ApplicationSettings_Enabled"))
                context.ApplicationSettings_Enabled = this.ApplicationSettings_Enabled;
            context.ApplicationSettings_SettingsGroup = this.ApplicationSettings_SettingsGroup;
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("DeleteStorageConnector"))
                context.DeleteStorageConnectors = this.DeleteStorageConnector;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.FeedbackURL = this.FeedbackURL;
            context.Name = this.Name;
            context.RedirectURL = this.RedirectURL;
            if (this.StorageConnector != null)
            {
                context.StorageConnectors = new List<Amazon.AppStream.Model.StorageConnector>(this.StorageConnector);
            }
            if (this.UserSetting != null)
            {
                context.UserSettings = new List<Amazon.AppStream.Model.UserSetting>(this.UserSetting);
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
            var request = new Amazon.AppStream.Model.UpdateStackRequest();
            
            
             // populate ApplicationSettings
            bool requestApplicationSettingsIsNull = true;
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
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.DeleteStorageConnectors != null)
            {
                request.DeleteStorageConnectors = cmdletContext.DeleteStorageConnectors.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
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
            if (cmdletContext.StorageConnectors != null)
            {
                request.StorageConnectors = cmdletContext.StorageConnectors;
            }
            if (cmdletContext.UserSettings != null)
            {
                request.UserSettings = cmdletContext.UserSettings;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Stack;
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
        
        private Amazon.AppStream.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "UpdateStack");
            try
            {
                #if DESKTOP
                return client.UpdateStack(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateStackAsync(request);
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
            public System.Boolean? ApplicationSettings_Enabled { get; set; }
            public System.String ApplicationSettings_SettingsGroup { get; set; }
            public List<System.String> AttributesToDelete { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? DeleteStorageConnectors { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FeedbackURL { get; set; }
            public System.String Name { get; set; }
            public System.String RedirectURL { get; set; }
            public List<Amazon.AppStream.Model.StorageConnector> StorageConnectors { get; set; }
            public List<Amazon.AppStream.Model.UserSetting> UserSettings { get; set; }
        }
        
    }
}
