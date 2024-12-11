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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a transfer <i>location</i> for an Amazon S3 bucket. DataSync can use this
    /// location as a source or destination for transferring data.
    /// 
    ///  <important><para>
    /// Before you begin, make sure that you read the following topics:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-s3-location.html#using-storage-classes">Storage
    /// class considerations with Amazon S3 locations</a></para></li><li><para><a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-s3-location.html#create-s3-location-s3-requests">Evaluating
    /// S3 request costs when using DataSync</a></para></li></ul></important><para>
    ///  For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-s3-location.html">Configuring
    /// transfers with Amazon S3</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationS3 API operation.", Operation = new[] {"CreateLocationS3"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationS3Response))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationS3Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationS3Response) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSYNLocationS3Cmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>(Amazon S3 on Outposts only) Specifies the Amazon Resource Name (ARN) of the DataSync
        /// agent on your Outpost.</para><para>For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/deploy-agents.html#outposts-agent">Deploy
        /// your DataSync agent on Outposts</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the IAM role that DataSync uses to access your S3 bucket.</para>
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
        public System.String S3Config_BucketAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter S3BucketArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the S3 bucket that you want to use as a location. (When creating
        /// your DataSync task later, you specify whether this location is a transfer source or
        /// destination.) </para><para>If your S3 bucket is located on an Outposts resource, you must specify an Amazon S3
        /// access point. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points.html">Managing
        /// data access with Amazon S3 access points</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        public System.String S3BucketArn { get; set; }
        #endregion
        
        #region Parameter S3StorageClass
        /// <summary>
        /// <para>
        /// <para>Specifies the storage class that you want your objects to use when Amazon S3 is a
        /// transfer destination.</para><para>For buckets in Amazon Web Services Regions, the storage class defaults to <c>STANDARD</c>.
        /// For buckets on Outposts, the storage class defaults to <c>OUTPOSTS</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-s3-location.html#using-storage-classes">Storage
        /// class considerations with Amazon S3 transfers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.S3StorageClass")]
        public Amazon.DataSync.S3StorageClass S3StorageClass { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a prefix in the S3 bucket that DataSync reads from or writes to (depending
        /// on whether the bucket is a source or destination location).</para><note><para>DataSync can't transfer objects with a prefix that begins with a slash (<c>/</c>)
        /// or includes <c>//</c>, <c>/./</c>, or <c>/../</c> patterns. For example:</para><ul><li><para><c>/photos</c></para></li><li><para><c>photos//2006/January</c></para></li><li><para><c>photos/./2006/February</c></para></li><li><para><c>photos/../2006/March</c></para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies labels that help you categorize, filter, and search for your Amazon Web
        /// Services resources. We recommend creating at least a name tag for your transfer location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationS3Response).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationS3Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationS3 (CreateLocationS3)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationS3Response, NewDSYNLocationS3Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.S3BucketArn = this.S3BucketArn;
            #if MODULAR
            if (this.S3BucketArn == null && ParameterWasBound(nameof(this.S3BucketArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Config_BucketAccessRoleArn = this.S3Config_BucketAccessRoleArn;
            #if MODULAR
            if (this.S3Config_BucketAccessRoleArn == null && ParameterWasBound(nameof(this.S3Config_BucketAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Config_BucketAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3StorageClass = this.S3StorageClass;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.S3BucketArn != null)
            {
                request.S3BucketArn = cmdletContext.S3BucketArn;
            }
            
             // populate S3Config
            var requestS3ConfigIsNull = true;
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
            if (cmdletContext.S3StorageClass != null)
            {
                request.S3StorageClass = cmdletContext.S3StorageClass;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            public List<System.String> AgentArn { get; set; }
            public System.String S3BucketArn { get; set; }
            public System.String S3Config_BucketAccessRoleArn { get; set; }
            public Amazon.DataSync.S3StorageClass S3StorageClass { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationS3Response, NewDSYNLocationS3Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
