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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Retrieves the list of metrics and dimensions that a RUM app monitor is sending to
    /// a single destination.
    /// </summary>
    [Cmdlet("Get", "CWRUMGetRumMetricDefinition")]
    [OutputType("Amazon.CloudWatchRUM.Model.MetricDefinition")]
    [AWSCmdlet("Calls the CloudWatch RUM BatchGetRumMetricDefinitions API operation.", Operation = new[] {"BatchGetRumMetricDefinitions"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchRUM.Model.MetricDefinition or Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchRUM.Model.MetricDefinition objects.",
        "The service call response (type Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWRUMGetRumMetricDefinitionCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch RUM app monitor that is sending the metrics.</para>
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
        public System.String AppMonitorName { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The type of destination that you want to view metrics for. Valid values are <c>CloudWatch</c>
        /// and <c>Evidently</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchRUM.MetricDestination")]
        public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>This parameter is required if <c>Destination</c> is <c>Evidently</c>. If <c>Destination</c>
        /// is <c>CloudWatch</c>, do not use this parameter.</para><para>This parameter specifies the ARN of the Evidently experiment that corresponds to the
        /// destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one operation. The default is 50. The maximum
        /// that you can specify is 100.</para><para>To retrieve the remaining results, make another call with the returned <c>NextToken</c>
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use the token returned by the previous operation to request the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricDefinitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricDefinitions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Destination parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Destination' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Destination' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse, GetCWRUMGetRumMetricDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Destination;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppMonitorName = this.AppMonitorName;
            #if MODULAR
            if (this.AppMonitorName == null && ParameterWasBound(nameof(this.AppMonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppMonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationArn = this.DestinationArn;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsRequest();
            
            if (cmdletContext.AppMonitorName != null)
            {
                request.AppMonitorName = cmdletContext.AppMonitorName;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "BatchGetRumMetricDefinitions");
            try
            {
                #if DESKTOP
                return client.BatchGetRumMetricDefinitions(request);
                #elif CORECLR
                return client.BatchGetRumMetricDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public System.String AppMonitorName { get; set; }
            public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
            public System.String DestinationArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.BatchGetRumMetricDefinitionsResponse, GetCWRUMGetRumMetricDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricDefinitions;
        }
        
    }
}
