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
    /// Modifies the logging configuration for the specified Amazon Web Services Verified
    /// Access instance.
    /// </summary>
    [Cmdlet("Edit", "EC2VerifiedAccessInstanceLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessInstanceLoggingConfiguration")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVerifiedAccessInstanceLoggingConfiguration API operation.", Operation = new[] {"ModifyVerifiedAccessInstanceLoggingConfiguration"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessInstanceLoggingConfiguration or Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessInstanceLoggingConfiguration object.",
        "The service call response (type Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VerifiedAccessInstanceLoggingConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_S3_BucketOwner")]
        public System.String S3_BucketOwner { get; set; }
        #endregion
        
        #region Parameter KinesisDataFirehose_DeliveryStream
        /// <summary>
        /// <para>
        /// <para>The ID of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_KinesisDataFirehose_DeliveryStream")]
        public System.String KinesisDataFirehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_CloudWatchLogs_Enabled")]
        public System.Boolean? CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter KinesisDataFirehose_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_KinesisDataFirehose_Enabled")]
        public System.Boolean? KinesisDataFirehose_Enabled { get; set; }
        #endregion
        
        #region Parameter S3_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_S3_Enabled")]
        public System.Boolean? S3_Enabled { get; set; }
        #endregion
        
        #region Parameter AccessLogs_IncludeTrustContext
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include trust data sent by trust providers in the logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccessLogs_IncludeTrustContext { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// <para>The ID of the CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter AccessLogs_LogVersion
        /// <summary>
        /// <para>
        /// <para>The logging version.</para><para>Valid values: <c>ocsf-0.1</c> | <c>ocsf-1.0.0-rc.2</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLogs_LogVersion { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The bucket prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessLogs_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessInstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access instance.</para>
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
        public System.String VerifiedAccessInstanceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedAccessInstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedAccessInstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedAccessInstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedAccessInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VerifiedAccessInstanceLoggingConfiguration (ModifyVerifiedAccessInstanceLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse, EditEC2VerifiedAccessInstanceLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedAccessInstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogs_Enabled = this.CloudWatchLogs_Enabled;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.AccessLogs_IncludeTrustContext = this.AccessLogs_IncludeTrustContext;
            context.KinesisDataFirehose_DeliveryStream = this.KinesisDataFirehose_DeliveryStream;
            context.KinesisDataFirehose_Enabled = this.KinesisDataFirehose_Enabled;
            context.AccessLogs_LogVersion = this.AccessLogs_LogVersion;
            context.S3_BucketName = this.S3_BucketName;
            context.S3_BucketOwner = this.S3_BucketOwner;
            context.S3_Enabled = this.S3_Enabled;
            context.S3_Prefix = this.S3_Prefix;
            context.ClientToken = this.ClientToken;
            context.VerifiedAccessInstanceId = this.VerifiedAccessInstanceId;
            #if MODULAR
            if (this.VerifiedAccessInstanceId == null && ParameterWasBound(nameof(this.VerifiedAccessInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationRequest();
            
            
             // populate AccessLogs
            request.AccessLogs = new Amazon.EC2.Model.VerifiedAccessLogOptions();
            System.Boolean? requestAccessLogs_accessLogs_IncludeTrustContext = null;
            if (cmdletContext.AccessLogs_IncludeTrustContext != null)
            {
                requestAccessLogs_accessLogs_IncludeTrustContext = cmdletContext.AccessLogs_IncludeTrustContext.Value;
            }
            if (requestAccessLogs_accessLogs_IncludeTrustContext != null)
            {
                request.AccessLogs.IncludeTrustContext = requestAccessLogs_accessLogs_IncludeTrustContext.Value;
            }
            System.String requestAccessLogs_accessLogs_LogVersion = null;
            if (cmdletContext.AccessLogs_LogVersion != null)
            {
                requestAccessLogs_accessLogs_LogVersion = cmdletContext.AccessLogs_LogVersion;
            }
            if (requestAccessLogs_accessLogs_LogVersion != null)
            {
                request.AccessLogs.LogVersion = requestAccessLogs_accessLogs_LogVersion;
            }
            Amazon.EC2.Model.VerifiedAccessLogCloudWatchLogsDestinationOptions requestAccessLogs_accessLogs_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestAccessLogs_accessLogs_CloudWatchLogsIsNull = true;
            requestAccessLogs_accessLogs_CloudWatchLogs = new Amazon.EC2.Model.VerifiedAccessLogCloudWatchLogsDestinationOptions();
            System.Boolean? requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_Enabled = null;
            if (cmdletContext.CloudWatchLogs_Enabled != null)
            {
                requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_Enabled = cmdletContext.CloudWatchLogs_Enabled.Value;
            }
            if (requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_Enabled != null)
            {
                requestAccessLogs_accessLogs_CloudWatchLogs.Enabled = requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_Enabled.Value;
                requestAccessLogs_accessLogs_CloudWatchLogsIsNull = false;
            }
            System.String requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestAccessLogs_accessLogs_CloudWatchLogs.LogGroup = requestAccessLogs_accessLogs_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestAccessLogs_accessLogs_CloudWatchLogsIsNull = false;
            }
             // determine if requestAccessLogs_accessLogs_CloudWatchLogs should be set to null
            if (requestAccessLogs_accessLogs_CloudWatchLogsIsNull)
            {
                requestAccessLogs_accessLogs_CloudWatchLogs = null;
            }
            if (requestAccessLogs_accessLogs_CloudWatchLogs != null)
            {
                request.AccessLogs.CloudWatchLogs = requestAccessLogs_accessLogs_CloudWatchLogs;
            }
            Amazon.EC2.Model.VerifiedAccessLogKinesisDataFirehoseDestinationOptions requestAccessLogs_accessLogs_KinesisDataFirehose = null;
            
             // populate KinesisDataFirehose
            var requestAccessLogs_accessLogs_KinesisDataFirehoseIsNull = true;
            requestAccessLogs_accessLogs_KinesisDataFirehose = new Amazon.EC2.Model.VerifiedAccessLogKinesisDataFirehoseDestinationOptions();
            System.String requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_DeliveryStream = null;
            if (cmdletContext.KinesisDataFirehose_DeliveryStream != null)
            {
                requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_DeliveryStream = cmdletContext.KinesisDataFirehose_DeliveryStream;
            }
            if (requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_DeliveryStream != null)
            {
                requestAccessLogs_accessLogs_KinesisDataFirehose.DeliveryStream = requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_DeliveryStream;
                requestAccessLogs_accessLogs_KinesisDataFirehoseIsNull = false;
            }
            System.Boolean? requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_Enabled = null;
            if (cmdletContext.KinesisDataFirehose_Enabled != null)
            {
                requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_Enabled = cmdletContext.KinesisDataFirehose_Enabled.Value;
            }
            if (requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_Enabled != null)
            {
                requestAccessLogs_accessLogs_KinesisDataFirehose.Enabled = requestAccessLogs_accessLogs_KinesisDataFirehose_kinesisDataFirehose_Enabled.Value;
                requestAccessLogs_accessLogs_KinesisDataFirehoseIsNull = false;
            }
             // determine if requestAccessLogs_accessLogs_KinesisDataFirehose should be set to null
            if (requestAccessLogs_accessLogs_KinesisDataFirehoseIsNull)
            {
                requestAccessLogs_accessLogs_KinesisDataFirehose = null;
            }
            if (requestAccessLogs_accessLogs_KinesisDataFirehose != null)
            {
                request.AccessLogs.KinesisDataFirehose = requestAccessLogs_accessLogs_KinesisDataFirehose;
            }
            Amazon.EC2.Model.VerifiedAccessLogS3DestinationOptions requestAccessLogs_accessLogs_S3 = null;
            
             // populate S3
            var requestAccessLogs_accessLogs_S3IsNull = true;
            requestAccessLogs_accessLogs_S3 = new Amazon.EC2.Model.VerifiedAccessLogS3DestinationOptions();
            System.String requestAccessLogs_accessLogs_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestAccessLogs_accessLogs_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestAccessLogs_accessLogs_S3_s3_BucketName != null)
            {
                requestAccessLogs_accessLogs_S3.BucketName = requestAccessLogs_accessLogs_S3_s3_BucketName;
                requestAccessLogs_accessLogs_S3IsNull = false;
            }
            System.String requestAccessLogs_accessLogs_S3_s3_BucketOwner = null;
            if (cmdletContext.S3_BucketOwner != null)
            {
                requestAccessLogs_accessLogs_S3_s3_BucketOwner = cmdletContext.S3_BucketOwner;
            }
            if (requestAccessLogs_accessLogs_S3_s3_BucketOwner != null)
            {
                requestAccessLogs_accessLogs_S3.BucketOwner = requestAccessLogs_accessLogs_S3_s3_BucketOwner;
                requestAccessLogs_accessLogs_S3IsNull = false;
            }
            System.Boolean? requestAccessLogs_accessLogs_S3_s3_Enabled = null;
            if (cmdletContext.S3_Enabled != null)
            {
                requestAccessLogs_accessLogs_S3_s3_Enabled = cmdletContext.S3_Enabled.Value;
            }
            if (requestAccessLogs_accessLogs_S3_s3_Enabled != null)
            {
                requestAccessLogs_accessLogs_S3.Enabled = requestAccessLogs_accessLogs_S3_s3_Enabled.Value;
                requestAccessLogs_accessLogs_S3IsNull = false;
            }
            System.String requestAccessLogs_accessLogs_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestAccessLogs_accessLogs_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestAccessLogs_accessLogs_S3_s3_Prefix != null)
            {
                requestAccessLogs_accessLogs_S3.Prefix = requestAccessLogs_accessLogs_S3_s3_Prefix;
                requestAccessLogs_accessLogs_S3IsNull = false;
            }
             // determine if requestAccessLogs_accessLogs_S3 should be set to null
            if (requestAccessLogs_accessLogs_S3IsNull)
            {
                requestAccessLogs_accessLogs_S3 = null;
            }
            if (requestAccessLogs_accessLogs_S3 != null)
            {
                request.AccessLogs.S3 = requestAccessLogs_accessLogs_S3;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.VerifiedAccessInstanceId != null)
            {
                request.VerifiedAccessInstanceId = cmdletContext.VerifiedAccessInstanceId;
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
        
        private Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVerifiedAccessInstanceLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.ModifyVerifiedAccessInstanceLoggingConfiguration(request);
                #elif CORECLR
                return client.ModifyVerifiedAccessInstanceLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CloudWatchLogs_Enabled { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.Boolean? AccessLogs_IncludeTrustContext { get; set; }
            public System.String KinesisDataFirehose_DeliveryStream { get; set; }
            public System.Boolean? KinesisDataFirehose_Enabled { get; set; }
            public System.String AccessLogs_LogVersion { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String S3_BucketOwner { get; set; }
            public System.Boolean? S3_Enabled { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.String ClientToken { get; set; }
            public System.String VerifiedAccessInstanceId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVerifiedAccessInstanceLoggingConfigurationResponse, EditEC2VerifiedAccessInstanceLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}
