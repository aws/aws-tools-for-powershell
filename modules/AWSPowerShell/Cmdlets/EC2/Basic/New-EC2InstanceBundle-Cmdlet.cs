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
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EC2InstanceBundle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.BundleTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) BundleInstance API operation.", Operation = new[] {"BundleInstance"}, SelectReturnType = typeof(Amazon.EC2.Model.BundleInstanceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.BundleTask or Amazon.EC2.Model.BundleInstanceResponse",
        "This cmdlet returns an Amazon.EC2.Model.BundleTask object.",
        "The service call response (type Amazon.EC2.Model.BundleInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2InstanceBundleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_AWSAccessKeyId
        /// <summary>
        /// <para>
        /// <para>The access key ID of the owner of the bucket. Before you specify a value for your
        /// access key ID, review and follow the guidance in <a href="https://docs.aws.amazon.com/accounts/latest/reference/best-practices.html">Best
        /// Practices for Amazon Web Services accounts</a> in the <i>Account ManagementReference
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Storage_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance to bundle.</para><para>Default: None</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The beginning of the file name of the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("Storage_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter S3_UploadPolicy
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 upload policy that gives Amazon EC2 permission to upload items into Amazon
        /// S3 on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Storage_S3_UploadPolicy")]
        public System.String S3_UploadPolicy { get; set; }
        #endregion
        
        #region Parameter S3_UploadPolicySignature
        /// <summary>
        /// <para>
        /// <para>The signature of the JSON document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Storage_S3_UploadPolicySignature")]
        public System.String S3_UploadPolicySignature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BundleTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.BundleInstanceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.BundleInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BundleTask";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceBundle (BundleInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.BundleInstanceResponse, NewEC2InstanceBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3_AWSAccessKeyId = this.S3_AWSAccessKeyId;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Prefix = this.S3_Prefix;
            context.S3_UploadPolicy = this.S3_UploadPolicy;
            context.S3_UploadPolicySignature = this.S3_UploadPolicySignature;
            
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
            var request = new Amazon.EC2.Model.BundleInstanceRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate Storage
            var requestStorageIsNull = true;
            request.Storage = new Amazon.EC2.Model.Storage();
            Amazon.EC2.Model.S3Storage requestStorage_storage_S3 = null;
            
             // populate S3
            var requestStorage_storage_S3IsNull = true;
            requestStorage_storage_S3 = new Amazon.EC2.Model.S3Storage();
            System.String requestStorage_storage_S3_s3_AWSAccessKeyId = null;
            if (cmdletContext.S3_AWSAccessKeyId != null)
            {
                requestStorage_storage_S3_s3_AWSAccessKeyId = cmdletContext.S3_AWSAccessKeyId;
            }
            if (requestStorage_storage_S3_s3_AWSAccessKeyId != null)
            {
                requestStorage_storage_S3.AWSAccessKeyId = requestStorage_storage_S3_s3_AWSAccessKeyId;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestStorage_storage_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestStorage_storage_S3_s3_Bucket != null)
            {
                requestStorage_storage_S3.Bucket = requestStorage_storage_S3_s3_Bucket;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestStorage_storage_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestStorage_storage_S3_s3_Prefix != null)
            {
                requestStorage_storage_S3.Prefix = requestStorage_storage_S3_s3_Prefix;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_UploadPolicy = null;
            if (cmdletContext.S3_UploadPolicy != null)
            {
                requestStorage_storage_S3_s3_UploadPolicy = cmdletContext.S3_UploadPolicy;
            }
            if (requestStorage_storage_S3_s3_UploadPolicy != null)
            {
                requestStorage_storage_S3.UploadPolicy = requestStorage_storage_S3_s3_UploadPolicy;
                requestStorage_storage_S3IsNull = false;
            }
            System.String requestStorage_storage_S3_s3_UploadPolicySignature = null;
            if (cmdletContext.S3_UploadPolicySignature != null)
            {
                requestStorage_storage_S3_s3_UploadPolicySignature = cmdletContext.S3_UploadPolicySignature;
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
        
        private Amazon.EC2.Model.BundleInstanceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.BundleInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "BundleInstance");
            try
            {
                #if DESKTOP
                return client.BundleInstance(request);
                #elif CORECLR
                return client.BundleInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String S3_AWSAccessKeyId { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.String S3_UploadPolicy { get; set; }
            public System.String S3_UploadPolicySignature { get; set; }
            public System.Func<Amazon.EC2.Model.BundleInstanceResponse, NewEC2InstanceBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BundleTask;
        }
        
    }
}
