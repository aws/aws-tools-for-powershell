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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates the feature group by either adding features or updating the online store configuration.
    /// Use one of the following request parameters at a time while using the <code>UpdateFeatureGroup</code>
    /// API.
    /// 
    ///  
    /// <para>
    /// You can add features for your feature group using the <code>FeatureAdditions</code>
    /// request parameter. Features cannot be removed from a feature group.
    /// </para><para>
    /// You can update the online store configuration by using the <code>OnlineStoreConfig</code>
    /// request parameter. If a <code>TtlDuration</code> is specified, the default <code>TtlDuration</code>
    /// applies for all records added to the feature group <i>after the feature group is updated</i>.
    /// If a record level <code>TtlDuration</code> exists from using the <code>PutRecord</code>
    /// API, the record level <code>TtlDuration</code> applies to that record instead of the
    /// default <code>TtlDuration</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMFeatureGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateFeatureGroup API operation.", Operation = new[] {"UpdateFeatureGroup"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateFeatureGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateFeatureGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateFeatureGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMFeatureGroupCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FeatureAddition
        /// <summary>
        /// <para>
        /// <para>Updates the feature group. Updating a feature group is an asynchronous operation.
        /// When you get an HTTP 200 response, you've made a valid request. It takes some time
        /// after you've made a valid request for Feature Store to update the feature group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeatureAdditions")]
        public Amazon.SageMaker.Model.FeatureDefinition[] FeatureAddition { get; set; }
        #endregion
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the feature group that you're updating.</para>
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
        public System.String FeatureGroupName { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ProvisionedReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>For provisioned feature groups with online store enabled, this indicates the read
        /// throughput you are billed for and can consume without throttling. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThroughputConfig_ProvisionedReadCapacityUnits")]
        public System.Int32? ThroughputConfig_ProvisionedReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ProvisionedWriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>For provisioned feature groups, this indicates the write throughput you are billed
        /// for and can consume without throttling. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThroughputConfig_ProvisionedWriteCapacityUnits")]
        public System.Int32? ThroughputConfig_ProvisionedWriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>Target throughput mode of the feature group. Throughput update is an asynchronous
        /// operation, and the outcome should be monitored by polling <code>LastUpdateStatus</code>
        /// field in <code>DescribeFeatureGroup</code> response. You cannot update a feature group's
        /// throughput while another update is in progress. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ThroughputMode")]
        public Amazon.SageMaker.ThroughputMode ThroughputConfig_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Unit
        /// <summary>
        /// <para>
        /// <para><code>TtlDuration</code> time unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_TtlDuration_Unit")]
        [AWSConstantClassSource("Amazon.SageMaker.TtlDurationUnit")]
        public Amazon.SageMaker.TtlDurationUnit TtlDuration_Unit { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Value
        /// <summary>
        /// <para>
        /// <para><code>TtlDuration</code> time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_TtlDuration_Value")]
        public System.Int32? TtlDuration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FeatureGroupArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateFeatureGroupResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateFeatureGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FeatureGroupArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FeatureGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FeatureGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FeatureGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMFeatureGroup (UpdateFeatureGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateFeatureGroupResponse, UpdateSMFeatureGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FeatureGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FeatureAddition != null)
            {
                context.FeatureAddition = new List<Amazon.SageMaker.Model.FeatureDefinition>(this.FeatureAddition);
            }
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TtlDuration_Unit = this.TtlDuration_Unit;
            context.TtlDuration_Value = this.TtlDuration_Value;
            context.ThroughputConfig_ProvisionedReadCapacityUnit = this.ThroughputConfig_ProvisionedReadCapacityUnit;
            context.ThroughputConfig_ProvisionedWriteCapacityUnit = this.ThroughputConfig_ProvisionedWriteCapacityUnit;
            context.ThroughputConfig_ThroughputMode = this.ThroughputConfig_ThroughputMode;
            
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
            var request = new Amazon.SageMaker.Model.UpdateFeatureGroupRequest();
            
            if (cmdletContext.FeatureAddition != null)
            {
                request.FeatureAdditions = cmdletContext.FeatureAddition;
            }
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            
             // populate OnlineStoreConfig
            var requestOnlineStoreConfigIsNull = true;
            request.OnlineStoreConfig = new Amazon.SageMaker.Model.OnlineStoreConfigUpdate();
            Amazon.SageMaker.Model.TtlDuration requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = null;
            
             // populate TtlDuration
            var requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = true;
            requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = new Amazon.SageMaker.Model.TtlDuration();
            Amazon.SageMaker.TtlDurationUnit requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit = null;
            if (cmdletContext.TtlDuration_Unit != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit = cmdletContext.TtlDuration_Unit;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration.Unit = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit;
                requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = false;
            }
            System.Int32? requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value = null;
            if (cmdletContext.TtlDuration_Value != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value = cmdletContext.TtlDuration_Value.Value;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration.Value = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value.Value;
                requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = false;
            }
             // determine if requestOnlineStoreConfig_onlineStoreConfig_TtlDuration should be set to null
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = null;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration != null)
            {
                request.OnlineStoreConfig.TtlDuration = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration;
                requestOnlineStoreConfigIsNull = false;
            }
             // determine if request.OnlineStoreConfig should be set to null
            if (requestOnlineStoreConfigIsNull)
            {
                request.OnlineStoreConfig = null;
            }
            
             // populate ThroughputConfig
            var requestThroughputConfigIsNull = true;
            request.ThroughputConfig = new Amazon.SageMaker.Model.ThroughputConfigUpdate();
            System.Int32? requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit = null;
            if (cmdletContext.ThroughputConfig_ProvisionedReadCapacityUnit != null)
            {
                requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit = cmdletContext.ThroughputConfig_ProvisionedReadCapacityUnit.Value;
            }
            if (requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit != null)
            {
                request.ThroughputConfig.ProvisionedReadCapacityUnits = requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit.Value;
                requestThroughputConfigIsNull = false;
            }
            System.Int32? requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit = null;
            if (cmdletContext.ThroughputConfig_ProvisionedWriteCapacityUnit != null)
            {
                requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit = cmdletContext.ThroughputConfig_ProvisionedWriteCapacityUnit.Value;
            }
            if (requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit != null)
            {
                request.ThroughputConfig.ProvisionedWriteCapacityUnits = requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit.Value;
                requestThroughputConfigIsNull = false;
            }
            Amazon.SageMaker.ThroughputMode requestThroughputConfig_throughputConfig_ThroughputMode = null;
            if (cmdletContext.ThroughputConfig_ThroughputMode != null)
            {
                requestThroughputConfig_throughputConfig_ThroughputMode = cmdletContext.ThroughputConfig_ThroughputMode;
            }
            if (requestThroughputConfig_throughputConfig_ThroughputMode != null)
            {
                request.ThroughputConfig.ThroughputMode = requestThroughputConfig_throughputConfig_ThroughputMode;
                requestThroughputConfigIsNull = false;
            }
             // determine if request.ThroughputConfig should be set to null
            if (requestThroughputConfigIsNull)
            {
                request.ThroughputConfig = null;
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
        
        private Amazon.SageMaker.Model.UpdateFeatureGroupResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateFeatureGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateFeatureGroup");
            try
            {
                #if DESKTOP
                return client.UpdateFeatureGroup(request);
                #elif CORECLR
                return client.UpdateFeatureGroupAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.FeatureDefinition> FeatureAddition { get; set; }
            public System.String FeatureGroupName { get; set; }
            public Amazon.SageMaker.TtlDurationUnit TtlDuration_Unit { get; set; }
            public System.Int32? TtlDuration_Value { get; set; }
            public System.Int32? ThroughputConfig_ProvisionedReadCapacityUnit { get; set; }
            public System.Int32? ThroughputConfig_ProvisionedWriteCapacityUnit { get; set; }
            public Amazon.SageMaker.ThroughputMode ThroughputConfig_ThroughputMode { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateFeatureGroupResponse, UpdateSMFeatureGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FeatureGroupArn;
        }
        
    }
}
