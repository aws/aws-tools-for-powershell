/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Enables enhanced Kinesis data stream monitoring for shard-level metrics.
    /// </summary>
    [Cmdlet("Enable", "KINEnhancedMonitoring", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.EnableEnhancedMonitoringResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis EnableEnhancedMonitoring API operation.", Operation = new[] {"EnableEnhancedMonitoring"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.EnableEnhancedMonitoringResponse",
        "This cmdlet returns a Amazon.Kinesis.Model.EnableEnhancedMonitoringResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableKINEnhancedMonitoringCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ShardLevelMetric
        /// <summary>
        /// <para>
        /// <para>List of shard-level metrics to enable.</para><para>The following are the valid shard-level metrics. The value "<code>ALL</code>" enables
        /// every metric.</para><ul><li><para><code>IncomingBytes</code></para></li><li><para><code>IncomingRecords</code></para></li><li><para><code>OutgoingBytes</code></para></li><li><para><code>OutgoingRecords</code></para></li><li><para><code>WriteProvisionedThroughputExceeded</code></para></li><li><para><code>ReadProvisionedThroughputExceeded</code></para></li><li><para><code>IteratorAgeMilliseconds</code></para></li><li><para><code>ALL</code></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/monitoring-with-cloudwatch.html">Monitoring
        /// the Amazon Kinesis Data Streams Service with Amazon CloudWatch</a> in the <i>Amazon
        /// Kinesis Data Streams Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ShardLevelMetrics")]
        public System.String[] ShardLevelMetric { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream for which to enable enhanced monitoring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-KINEnhancedMonitoring (EnableEnhancedMonitoring)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.ShardLevelMetric != null)
            {
                context.ShardLevelMetrics = new List<System.String>(this.ShardLevelMetric);
            }
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.Kinesis.Model.EnableEnhancedMonitoringRequest();
            
            if (cmdletContext.ShardLevelMetrics != null)
            {
                request.ShardLevelMetrics = cmdletContext.ShardLevelMetrics;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Kinesis.Model.EnableEnhancedMonitoringResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.EnableEnhancedMonitoringRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "EnableEnhancedMonitoring");
            try
            {
                #if DESKTOP
                return client.EnableEnhancedMonitoring(request);
                #elif CORECLR
                return client.EnableEnhancedMonitoringAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ShardLevelMetrics { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
