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
    /// Updates one or more feature values for an existing record in the specified feature
    /// group. Features that you do not include in the request remain unchanged. You can update
    /// up to 100 features per call.
    /// 
    ///  <important><para>
    /// This operation is available only for feature groups that use the <c>Standard_V2</c>
    /// or <c>InMemory</c> online store type.
    /// </para></important><para>
    /// The record must already exist. If the record does not exist or has been soft-deleted,
    /// the operation returns a <c>ResourceNotFound</c> error. To create a record, use <c>PutRecord</c>.
    /// </para><para>
    /// If you provide an <c>EventTime</c> that is older than the record's current <c>EventTime</c>,
    /// the service rejects the update with a <c>ConflictException</c>. If the <c>EventTime</c>
    /// is equal to or newer than the current value, the service applies the update. If you
    /// omit <c>EventTime</c>, the service keeps the record's existing <c>EventTime</c> and
    /// applies the update.
    /// </para><para>
    /// If you specify a <c>TtlDuration</c>, you must also provide an <c>EventTime</c> in
    /// the request. Otherwise, the operation returns a <c>ValidationError</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMFSRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime UpdateRecord API operation.", Operation = new[] {"UpdateRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse))]
    [AWSCmdletOutput("None or Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMFSRecordCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The identifier for the feature group that contains the record to update. You can specify
        /// one of the following:</para><ul><li><para>The feature group name.</para></li><li><para>The feature group Amazon Resource Name (ARN).</para></li></ul>
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
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>The feature values to write to the record.</para><para />
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
        [Alias("Features")]
        public Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue[] Feature { get; set; }
        #endregion
        
        #region Parameter RecordIdentifierValueAsString
        /// <summary>
        /// <para>
        /// <para>The value that uniquely identifies the record in the feature group. This must match
        /// the value defined by the feature group's record identifier feature.</para>
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
        public System.String RecordIdentifierValueAsString { get; set; }
        #endregion
        
        #region Parameter TargetStore
        /// <summary>
        /// <para>
        /// <para>The target stores for the record update. By default, Amazon SageMaker Feature Store
        /// updates the record in all stores associated with the <c>FeatureGroup</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetStores")]
        public System.String[] TargetStore { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMFSRecord (UpdateRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse, UpdateSMFSRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Feature != null)
            {
                context.Feature = new List<Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue>(this.Feature);
            }
            #if MODULAR
            if (this.Feature == null && ParameterWasBound(nameof(this.Feature)))
            {
                WriteWarning("You are passing $null as a value for parameter Feature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordIdentifierValueAsString = this.RecordIdentifierValueAsString;
            #if MODULAR
            if (this.RecordIdentifierValueAsString == null && ParameterWasBound(nameof(this.RecordIdentifierValueAsString)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordIdentifierValueAsString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordRequest();
            
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
            }
            if (cmdletContext.RecordIdentifierValueAsString != null)
            {
                request.RecordIdentifierValueAsString = cmdletContext.RecordIdentifierValueAsString;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "UpdateRecord");
            try
            {
                return client.UpdateRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue> Feature { get; set; }
            public System.String RecordIdentifierValueAsString { get; set; }
            public List<System.String> TargetStore { get; set; }
            public Amazon.SageMakerFeatureStoreRuntime.TtlDurationUnit TtlDuration_Unit { get; set; }
            public System.Int32? TtlDuration_Value { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.UpdateRecordResponse, UpdateSMFSRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
