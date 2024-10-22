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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Updates an ingestion destination, which specifies how an application's ingested data
    /// is processed by Amazon Web Services AppFabric and where it's delivered.
    /// </summary>
    [Cmdlet("Update", "AFABIngestionDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppFabric.Model.IngestionDestination")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric UpdateIngestionDestination API operation.", Operation = new[] {"UpdateIngestionDestination"}, SelectReturnType = typeof(Amazon.AppFabric.Model.UpdateIngestionDestinationResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.IngestionDestination or Amazon.AppFabric.Model.UpdateIngestionDestinationResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.IngestionDestination object.",
        "The service call response (type Amazon.AppFabric.Model.UpdateIngestionDestinationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAFABIngestionDestinationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter S3Bucket_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_AuditLog_Destination_S3Bucket_BucketName")]
        public System.String S3Bucket_BucketName { get; set; }
        #endregion
        
        #region Parameter IngestionDestinationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the ingestion
        /// destination to use for the request.</para>
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
        public System.String IngestionDestinationIdentifier { get; set; }
        #endregion
        
        #region Parameter IngestionIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the ingestion
        /// to use for the request.</para>
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
        public System.String IngestionIdentifier { get; set; }
        #endregion
        
        #region Parameter S3Bucket_Prefix
        /// <summary>
        /// <para>
        /// <para>The object key to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_AuditLog_Destination_S3Bucket_Prefix")]
        public System.String S3Bucket_Prefix { get; set; }
        #endregion
        
        #region Parameter FirehoseStream_StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Kinesis Data Firehose delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_AuditLog_Destination_FirehoseStream_StreamName")]
        public System.String FirehoseStream_StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngestionDestination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.UpdateIngestionDestinationResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.UpdateIngestionDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngestionDestination";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngestionDestinationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AFABIngestionDestination (UpdateIngestionDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.UpdateIngestionDestinationResponse, UpdateAFABIngestionDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirehoseStream_StreamName = this.FirehoseStream_StreamName;
            context.S3Bucket_BucketName = this.S3Bucket_BucketName;
            context.S3Bucket_Prefix = this.S3Bucket_Prefix;
            context.IngestionDestinationIdentifier = this.IngestionDestinationIdentifier;
            #if MODULAR
            if (this.IngestionDestinationIdentifier == null && ParameterWasBound(nameof(this.IngestionDestinationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionDestinationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionIdentifier = this.IngestionIdentifier;
            #if MODULAR
            if (this.IngestionIdentifier == null && ParameterWasBound(nameof(this.IngestionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppFabric.Model.UpdateIngestionDestinationRequest();
            
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.AppFabric.Model.DestinationConfiguration();
            Amazon.AppFabric.Model.AuditLogDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_AuditLog = null;
            
             // populate AuditLog
            var requestDestinationConfiguration_destinationConfiguration_AuditLogIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_AuditLog = new Amazon.AppFabric.Model.AuditLogDestinationConfiguration();
            Amazon.AppFabric.Model.Destination requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination = null;
            
             // populate Destination
            var requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_DestinationIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination = new Amazon.AppFabric.Model.Destination();
            Amazon.AppFabric.Model.FirehoseStream requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream = null;
            
             // populate FirehoseStream
            var requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStreamIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream = new Amazon.AppFabric.Model.FirehoseStream();
            System.String requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream_firehoseStream_StreamName = null;
            if (cmdletContext.FirehoseStream_StreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream_firehoseStream_StreamName = cmdletContext.FirehoseStream_StreamName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream_firehoseStream_StreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream.StreamName = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream_firehoseStream_StreamName;
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStreamIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStreamIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination.FirehoseStream = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_FirehoseStream;
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_DestinationIsNull = false;
            }
            Amazon.AppFabric.Model.S3Bucket requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket = null;
            
             // populate S3Bucket
            var requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3BucketIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket = new Amazon.AppFabric.Model.S3Bucket();
            System.String requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_BucketName = null;
            if (cmdletContext.S3Bucket_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_BucketName = cmdletContext.S3Bucket_BucketName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket.BucketName = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_BucketName;
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3BucketIsNull = false;
            }
            System.String requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_Prefix = null;
            if (cmdletContext.S3Bucket_Prefix != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_Prefix = cmdletContext.S3Bucket_Prefix;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_Prefix != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket.Prefix = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket_s3Bucket_Prefix;
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3BucketIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3BucketIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination.S3Bucket = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination_destinationConfiguration_AuditLog_Destination_S3Bucket;
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_DestinationIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_DestinationIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination != null)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog.Destination = requestDestinationConfiguration_destinationConfiguration_AuditLog_destinationConfiguration_AuditLog_Destination;
                requestDestinationConfiguration_destinationConfiguration_AuditLogIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_AuditLog should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_AuditLogIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_AuditLog = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_AuditLog != null)
            {
                request.DestinationConfiguration.AuditLog = requestDestinationConfiguration_destinationConfiguration_AuditLog;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
            }
            if (cmdletContext.IngestionDestinationIdentifier != null)
            {
                request.IngestionDestinationIdentifier = cmdletContext.IngestionDestinationIdentifier;
            }
            if (cmdletContext.IngestionIdentifier != null)
            {
                request.IngestionIdentifier = cmdletContext.IngestionIdentifier;
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
        
        private Amazon.AppFabric.Model.UpdateIngestionDestinationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.UpdateIngestionDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "UpdateIngestionDestination");
            try
            {
                #if DESKTOP
                return client.UpdateIngestionDestination(request);
                #elif CORECLR
                return client.UpdateIngestionDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppBundleIdentifier { get; set; }
            public System.String FirehoseStream_StreamName { get; set; }
            public System.String S3Bucket_BucketName { get; set; }
            public System.String S3Bucket_Prefix { get; set; }
            public System.String IngestionDestinationIdentifier { get; set; }
            public System.String IngestionIdentifier { get; set; }
            public System.Func<Amazon.AppFabric.Model.UpdateIngestionDestinationResponse, UpdateAFABIngestionDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngestionDestination;
        }
        
    }
}
