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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Set the configuration values for model invocation logging.
    /// </summary>
    [Cmdlet("Write", "BDRModelInvocationLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Bedrock PutModelInvocationLoggingConfiguration API operation.", Operation = new[] {"PutModelInvocationLoggingConfiguration"}, SelectReturnType = typeof(Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteBDRModelInvocationLoggingConfigurationCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        #region Parameter LargeDataDeliveryS3Config_BucketName
        /// <summary>
        /// <para>
        /// <para>S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_BucketName")]
        public System.String LargeDataDeliveryS3Config_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketName
        /// <summary>
        /// <para>
        /// <para>S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_S3Config_BucketName")]
        public System.String S3Config_BucketName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_EmbeddingDataDeliveryEnabled
        /// <summary>
        /// <para>
        /// <para>Set to include embeddings data in the log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfig_EmbeddingDataDeliveryEnabled { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_ImageDataDeliveryEnabled
        /// <summary>
        /// <para>
        /// <para>Set to include image data in the log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfig_ImageDataDeliveryEnabled { get; set; }
        #endregion
        
        #region Parameter LargeDataDeliveryS3Config_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>S3 prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_KeyPrefix")]
        public System.String LargeDataDeliveryS3Config_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Config_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>S3 prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_S3Config_KeyPrefix")]
        public System.String S3Config_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter CloudWatchConfig_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_CloudWatchConfig_LogGroupName")]
        public System.String CloudWatchConfig_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfig_CloudWatchConfig_RoleArn")]
        public System.String CloudWatchConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_TextDataDeliveryEnabled
        /// <summary>
        /// <para>
        /// <para>Set to include text data in the log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfig_TextDataDeliveryEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BDRModelInvocationLoggingConfiguration (PutModelInvocationLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse, WriteBDRModelInvocationLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LargeDataDeliveryS3Config_BucketName = this.LargeDataDeliveryS3Config_BucketName;
            context.LargeDataDeliveryS3Config_KeyPrefix = this.LargeDataDeliveryS3Config_KeyPrefix;
            context.CloudWatchConfig_LogGroupName = this.CloudWatchConfig_LogGroupName;
            context.CloudWatchConfig_RoleArn = this.CloudWatchConfig_RoleArn;
            context.LoggingConfig_EmbeddingDataDeliveryEnabled = this.LoggingConfig_EmbeddingDataDeliveryEnabled;
            context.LoggingConfig_ImageDataDeliveryEnabled = this.LoggingConfig_ImageDataDeliveryEnabled;
            context.S3Config_BucketName = this.S3Config_BucketName;
            context.S3Config_KeyPrefix = this.S3Config_KeyPrefix;
            context.LoggingConfig_TextDataDeliveryEnabled = this.LoggingConfig_TextDataDeliveryEnabled;
            
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
            var request = new Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationRequest();
            
            
             // populate LoggingConfig
            var requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.Bedrock.Model.LoggingConfig();
            System.Boolean? requestLoggingConfig_loggingConfig_EmbeddingDataDeliveryEnabled = null;
            if (cmdletContext.LoggingConfig_EmbeddingDataDeliveryEnabled != null)
            {
                requestLoggingConfig_loggingConfig_EmbeddingDataDeliveryEnabled = cmdletContext.LoggingConfig_EmbeddingDataDeliveryEnabled.Value;
            }
            if (requestLoggingConfig_loggingConfig_EmbeddingDataDeliveryEnabled != null)
            {
                request.LoggingConfig.EmbeddingDataDeliveryEnabled = requestLoggingConfig_loggingConfig_EmbeddingDataDeliveryEnabled.Value;
                requestLoggingConfigIsNull = false;
            }
            System.Boolean? requestLoggingConfig_loggingConfig_ImageDataDeliveryEnabled = null;
            if (cmdletContext.LoggingConfig_ImageDataDeliveryEnabled != null)
            {
                requestLoggingConfig_loggingConfig_ImageDataDeliveryEnabled = cmdletContext.LoggingConfig_ImageDataDeliveryEnabled.Value;
            }
            if (requestLoggingConfig_loggingConfig_ImageDataDeliveryEnabled != null)
            {
                request.LoggingConfig.ImageDataDeliveryEnabled = requestLoggingConfig_loggingConfig_ImageDataDeliveryEnabled.Value;
                requestLoggingConfigIsNull = false;
            }
            System.Boolean? requestLoggingConfig_loggingConfig_TextDataDeliveryEnabled = null;
            if (cmdletContext.LoggingConfig_TextDataDeliveryEnabled != null)
            {
                requestLoggingConfig_loggingConfig_TextDataDeliveryEnabled = cmdletContext.LoggingConfig_TextDataDeliveryEnabled.Value;
            }
            if (requestLoggingConfig_loggingConfig_TextDataDeliveryEnabled != null)
            {
                request.LoggingConfig.TextDataDeliveryEnabled = requestLoggingConfig_loggingConfig_TextDataDeliveryEnabled.Value;
                requestLoggingConfigIsNull = false;
            }
            Amazon.Bedrock.Model.S3Config requestLoggingConfig_loggingConfig_S3Config = null;
            
             // populate S3Config
            var requestLoggingConfig_loggingConfig_S3ConfigIsNull = true;
            requestLoggingConfig_loggingConfig_S3Config = new Amazon.Bedrock.Model.S3Config();
            System.String requestLoggingConfig_loggingConfig_S3Config_s3Config_BucketName = null;
            if (cmdletContext.S3Config_BucketName != null)
            {
                requestLoggingConfig_loggingConfig_S3Config_s3Config_BucketName = cmdletContext.S3Config_BucketName;
            }
            if (requestLoggingConfig_loggingConfig_S3Config_s3Config_BucketName != null)
            {
                requestLoggingConfig_loggingConfig_S3Config.BucketName = requestLoggingConfig_loggingConfig_S3Config_s3Config_BucketName;
                requestLoggingConfig_loggingConfig_S3ConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_S3Config_s3Config_KeyPrefix = null;
            if (cmdletContext.S3Config_KeyPrefix != null)
            {
                requestLoggingConfig_loggingConfig_S3Config_s3Config_KeyPrefix = cmdletContext.S3Config_KeyPrefix;
            }
            if (requestLoggingConfig_loggingConfig_S3Config_s3Config_KeyPrefix != null)
            {
                requestLoggingConfig_loggingConfig_S3Config.KeyPrefix = requestLoggingConfig_loggingConfig_S3Config_s3Config_KeyPrefix;
                requestLoggingConfig_loggingConfig_S3ConfigIsNull = false;
            }
             // determine if requestLoggingConfig_loggingConfig_S3Config should be set to null
            if (requestLoggingConfig_loggingConfig_S3ConfigIsNull)
            {
                requestLoggingConfig_loggingConfig_S3Config = null;
            }
            if (requestLoggingConfig_loggingConfig_S3Config != null)
            {
                request.LoggingConfig.S3Config = requestLoggingConfig_loggingConfig_S3Config;
                requestLoggingConfigIsNull = false;
            }
            Amazon.Bedrock.Model.CloudWatchConfig requestLoggingConfig_loggingConfig_CloudWatchConfig = null;
            
             // populate CloudWatchConfig
            var requestLoggingConfig_loggingConfig_CloudWatchConfigIsNull = true;
            requestLoggingConfig_loggingConfig_CloudWatchConfig = new Amazon.Bedrock.Model.CloudWatchConfig();
            System.String requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_LogGroupName = null;
            if (cmdletContext.CloudWatchConfig_LogGroupName != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_LogGroupName = cmdletContext.CloudWatchConfig_LogGroupName;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_LogGroupName != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig.LogGroupName = requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_LogGroupName;
                requestLoggingConfig_loggingConfig_CloudWatchConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_RoleArn = null;
            if (cmdletContext.CloudWatchConfig_RoleArn != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_RoleArn = cmdletContext.CloudWatchConfig_RoleArn;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_RoleArn != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig.RoleArn = requestLoggingConfig_loggingConfig_CloudWatchConfig_cloudWatchConfig_RoleArn;
                requestLoggingConfig_loggingConfig_CloudWatchConfigIsNull = false;
            }
            Amazon.Bedrock.Model.S3Config requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config = null;
            
             // populate LargeDataDeliveryS3Config
            var requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3ConfigIsNull = true;
            requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config = new Amazon.Bedrock.Model.S3Config();
            System.String requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_BucketName = null;
            if (cmdletContext.LargeDataDeliveryS3Config_BucketName != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_BucketName = cmdletContext.LargeDataDeliveryS3Config_BucketName;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_BucketName != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config.BucketName = requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_BucketName;
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3ConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_KeyPrefix = null;
            if (cmdletContext.LargeDataDeliveryS3Config_KeyPrefix != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_KeyPrefix = cmdletContext.LargeDataDeliveryS3Config_KeyPrefix;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_KeyPrefix != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config.KeyPrefix = requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config_largeDataDeliveryS3Config_KeyPrefix;
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3ConfigIsNull = false;
            }
             // determine if requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config should be set to null
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3ConfigIsNull)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config = null;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config != null)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig.LargeDataDeliveryS3Config = requestLoggingConfig_loggingConfig_CloudWatchConfig_loggingConfig_CloudWatchConfig_LargeDataDeliveryS3Config;
                requestLoggingConfig_loggingConfig_CloudWatchConfigIsNull = false;
            }
             // determine if requestLoggingConfig_loggingConfig_CloudWatchConfig should be set to null
            if (requestLoggingConfig_loggingConfig_CloudWatchConfigIsNull)
            {
                requestLoggingConfig_loggingConfig_CloudWatchConfig = null;
            }
            if (requestLoggingConfig_loggingConfig_CloudWatchConfig != null)
            {
                request.LoggingConfig.CloudWatchConfig = requestLoggingConfig_loggingConfig_CloudWatchConfig;
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
        
        private Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "PutModelInvocationLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutModelInvocationLoggingConfiguration(request);
                #elif CORECLR
                return client.PutModelInvocationLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String LargeDataDeliveryS3Config_BucketName { get; set; }
            public System.String LargeDataDeliveryS3Config_KeyPrefix { get; set; }
            public System.String CloudWatchConfig_LogGroupName { get; set; }
            public System.String CloudWatchConfig_RoleArn { get; set; }
            public System.Boolean? LoggingConfig_EmbeddingDataDeliveryEnabled { get; set; }
            public System.Boolean? LoggingConfig_ImageDataDeliveryEnabled { get; set; }
            public System.String S3Config_BucketName { get; set; }
            public System.String S3Config_KeyPrefix { get; set; }
            public System.Boolean? LoggingConfig_TextDataDeliveryEnabled { get; set; }
            public System.Func<Amazon.Bedrock.Model.PutModelInvocationLoggingConfigurationResponse, WriteBDRModelInvocationLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
