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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Disables enhanced monitoring.
    /// </summary>
    [Cmdlet("Disable", "KINEnhancedMonitoring", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis DisableEnhancedMonitoring API operation.", Operation = new[] {"DisableEnhancedMonitoring"}, SelectReturnType = typeof(Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableKINEnhancedMonitoringCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ShardLevelMetric
        /// <summary>
        /// <para>
        /// <para>List of shard-level metrics to disable.</para><para>The following are the valid shard-level metrics. The value "<code>ALL</code>" disables
        /// every metric.</para><ul><li><para><code>IncomingBytes</code></para></li><li><para><code>IncomingRecords</code></para></li><li><para><code>OutgoingBytes</code></para></li><li><para><code>OutgoingRecords</code></para></li><li><para><code>WriteProvisionedThroughputExceeded</code></para></li><li><para><code>ReadProvisionedThroughputExceeded</code></para></li><li><para><code>IteratorAgeMilliseconds</code></para></li><li><para><code>ALL</code></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/monitoring-with-cloudwatch.html">Monitoring
        /// the Amazon Kinesis Data Streams Service with Amazon CloudWatch</a> in the <i>Amazon
        /// Kinesis Data Streams Developer Guide</i>.</para>
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
        [Alias("ShardLevelMetrics")]
        public System.String[] ShardLevelMetric { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Kinesis data stream for which to disable enhanced monitoring.</para>
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
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-KINEnhancedMonitoring (DisableEnhancedMonitoring)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse, DisableKINEnhancedMonitoringCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ShardLevelMetric != null)
            {
                context.ShardLevelMetric = new List<System.String>(this.ShardLevelMetric);
            }
            #if MODULAR
            if (this.ShardLevelMetric == null && ParameterWasBound(nameof(this.ShardLevelMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardLevelMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamName = this.StreamName;
            #if MODULAR
            if (this.StreamName == null && ParameterWasBound(nameof(this.StreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.DisableEnhancedMonitoringRequest();
            
            if (cmdletContext.ShardLevelMetric != null)
            {
                request.ShardLevelMetrics = cmdletContext.ShardLevelMetric;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DisableEnhancedMonitoringRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DisableEnhancedMonitoring");
            try
            {
                #if DESKTOP
                return client.DisableEnhancedMonitoring(request);
                #elif CORECLR
                return client.DisableEnhancedMonitoringAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ShardLevelMetric { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.DisableEnhancedMonitoringResponse, DisableKINEnhancedMonitoringCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
