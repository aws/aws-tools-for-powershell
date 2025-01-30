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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Updates cluster broker volume size (or) sets cluster storage mode to TIERED.
    /// </summary>
    [Cmdlet("Update", "MSKStorage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateStorageResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateStorage API operation.", Operation = new[] {"UpdateStorage"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateStorageResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateStorageResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateStorageResponse object containing multiple properties."
    )]
    public partial class UpdateMSKStorageCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the cluster to be updated.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The version of cluster to update from. A successful operation will then generate a
        /// new version.</para>
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
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughput_Enabled
        /// <summary>
        /// <para>
        /// <para>Provisioned throughput is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProvisionedThroughput_Enabled { get; set; }
        #endregion
        
        #region Parameter StorageMode
        /// <summary>
        /// <para>
        /// <para>Controls storage mode for supported storage tiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.StorageMode")]
        public Amazon.Kafka.StorageMode StorageMode { get; set; }
        #endregion
        
        #region Parameter VolumeSizeGB
        /// <summary>
        /// <para>
        /// <para>size of the EBS volume to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VolumeSizeGB { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughput_VolumeThroughput
        /// <summary>
        /// <para>
        /// <para>Throughput value of the EBS volumes for the data drive on each kafka broker node in
        /// MiB per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisionedThroughput_VolumeThroughput { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateStorageResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateStorageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKStorage (UpdateStorage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateStorageResponse, UpdateMSKStorageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedThroughput_Enabled = this.ProvisionedThroughput_Enabled;
            context.ProvisionedThroughput_VolumeThroughput = this.ProvisionedThroughput_VolumeThroughput;
            context.StorageMode = this.StorageMode;
            context.VolumeSizeGB = this.VolumeSizeGB;
            
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
            var request = new Amazon.Kafka.Model.UpdateStorageRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
            }
            
             // populate ProvisionedThroughput
            var requestProvisionedThroughputIsNull = true;
            request.ProvisionedThroughput = new Amazon.Kafka.Model.ProvisionedThroughput();
            System.Boolean? requestProvisionedThroughput_provisionedThroughput_Enabled = null;
            if (cmdletContext.ProvisionedThroughput_Enabled != null)
            {
                requestProvisionedThroughput_provisionedThroughput_Enabled = cmdletContext.ProvisionedThroughput_Enabled.Value;
            }
            if (requestProvisionedThroughput_provisionedThroughput_Enabled != null)
            {
                request.ProvisionedThroughput.Enabled = requestProvisionedThroughput_provisionedThroughput_Enabled.Value;
                requestProvisionedThroughputIsNull = false;
            }
            System.Int32? requestProvisionedThroughput_provisionedThroughput_VolumeThroughput = null;
            if (cmdletContext.ProvisionedThroughput_VolumeThroughput != null)
            {
                requestProvisionedThroughput_provisionedThroughput_VolumeThroughput = cmdletContext.ProvisionedThroughput_VolumeThroughput.Value;
            }
            if (requestProvisionedThroughput_provisionedThroughput_VolumeThroughput != null)
            {
                request.ProvisionedThroughput.VolumeThroughput = requestProvisionedThroughput_provisionedThroughput_VolumeThroughput.Value;
                requestProvisionedThroughputIsNull = false;
            }
             // determine if request.ProvisionedThroughput should be set to null
            if (requestProvisionedThroughputIsNull)
            {
                request.ProvisionedThroughput = null;
            }
            if (cmdletContext.StorageMode != null)
            {
                request.StorageMode = cmdletContext.StorageMode;
            }
            if (cmdletContext.VolumeSizeGB != null)
            {
                request.VolumeSizeGB = cmdletContext.VolumeSizeGB.Value;
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
        
        private Amazon.Kafka.Model.UpdateStorageResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateStorageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateStorage");
            try
            {
                #if DESKTOP
                return client.UpdateStorage(request);
                #elif CORECLR
                return client.UpdateStorageAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.Boolean? ProvisionedThroughput_Enabled { get; set; }
            public System.Int32? ProvisionedThroughput_VolumeThroughput { get; set; }
            public Amazon.Kafka.StorageMode StorageMode { get; set; }
            public System.Int32? VolumeSizeGB { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateStorageResponse, UpdateMSKStorageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
