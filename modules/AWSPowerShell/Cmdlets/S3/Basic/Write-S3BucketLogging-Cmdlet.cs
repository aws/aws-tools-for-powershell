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
    /// <important><para>
    /// End of support notice: As of October 1, 2025, Amazon S3 has discontinued support for
    /// Email Grantee Access Control Lists (ACLs). If you attempt to use an Email Grantee
    /// ACL in a request after October 1, 2025, the request will receive an <c>HTTP 405</c>
    /// (Method Not Allowed) error.
    /// </para><para>
    /// This change affects the following Amazon Web Services Regions: US East (N. Virginia),
    /// US West (N. California), US West (Oregon), Asia Pacific (Singapore), Asia Pacific
    /// (Sydney), Asia Pacific (Tokyo), Europe (Ireland), and South America (São Paulo).
    /// </para></important><note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Set the logging parameters for a bucket and to specify permissions for who can view
    /// and modify the logging parameters. All logs are saved to buckets in the same Amazon
    /// Web Services Region as the source bucket. To set the logging status of a bucket, you
    /// must be the bucket owner.
    /// </para><para>
    /// The bucket owner is automatically granted FULL_CONTROL to all logs. You use the <c>Grantee</c>
    /// request element to grant access to other people. The <c>Permissions</c> request element
    /// specifies the kind of access the grantee has to the logs.
    /// </para><important><para>
    /// If the target bucket for log delivery uses the bucket owner enforced setting for S3
    /// Object Ownership, you can't use the <c>Grantee</c> request element to grant access
    /// to others. Permissions can only be granted using policies. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/enable-server-access-logging.html#grant-log-delivery-permissions-general">Permissions
    /// for server access log delivery</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></important><dl><dt>Grantee Values</dt><dd><para>
    /// You can specify the person (grantee) to whom you're assigning access rights (by using
    /// request elements) in the following ways. For examples of how to specify these grantee
    /// values in JSON format, see the Amazon Web Services CLI example in <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/enable-server-access-logging.html">
    /// Enabling Amazon S3 server access logging</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><ul><li><para>
    /// By the person's ID:
    /// </para><para><c>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="CanonicalUser"&gt;&lt;ID&gt;&lt;&gt;ID&lt;&gt;&lt;/ID&gt;&lt;DisplayName&gt;&lt;&gt;GranteesEmail&lt;&gt;&lt;/DisplayName&gt;
    /// &lt;/Grantee&gt;</c></para><para><c>DisplayName</c> is optional and ignored in the request.
    /// </para></li><li><para>
    /// By Email address:
    /// </para><para><c> &lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="AmazonCustomerByEmail"&gt;&lt;EmailAddress&gt;&lt;&gt;Grantees@email.com&lt;&gt;&lt;/EmailAddress&gt;&lt;/Grantee&gt;</c></para><para>
    /// The grantee is resolved to the <c>CanonicalUser</c> and, in a response to a <c>GETObjectAcl</c>
    /// request, appears as the CanonicalUser.
    /// </para></li><li><para>
    /// By URI:
    /// </para><para><c>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="Group"&gt;&lt;URI&gt;&lt;&gt;http://acs.amazonaws.com/groups/global/AuthenticatedUsers&lt;&gt;&lt;/URI&gt;&lt;/Grantee&gt;</c></para></li></ul></dd></dl><para>
    /// To enable logging, you use <c>LoggingEnabled</c> and its children request elements.
    /// To disable logging, you use an empty <c>BucketLoggingStatus</c> request element:
    /// </para><para><c>&lt;BucketLoggingStatus xmlns="http://doc.s3.amazonaws.com/2006-03-01" /&gt;</c></para><para>
    /// For more information about server access logging, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/ServerLogs.html">Server
    /// Access Logging</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para><para>
    /// For more information about creating a bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a>.
    /// For more information about returning the logging status of a bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketLogging.html">GetBucketLogging</a>.
    /// </para><para>
    /// The following operations are related to <c>PutBucketLogging</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucket.html">DeleteBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketLogging.html">GetBucketLogging</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "S3BucketLogging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketLogging API operation.", Operation = new[] {"PutBucketLogging"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketLoggingResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketLoggingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketLoggingResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3BucketLoggingCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the object when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <code>x-amz-checksum</code>
        /// or <code>x-amz-trailer</code> header sent. Otherwise, Amazon S3 fails the request
        /// with the HTTP status code <code>400 Bad Request</code>. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <code>ChecksumAlgorithm</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// 
        /// <para>Buckets that use the bucket owner enforced setting for Object Ownership don't support
        /// target grants. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/enable-server-access-logging.html#grant-log-delivery-permissions-general">Permissions
        /// for server access log delivery</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_Grants")]
        public Amazon.S3.Model.S3Grant[] LoggingConfig_Grant { get; set; }
        #endregion
        
        #region Parameter PartitionedPrefix_PartitionDateSource
        /// <summary>
        /// <para>
        /// <para>Specifies the partition date source for the partitioned prefix. 
        /// <code>PartitionDateSource</code> can be <code>EventTime</code> or 
        /// <code>DeliveryTime</code>.</para><para>For <code>DeliveryTime</code>, 
        /// the time in the log file names corresponds to the delivery time for the 
        /// log files. </para><para> For <code>EventTime</code>, The logs delivered 
        /// are for a specific day only. The year, month, and day correspond to the 
        /// day on which the event occurred, and the hour, minutes and seconds are 
        /// set to 00 in the key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource")]
        [AWSConstantClassSource("Amazon.S3.PartitionDateSource")]
        public Amazon.S3.PartitionDateSource PartitionedPrefix_PartitionDateSource { get; set; }
        #endregion
        
        #region Parameter TargetObjectKeyFormat_SimplePrefix
        /// <summary>
        /// <para>
        /// <para>To use the simple format for S3 keys for log objects. To specify SimplePrefix format,
        /// set SimplePrefix to {}.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_TargetObjectKeyFormat_SimplePrefix")]
        public Amazon.S3.Model.SimplePrefix TargetObjectKeyFormat_SimplePrefix { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_TargetBucketName
        /// <summary>
        /// <para>
        /// Specifies the bucket where you want Amazon S3 to store server access logs. You can have your logs delivered to any bucket that you own,
        /// including the same bucket that is being logged. You can also configure multiple buckets to deliver their logs to the same target bucket. In
        /// this case you should choose a different TargetPrefix for each source bucket so that the delivered log files can be distinguished by key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_TargetBucketName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_TargetPrefix
        /// <summary>
        /// <para>
        /// <para>A prefix for all log object keys. If you store log files from multiple Amazon S3 buckets
        /// in a single bucket, you can use a prefix to distinguish which log files came from
        /// which bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_TargetPrefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketLoggingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketLogging (PutBucketLogging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketLoggingResponse, WriteS3BucketLoggingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.LoggingConfig_TargetBucketName = this.LoggingConfig_TargetBucketName;
            if (this.LoggingConfig_Grant != null)
            {
                context.LoggingConfig_Grant = new List<Amazon.S3.Model.S3Grant>(this.LoggingConfig_Grant);
            }
            context.PartitionedPrefix_PartitionDateSource = this.PartitionedPrefix_PartitionDateSource;
            context.TargetObjectKeyFormat_SimplePrefix = this.TargetObjectKeyFormat_SimplePrefix;
            context.LoggingConfig_TargetPrefix = this.LoggingConfig_TargetPrefix;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.PutBucketLoggingRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            
             // populate LoggingConfig
            var requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.S3.Model.S3BucketLoggingConfig();
            System.String requestLoggingConfig_loggingConfig_TargetBucketName = null;
            if (cmdletContext.LoggingConfig_TargetBucketName != null)
            {
                requestLoggingConfig_loggingConfig_TargetBucketName = cmdletContext.LoggingConfig_TargetBucketName;
            }
            if (requestLoggingConfig_loggingConfig_TargetBucketName != null)
            {
                request.LoggingConfig.TargetBucketName = requestLoggingConfig_loggingConfig_TargetBucketName;
                requestLoggingConfigIsNull = false;
            }
            List<Amazon.S3.Model.S3Grant> requestLoggingConfig_loggingConfig_Grant = null;
            if (cmdletContext.LoggingConfig_Grant != null)
            {
                requestLoggingConfig_loggingConfig_Grant = cmdletContext.LoggingConfig_Grant;
            }
            if (requestLoggingConfig_loggingConfig_Grant != null)
            {
                request.LoggingConfig.Grants = requestLoggingConfig_loggingConfig_Grant;
                requestLoggingConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_TargetPrefix = null;
            if (cmdletContext.LoggingConfig_TargetPrefix != null)
            {
                requestLoggingConfig_loggingConfig_TargetPrefix = cmdletContext.LoggingConfig_TargetPrefix;
            }
            if (requestLoggingConfig_loggingConfig_TargetPrefix != null)
            {
                request.LoggingConfig.TargetPrefix = requestLoggingConfig_loggingConfig_TargetPrefix;
                requestLoggingConfigIsNull = false;
            }
            Amazon.S3.Model.TargetObjectKeyFormat requestLoggingConfig_loggingConfig_TargetObjectKeyFormat = null;
            
             // populate TargetObjectKeyFormat
            var requestLoggingConfig_loggingConfig_TargetObjectKeyFormatIsNull = true;
            requestLoggingConfig_loggingConfig_TargetObjectKeyFormat = new Amazon.S3.Model.TargetObjectKeyFormat();
            Amazon.S3.Model.SimplePrefix requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_targetObjectKeyFormat_SimplePrefix = null;
            if (cmdletContext.TargetObjectKeyFormat_SimplePrefix != null)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_targetObjectKeyFormat_SimplePrefix = cmdletContext.TargetObjectKeyFormat_SimplePrefix;
            }
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_targetObjectKeyFormat_SimplePrefix != null)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat.SimplePrefix = requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_targetObjectKeyFormat_SimplePrefix;
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormatIsNull = false;
            }
            Amazon.S3.Model.PartitionedPrefix requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix = null;
            
             // populate PartitionedPrefix
            var requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefixIsNull = true;
            requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix = new Amazon.S3.Model.PartitionedPrefix();
            Amazon.S3.PartitionDateSource requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix_partitionedPrefix_PartitionDateSource = null;
            if (cmdletContext.PartitionedPrefix_PartitionDateSource != null)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix_partitionedPrefix_PartitionDateSource = cmdletContext.PartitionedPrefix_PartitionDateSource;
            }
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix_partitionedPrefix_PartitionDateSource != null)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix.PartitionDateSource = requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix_partitionedPrefix_PartitionDateSource;
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefixIsNull = false;
            }
             // determine if requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix should be set to null
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefixIsNull)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix = null;
            }
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix != null)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat.PartitionedPrefix = requestLoggingConfig_loggingConfig_TargetObjectKeyFormat_loggingConfig_TargetObjectKeyFormat_PartitionedPrefix;
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormatIsNull = false;
            }
             // determine if requestLoggingConfig_loggingConfig_TargetObjectKeyFormat should be set to null
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormatIsNull)
            {
                requestLoggingConfig_loggingConfig_TargetObjectKeyFormat = null;
            }
            if (requestLoggingConfig_loggingConfig_TargetObjectKeyFormat != null)
            {
                request.LoggingConfig.TargetObjectKeyFormat = requestLoggingConfig_loggingConfig_TargetObjectKeyFormat;
                requestLoggingConfigIsNull = false;
            }
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.PutBucketLoggingResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketLoggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketLogging");
            try
            {
                return client.PutBucketLoggingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LoggingConfig_TargetBucketName { get; set; }
            public List<Amazon.S3.Model.S3Grant> LoggingConfig_Grant { get; set; }
            public Amazon.S3.PartitionDateSource PartitionedPrefix_PartitionDateSource { get; set; }
            public Amazon.S3.Model.SimplePrefix TargetObjectKeyFormat_SimplePrefix { get; set; }
            public System.String LoggingConfig_TargetPrefix { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketLoggingResponse, WriteS3BucketLoggingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
