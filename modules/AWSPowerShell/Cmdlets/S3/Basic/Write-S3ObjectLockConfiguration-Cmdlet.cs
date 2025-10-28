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
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Places an Object Lock configuration on the specified bucket. The rule specified in
    /// the Object Lock configuration will be applied by default to every new object placed
    /// in the specified bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/object-lock.html">Locking
    /// Objects</a>. 
    /// </para><note><ul><li><para>
    /// The <c>DefaultRetention</c> settings require both a mode and a period.
    /// </para></li><li><para>
    /// The <c>DefaultRetention</c> period can be either <c>Days</c> or <c>Years</c> but you
    /// must select one. You cannot specify <c>Days</c> and <c>Years</c> at the same time.
    /// </para></li><li><para>
    /// You can enable Object Lock for new or existing buckets. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-lock-configure.html">Configuring
    /// Object Lock</a>.
    /// </para></li></ul></note><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "S3ObjectLockConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.RequestCharged")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutObjectLockConfiguration API operation.", Operation = new[] {"PutObjectLockConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.PutObjectLockConfigurationResponse))]
    [AWSCmdletOutput("Amazon.S3.RequestCharged or Amazon.S3.Model.PutObjectLockConfigurationResponse",
        "This cmdlet returns an Amazon.S3.RequestCharged object.",
        "The service call response (type Amazon.S3.Model.PutObjectLockConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteS3ObjectLockConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket whose Object Lock configuration you want to create or replace.</para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the object when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <c>x-amz-checksum</c>
        /// or <c>x-amz-trailer</c> header sent. Otherwise, Amazon S3 fails the request with the
        /// HTTP status code <c>400 Bad Request</c>. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <c>ChecksumAlgorithm</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>The MD5 hash for the request body.</para><para>For requests made using the Amazon Web Services Command Line Interface (CLI) or Amazon
        /// Web Services SDKs, this field is calculated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Day
        /// <summary>
        /// <para>
        /// <para>The number of days that you want to specify for the default retention period. Must
        /// be used with <c>Mode</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Days")]
        public System.Int32? DefaultRetention_Day { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Mode
        /// <summary>
        /// <para>
        /// <para>The default Object Lock retention mode you want to apply to new objects placed in
        /// the specified bucket. Must be used with either <c>Days</c> or <c>Years</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Mode")]
        [AWSConstantClassSource("Amazon.S3.ObjectLockRetentionMode")]
        public Amazon.S3.ObjectLockRetentionMode DefaultRetention_Mode { get; set; }
        #endregion
        
        #region Parameter ObjectLockConfiguration_ObjectLockEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether this bucket has an Object Lock configuration enabled. Enable <c>ObjectLockEnabled</c>
        /// when you apply <c>ObjectLockConfiguration</c> to a bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ObjectLockEnabled")]
        public Amazon.S3.ObjectLockEnabled ObjectLockConfiguration_ObjectLockEnabled { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>A token to allow Object Lock to be enabled for an existing bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Year
        /// <summary>
        /// <para>
        /// <para>The number of years that you want to specify for the default retention period. Must
        /// be used with <c>Mode</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Years")]
        public System.Int32? DefaultRetention_Year { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestCharged'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutObjectLockConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.PutObjectLockConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestCharged";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3ObjectLockConfiguration (PutObjectLockConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutObjectLockConfigurationResponse, WriteS3ObjectLockConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.ObjectLockConfiguration_ObjectLockEnabled = this.ObjectLockConfiguration_ObjectLockEnabled;
            context.DefaultRetention_Day = this.DefaultRetention_Day;
            context.DefaultRetention_Mode = this.DefaultRetention_Mode;
            context.DefaultRetention_Year = this.DefaultRetention_Year;
            context.RequestPayer = this.RequestPayer;
            context.Token = this.Token;
            
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
            var request = new Amazon.S3.Model.PutObjectLockConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            
             // populate ObjectLockConfiguration
            var requestObjectLockConfigurationIsNull = true;
            request.ObjectLockConfiguration = new Amazon.S3.Model.ObjectLockConfiguration();
            Amazon.S3.ObjectLockEnabled requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled = null;
            if (cmdletContext.ObjectLockConfiguration_ObjectLockEnabled != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled = cmdletContext.ObjectLockConfiguration_ObjectLockEnabled;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled != null)
            {
                request.ObjectLockConfiguration.ObjectLockEnabled = requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled;
                requestObjectLockConfigurationIsNull = false;
            }
            Amazon.S3.Model.ObjectLockRule requestObjectLockConfiguration_objectLockConfiguration_Rule = null;
            
             // populate Rule
            var requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull = true;
            requestObjectLockConfiguration_objectLockConfiguration_Rule = new Amazon.S3.Model.ObjectLockRule();
            Amazon.S3.Model.DefaultRetention requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = null;
            
             // populate DefaultRetention
            var requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = true;
            requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = new Amazon.S3.Model.DefaultRetention();
            System.Int32? requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day = null;
            if (cmdletContext.DefaultRetention_Day != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day = cmdletContext.DefaultRetention_Day.Value;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Days = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day.Value;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
            Amazon.S3.ObjectLockRetentionMode requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode = null;
            if (cmdletContext.DefaultRetention_Mode != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode = cmdletContext.DefaultRetention_Mode;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Mode = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
            System.Int32? requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year = null;
            if (cmdletContext.DefaultRetention_Year != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year = cmdletContext.DefaultRetention_Year.Value;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Years = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year.Value;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
             // determine if requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention should be set to null
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = null;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule.DefaultRetention = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention;
                requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull = false;
            }
             // determine if requestObjectLockConfiguration_objectLockConfiguration_Rule should be set to null
            if (requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule = null;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule != null)
            {
                request.ObjectLockConfiguration.Rule = requestObjectLockConfiguration_objectLockConfiguration_Rule;
                requestObjectLockConfigurationIsNull = false;
            }
             // determine if request.ObjectLockConfiguration should be set to null
            if (requestObjectLockConfigurationIsNull)
            {
                request.ObjectLockConfiguration = null;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
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
        
        private Amazon.S3.Model.PutObjectLockConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectLockConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutObjectLockConfiguration");
            try
            {
                return client.PutObjectLockConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public Amazon.S3.ObjectLockEnabled ObjectLockConfiguration_ObjectLockEnabled { get; set; }
            public System.Int32? DefaultRetention_Day { get; set; }
            public Amazon.S3.ObjectLockRetentionMode DefaultRetention_Mode { get; set; }
            public System.Int32? DefaultRetention_Year { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String Token { get; set; }
            public System.Func<Amazon.S3.Model.PutObjectLockConfigurationResponse, WriteS3ObjectLockConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestCharged;
        }
        
    }
}
