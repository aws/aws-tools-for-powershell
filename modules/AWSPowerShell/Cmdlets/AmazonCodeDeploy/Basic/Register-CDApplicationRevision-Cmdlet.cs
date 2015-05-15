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
    /// Registers with AWS CodeDeploy a revision for the specified application.
    /// </summary>
    [Cmdlet("Register", "CDApplicationRevision", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the RegisterApplicationRevision operation against Amazon CodeDeploy.", Operation = new[] {"RegisterApplicationRevision"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type RegisterApplicationRevisionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterCDApplicationRevisionCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of an existing AWS CodeDeploy application associated with the applicable
        /// IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the application revision is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Bucket")]
        public String S3Location_Bucket { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The file type of the application revision. Must be one of the following:</para><ul><li>tar: A tar archive file.</li><li>tgz: A compressed tar archive file.</li><li>zip: A zip archive file.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_BundleType")]
        public BundleType S3Location_BundleType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The SHA1 commit ID of the GitHub commit that references the that represents the bundled
        /// artifacts for the application revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_GitHubLocation_CommitId")]
        public String GitHubLocation_CommitId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A comment about the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 object that represents the bundled artifacts for the application
        /// revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Key")]
        public String S3Location_Key { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The GitHub account and repository pair that stores a reference to the commit that
        /// represents the bundled artifacts for the application revision.</para><para>Specified as account/repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_GitHubLocation_Repository")]
        public String GitHubLocation_Repository { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The application revision's type:</para><ul><li>S3: An application revision stored in Amazon S3.</li><li>GitHub: An application
        /// revision stored in GitHub.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public RevisionLocationType Revision_RevisionType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A specific version of the Amazon S3 object that represents the bundled artifacts for
        /// the application revision.</para><para>If the version is not specified, the system will use the most recent version by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_Version")]
        public String S3Location_Version { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ETag of the Amazon S3 object that represents the bundled artifacts for the application
        /// revision.</para><para>If the ETag is not specified as an input parameter, ETag validation of the object
        /// will be skipped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_S3Location_ETag")]
        public String S3Location_ETag { get; set; }
        
        /// <summary>
        /// Returns the value passed to the ApplicationName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CDApplicationRevision (RegisterApplicationRevision)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            context.Description = this.Description;
            context.Revision_GitHubLocation_CommitId = this.GitHubLocation_CommitId;
            context.Revision_GitHubLocation_Repository = this.GitHubLocation_Repository;
            context.Revision_RevisionType = this.Revision_RevisionType;
            context.Revision_S3Location_Bucket = this.S3Location_Bucket;
            context.Revision_S3Location_BundleType = this.S3Location_BundleType;
            context.Revision_S3Location_ETag = this.S3Location_ETag;
            context.Revision_S3Location_Key = this.S3Location_Key;
            context.Revision_S3Location_Version = this.S3Location_Version;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RegisterApplicationRevisionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Revision
            bool requestRevisionIsNull = true;
            request.Revision = new RevisionLocation();
            RevisionLocationType requestRevision_revision_RevisionType = null;
            if (cmdletContext.Revision_RevisionType != null)
            {
                requestRevision_revision_RevisionType = cmdletContext.Revision_RevisionType;
            }
            if (requestRevision_revision_RevisionType != null)
            {
                request.Revision.RevisionType = requestRevision_revision_RevisionType;
                requestRevisionIsNull = false;
            }
            GitHubLocation requestRevision_revision_GitHubLocation = null;
            
             // populate GitHubLocation
            bool requestRevision_revision_GitHubLocationIsNull = true;
            requestRevision_revision_GitHubLocation = new GitHubLocation();
            String requestRevision_revision_GitHubLocation_gitHubLocation_CommitId = null;
            if (cmdletContext.Revision_GitHubLocation_CommitId != null)
            {
                requestRevision_revision_GitHubLocation_gitHubLocation_CommitId = cmdletContext.Revision_GitHubLocation_CommitId;
            }
            if (requestRevision_revision_GitHubLocation_gitHubLocation_CommitId != null)
            {
                requestRevision_revision_GitHubLocation.CommitId = requestRevision_revision_GitHubLocation_gitHubLocation_CommitId;
                requestRevision_revision_GitHubLocationIsNull = false;
            }
            String requestRevision_revision_GitHubLocation_gitHubLocation_Repository = null;
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
            S3Location requestRevision_revision_S3Location = null;
            
             // populate S3Location
            bool requestRevision_revision_S3LocationIsNull = true;
            requestRevision_revision_S3Location = new S3Location();
            String requestRevision_revision_S3Location_s3Location_Bucket = null;
            if (cmdletContext.Revision_S3Location_Bucket != null)
            {
                requestRevision_revision_S3Location_s3Location_Bucket = cmdletContext.Revision_S3Location_Bucket;
            }
            if (requestRevision_revision_S3Location_s3Location_Bucket != null)
            {
                requestRevision_revision_S3Location.Bucket = requestRevision_revision_S3Location_s3Location_Bucket;
                requestRevision_revision_S3LocationIsNull = false;
            }
            BundleType requestRevision_revision_S3Location_s3Location_BundleType = null;
            if (cmdletContext.Revision_S3Location_BundleType != null)
            {
                requestRevision_revision_S3Location_s3Location_BundleType = cmdletContext.Revision_S3Location_BundleType;
            }
            if (requestRevision_revision_S3Location_s3Location_BundleType != null)
            {
                requestRevision_revision_S3Location.BundleType = requestRevision_revision_S3Location_s3Location_BundleType;
                requestRevision_revision_S3LocationIsNull = false;
            }
            String requestRevision_revision_S3Location_s3Location_ETag = null;
            if (cmdletContext.Revision_S3Location_ETag != null)
            {
                requestRevision_revision_S3Location_s3Location_ETag = cmdletContext.Revision_S3Location_ETag;
            }
            if (requestRevision_revision_S3Location_s3Location_ETag != null)
            {
                requestRevision_revision_S3Location.ETag = requestRevision_revision_S3Location_s3Location_ETag;
                requestRevision_revision_S3LocationIsNull = false;
            }
            String requestRevision_revision_S3Location_s3Location_Key = null;
            if (cmdletContext.Revision_S3Location_Key != null)
            {
                requestRevision_revision_S3Location_s3Location_Key = cmdletContext.Revision_S3Location_Key;
            }
            if (requestRevision_revision_S3Location_s3Location_Key != null)
            {
                requestRevision_revision_S3Location.Key = requestRevision_revision_S3Location_s3Location_Key;
                requestRevision_revision_S3LocationIsNull = false;
            }
            String requestRevision_revision_S3Location_s3Location_Version = null;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RegisterApplicationRevision(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ApplicationName;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ApplicationName { get; set; }
            public String Description { get; set; }
            public String Revision_GitHubLocation_CommitId { get; set; }
            public String Revision_GitHubLocation_Repository { get; set; }
            public RevisionLocationType Revision_RevisionType { get; set; }
            public String Revision_S3Location_Bucket { get; set; }
            public BundleType Revision_S3Location_BundleType { get; set; }
            public String Revision_S3Location_ETag { get; set; }
            public String Revision_S3Location_Key { get; set; }
            public String Revision_S3Location_Version { get; set; }
        }
        
    }
}
