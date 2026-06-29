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
using Amazon.SageMakerFeatureStoreRuntime;
using Amazon.SageMakerFeatureStoreRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMFS
{
    /// <summary>
    /// Writes a batch of <c>Records</c> to one or more <c>FeatureGroup</c>s. Use this API
    /// for bulk ingestion of records into the <c>OnlineStore</c> and <c>OfflineStore</c>.
    /// 
    ///  
    /// <para>
    /// You can set the ingested records to expire at a given time to live (TTL) duration
    /// after the record's event time by specifying the <c>TtlDuration</c> parameter. A request
    /// level <c>TtlDuration</c> applies to all entries that do not specify their own <c>TtlDuration</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SMFSRecordBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime BatchWriteRecord API operation.", Operation = new[] {"BatchWriteRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse))]
    [AWSCmdletOutput("Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse",
        "This cmdlet returns an Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse object containing multiple properties."
    )]
    public partial class WriteSMFSRecordBatchCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>A list of records to write. Each entry specifies the <c>FeatureGroup</c>, the record
        /// data, and optionally target stores and a TTL duration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Entries")]
        public Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Unit
        /// <summary>
        /// <para>
        /// <para><c>TtlDuration</c> time unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit")]
        public Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit TtlDuration_Unit { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Value
        /// <summary>
        /// <para>
        /// <para><c>TtlDuration</c> time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TtlDuration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse).
        /// Specifying the name of a property of type Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMFSRecordBatch (BatchWriteRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse, WriteSMFSRecordBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TtlDuration_Unit = this.TtlDuration_Unit;
            context.TtlDuration_Value = this.TtlDuration_Value;
            
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordRequest();
            
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
            }
            
             // populate TtlDuration
            var requestTtlDurationIsNull = true;
            request.TtlDuration = new Amazon.SageMakerFeatureStoreRuntime.Model.TtlDuration();
            Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit requestTtlDuration_ttlDuration_Unit = null;
            if (cmdletContext.TtlDuration_Unit != null)
            {
                requestTtlDuration_ttlDuration_Unit = cmdletContext.TtlDuration_Unit;
            }
            if (requestTtlDuration_ttlDuration_Unit != null)
            {
                request.TtlDuration.Unit = requestTtlDuration_ttlDuration_Unit;
                requestTtlDurationIsNull = false;
            }
            System.Int32? requestTtlDuration_ttlDuration_Value = null;
            if (cmdletContext.TtlDuration_Value != null)
            {
                requestTtlDuration_ttlDuration_Value = cmdletContext.TtlDuration_Value.Value;
            }
            if (requestTtlDuration_ttlDuration_Value != null)
            {
                request.TtlDuration.Value = requestTtlDuration_ttlDuration_Value.Value;
                requestTtlDurationIsNull = false;
            }
             // determine if request.TtlDuration should be set to null
            if (requestTtlDurationIsNull)
            {
                request.TtlDuration = null;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "BatchWriteRecord");
            try
            {
                return client.BatchWriteRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordEntry> Entry { get; set; }
            public Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit TtlDuration_Unit { get; set; }
            public System.Int32? TtlDuration_Value { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.BatchWriteRecordResponse, WriteSMFSRecordBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
