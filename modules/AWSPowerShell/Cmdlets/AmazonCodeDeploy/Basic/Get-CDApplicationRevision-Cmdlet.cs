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
    /// Gets information about an application revision.
    /// </summary>
    [Cmdlet("Get", "CDApplicationRevision")]
    [OutputType("Amazon.CodeDeploy.Model.GetApplicationRevisionResponse")]
    [AWSCmdlet("Calls the AWS CodeDeploy GetApplicationRevision API operation.", Operation = new[] {"GetApplicationRevision"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.GetApplicationRevisionResponse",
        "This cmdlet returns a Amazon.CodeDeploy.Model.GetApplicationRevisionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDApplicationRevisionCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application that corresponds to the revision.</para>
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
        /// <para>The type of application revision:</para><ul><li><para>S3: An application revision stored in Amazon S3.</para></li><li><para>GitHub: An application revision stored in GitHub (EC2/On-premises deployments only)</para></li><li><para>String: A YAML-formatted or JSON-formatted string (AWS Lambda deployments only)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.RevisionLocationType")]
        public Amazon.CodeDeploy.RevisionLocationType Revision_RevisionType { get; set; }
        #endregion
        
        #region Parameter String_Sha256
        /// <summary>
        /// <para>
        /// <para>The SHA256 hash value of the revision that is specified as a RawString.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Revision_String_Sha256")]
        public System.String String_Sha256 { get; set; }
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
            
            context.ApplicationName = this.ApplicationName;
            context.Revision_GitHubLocation_CommitId = this.GitHubLocation_CommitId;
            context.Revision_GitHubLocation_Repository = this.GitHubLocation_Repository;
            context.Revision_RevisionType = this.Revision_RevisionType;
            context.Revision_S3Location_Bucket = this.S3Location_Bucket;
            context.Revision_S3Location_BundleType = this.S3Location_BundleType;
            context.Revision_S3Location_ETag = this.S3Location_ETag;
            context.Revision_S3Location_Key = this.S3Location_Key;
            context.Revision_S3Location_Version = this.S3Location_Version;
            context.Revision_String_Content = this.String_Content;
            context.Revision_String_Sha256 = this.String_Sha256;
            
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
            var request = new Amazon.CodeDeploy.Model.GetApplicationRevisionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.CodeDeploy.Model.GetApplicationRevisionResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.GetApplicationRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "GetApplicationRevision");
            try
            {
                #if DESKTOP
                return client.GetApplicationRevision(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetApplicationRevisionAsync(request);
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
            public System.String ApplicationName { get; set; }
            public System.String Revision_GitHubLocation_CommitId { get; set; }
            public System.String Revision_GitHubLocation_Repository { get; set; }
            public Amazon.CodeDeploy.RevisionLocationType Revision_RevisionType { get; set; }
            public System.String Revision_S3Location_Bucket { get; set; }
            public Amazon.CodeDeploy.BundleType Revision_S3Location_BundleType { get; set; }
            public System.String Revision_S3Location_ETag { get; set; }
            public System.String Revision_S3Location_Key { get; set; }
            public System.String Revision_S3Location_Version { get; set; }
            public System.String Revision_String_Content { get; set; }
            public System.String Revision_String_Sha256 { get; set; }
        }
        
    }
}
