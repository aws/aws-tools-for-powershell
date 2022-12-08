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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Creates or updates the configuration settings for storing data classification results.
    /// </summary>
    [Cmdlet("Write", "MAC2ClassificationExportConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.ClassificationExportConfiguration")]
    [AWSCmdlet("Calls the Amazon Macie 2 PutClassificationExportConfiguration API operation.", Operation = new[] {"PutClassificationExportConfiguration"}, SelectReturnType = typeof(Amazon.Macie2.Model.PutClassificationExportConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.ClassificationExportConfiguration or Amazon.Macie2.Model.PutClassificationExportConfigurationResponse",
        "This cmdlet returns an Amazon.Macie2.Model.ClassificationExportConfiguration object.",
        "The service call response (type Amazon.Macie2.Model.PutClassificationExportConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteMAC2ClassificationExportConfigurationCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter S3Destination_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_S3Destination_BucketName")]
        public System.String S3Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Destination_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The path prefix to use in the path to the location in the bucket. This prefix specifies
        /// where to store classification results in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_S3Destination_KeyPrefix")]
        public System.String S3Destination_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Destination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key to use for encryption
        /// of the results. This must be the ARN of an existing, symmetric encryption KMS key
        /// that's in the same Amazon Web Services Region as the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_S3Destination_KmsKeyArn")]
        public System.String S3Destination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.PutClassificationExportConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.PutClassificationExportConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-MAC2ClassificationExportConfiguration (PutClassificationExportConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.PutClassificationExportConfigurationResponse, WriteMAC2ClassificationExportConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.S3Destination_BucketName = this.S3Destination_BucketName;
            context.S3Destination_KeyPrefix = this.S3Destination_KeyPrefix;
            context.S3Destination_KmsKeyArn = this.S3Destination_KmsKeyArn;
            
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
            var request = new Amazon.Macie2.Model.PutClassificationExportConfigurationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Macie2.Model.ClassificationExportConfiguration();
            Amazon.Macie2.Model.S3Destination requestConfiguration_configuration_S3Destination = null;
            
             // populate S3Destination
            var requestConfiguration_configuration_S3DestinationIsNull = true;
            requestConfiguration_configuration_S3Destination = new Amazon.Macie2.Model.S3Destination();
            System.String requestConfiguration_configuration_S3Destination_s3Destination_BucketName = null;
            if (cmdletContext.S3Destination_BucketName != null)
            {
                requestConfiguration_configuration_S3Destination_s3Destination_BucketName = cmdletContext.S3Destination_BucketName;
            }
            if (requestConfiguration_configuration_S3Destination_s3Destination_BucketName != null)
            {
                requestConfiguration_configuration_S3Destination.BucketName = requestConfiguration_configuration_S3Destination_s3Destination_BucketName;
                requestConfiguration_configuration_S3DestinationIsNull = false;
            }
            System.String requestConfiguration_configuration_S3Destination_s3Destination_KeyPrefix = null;
            if (cmdletContext.S3Destination_KeyPrefix != null)
            {
                requestConfiguration_configuration_S3Destination_s3Destination_KeyPrefix = cmdletContext.S3Destination_KeyPrefix;
            }
            if (requestConfiguration_configuration_S3Destination_s3Destination_KeyPrefix != null)
            {
                requestConfiguration_configuration_S3Destination.KeyPrefix = requestConfiguration_configuration_S3Destination_s3Destination_KeyPrefix;
                requestConfiguration_configuration_S3DestinationIsNull = false;
            }
            System.String requestConfiguration_configuration_S3Destination_s3Destination_KmsKeyArn = null;
            if (cmdletContext.S3Destination_KmsKeyArn != null)
            {
                requestConfiguration_configuration_S3Destination_s3Destination_KmsKeyArn = cmdletContext.S3Destination_KmsKeyArn;
            }
            if (requestConfiguration_configuration_S3Destination_s3Destination_KmsKeyArn != null)
            {
                requestConfiguration_configuration_S3Destination.KmsKeyArn = requestConfiguration_configuration_S3Destination_s3Destination_KmsKeyArn;
                requestConfiguration_configuration_S3DestinationIsNull = false;
            }
             // determine if requestConfiguration_configuration_S3Destination should be set to null
            if (requestConfiguration_configuration_S3DestinationIsNull)
            {
                requestConfiguration_configuration_S3Destination = null;
            }
            if (requestConfiguration_configuration_S3Destination != null)
            {
                request.Configuration.S3Destination = requestConfiguration_configuration_S3Destination;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
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
        
        private Amazon.Macie2.Model.PutClassificationExportConfigurationResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.PutClassificationExportConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "PutClassificationExportConfiguration");
            try
            {
                #if DESKTOP
                return client.PutClassificationExportConfiguration(request);
                #elif CORECLR
                return client.PutClassificationExportConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Destination_BucketName { get; set; }
            public System.String S3Destination_KeyPrefix { get; set; }
            public System.String S3Destination_KmsKeyArn { get; set; }
            public System.Func<Amazon.Macie2.Model.PutClassificationExportConfigurationResponse, WriteMAC2ClassificationExportConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
