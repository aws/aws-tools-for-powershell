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
using Amazon.SageMakerFeatureStoreRuntime;
using Amazon.SageMakerFeatureStoreRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.SMFS
{
    /// <summary>
    /// The <code>PutRecord</code> API is used to ingest a list of <code>Records</code> into
    /// your feature group. 
    /// 
    ///  
    /// <para>
    /// If a new record’s <code>EventTime</code> is greater, the new record is written to
    /// both the <code>OnlineStore</code> and <code>OfflineStore</code>. Otherwise, the record
    /// is a historic record and it is written only to the <code>OfflineStore</code>. 
    /// </para><para>
    /// You can specify the ingestion to be applied to the <code>OnlineStore</code>, <code>OfflineStore</code>,
    /// or both by using the <code>TargetStores</code> request parameter. 
    /// </para><para>
    /// You can set the ingested record to expire at a given time to live (TTL) duration after
    /// the record’s event time, <code>ExpiresAt</code> = <code>EventTime</code> + <code>TtlDuration</code>,
    /// by specifying the <code>TtlDuration</code> parameter. A record level <code>TtlDuration</code>
    /// is set when specifying the <code>TtlDuration</code> parameter using the <code>PutRecord</code>
    /// API call. If the input <code>TtlDuration</code> is <code>null</code> or unspecified,
    /// <code>TtlDuration</code> is set to the default feature group level <code>TtlDuration</code>.
    /// A record level <code>TtlDuration</code> supersedes the group level <code>TtlDuration</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SMFSRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime PutRecord API operation.", Operation = new[] {"PutRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse))]
    [AWSCmdletOutput("None or Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSMFSRecordCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the feature group that you want to insert
        /// the record into.</para>
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
        public System.String FeatureGroupName { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>List of FeatureValues to be inserted. This will be a full over-write. If you only
        /// want to update few of the feature values, do the following:</para><ul><li><para>Use <code>GetRecord</code> to retrieve the latest record.</para></li><li><para>Update the record returned from <code>GetRecord</code>. </para></li><li><para>Use <code>PutRecord</code> to update feature values.</para></li></ul>
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
        public Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue[] Record { get; set; }
        #endregion
        
        #region Parameter TargetStore
        /// <summary>
        /// <para>
        /// <para>A list of stores to which you're adding the record. By default, Feature Store adds
        /// the record to all of the stores that you're using for the <code>FeatureGroup</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetStores")]
        public System.String[] TargetStore { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Unit
        /// <summary>
        /// <para>
        /// <para><code>TtlDuration</code> time unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit")]
        public Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit TtlDuration_Unit { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Value
        /// <summary>
        /// <para>
        /// <para><code>TtlDuration</code> time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TtlDuration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMFSRecord (PutRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse, WriteSMFSRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Record != null)
            {
                context.Record = new List<Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetStore != null)
            {
                context.TargetStore = new List<System.String>(this.TargetStore);
            }
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordRequest();
            
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            if (cmdletContext.Record != null)
            {
                request.Record = cmdletContext.Record;
            }
            if (cmdletContext.TargetStore != null)
            {
                request.TargetStores = cmdletContext.TargetStore;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "PutRecord");
            try
            {
                #if DESKTOP
                return client.PutRecord(request);
                #elif CORECLR
                return client.PutRecordAsync(request).GetAwaiter().GetResult();
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
            public System.String FeatureGroupName { get; set; }
            public List<Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue> Record { get; set; }
            public List<System.String> TargetStore { get; set; }
            public Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit TtlDuration_Unit { get; set; }
            public System.Int32? TtlDuration_Value { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.PutRecordResponse, WriteSMFSRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
