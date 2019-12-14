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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Set the logging parameters for a bucket and to specify permissions for who can view
    /// and modify the logging parameters. All logs are saved to buckets in the same AWS Region
    /// as the source bucket. To set the logging status of a bucket, you must be the bucket
    /// owner.
    /// 
    ///  
    /// <para>
    /// The bucket owner is automatically granted FULL_CONTROL to all logs. You use the <code>Grantee</code>
    /// request element to grant access to other people. The <code>Permissions</code> request
    /// element specifies the kind of access the grantee has to the logs.
    /// </para><para><b>Grantee Values</b></para><para>
    /// You can specify the person (grantee) to whom you're assigning access rights (using
    /// request elements) in the following ways:
    /// </para><ul><li><para>
    /// By the person's ID:
    /// </para><para><code>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="CanonicalUser"&gt;&lt;ID&gt;&lt;&gt;ID&lt;&gt;&lt;/ID&gt;&lt;DisplayName&gt;&lt;&gt;GranteesEmail&lt;&gt;&lt;/DisplayName&gt;
    /// &lt;/Grantee&gt;</code></para><para>
    /// DisplayName is optional and ignored in the request.
    /// </para></li><li><para>
    /// By Email address:
    /// </para><para><code> &lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="AmazonCustomerByEmail"&gt;&lt;EmailAddress&gt;&lt;&gt;Grantees@email.com&lt;&gt;&lt;/EmailAddress&gt;&lt;/Grantee&gt;</code></para><para>
    /// The grantee is resolved to the CanonicalUser and, in a response to a GET Object acl
    /// request, appears as the CanonicalUser.
    /// </para></li><li><para>
    /// By URI:
    /// </para><para><code>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="Group"&gt;&lt;URI&gt;&lt;&gt;http://acs.amazonaws.com/groups/global/AuthenticatedUsers&lt;&gt;&lt;/URI&gt;&lt;/Grantee&gt;</code></para></li></ul><para>
    /// To enable logging, you use LoggingEnabled and its children request elements. To disable
    /// logging, you use an empty BucketLoggingStatus request element:
    /// </para><para><code>&lt;BucketLoggingStatus xmlns="http://doc.s3.amazonaws.com/2006-03-01" /&gt;</code></para><para>
    /// For more information about server access logging, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerLogs.html">Server
    /// Access Logging</a>. 
    /// </para><para>
    /// For more information about creating a bucket, see <a>CreateBucket</a>. For more information
    /// about returning the logging status of a bucket, see <a>GetBucketLogging</a>.
    /// </para><para>
    /// The following operations are related to <code>PutBucketLogging</code>:
    /// </para><ul><li><para><a>PutObject</a></para></li><li><para><a>DeleteBucket</a></para></li><li><para><a>CreateBucket</a></para></li><li><para><a>GetBucketLogging</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketLogging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketLogging API operation.", Operation = new[] {"PutBucketLogging"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketLoggingResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketLoggingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketLoggingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketLoggingCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_Grants")]
        public Amazon.S3.Model.S3Grant[] LoggingConfig_Grant { get; set; }
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
        /// This element lets you specify a prefix for the keys that the log files will be stored under.
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketLogging (PutBucketLogging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketLoggingResponse, WriteS3BucketLoggingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.LoggingConfig_TargetBucketName = this.LoggingConfig_TargetBucketName;
            if (this.LoggingConfig_Grant != null)
            {
                context.LoggingConfig_Grant = new List<Amazon.S3.Model.S3Grant>(this.LoggingConfig_Grant);
            }
            context.LoggingConfig_TargetPrefix = this.LoggingConfig_TargetPrefix;
            
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
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
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
                #if DESKTOP
                return client.PutBucketLogging(request);
                #elif CORECLR
                return client.PutBucketLoggingAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public System.String LoggingConfig_TargetBucketName { get; set; }
            public List<Amazon.S3.Model.S3Grant> LoggingConfig_Grant { get; set; }
            public System.String LoggingConfig_TargetPrefix { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketLoggingResponse, WriteS3BucketLoggingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
