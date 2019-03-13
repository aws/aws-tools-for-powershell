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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Deploys an application revision through the specified deployment group.
    /// </summary>
    [Cmdlet("New", "CDDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy CreateDeployment API operation.", Operation = new[] {"CreateDeployment"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDDeploymentCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an AWS CodeDeploy application associated with the IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter TargetInstancesAutoScalingGroup
        /// <summary>
        /// <para>
        /// <para>The names of one or more Auto Scaling groups to identify a replacement environment
        /// for a blue/green deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetInstances_AutoScalingGroup","TargetInstances_AutoScalingGroups")]
        public System.String[] TargetInstancesAutoScalingGroup { get; set; }
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
        
        #region Parameter AppSpecContent_Content
        /// <summary>
        /// <para>
        /// <para> The YAML-formatted or JSON-formatted revision string. </para><para> For an AWS Lambda deployment, the content includes a Lambda function name, the alias
        /// for its original version, and the alias for its replacement version. The deployment
        /// shifts traffic from the original version of the Lambda function to the replacement
        /// version. </para><para> For an Amazon ECS deployment, the content includes the task name, information about
        /// the load balancer that serves traffic to the container, and more. </para><para> For both types of deployments, the content can specify Lambda functions that run
        /// at specified hooks, such as <code>BeforeInstall</code>, during a deployment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_AppSpecContent_Content")]
        public System.String AppSpecContent_Content { get; set; }
        #endregion
        
        #region Parameter String_Content
        /// <summary>
        /// <para>
        /// <para>The YAML-formatted or JSON-formatted revision string. It includes information about
        /// which Lambda function to update and optional Lambda functions that validate deployment
        /// lifecycle events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_String_Content")]
        public System.String String_Content { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>The name of a deployment configuration associated with the IAM user or AWS account.</para><para>If not specified, the value configured in the deployment group is used as the default.
        /// If the deployment group does not have a deployment configuration associated with it,
        /// CodeDeployDefault.OneAtATime is used by default.</para>
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
        
        #region Parameter Ec2TagSetList
        /// <summary>
        /// <para>
        /// <para>A list that contains other lists of EC2 instance tag groups. For an instance to be
        /// included in the deployment group, it must be identified by all of the tag groups in
        /// the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeDeploy.Model.EC2TagFilter[][] Ec2TagSetList { get; set; }
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
        
        #region Parameter S3Location_ETag
        /// <summary>
        /// <para>
        /// <para>The ETag of the Amazon S3 object that represents the bundled artifacts for the application
        /// revision.</para><para>If the ETag is not specified as an input parameter, ETag validation of the object
        /// is skipped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_ETag")]
        public System.String S3Location_ETag { get; set; }
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
        
        #region Parameter FileExistsBehavior
        /// <summary>
        /// <para>
        /// <para>Information about how AWS CodeDeploy handles files that already exist in a deployment
        /// target location but weren't part of the previous successful deployment.</para><para>The fileExistsBehavior parameter takes any of the following values:</para><ul><li><para>DISALLOW: The deployment fails. This is also the default behavior if no option is
        /// specified.</para></li><li><para>OVERWRITE: The version of the file from the application revision currently being deployed
        /// replaces the version already on the instance.</para></li><li><para>RETAIN: The version of the file already on the instance is kept and used as part of
        /// the new deployment.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.FileExistsBehavior")]
        public Amazon.CodeDeploy.FileExistsBehavior FileExistsBehavior { get; set; }
        #endregion
        
        #region Parameter IgnoreApplicationStopFailure
        /// <summary>
        /// <para>
        /// <para> If true, then if an ApplicationStop, BeforeBlockTraffic, or AfterBlockTraffic deployment
        /// lifecycle event to an instance fails, then the deployment continues to the next deployment
        /// lifecycle event. For example, if ApplicationStop fails, the deployment continues with
        /// DownloadBundle. If BeforeBlockTraffic fails, the deployment continues with BlockTraffic.
        /// If AfterBlockTraffic fails, the deployment continues with ApplicationStop. </para><para> If false or not specified, then if a lifecycle event fails during a deployment to
        /// an instance, that deployment fails. If deployment to that instance is part of an overall
        /// deployment and the number of healthy hosts is not less than the minimum number of
        /// healthy hosts, then a deployment to the next instance is attempted. </para><para> During a deployment, the AWS CodeDeploy agent runs the scripts specified for ApplicationStop,
        /// BeforeBlockTraffic, and AfterBlockTraffic in the AppSpec file from the previous successful
        /// deployment. (All other scripts are run from the AppSpec file in the current deployment.)
        /// If one of these scripts contains an error and does not run successfully, the deployment
        /// can fail. </para><para> If the cause of the failure is a script from the last successful deployment that
        /// will never run successfully, create a new deployment and use <code>ignoreApplicationStopFailures</code>
        /// to specify that the ApplicationStop, BeforeBlockTraffic, and AfterBlockTraffic failures
        /// should be ignored. </para>
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
        
        #region Parameter RevisionType
        /// <summary>
        /// <para>
        /// <para>The type of application revision:</para><ul><li><para>S3: An application revision stored in Amazon S3.</para></li><li><para>GitHub: An application revision stored in GitHub (EC2/On-premises deployments only).</para></li><li><para>String: A YAML-formatted or JSON-formatted string (AWS Lambda deployments only).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_RevisionType")]
        [AWSConstantClassSource("Amazon.CodeDeploy.RevisionLocationType")]
        public Amazon.CodeDeploy.RevisionLocationType RevisionType { get; set; }
        #endregion
        
        #region Parameter AppSpecContent_Sha256
        /// <summary>
        /// <para>
        /// <para> The SHA256 hash value of the revision content. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_AppSpecContent_Sha256")]
        public System.String AppSpecContent_Sha256 { get; set; }
        #endregion
        
        #region Parameter String_Sha256
        /// <summary>
        /// <para>
        /// <para>The SHA256 hash value of the revision content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_String_Sha256")]
        public System.String String_Sha256 { get; set; }
        #endregion
        
        #region Parameter TargetInstancesTagFilter
        /// <summary>
        /// <para>
        /// <para>The tag filter key, type, and value used to identify Amazon EC2 instances in a replacement
        /// environment for a blue/green deployment. Cannot be used in the same call as ec2TagSet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetInstances_TagFilter","TargetInstances_TagFilters")]
        public Amazon.CodeDeploy.Model.EC2TagFilter[] TargetInstancesTagFilter { get; set; }
        #endregion
        
        #region Parameter UpdateOutdatedInstancesOnly
        /// <summary>
        /// <para>
        /// <para> Indicates whether to deploy to all instances or only to instances that are not running
        /// the latest application revision. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UpdateOutdatedInstancesOnly { get; set; }
        #endregion
        
        #region Parameter S3Location_Version
        /// <summary>
        /// <para>
        /// <para>A specific version of the Amazon S3 object that represents the bundled artifacts for
        /// the application revision.</para><para>If the version is not specified, the system uses the most recent version by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Version")]
        public System.String S3Location_Version { get; set; }
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
            context.FileExistsBehavior = this.FileExistsBehavior;
            if (ParameterWasBound("IgnoreApplicationStopFailure"))
                context.IgnoreApplicationStopFailures = this.IgnoreApplicationStopFailure;
            context.Revision_AppSpecContent_Content = this.AppSpecContent_Content;
            context.Revision_AppSpecContent_Sha256 = this.AppSpecContent_Sha256;
            context.Revision_GitHubLocation_CommitId = this.GitHubLocation_CommitId;
            context.Revision_GitHubLocation_Repository = this.GitHubLocation_Repository;
            context.RevisionType = this.RevisionType;
            context.Revision_S3Location_Bucket = this.S3Location_Bucket;
            context.Revision_S3Location_BundleType = this.S3Location_BundleType;
            context.Revision_S3Location_ETag = this.S3Location_ETag;
            context.Revision_S3Location_Key = this.S3Location_Key;
            context.Revision_S3Location_Version = this.S3Location_Version;
            context.Revision_String_Content = this.String_Content;
            context.Revision_String_Sha256 = this.String_Sha256;
            if (this.TargetInstancesAutoScalingGroup != null)
            {
                context.TargetInstancesAutoScalingGroup = new List<System.String>(this.TargetInstancesAutoScalingGroup);
            }
            if (this.Ec2TagSetList != null)
            {
                context.Ec2TagSetList = new List<List<Amazon.CodeDeploy.Model.EC2TagFilter>>();
                foreach (var innerList in this.Ec2TagSetList)
                {
                    context.Ec2TagSetList.Add(new List<Amazon.CodeDeploy.Model.EC2TagFilter>(innerList));
                }
            }
            if (this.TargetInstancesTagFilter != null)
            {
                context.TargetInstancesTagFilter = new List<Amazon.CodeDeploy.Model.EC2TagFilter>(this.TargetInstancesTagFilter);
            }
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
            if (cmdletContext.FileExistsBehavior != null)
            {
                request.FileExistsBehavior = cmdletContext.FileExistsBehavior;
            }
            if (cmdletContext.IgnoreApplicationStopFailures != null)
            {
                request.IgnoreApplicationStopFailures = cmdletContext.IgnoreApplicationStopFailures.Value;
            }
            
             // populate Revision
            bool requestRevisionIsNull = true;
            request.Revision = new Amazon.CodeDeploy.Model.RevisionLocation();
            Amazon.CodeDeploy.RevisionLocationType requestRevision_revisionType = null;
            if (cmdletContext.RevisionType != null)
            {
                requestRevision_revisionType = cmdletContext.RevisionType;
            }
            if (requestRevision_revisionType != null)
            {
                request.Revision.RevisionType = requestRevision_revisionType;
                requestRevisionIsNull = false;
            }
            Amazon.CodeDeploy.Model.AppSpecContent requestRevision_revision_AppSpecContent = null;
            
             // populate AppSpecContent
            bool requestRevision_revision_AppSpecContentIsNull = true;
            requestRevision_revision_AppSpecContent = new Amazon.CodeDeploy.Model.AppSpecContent();
            System.String requestRevision_revision_AppSpecContent_appSpecContent_Content = null;
            if (cmdletContext.Revision_AppSpecContent_Content != null)
            {
                requestRevision_revision_AppSpecContent_appSpecContent_Content = cmdletContext.Revision_AppSpecContent_Content;
            }
            if (requestRevision_revision_AppSpecContent_appSpecContent_Content != null)
            {
                requestRevision_revision_AppSpecContent.Content = requestRevision_revision_AppSpecContent_appSpecContent_Content;
                requestRevision_revision_AppSpecContentIsNull = false;
            }
            System.String requestRevision_revision_AppSpecContent_appSpecContent_Sha256 = null;
            if (cmdletContext.Revision_AppSpecContent_Sha256 != null)
            {
                requestRevision_revision_AppSpecContent_appSpecContent_Sha256 = cmdletContext.Revision_AppSpecContent_Sha256;
            }
            if (requestRevision_revision_AppSpecContent_appSpecContent_Sha256 != null)
            {
                requestRevision_revision_AppSpecContent.Sha256 = requestRevision_revision_AppSpecContent_appSpecContent_Sha256;
                requestRevision_revision_AppSpecContentIsNull = false;
            }
             // determine if requestRevision_revision_AppSpecContent should be set to null
            if (requestRevision_revision_AppSpecContentIsNull)
            {
                requestRevision_revision_AppSpecContent = null;
            }
            if (requestRevision_revision_AppSpecContent != null)
            {
                request.Revision.AppSpecContent = requestRevision_revision_AppSpecContent;
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
            Amazon.CodeDeploy.Model.RawString requestRevision_revision_String = null;
            
             // populate String
            bool requestRevision_revision_StringIsNull = true;
            requestRevision_revision_String = new Amazon.CodeDeploy.Model.RawString();
            System.String requestRevision_revision_String_string_Content = null;
            if (cmdletContext.Revision_String_Content != null)
            {
                requestRevision_revision_String_string_Content = cmdletContext.Revision_String_Content;
            }
            if (requestRevision_revision_String_string_Content != null)
            {
                requestRevision_revision_String.Content = requestRevision_revision_String_string_Content;
                requestRevision_revision_StringIsNull = false;
            }
            System.String requestRevision_revision_String_string_Sha256 = null;
            if (cmdletContext.Revision_String_Sha256 != null)
            {
                requestRevision_revision_String_string_Sha256 = cmdletContext.Revision_String_Sha256;
            }
            if (requestRevision_revision_String_string_Sha256 != null)
            {
                requestRevision_revision_String.Sha256 = requestRevision_revision_String_string_Sha256;
                requestRevision_revision_StringIsNull = false;
            }
             // determine if requestRevision_revision_String should be set to null
            if (requestRevision_revision_StringIsNull)
            {
                requestRevision_revision_String = null;
            }
            if (requestRevision_revision_String != null)
            {
                request.Revision.String = requestRevision_revision_String;
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
            
             // populate TargetInstances
            bool requestTargetInstancesIsNull = true;
            request.TargetInstances = new Amazon.CodeDeploy.Model.TargetInstances();
            List<System.String> requestTargetInstances_targetInstancesAutoScalingGroup = null;
            if (cmdletContext.TargetInstancesAutoScalingGroup != null)
            {
                requestTargetInstances_targetInstancesAutoScalingGroup = cmdletContext.TargetInstancesAutoScalingGroup;
            }
            if (requestTargetInstances_targetInstancesAutoScalingGroup != null)
            {
                request.TargetInstances.AutoScalingGroups = requestTargetInstances_targetInstancesAutoScalingGroup;
                requestTargetInstancesIsNull = false;
            }
            List<Amazon.CodeDeploy.Model.EC2TagFilter> requestTargetInstances_targetInstancesTagFilter = null;
            if (cmdletContext.TargetInstancesTagFilter != null)
            {
                requestTargetInstances_targetInstancesTagFilter = cmdletContext.TargetInstancesTagFilter;
            }
            if (requestTargetInstances_targetInstancesTagFilter != null)
            {
                request.TargetInstances.TagFilters = requestTargetInstances_targetInstancesTagFilter;
                requestTargetInstancesIsNull = false;
            }
            Amazon.CodeDeploy.Model.EC2TagSet requestTargetInstances_targetInstances_Ec2TagSet = null;
            
             // populate Ec2TagSet
            bool requestTargetInstances_targetInstances_Ec2TagSetIsNull = true;
            requestTargetInstances_targetInstances_Ec2TagSet = new Amazon.CodeDeploy.Model.EC2TagSet();
            List<List<Amazon.CodeDeploy.Model.EC2TagFilter>> requestTargetInstances_targetInstances_Ec2TagSet_ec2TagSetList = null;
            if (cmdletContext.Ec2TagSetList != null)
            {
                requestTargetInstances_targetInstances_Ec2TagSet_ec2TagSetList = cmdletContext.Ec2TagSetList;
            }
            if (requestTargetInstances_targetInstances_Ec2TagSet_ec2TagSetList != null)
            {
                requestTargetInstances_targetInstances_Ec2TagSet.Ec2TagSetList = requestTargetInstances_targetInstances_Ec2TagSet_ec2TagSetList;
                requestTargetInstances_targetInstances_Ec2TagSetIsNull = false;
            }
             // determine if requestTargetInstances_targetInstances_Ec2TagSet should be set to null
            if (requestTargetInstances_targetInstances_Ec2TagSetIsNull)
            {
                requestTargetInstances_targetInstances_Ec2TagSet = null;
            }
            if (requestTargetInstances_targetInstances_Ec2TagSet != null)
            {
                request.TargetInstances.Ec2TagSet = requestTargetInstances_targetInstances_Ec2TagSet;
                requestTargetInstancesIsNull = false;
            }
             // determine if request.TargetInstances should be set to null
            if (requestTargetInstancesIsNull)
            {
                request.TargetInstances = null;
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
        
        private Amazon.CodeDeploy.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.CreateDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "CreateDeployment");
            try
            {
                #if DESKTOP
                return client.CreateDeployment(request);
                #elif CORECLR
                return client.CreateDeploymentAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoRollbackConfiguration_Enabled { get; set; }
            public List<System.String> AutoRollbackConfiguration_Events { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public System.String DeploymentGroupName { get; set; }
            public System.String Description { get; set; }
            public Amazon.CodeDeploy.FileExistsBehavior FileExistsBehavior { get; set; }
            public System.Boolean? IgnoreApplicationStopFailures { get; set; }
            public System.String Revision_AppSpecContent_Content { get; set; }
            public System.String Revision_AppSpecContent_Sha256 { get; set; }
            public System.String Revision_GitHubLocation_CommitId { get; set; }
            public System.String Revision_GitHubLocation_Repository { get; set; }
            public Amazon.CodeDeploy.RevisionLocationType RevisionType { get; set; }
            public System.String Revision_S3Location_Bucket { get; set; }
            public Amazon.CodeDeploy.BundleType Revision_S3Location_BundleType { get; set; }
            public System.String Revision_S3Location_ETag { get; set; }
            public System.String Revision_S3Location_Key { get; set; }
            public System.String Revision_S3Location_Version { get; set; }
            public System.String Revision_String_Content { get; set; }
            public System.String Revision_String_Sha256 { get; set; }
            public List<System.String> TargetInstancesAutoScalingGroup { get; set; }
            public List<List<Amazon.CodeDeploy.Model.EC2TagFilter>> Ec2TagSetList { get; set; }
            public List<Amazon.CodeDeploy.Model.EC2TagFilter> TargetInstancesTagFilter { get; set; }
            public System.Boolean? UpdateOutdatedInstancesOnly { get; set; }
        }
        
    }
}
