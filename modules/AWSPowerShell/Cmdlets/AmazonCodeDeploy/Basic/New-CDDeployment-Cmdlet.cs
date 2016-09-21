/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Deploys an application revision through the specified deployment group.
    /// </summary>
    [Cmdlet("New", "CDDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDeployment operation against AWS CodeDeploy.", Operation = new[] {"CreateDeployment"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDDeploymentCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an AWS CodeDeploy application associated with the applicable IAM user
        /// or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the application revision is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Bucket")]
        public System.String S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter S3Location_BundleType
        /// <summary>
        /// <para>
        /// <para>The file type of the application revision. Must be one of the following:</para><ul><li><para>tar: A tar archive file.</para></li><li><para>tgz: A compressed tar archive file.</para></li><li><para>zip: A zip archive file.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_BundleType")]
        [AWSConstantClassSource("Amazon.CodeDeploy.BundleType")]
        public Amazon.CodeDeploy.BundleType S3Location_BundleType { get; set; }
        #endregion
        
        #region Parameter GitHubLocation_CommitId
        /// <summary>
        /// <para>
        /// <para>The SHA1 commit ID of the GitHub commit that represents the bundled artifacts for
        /// the application revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_GitHubLocation_CommitId")]
        public System.String GitHubLocation_CommitId { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>The name of a deployment configuration associated with the applicable IAM user or
        /// AWS account.</para><para>If not specified, the value configured in the deployment group will be used as the
        /// default. If the deployment group does not have a deployment configuration associated
        /// with it, then CodeDeployDefault.OneAtATime will be used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter DeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A comment about the deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether a defined automatic rollback configuration is currently enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoRollbackConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Event
        /// <summary>
        /// <para>
        /// <para>The event type or types that trigger a rollback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoRollbackConfiguration_Events")]
        public System.String[] AutoRollbackConfiguration_Event { get; set; }
        #endregion
        
        #region Parameter IgnoreApplicationStopFailure
        /// <summary>
        /// <para>
        /// <para>If set to true, then if the deployment causes the ApplicationStop deployment lifecycle
        /// event to an instance to fail, the deployment to that instance will not be considered
        /// to have failed at that point and will continue on to the BeforeInstall deployment
        /// lifecycle event.</para><para>If set to false or not specified, then if the deployment causes the ApplicationStop
        /// deployment lifecycle event to fail to an instance, the deployment to that instance
        /// will stop, and the deployment to that instance will be considered to have failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IgnoreApplicationStopFailures")]
        public System.Boolean IgnoreApplicationStopFailure { get; set; }
        #endregion
        
        #region Parameter S3Location_Key
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 object that represents the bundled artifacts for the application
        /// revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Key")]
        public System.String S3Location_Key { get; set; }
        #endregion
        
        #region Parameter GitHubLocation_Repository
        /// <summary>
        /// <para>
        /// <para>The GitHub account and repository pair that stores a reference to the commit that
        /// represents the bundled artifacts for the application revision. </para><para>Specified as account/repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_GitHubLocation_Repository")]
        public System.String GitHubLocation_Repository { get; set; }
        #endregion
        
        #region Parameter Revision_RevisionType
        /// <summary>
        /// <para>
        /// <para>The type of application revision:</para><ul><li><para>S3: An application revision stored in Amazon S3.</para></li><li><para>GitHub: An application revision stored in GitHub.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.RevisionLocationType")]
        public Amazon.CodeDeploy.RevisionLocationType Revision_RevisionType { get; set; }
        #endregion
        
        #region Parameter UpdateOutdatedInstancesOnly
        /// <summary>
        /// <para>
        /// <para>Indicates whether to deploy to all instances or only to instances that are not running
        /// the latest application revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UpdateOutdatedInstancesOnly { get; set; }
        #endregion
        
        #region Parameter S3Location_Version
        /// <summary>
        /// <para>
        /// <para>A specific version of the Amazon S3 object that represents the bundled artifacts for
        /// the application revision.</para><para>If the version is not specified, the system will use the most recent version by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Version")]
        public System.String S3Location_Version { get; set; }
        #endregion
        
        #region Parameter S3Location_ETag
        /// <summary>
        /// <para>
        /// <para>The ETag of the Amazon S3 object that represents the bundled artifacts for the application
        /// revision.</para><para>If the ETag is not specified as an input parameter, ETag validation of the object
        /// will be skipped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_ETag")]
        public System.String S3Location_ETag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeployment (CreateDeployment)"))
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
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("AutoRollbackConfiguration_Enabled"))
                context.AutoRollbackConfiguration_Enabled = this.AutoRollbackConfiguration_Enabled;
            if (this.AutoRollbackConfiguration_Event != null)
            {
                context.AutoRollbackConfiguration_Events = new List<System.String>(this.AutoRollbackConfiguration_Event);
            }
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.DeploymentGroupName = this.DeploymentGroupName;
            context.Description = this.Description;
            if (ParameterWasBound("IgnoreApplicationStopFailure"))
                context.IgnoreApplicationStopFailures = this.IgnoreApplicationStopFailure;
            context.Revision_GitHubLocation_CommitId = this.GitHubLocation_CommitId;
            context.Revision_GitHubLocation_Repository = this.GitHubLocation_Repository;
            context.Revision_RevisionType = this.Revision_RevisionType;
            context.Revision_S3Location_Bucket = this.S3Location_Bucket;
            context.Revision_S3Location_BundleType = this.S3Location_BundleType;
            context.Revision_S3Location_ETag = this.S3Location_ETag;
            context.Revision_S3Location_Key = this.S3Location_Key;
            context.Revision_S3Location_Version = this.S3Location_Version;
            if (ParameterWasBound("UpdateOutdatedInstancesOnly"))
                context.UpdateOutdatedInstancesOnly = this.UpdateOutdatedInstancesOnly;
            
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
            var request = new Amazon.CodeDeploy.Model.CreateDeploymentRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate AutoRollbackConfiguration
            bool requestAutoRollbackConfigurationIsNull = true;
            request.AutoRollbackConfiguration = new Amazon.CodeDeploy.Model.AutoRollbackConfiguration();
            System.Boolean? requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled = null;
            if (cmdletContext.AutoRollbackConfiguration_Enabled != null)
            {
                requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled = cmdletContext.AutoRollbackConfiguration_Enabled.Value;
            }
            if (requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled != null)
            {
                request.AutoRollbackConfiguration.Enabled = requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled.Value;
                requestAutoRollbackConfigurationIsNull = false;
            }
            List<System.String> requestAutoRollbackConfiguration_autoRollbackConfiguration_Event = null;
            if (cmdletContext.AutoRollbackConfiguration_Events != null)
            {
                requestAutoRollbackConfiguration_autoRollbackConfiguration_Event = cmdletContext.AutoRollbackConfiguration_Events;
            }
            if (requestAutoRollbackConfiguration_autoRollbackConfiguration_Event != null)
            {
                request.AutoRollbackConfiguration.Events = requestAutoRollbackConfiguration_autoRollbackConfiguration_Event;
                requestAutoRollbackConfigurationIsNull = false;
            }
             // determine if request.AutoRollbackConfiguration should be set to null
            if (requestAutoRollbackConfigurationIsNull)
            {
                request.AutoRollbackConfiguration = null;
            }
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            if (cmdletContext.DeploymentGroupName != null)
            {
                request.DeploymentGroupName = cmdletContext.DeploymentGroupName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IgnoreApplicationStopFailures != null)
            {
                request.IgnoreApplicationStopFailures = cmdletContext.IgnoreApplicationStopFailures.Value;
            }
            
             // populate Revision
            bool requestRevisionIsNull = true;
            request.Revision = new Amazon.CodeDeploy.Model.RevisionLocation();
            Amazon.CodeDeploy.RevisionLocationType requestRevision_revision_RevisionType = null;
            if (cmdletContext.Revision_RevisionType != null)
            {
                requestRevision_revision_RevisionType = cmdletContext.Revision_RevisionType;
            }
            if (requestRevision_revision_RevisionType != null)
            {
                request.Revision.RevisionType = requestRevision_revision_RevisionType;
                requestRevisionIsNull = false;
            }
            Amazon.CodeDeploy.Model.GitHubLocation requestRevision_revision_GitHubLocation = null;
            
             // populate GitHubLocation
            bool requestRevision_revision_GitHubLocationIsNull = true;
            requestRevision_revision_GitHubLocation = new Amazon.CodeDeploy.Model.GitHubLocation();
            System.String requestRevision_revision_GitHubLocation_gitHubLocation_CommitId = null;
            if (cmdletContext.Revision_GitHubLocation_CommitId != null)
            {
                requestRevision_revision_GitHubLocation_gitHubLocation_CommitId = cmdletContext.Revision_GitHubLocation_CommitId;
            }
            if (requestRevision_revision_GitHubLocation_gitHubLocation_CommitId != null)
            {
                requestRevision_revision_GitHubLocation.CommitId = requestRevision_revision_GitHubLocation_gitHubLocation_CommitId;
                requestRevision_revision_GitHubLocationIsNull = false;
            }
            System.String requestRevision_revision_GitHubLocation_gitHubLocation_Repository = null;
            if (cmdletContext.Revision_GitHubLocation_Repository != null)
            {
                requestRevision_revision_GitHubLocation_gitHubLocation_Repository = cmdletContext.Revision_GitHubLocation_Repository;
            }
            if (requestRevision_revision_GitHubLocation_gitHubLocation_Repository != null)
            {
                requestRevision_revision_GitHubLocation.Repository = requestRevision_revision_GitHubLocation_gitHubLocation_Repository;
                requestRevision_revision_GitHubLocationIsNull = false;
            }
             // determine if requestRevision_revision_GitHubLocation should be set to null
            if (requestRevision_revision_GitHubLocationIsNull)
            {
                requestRevision_revision_GitHubLocation = null;
            }
            if (requestRevision_revision_GitHubLocation != null)
            {
                request.Revision.GitHubLocation = requestRevision_revision_GitHubLocation;
                requestRevisionIsNull = false;
            }
            Amazon.CodeDeploy.Model.S3Location requestRevision_revision_S3Location = null;
            
             // populate S3Location
            bool requestRevision_revision_S3LocationIsNull = true;
            requestRevision_revision_S3Location = new Amazon.CodeDeploy.Model.S3Location();
            System.String requestRevision_revision_S3Location_s3Location_Bucket = null;
            if (cmdletContext.Revision_S3Location_Bucket != null)
            {
                requestRevision_revision_S3Location_s3Location_Bucket = cmdletContext.Revision_S3Location_Bucket;
            }
            if (requestRevision_revision_S3Location_s3Location_Bucket != null)
            {
                requestRevision_revision_S3Location.Bucket = requestRevision_revision_S3Location_s3Location_Bucket;
                requestRevision_revision_S3LocationIsNull = false;
            }
            Amazon.CodeDeploy.BundleType requestRevision_revision_S3Location_s3Location_BundleType = null;
            if (cmdletContext.Revision_S3Location_BundleType != null)
            {
                requestRevision_revision_S3Location_s3Location_BundleType = cmdletContext.Revision_S3Location_BundleType;
            }
            if (requestRevision_revision_S3Location_s3Location_BundleType != null)
            {
                requestRevision_revision_S3Location.BundleType = requestRevision_revision_S3Location_s3Location_BundleType;
                requestRevision_revision_S3LocationIsNull = false;
            }
            System.String requestRevision_revision_S3Location_s3Location_ETag = null;
            if (cmdletContext.Revision_S3Location_ETag != null)
            {
                requestRevision_revision_S3Location_s3Location_ETag = cmdletContext.Revision_S3Location_ETag;
            }
            if (requestRevision_revision_S3Location_s3Location_ETag != null)
            {
                requestRevision_revision_S3Location.ETag = requestRevision_revision_S3Location_s3Location_ETag;
                requestRevision_revision_S3LocationIsNull = false;
            }
            System.String requestRevision_revision_S3Location_s3Location_Key = null;
            if (cmdletContext.Revision_S3Location_Key != null)
            {
                requestRevision_revision_S3Location_s3Location_Key = cmdletContext.Revision_S3Location_Key;
            }
            if (requestRevision_revision_S3Location_s3Location_Key != null)
            {
                requestRevision_revision_S3Location.Key = requestRevision_revision_S3Location_s3Location_Key;
                requestRevision_revision_S3LocationIsNull = false;
            }
            System.String requestRevision_revision_S3Location_s3Location_Version = null;
            if (cmdletContext.Revision_S3Location_Version != null)
            {
                requestRevision_revision_S3Location_s3Location_Version = cmdletContext.Revision_S3Location_Version;
            }
            if (requestRevision_revision_S3Location_s3Location_Version != null)
            {
                requestRevision_revision_S3Location.Version = requestRevision_revision_S3Location_s3Location_Version;
                requestRevision_revision_S3LocationIsNull = false;
            }
             // determine if requestRevision_revision_S3Location should be set to null
            if (requestRevision_revision_S3LocationIsNull)
            {
                requestRevision_revision_S3Location = null;
            }
            if (requestRevision_revision_S3Location != null)
            {
                request.Revision.S3Location = requestRevision_revision_S3Location;
                requestRevisionIsNull = false;
            }
             // determine if request.Revision should be set to null
            if (requestRevisionIsNull)
            {
                request.Revision = null;
            }
            if (cmdletContext.UpdateOutdatedInstancesOnly != null)
            {
                request.UpdateOutdatedInstancesOnly = cmdletContext.UpdateOutdatedInstancesOnly.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentId;
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
        
        private static Amazon.CodeDeploy.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.CreateDeploymentRequest request)
        {
            #if DESKTOP
            return client.CreateDeployment(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateDeploymentAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoRollbackConfiguration_Enabled { get; set; }
            public List<System.String> AutoRollbackConfiguration_Events { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public System.String DeploymentGroupName { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? IgnoreApplicationStopFailures { get; set; }
            public System.String Revision_GitHubLocation_CommitId { get; set; }
            public System.String Revision_GitHubLocation_Repository { get; set; }
            public Amazon.CodeDeploy.RevisionLocationType Revision_RevisionType { get; set; }
            public System.String Revision_S3Location_Bucket { get; set; }
            public Amazon.CodeDeploy.BundleType Revision_S3Location_BundleType { get; set; }
            public System.String Revision_S3Location_ETag { get; set; }
            public System.String Revision_S3Location_Key { get; set; }
            public System.String Revision_S3Location_Version { get; set; }
            public System.Boolean? UpdateOutdatedInstancesOnly { get; set; }
        }
        
    }
}
