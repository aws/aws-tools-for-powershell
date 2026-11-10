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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Sets, updates, or removes the server access logging configuration for a table bucket.
    /// When logging is enabled, Amazon S3 delivers a record of the requests made to the table
    /// bucket and its tables to the target general purpose bucket that you specify. To disable
    /// logging, call this operation with an empty <c>tableBucketLoggingStatus</c>. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-server-logs.html">Server
    /// access logging for table buckets</a> in the <i>Amazon Simple Storage Service User
    /// Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:PutTableBucketLogging</c> permission to use this operation.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableBucketLogging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableBucketLogging API operation.", Operation = new[] {"PutTableBucketLogging"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableBucketLoggingResponse))]
    [AWSCmdletOutput("None or Amazon.S3Tables.Model.PutTableBucketLoggingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Tables.Model.PutTableBucketLoggingResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3TTableBucketLoggingCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource
        /// <summary>
        /// <para>
        /// <para>The date to use for the log object key partitions. Valid values are <c>EventTime</c>,
        /// the time that the requests in the log were made, and <c>DeliveryTime</c>, the time
        /// that the log was delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.PartitionDateSource")]
        public Amazon.S3Tables.PartitionDateSource TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket.</para>
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter TableBucketLoggingStatus_LoggingEnabled_TargetBucket
        /// <summary>
        /// <para>
        /// <para>The name of the general purpose bucket that logs are delivered to. The bucket must
        /// be in the same Amazon Web Services Region and owned by the same Amazon Web Services
        /// account as the table bucket. The bucket can't use SSE-KMS or DSSE-KMS default encryption,
        /// can't have S3 Object Lock enabled, and can't have Requester Pays enabled. You can
        /// deliver logs from multiple table buckets to the same target bucket. In this case,
        /// choose a different <c>targetPrefix</c> for each table bucket so that you can tell
        /// their log objects apart.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableBucketLoggingStatus_LoggingEnabled_TargetBucket { get; set; }
        #endregion
        
        #region Parameter TableBucketLoggingStatus_LoggingEnabled_TargetPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the keys of the log objects that are delivered to the target bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableBucketLoggingStatus_LoggingEnabled_TargetPrefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableBucketLoggingResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableBucketARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableBucketLogging (PutTableBucketLogging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableBucketLoggingResponse, WriteS3TTableBucketLoggingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableBucketLoggingStatus_LoggingEnabled_TargetBucket = this.TableBucketLoggingStatus_LoggingEnabled_TargetBucket;
            context.TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource = this.TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource;
            context.TableBucketLoggingStatus_LoggingEnabled_TargetPrefix = this.TableBucketLoggingStatus_LoggingEnabled_TargetPrefix;
            
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
            var request = new Amazon.S3Tables.Model.PutTableBucketLoggingRequest();
            
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
            }
            
             // populate TableBucketLoggingStatus
            var requestTableBucketLoggingStatusIsNull = true;
            request.TableBucketLoggingStatus = new Amazon.S3Tables.Model.TableBucketLoggingStatus();
            Amazon.S3Tables.Model.LoggingEnabled requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled = null;
            
             // populate LoggingEnabled
            var requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabledIsNull = true;
            requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled = new Amazon.S3Tables.Model.LoggingEnabled();
            System.String requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetBucket = null;
            if (cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetBucket != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetBucket = cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetBucket;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetBucket != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled.TargetBucket = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetBucket;
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabledIsNull = false;
            }
            System.String requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetPrefix = null;
            if (cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetPrefix != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetPrefix = cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetPrefix;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetPrefix != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled.TargetPrefix = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetPrefix;
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabledIsNull = false;
            }
            Amazon.S3Tables.Model.TargetObjectKeyFormat requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat = null;
            
             // populate TargetObjectKeyFormat
            var requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormatIsNull = true;
            requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat = new Amazon.S3Tables.Model.TargetObjectKeyFormat();
            Amazon.S3Tables.Model.PartitionedPrefix requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix = null;
            
             // populate PartitionedPrefix
            var requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefixIsNull = true;
            requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix = new Amazon.S3Tables.Model.PartitionedPrefix();
            Amazon.S3Tables.PartitionDateSource requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource = null;
            if (cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource = cmdletContext.TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix.PartitionDateSource = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource;
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefixIsNull = false;
            }
             // determine if requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix should be set to null
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefixIsNull)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix = null;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat.PartitionedPrefix = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix;
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormatIsNull = false;
            }
             // determine if requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat should be set to null
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormatIsNull)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat = null;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat != null)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled.TargetObjectKeyFormat = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled_tableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat;
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabledIsNull = false;
            }
             // determine if requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled should be set to null
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabledIsNull)
            {
                requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled = null;
            }
            if (requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled != null)
            {
                request.TableBucketLoggingStatus.LoggingEnabled = requestTableBucketLoggingStatus_tableBucketLoggingStatus_LoggingEnabled;
                requestTableBucketLoggingStatusIsNull = false;
            }
             // determine if request.TableBucketLoggingStatus should be set to null
            if (requestTableBucketLoggingStatusIsNull)
            {
                request.TableBucketLoggingStatus = null;
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
        
        private Amazon.S3Tables.Model.PutTableBucketLoggingResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableBucketLoggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableBucketLogging");
            try
            {
                return client.PutTableBucketLoggingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TableBucketARN { get; set; }
            public System.String TableBucketLoggingStatus_LoggingEnabled_TargetBucket { get; set; }
            public Amazon.S3Tables.PartitionDateSource TableBucketLoggingStatus_LoggingEnabled_TargetObjectKeyFormat_PartitionedPrefix_PartitionDateSource { get; set; }
            public System.String TableBucketLoggingStatus_LoggingEnabled_TargetPrefix { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableBucketLoggingResponse, WriteS3TTableBucketLoggingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
