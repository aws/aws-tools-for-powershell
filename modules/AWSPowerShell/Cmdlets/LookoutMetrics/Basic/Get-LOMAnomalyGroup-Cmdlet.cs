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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Returns details about a group of anomalous metrics.
    /// </summary>
    [Cmdlet("Get", "LOMAnomalyGroup")]
    [OutputType("Amazon.LookoutMetrics.Model.AnomalyGroup")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics GetAnomalyGroup API operation.", Operation = new[] {"GetAnomalyGroup"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.AnomalyGroup or Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse",
        "This cmdlet returns an Amazon.LookoutMetrics.Model.AnomalyGroup object.",
        "The service call response (type Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLOMAnomalyGroupCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the anomaly detector.</para>
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
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter AnomalyGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the anomaly group.</para>
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
        public System.String AnomalyGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnomalyGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnomalyGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnomalyGroupId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse, GetLOMAnomalyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnomalyGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupId = this.AnomalyGroupId;
            #if MODULAR
            if (this.AnomalyGroupId == null && ParameterWasBound(nameof(this.AnomalyGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutMetrics.Model.GetAnomalyGroupRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            if (cmdletContext.AnomalyGroupId != null)
            {
                request.AnomalyGroupId = cmdletContext.AnomalyGroupId;
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
        
        private Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.GetAnomalyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "GetAnomalyGroup");
            try
            {
                #if DESKTOP
                return client.GetAnomalyGroup(request);
                #elif CORECLR
                return client.GetAnomalyGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorArn { get; set; }
            public System.String AnomalyGroupId { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.GetAnomalyGroupResponse, GetLOMAnomalyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyGroup;
        }
        
    }
}
