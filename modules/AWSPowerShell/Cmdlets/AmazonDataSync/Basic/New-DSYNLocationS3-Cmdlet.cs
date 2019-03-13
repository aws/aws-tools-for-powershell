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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates an endpoint for an Amazon S3 bucket.
    /// 
    ///  
    /// <para>
    /// For AWS DataSync to access a destination S3 bucket, it needs an AWS Identity and Access
    /// Management (IAM) role that has the required permissions. You can set up the required
    /// permissions by creating an IAM policy that grants the required permissions and attaching
    /// the policy to the role. An example of such a policy is shown in the examples section.
    /// For more information, see <a href="https://docs.aws.amazon.com/sync-service/latest/userguide/configuring-s3-locations.html">Configuring
    /// Amazon S3 Location Settings</a> in the <i>AWS DataSync User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationS3 API operation.", Operation = new[] {"CreateLocationS3"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationS3Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationS3Cmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter S3Config_BucketAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to access. This bucket is used as a parameter in the <a>CreateLocationS3</a>
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Config_BucketAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter S3BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3BucketArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the Amazon S3 bucket. This subdirectory in Amazon S3 is used to
        /// read data from the S3 source location or write data to the S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the location. The
        /// value can be an empty string. We recommend using tags to name your resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationS3 (CreateLocationS3)"))
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
            
            context.S3BucketArn = this.S3BucketArn;
            context.S3Config_BucketAccessRoleArn = this.S3Config_BucketAccessRoleArn;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.CreateLocationS3Request();
            
            if (cmdletContext.S3BucketArn != null)
            {
                request.S3BucketArn = cmdletContext.S3BucketArn;
            }
            
             // populate S3Config
            bool requestS3ConfigIsNull = true;
            request.S3Config = new Amazon.DataSync.Model.S3Config();
            System.String requestS3Config_s3Config_BucketAccessRoleArn = null;
            if (cmdletContext.S3Config_BucketAccessRoleArn != null)
            {
                requestS3Config_s3Config_BucketAccessRoleArn = cmdletContext.S3Config_BucketAccessRoleArn;
            }
            if (requestS3Config_s3Config_BucketAccessRoleArn != null)
            {
                request.S3Config.BucketAccessRoleArn = requestS3Config_s3Config_BucketAccessRoleArn;
                requestS3ConfigIsNull = false;
            }
             // determine if request.S3Config should be set to null
            if (requestS3ConfigIsNull)
            {
                request.S3Config = null;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LocationArn;
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
        
        private Amazon.DataSync.Model.CreateLocationS3Response CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationS3Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationS3");
            try
            {
                #if DESKTOP
                return client.CreateLocationS3(request);
                #elif CORECLR
                return client.CreateLocationS3Async(request).GetAwaiter().GetResult();
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
            public System.String S3BucketArn { get; set; }
            public System.String S3Config_BucketAccessRoleArn { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tags { get; set; }
        }
        
    }
}
