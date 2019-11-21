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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a resource data sync configuration to a single bucket in Amazon S3. This is
    /// an asynchronous operation that returns immediately. After a successful initial sync
    /// is completed, the system continuously syncs data to the Amazon S3 bucket. To check
    /// the status of the sync, use the <a>ListResourceDataSync</a>.
    /// 
    ///  
    /// <para>
    /// By default, data is not encrypted in Amazon S3. We strongly recommend that you enable
    /// encryption in Amazon S3 to ensure secure data storage. We also recommend that you
    /// secure access to the Amazon S3 bucket by creating a restrictive bucket policy. For
    /// more information, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-inventory-datasync.html">Configuring
    /// Resource Data Sync for Inventory</a> in the <i>AWS Systems Manager User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMResourceDataSync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateResourceDataSync API operation.", Operation = new[] {"CreateResourceDataSync"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMResourceDataSyncCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter S3Destination_AWSKMSKeyARN
        /// <summary>
        /// <para>
        /// <para>The ARN of an encryption key for a destination in Amazon S3. Must belong to the same
        /// Region as the destination Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Destination_AWSKMSKeyARN { get; set; }
        #endregion
        
        #region Parameter S3Destination_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the aggregated data is stored.</para>
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
        public System.String S3Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Destination_Prefix
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 prefix for the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Destination_Prefix { get; set; }
        #endregion
        
        #region Parameter S3Destination_Region
        /// <summary>
        /// <para>
        /// <para>The AWS Region with the Amazon S3 bucket targeted by the Resource Data Sync.</para>
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
        public System.String S3Destination_Region { get; set; }
        #endregion
        
        #region Parameter S3Destination_SyncFormat
        /// <summary>
        /// <para>
        /// <para>A supported sync format. The following format is currently supported: JsonSerDe</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format")]
        public Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format S3Destination_SyncFormat { get; set; }
        #endregion
        
        #region Parameter SyncName
        /// <summary>
        /// <para>
        /// <para>A name for the configuration.</para>
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
        public System.String SyncName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SyncName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SyncName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SyncName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SyncName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMResourceDataSync (CreateResourceDataSync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse, NewSSMResourceDataSyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SyncName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3Destination_AWSKMSKeyARN = this.S3Destination_AWSKMSKeyARN;
            context.S3Destination_BucketName = this.S3Destination_BucketName;
            #if MODULAR
            if (this.S3Destination_BucketName == null && ParameterWasBound(nameof(this.S3Destination_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_Prefix = this.S3Destination_Prefix;
            context.S3Destination_Region = this.S3Destination_Region;
            #if MODULAR
            if (this.S3Destination_Region == null && ParameterWasBound(nameof(this.S3Destination_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_SyncFormat = this.S3Destination_SyncFormat;
            #if MODULAR
            if (this.S3Destination_SyncFormat == null && ParameterWasBound(nameof(this.S3Destination_SyncFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_SyncFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyncName = this.SyncName;
            #if MODULAR
            if (this.SyncName == null && ParameterWasBound(nameof(this.SyncName)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncRequest();
            
            
             // populate S3Destination
            var requestS3DestinationIsNull = true;
            request.S3Destination = new Amazon.SimpleSystemsManagement.Model.ResourceDataSyncS3Destination();
            System.String requestS3Destination_s3Destination_AWSKMSKeyARN = null;
            if (cmdletContext.S3Destination_AWSKMSKeyARN != null)
            {
                requestS3Destination_s3Destination_AWSKMSKeyARN = cmdletContext.S3Destination_AWSKMSKeyARN;
            }
            if (requestS3Destination_s3Destination_AWSKMSKeyARN != null)
            {
                request.S3Destination.AWSKMSKeyARN = requestS3Destination_s3Destination_AWSKMSKeyARN;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_BucketName = null;
            if (cmdletContext.S3Destination_BucketName != null)
            {
                requestS3Destination_s3Destination_BucketName = cmdletContext.S3Destination_BucketName;
            }
            if (requestS3Destination_s3Destination_BucketName != null)
            {
                request.S3Destination.BucketName = requestS3Destination_s3Destination_BucketName;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_Prefix = null;
            if (cmdletContext.S3Destination_Prefix != null)
            {
                requestS3Destination_s3Destination_Prefix = cmdletContext.S3Destination_Prefix;
            }
            if (requestS3Destination_s3Destination_Prefix != null)
            {
                request.S3Destination.Prefix = requestS3Destination_s3Destination_Prefix;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_Region = null;
            if (cmdletContext.S3Destination_Region != null)
            {
                requestS3Destination_s3Destination_Region = cmdletContext.S3Destination_Region;
            }
            if (requestS3Destination_s3Destination_Region != null)
            {
                request.S3Destination.Region = requestS3Destination_s3Destination_Region;
                requestS3DestinationIsNull = false;
            }
            Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format requestS3Destination_s3Destination_SyncFormat = null;
            if (cmdletContext.S3Destination_SyncFormat != null)
            {
                requestS3Destination_s3Destination_SyncFormat = cmdletContext.S3Destination_SyncFormat;
            }
            if (requestS3Destination_s3Destination_SyncFormat != null)
            {
                request.S3Destination.SyncFormat = requestS3Destination_s3Destination_SyncFormat;
                requestS3DestinationIsNull = false;
            }
             // determine if request.S3Destination should be set to null
            if (requestS3DestinationIsNull)
            {
                request.S3Destination = null;
            }
            if (cmdletContext.SyncName != null)
            {
                request.SyncName = cmdletContext.SyncName;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateResourceDataSync");
            try
            {
                #if DESKTOP
                return client.CreateResourceDataSync(request);
                #elif CORECLR
                return client.CreateResourceDataSyncAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Destination_AWSKMSKeyARN { get; set; }
            public System.String S3Destination_BucketName { get; set; }
            public System.String S3Destination_Prefix { get; set; }
            public System.String S3Destination_Region { get; set; }
            public Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format S3Destination_SyncFormat { get; set; }
            public System.String SyncName { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateResourceDataSyncResponse, NewSSMResourceDataSyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
