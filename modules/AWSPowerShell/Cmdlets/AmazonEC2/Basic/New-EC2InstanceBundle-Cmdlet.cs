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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Bundles an Amazon instance store-backed Windows instance.
    /// 
    ///  
    /// <para>
    /// During bundling, only the root device volume (C:\) is bundled. Data on other instance
    /// store volumes is not preserved.
    /// </para><note><para>
    /// This action is not applicable for Linux/Unix instances or Windows instances that are
    /// backed by Amazon EBS.
    /// </para></note><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/Creating_InstanceStoreBacked_WinAMI.html">Creating
    /// an Instance Store-Backed Windows AMI</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2InstanceBundle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.BundleTask")]
    [AWSCmdlet("Invokes the BundleInstance operation against Amazon Elastic Compute Cloud.", Operation = new[] {"BundleInstance"})]
    [AWSCmdletOutput("Amazon.EC2.Model.BundleTask",
        "This cmdlet returns a BundleTask object.",
        "The service call response (type Amazon.EC2.Model.BundleInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2InstanceBundleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter S3_AWSAccessKeyId
        /// <summary>
        /// <para>
        /// <para>The access key ID of the owner of the bucket. Before you specify a value for your
        /// access key ID, review and follow the guidance in <a href="http://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html">Best
        /// Practices for Managing AWS Access Keys</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Storage_S3_AWSAccessKeyId")]
        public System.String S3_AWSAccessKeyId { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The bucket in which to store the AMI. You can specify a bucket that you already own
        /// or a new bucket that Amazon EC2 creates on your behalf. If you specify a bucket that
        /// belongs to someone else, Amazon EC2 returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Storage_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance to bundle.</para><para>Type: String</para><para>Default: None</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The beginning of the file name of the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Storage_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter S3_UploadPolicy
        /// <summary>
        /// <para>
        /// <para>A base64-encoded Amazon S3 upload policy that gives Amazon EC2 permission to upload
        /// items into Amazon S3 on your behalf. For command line tools, base64 encoding is performed
        /// for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Storage_S3_UploadPolicy")]
        public System.String S3_UploadPolicy { get; set; }
        #endregion
        
        #region Parameter S3_UploadPolicySignature
        /// <summary>
        /// <para>
        /// <para>The signature of the Base64 encoded JSON document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Storage_S3_UploadPolicySignature")]
        public System.String S3_UploadPolicySignature { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceBundle (BundleInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.InstanceId = this.InstanceId;
            context.Storage_S3_AWSAccessKeyId = this.S3_AWSAccessKeyId;
            context.Storage_S3_Bucket = this.S3_Bucket;
            context.Storage_S3_Prefix = this.S3_Prefix;
            context.Storage_S3_UploadPolicy = this.S3_UploadPolicy;
            context.Storage_S3_UploadPolicySignature = this.S3_UploadPolicySignature;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.BundleInstanceRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate Storage
            bool requestStorageIsNull = true;
            request.Storage = new Amazon.EC2.Model.Storage();
            Amazon.EC2.Model.S3Storage requestStorage_storage_S3 = null;
            
             // populate S3
            bool requestStorage_storage_S3IsNull = true;
            requestStorage_storage_S3 = new Amazon.EC2.Model.S3Storage();
            System.String requestStorage_storage_S3_s3_AWSAccessKeyId = null;
            if (cmdletContext.Storage_S3_AWSAccessKeyId != null)
            {
                requestStorage_storage_S3_s3_AWSAccessKeyId = cmdletContext.Storage_S3_AWSAccessKeyId;
            }
            if (requestStorage_storage_S3_s3_AWSAccessKeyId != null)
            {
                requestStorage_storage_S3.AWSAccessKeyId = requestStorage_storage_S3_s3_AWSAccessKeyId;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_Bucket = null;
            if (cmdletContext.Storage_S3_Bucket != null)
            {
                requestStorage_storage_S3_s3_Bucket = cmdletContext.Storage_S3_Bucket;
            }
            if (requestStorage_storage_S3_s3_Bucket != null)
            {
                requestStorage_storage_S3.Bucket = requestStorage_storage_S3_s3_Bucket;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_Prefix = null;
            if (cmdletContext.Storage_S3_Prefix != null)
            {
                requestStorage_storage_S3_s3_Prefix = cmdletContext.Storage_S3_Prefix;
            }
            if (requestStorage_storage_S3_s3_Prefix != null)
            {
                requestStorage_storage_S3.Prefix = requestStorage_storage_S3_s3_Prefix;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_UploadPolicy = null;
            if (cmdletContext.Storage_S3_UploadPolicy != null)
            {
                requestStorage_storage_S3_s3_UploadPolicy = cmdletContext.Storage_S3_UploadPolicy;
            }
            if (requestStorage_storage_S3_s3_UploadPolicy != null)
            {
                requestStorage_storage_S3.UploadPolicy = requestStorage_storage_S3_s3_UploadPolicy;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_UploadPolicySignature = null;
            if (cmdletContext.Storage_S3_UploadPolicySignature != null)
            {
                requestStorage_storage_S3_s3_UploadPolicySignature = cmdletContext.Storage_S3_UploadPolicySignature;
            }
            if (requestStorage_storage_S3_s3_UploadPolicySignature != null)
            {
                requestStorage_storage_S3.UploadPolicySignature = requestStorage_storage_S3_s3_UploadPolicySignature;
                requestStorage_storage_S3IsNull = false;
            }
             // determine if requestStorage_storage_S3 should be set to null
            if (requestStorage_storage_S3IsNull)
            {
                requestStorage_storage_S3 = null;
            }
            if (requestStorage_storage_S3 != null)
            {
                request.Storage.S3 = requestStorage_storage_S3;
                requestStorageIsNull = false;
            }
             // determine if request.Storage should be set to null
            if (requestStorageIsNull)
            {
                request.Storage = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.BundleInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BundleTask;
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
            public System.String InstanceId { get; set; }
            public System.String Storage_S3_AWSAccessKeyId { get; set; }
            public System.String Storage_S3_Bucket { get; set; }
            public System.String Storage_S3_Prefix { get; set; }
            public System.String Storage_S3_UploadPolicy { get; set; }
            public System.String Storage_S3_UploadPolicySignature { get; set; }
        }
        
    }
}
