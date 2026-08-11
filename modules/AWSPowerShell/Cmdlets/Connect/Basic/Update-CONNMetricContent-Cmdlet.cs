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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the calculation, unit, and/or trend indicator of an existing metric in the
    /// specified Connect Customer instance.
    /// </summary>
    [Cmdlet("Update", "CONNMetricContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateMetricContent API operation.", Operation = new[] {"UpdateMetricContent"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateMetricContentResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateMetricContentResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateMetricContentResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNMetricContentCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetricCalculation_Calculation
        /// <summary>
        /// <para>
        /// <para>The formula expression that defines how the metric is calculated. Uses component aliases
        /// (for example, <c>100 * SUM(M1) / SUM(M2)</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricCalculation_Calculation { get; set; }
        #endregion
        
        #region Parameter MetricCalculation_CalculationComponent
        /// <summary>
        /// <para>
        /// <para>The list of component metrics referenced in the calculation formula. Each component
        /// has an alias used in the formula expression.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricCalculation_CalculationComponents")]
        public Amazon.Connect.Model.CalculationComponent[] MetricCalculation_CalculationComponent { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MetricId
        /// <summary>
        /// <para>
        /// <para>The identifier of the metric to update. Adding the <c>$SAVED</c> qualifier will update
        /// the saved version of the metric. Adding <c>$LATEST</c> or omitting a qualifier will
        /// update the published version.</para>
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
        public System.String MetricId { get; set; }
        #endregion
        
        #region Parameter PositiveTrendIndicator
        /// <summary>
        /// <para>
        /// <para>How an increase in the metric value should be interpreted. Valid values: <c>POSITIVE</c>,
        /// <c>NEUTRAL</c>, <c>NEGATIVE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.TrendIndicator")]
        public Amazon.Connect.TrendIndicator PositiveTrendIndicator { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The updated display unit for the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.MetricUnit")]
        public Amazon.Connect.MetricUnit Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateMetricContentResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.InstanceId),
                nameof(this.MetricId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNMetricContent (UpdateMetricContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateMetricContentResponse, UpdateCONNMetricContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricCalculation_Calculation = this.MetricCalculation_Calculation;
            if (this.MetricCalculation_CalculationComponent != null)
            {
                context.MetricCalculation_CalculationComponent = new List<Amazon.Connect.Model.CalculationComponent>(this.MetricCalculation_CalculationComponent);
            }
            context.MetricId = this.MetricId;
            #if MODULAR
            if (this.MetricId == null && ParameterWasBound(nameof(this.MetricId)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PositiveTrendIndicator = this.PositiveTrendIndicator;
            context.Unit = this.Unit;
            
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
            var request = new Amazon.Connect.Model.UpdateMetricContentRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate MetricCalculation
            var requestMetricCalculationIsNull = true;
            request.MetricCalculation = new Amazon.Connect.Model.MetricCalculation();
            System.String requestMetricCalculation_metricCalculation_Calculation = null;
            if (cmdletContext.MetricCalculation_Calculation != null)
            {
                requestMetricCalculation_metricCalculation_Calculation = cmdletContext.MetricCalculation_Calculation;
            }
            if (requestMetricCalculation_metricCalculation_Calculation != null)
            {
                request.MetricCalculation.Calculation = requestMetricCalculation_metricCalculation_Calculation;
                requestMetricCalculationIsNull = false;
            }
            List<Amazon.Connect.Model.CalculationComponent> requestMetricCalculation_metricCalculation_CalculationComponent = null;
            if (cmdletContext.MetricCalculation_CalculationComponent != null)
            {
                requestMetricCalculation_metricCalculation_CalculationComponent = cmdletContext.MetricCalculation_CalculationComponent;
            }
            if (requestMetricCalculation_metricCalculation_CalculationComponent != null)
            {
                request.MetricCalculation.CalculationComponents = requestMetricCalculation_metricCalculation_CalculationComponent;
                requestMetricCalculationIsNull = false;
            }
             // determine if request.MetricCalculation should be set to null
            if (requestMetricCalculationIsNull)
            {
                request.MetricCalculation = null;
            }
            if (cmdletContext.MetricId != null)
            {
                request.MetricId = cmdletContext.MetricId;
            }
            if (cmdletContext.PositiveTrendIndicator != null)
            {
                request.PositiveTrendIndicator = cmdletContext.PositiveTrendIndicator;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
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
        
        private Amazon.Connect.Model.UpdateMetricContentResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateMetricContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateMetricContent");
            try
            {
                return client.UpdateMetricContentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String MetricCalculation_Calculation { get; set; }
            public List<Amazon.Connect.Model.CalculationComponent> MetricCalculation_CalculationComponent { get; set; }
            public System.String MetricId { get; set; }
            public Amazon.Connect.TrendIndicator PositiveTrendIndicator { get; set; }
            public Amazon.Connect.MetricUnit Unit { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateMetricContentResponse, UpdateCONNMetricContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
