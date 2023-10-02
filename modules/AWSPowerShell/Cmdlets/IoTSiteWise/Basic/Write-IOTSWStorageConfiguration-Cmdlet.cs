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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Configures storage settings for IoT SiteWise.
    /// </summary>
    [Cmdlet("Write", "IOTSWStorageConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise PutStorageConfiguration API operation.", Operation = new[] {"PutStorageConfiguration"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteIOTSWStorageConfigurationCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DisassociatedDataStorage
        /// <summary>
        /// <para>
        /// <para>Contains the storage configuration for time series (data streams) that aren't associated
        /// with asset properties. The <code>disassociatedDataStorage</code> can be one of the
        /// following values:</para><ul><li><para><code>ENABLED</code> – IoT SiteWise accepts time series that aren't associated with
        /// asset properties.</para><important><para>After the <code>disassociatedDataStorage</code> is enabled, you can't disable it.</para></important></li><li><para><code>DISABLED</code> – IoT SiteWise doesn't accept time series (data streams) that
        /// aren't associated with asset properties.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/data-streams.html">Data
        /// streams</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.DisassociatedDataStorageState")]
        public Amazon.IoTSiteWise.DisassociatedDataStorageState DisassociatedDataStorage { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod_NumberOfDay
        /// <summary>
        /// <para>
        /// <para>The number of days that your data is kept.</para><note><para>If you specified a value for this parameter, the <code>unlimited</code> parameter
        /// must be <code>false</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionPeriod_NumberOfDays")]
        public System.Int32? RetentionPeriod_NumberOfDay { get; set; }
        #endregion
        
        #region Parameter CustomerManagedS3Storage_RoleArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the Identity and Access Management role that allows IoT SiteWise to send data to
        /// Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiLayerStorage_CustomerManagedS3Storage_RoleArn")]
        public System.String CustomerManagedS3Storage_RoleArn { get; set; }
        #endregion
        
        #region Parameter CustomerManagedS3Storage_S3ResourceArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the Amazon S3 object. For more information about how to find the ARN for an Amazon
        /// S3 object, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-arn-format.html">Amazon
        /// S3 resources</a> in the <i>Amazon Simple Storage Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiLayerStorage_CustomerManagedS3Storage_S3ResourceArn")]
        public System.String CustomerManagedS3Storage_S3ResourceArn { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage tier that you specified for your data. The <code>storageType</code> parameter
        /// can be one of the following values:</para><ul><li><para><code>SITEWISE_DEFAULT_STORAGE</code> – IoT SiteWise saves your data into the hot
        /// tier. The hot tier is a service-managed database.</para></li><li><para><code>MULTI_LAYER_STORAGE</code> – IoT SiteWise saves your data in both the cold
        /// tier and the hot tier. The cold tier is a customer-managed Amazon S3 bucket.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSiteWise.StorageType")]
        public Amazon.IoTSiteWise.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod_Unlimited
        /// <summary>
        /// <para>
        /// <para>If true, your data is kept indefinitely.</para><note><para>If configured to <code>true</code>, you must not specify a value for the <code>numberOfDays</code>
        /// parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetentionPeriod_Unlimited { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StorageType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StorageType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StorageType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTSWStorageConfiguration (PutStorageConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse, WriteIOTSWStorageConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StorageType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DisassociatedDataStorage = this.DisassociatedDataStorage;
            context.CustomerManagedS3Storage_RoleArn = this.CustomerManagedS3Storage_RoleArn;
            context.CustomerManagedS3Storage_S3ResourceArn = this.CustomerManagedS3Storage_S3ResourceArn;
            context.RetentionPeriod_NumberOfDay = this.RetentionPeriod_NumberOfDay;
            context.RetentionPeriod_Unlimited = this.RetentionPeriod_Unlimited;
            context.StorageType = this.StorageType;
            #if MODULAR
            if (this.StorageType == null && ParameterWasBound(nameof(this.StorageType)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.PutStorageConfigurationRequest();
            
            if (cmdletContext.DisassociatedDataStorage != null)
            {
                request.DisassociatedDataStorage = cmdletContext.DisassociatedDataStorage;
            }
            
             // populate MultiLayerStorage
            var requestMultiLayerStorageIsNull = true;
            request.MultiLayerStorage = new Amazon.IoTSiteWise.Model.MultiLayerStorage();
            Amazon.IoTSiteWise.Model.CustomerManagedS3Storage requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage = null;
            
             // populate CustomerManagedS3Storage
            var requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3StorageIsNull = true;
            requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage = new Amazon.IoTSiteWise.Model.CustomerManagedS3Storage();
            System.String requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_RoleArn = null;
            if (cmdletContext.CustomerManagedS3Storage_RoleArn != null)
            {
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_RoleArn = cmdletContext.CustomerManagedS3Storage_RoleArn;
            }
            if (requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_RoleArn != null)
            {
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage.RoleArn = requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_RoleArn;
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3StorageIsNull = false;
            }
            System.String requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_S3ResourceArn = null;
            if (cmdletContext.CustomerManagedS3Storage_S3ResourceArn != null)
            {
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_S3ResourceArn = cmdletContext.CustomerManagedS3Storage_S3ResourceArn;
            }
            if (requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_S3ResourceArn != null)
            {
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage.S3ResourceArn = requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage_customerManagedS3Storage_S3ResourceArn;
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3StorageIsNull = false;
            }
             // determine if requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage should be set to null
            if (requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3StorageIsNull)
            {
                requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage = null;
            }
            if (requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage != null)
            {
                request.MultiLayerStorage.CustomerManagedS3Storage = requestMultiLayerStorage_multiLayerStorage_CustomerManagedS3Storage;
                requestMultiLayerStorageIsNull = false;
            }
             // determine if request.MultiLayerStorage should be set to null
            if (requestMultiLayerStorageIsNull)
            {
                request.MultiLayerStorage = null;
            }
            
             // populate RetentionPeriod
            var requestRetentionPeriodIsNull = true;
            request.RetentionPeriod = new Amazon.IoTSiteWise.Model.RetentionPeriod();
            System.Int32? requestRetentionPeriod_retentionPeriod_NumberOfDay = null;
            if (cmdletContext.RetentionPeriod_NumberOfDay != null)
            {
                requestRetentionPeriod_retentionPeriod_NumberOfDay = cmdletContext.RetentionPeriod_NumberOfDay.Value;
            }
            if (requestRetentionPeriod_retentionPeriod_NumberOfDay != null)
            {
                request.RetentionPeriod.NumberOfDays = requestRetentionPeriod_retentionPeriod_NumberOfDay.Value;
                requestRetentionPeriodIsNull = false;
            }
            System.Boolean? requestRetentionPeriod_retentionPeriod_Unlimited = null;
            if (cmdletContext.RetentionPeriod_Unlimited != null)
            {
                requestRetentionPeriod_retentionPeriod_Unlimited = cmdletContext.RetentionPeriod_Unlimited.Value;
            }
            if (requestRetentionPeriod_retentionPeriod_Unlimited != null)
            {
                request.RetentionPeriod.Unlimited = requestRetentionPeriod_retentionPeriod_Unlimited.Value;
                requestRetentionPeriodIsNull = false;
            }
             // determine if request.RetentionPeriod should be set to null
            if (requestRetentionPeriodIsNull)
            {
                request.RetentionPeriod = null;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
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
        
        private Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.PutStorageConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "PutStorageConfiguration");
            try
            {
                #if DESKTOP
                return client.PutStorageConfiguration(request);
                #elif CORECLR
                return client.PutStorageConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTSiteWise.DisassociatedDataStorageState DisassociatedDataStorage { get; set; }
            public System.String CustomerManagedS3Storage_RoleArn { get; set; }
            public System.String CustomerManagedS3Storage_S3ResourceArn { get; set; }
            public System.Int32? RetentionPeriod_NumberOfDay { get; set; }
            public System.Boolean? RetentionPeriod_Unlimited { get; set; }
            public Amazon.IoTSiteWise.StorageType StorageType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.PutStorageConfigurationResponse, WriteIOTSWStorageConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
