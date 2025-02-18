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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Adds a new table to an existing database in your account. In an Amazon Web Services
    /// account, table names must be at least unique within each Region if they are in the
    /// same database. You might have identical table names in the same Region if the tables
    /// are in separate databases. While creating the table, you must specify the table name,
    /// database name, and the retention properties. <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html">Service
    /// quotas apply</a>. See <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.create-table.html">code
    /// sample</a> for details.
    /// </summary>
    [Cmdlet("New", "TSWTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamWrite.Model.Table")]
    [AWSCmdlet("Calls the Amazon Timestream Write CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.CreateTableResponse))]
    [AWSCmdletOutput("Amazon.TimestreamWrite.Model.Table or Amazon.TimestreamWrite.Model.CreateTableResponse",
        "This cmdlet returns an Amazon.TimestreamWrite.Model.Table object.",
        "The service call response (type Amazon.TimestreamWrite.Model.CreateTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTSWTableCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name of the customer S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MagneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_BucketName")]
        public System.String S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter Schema_CompositePartitionKey
        /// <summary>
        /// <para>
        /// <para>A non-empty list of partition keys defining the attributes used to partition the table
        /// data. The order of the list determines the partition hierarchy. The name and type
        /// of each partition key as well as the partition key order cannot be changed after the
        /// table is created. However, the enforcement level of each partition key can be changed.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.TimestreamWrite.Model.PartitionKey[] Schema_CompositePartitionKey { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream database.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter MagneticStoreWriteProperties_EnableMagneticStoreWrite
        /// <summary>
        /// <para>
        /// <para>A flag to enable magnetic store writes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MagneticStoreWriteProperties_EnableMagneticStoreWrites")]
        public System.Boolean? MagneticStoreWriteProperties_EnableMagneticStoreWrite { get; set; }
        #endregion
        
        #region Parameter S3Configuration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>The encryption option for the customer S3 location. Options are S3 server-side encryption
        /// with an S3 managed key or Amazon Web Services managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MagneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.TimestreamWrite.S3EncryptionOption")]
        public Amazon.TimestreamWrite.S3EncryptionOption S3Configuration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter S3Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key ID for the customer S3 location when encrypting with an Amazon Web Services
        /// managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MagneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_KmsKeyId")]
        public System.String S3Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RetentionProperties_MagneticStoreRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The duration for which data must be stored in the magnetic store. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionProperties_MagneticStoreRetentionPeriodInDays")]
        public System.Int64? RetentionProperties_MagneticStoreRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter RetentionProperties_MemoryStoreRetentionPeriodInHour
        /// <summary>
        /// <para>
        /// <para>The duration for which data must be stored in the memory store. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionProperties_MemoryStoreRetentionPeriodInHours")]
        public System.Int64? RetentionProperties_MemoryStoreRetentionPeriodInHour { get; set; }
        #endregion
        
        #region Parameter S3Configuration_ObjectKeyPrefix
        /// <summary>
        /// <para>
        /// <para>The object key preview for the customer S3 location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MagneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_ObjectKeyPrefix")]
        public System.String S3Configuration_ObjectKeyPrefix { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A list of key-value pairs to label the table. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TimestreamWrite.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Table'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.CreateTableResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.CreateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Table";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TSWTable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.CreateTableResponse, NewTSWTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MagneticStoreWriteProperties_EnableMagneticStoreWrite = this.MagneticStoreWriteProperties_EnableMagneticStoreWrite;
            context.S3Configuration_BucketName = this.S3Configuration_BucketName;
            context.S3Configuration_EncryptionOption = this.S3Configuration_EncryptionOption;
            context.S3Configuration_KmsKeyId = this.S3Configuration_KmsKeyId;
            context.S3Configuration_ObjectKeyPrefix = this.S3Configuration_ObjectKeyPrefix;
            context.RetentionProperties_MagneticStoreRetentionPeriodInDay = this.RetentionProperties_MagneticStoreRetentionPeriodInDay;
            context.RetentionProperties_MemoryStoreRetentionPeriodInHour = this.RetentionProperties_MemoryStoreRetentionPeriodInHour;
            if (this.Schema_CompositePartitionKey != null)
            {
                context.Schema_CompositePartitionKey = new List<Amazon.TimestreamWrite.Model.PartitionKey>(this.Schema_CompositePartitionKey);
            }
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TimestreamWrite.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.TimestreamWrite.Model.CreateTableRequest();
            
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate MagneticStoreWriteProperties
            var requestMagneticStoreWritePropertiesIsNull = true;
            request.MagneticStoreWriteProperties = new Amazon.TimestreamWrite.Model.MagneticStoreWriteProperties();
            System.Boolean? requestMagneticStoreWriteProperties_magneticStoreWriteProperties_EnableMagneticStoreWrite = null;
            if (cmdletContext.MagneticStoreWriteProperties_EnableMagneticStoreWrite != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_EnableMagneticStoreWrite = cmdletContext.MagneticStoreWriteProperties_EnableMagneticStoreWrite.Value;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_EnableMagneticStoreWrite != null)
            {
                request.MagneticStoreWriteProperties.EnableMagneticStoreWrites = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_EnableMagneticStoreWrite.Value;
                requestMagneticStoreWritePropertiesIsNull = false;
            }
            Amazon.TimestreamWrite.Model.MagneticStoreRejectedDataLocation requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation = null;
            
             // populate MagneticStoreRejectedDataLocation
            var requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocationIsNull = true;
            requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation = new Amazon.TimestreamWrite.Model.MagneticStoreRejectedDataLocation();
            Amazon.TimestreamWrite.Model.S3Configuration requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration = null;
            
             // populate S3Configuration
            var requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull = true;
            requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration = new Amazon.TimestreamWrite.Model.S3Configuration();
            System.String requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_BucketName = null;
            if (cmdletContext.S3Configuration_BucketName != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_BucketName = cmdletContext.S3Configuration_BucketName;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_BucketName != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration.BucketName = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_BucketName;
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull = false;
            }
            Amazon.TimestreamWrite.S3EncryptionOption requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_EncryptionOption = null;
            if (cmdletContext.S3Configuration_EncryptionOption != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_EncryptionOption = cmdletContext.S3Configuration_EncryptionOption;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_EncryptionOption != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration.EncryptionOption = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_EncryptionOption;
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull = false;
            }
            System.String requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_KmsKeyId = null;
            if (cmdletContext.S3Configuration_KmsKeyId != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_KmsKeyId = cmdletContext.S3Configuration_KmsKeyId;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_KmsKeyId != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration.KmsKeyId = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_KmsKeyId;
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull = false;
            }
            System.String requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_ObjectKeyPrefix = null;
            if (cmdletContext.S3Configuration_ObjectKeyPrefix != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_ObjectKeyPrefix = cmdletContext.S3Configuration_ObjectKeyPrefix;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_ObjectKeyPrefix != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration.ObjectKeyPrefix = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration_s3Configuration_ObjectKeyPrefix;
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull = false;
            }
             // determine if requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration should be set to null
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3ConfigurationIsNull)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration = null;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration != null)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation.S3Configuration = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation_S3Configuration;
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocationIsNull = false;
            }
             // determine if requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation should be set to null
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocationIsNull)
            {
                requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation = null;
            }
            if (requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation != null)
            {
                request.MagneticStoreWriteProperties.MagneticStoreRejectedDataLocation = requestMagneticStoreWriteProperties_magneticStoreWriteProperties_MagneticStoreRejectedDataLocation;
                requestMagneticStoreWritePropertiesIsNull = false;
            }
             // determine if request.MagneticStoreWriteProperties should be set to null
            if (requestMagneticStoreWritePropertiesIsNull)
            {
                request.MagneticStoreWriteProperties = null;
            }
            
             // populate RetentionProperties
            var requestRetentionPropertiesIsNull = true;
            request.RetentionProperties = new Amazon.TimestreamWrite.Model.RetentionProperties();
            System.Int64? requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay = null;
            if (cmdletContext.RetentionProperties_MagneticStoreRetentionPeriodInDay != null)
            {
                requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay = cmdletContext.RetentionProperties_MagneticStoreRetentionPeriodInDay.Value;
            }
            if (requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay != null)
            {
                request.RetentionProperties.MagneticStoreRetentionPeriodInDays = requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay.Value;
                requestRetentionPropertiesIsNull = false;
            }
            System.Int64? requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour = null;
            if (cmdletContext.RetentionProperties_MemoryStoreRetentionPeriodInHour != null)
            {
                requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour = cmdletContext.RetentionProperties_MemoryStoreRetentionPeriodInHour.Value;
            }
            if (requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour != null)
            {
                request.RetentionProperties.MemoryStoreRetentionPeriodInHours = requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour.Value;
                requestRetentionPropertiesIsNull = false;
            }
             // determine if request.RetentionProperties should be set to null
            if (requestRetentionPropertiesIsNull)
            {
                request.RetentionProperties = null;
            }
            
             // populate Schema
            var requestSchemaIsNull = true;
            request.Schema = new Amazon.TimestreamWrite.Model.Schema();
            List<Amazon.TimestreamWrite.Model.PartitionKey> requestSchema_schema_CompositePartitionKey = null;
            if (cmdletContext.Schema_CompositePartitionKey != null)
            {
                requestSchema_schema_CompositePartitionKey = cmdletContext.Schema_CompositePartitionKey;
            }
            if (requestSchema_schema_CompositePartitionKey != null)
            {
                request.Schema.CompositePartitionKey = requestSchema_schema_CompositePartitionKey;
                requestSchemaIsNull = false;
            }
             // determine if request.Schema should be set to null
            if (requestSchemaIsNull)
            {
                request.Schema = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.TimestreamWrite.Model.CreateTableResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "CreateTable");
            try
            {
                return client.CreateTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.Boolean? MagneticStoreWriteProperties_EnableMagneticStoreWrite { get; set; }
            public System.String S3Configuration_BucketName { get; set; }
            public Amazon.TimestreamWrite.S3EncryptionOption S3Configuration_EncryptionOption { get; set; }
            public System.String S3Configuration_KmsKeyId { get; set; }
            public System.String S3Configuration_ObjectKeyPrefix { get; set; }
            public System.Int64? RetentionProperties_MagneticStoreRetentionPeriodInDay { get; set; }
            public System.Int64? RetentionProperties_MemoryStoreRetentionPeriodInHour { get; set; }
            public List<Amazon.TimestreamWrite.Model.PartitionKey> Schema_CompositePartitionKey { get; set; }
            public System.String TableName { get; set; }
            public List<Amazon.TimestreamWrite.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.CreateTableResponse, NewTSWTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Table;
        }
        
    }
}
