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
    /// Update the parameters of a model monitor alert.
    /// </summary>
    [Cmdlet("Update", "SMMonitoringAlert", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateMonitoringAlertResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateMonitoringAlert API operation.", Operation = new[] {"UpdateMonitoringAlert"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateMonitoringAlertResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateMonitoringAlertResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateMonitoringAlertResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMMonitoringAlertCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatapointsToAlert
        /// <summary>
        /// <para>
        /// <para>Within <c>EvaluationPeriod</c>, how many execution failures will raise an alert.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? DatapointsToAlert { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para>The number of most recent monitoring executions to consider when evaluating alert
        /// status.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter MonitoringAlertName
        /// <summary>
        /// <para>
        /// <para>The name of a monitoring alert.</para>
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
        public System.String MonitoringAlertName { get; set; }
        #endregion
        
        #region Parameter MonitoringScheduleName
        /// <summary>
        /// <para>
        /// <para>The name of a monitoring schedule.</para>
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
        public System.String MonitoringScheduleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateMonitoringAlertResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateMonitoringAlertResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMMonitoringAlert (UpdateMonitoringAlert)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateMonitoringAlertResponse, UpdateSMMonitoringAlertCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatapointsToAlert = this.DatapointsToAlert;
            #if MODULAR
            if (this.DatapointsToAlert == null && ParameterWasBound(nameof(this.DatapointsToAlert)))
            {
                WriteWarning("You are passing $null as a value for parameter DatapointsToAlert which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationPeriod = this.EvaluationPeriod;
            #if MODULAR
            if (this.EvaluationPeriod == null && ParameterWasBound(nameof(this.EvaluationPeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationPeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MonitoringAlertName = this.MonitoringAlertName;
            #if MODULAR
            if (this.MonitoringAlertName == null && ParameterWasBound(nameof(this.MonitoringAlertName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitoringAlertName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MonitoringScheduleName = this.MonitoringScheduleName;
            #if MODULAR
            if (this.MonitoringScheduleName == null && ParameterWasBound(nameof(this.MonitoringScheduleName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitoringScheduleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateMonitoringAlertRequest();
            
            if (cmdletContext.DatapointsToAlert != null)
            {
                request.DatapointsToAlert = cmdletContext.DatapointsToAlert.Value;
            }
            if (cmdletContext.EvaluationPeriod != null)
            {
                request.EvaluationPeriod = cmdletContext.EvaluationPeriod.Value;
            }
            if (cmdletContext.MonitoringAlertName != null)
            {
                request.MonitoringAlertName = cmdletContext.MonitoringAlertName;
            }
            if (cmdletContext.MonitoringScheduleName != null)
            {
                request.MonitoringScheduleName = cmdletContext.MonitoringScheduleName;
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
        
        private Amazon.SageMaker.Model.UpdateMonitoringAlertResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateMonitoringAlertRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateMonitoringAlert");
            try
            {
                #if DESKTOP
                return client.UpdateMonitoringAlert(request);
                #elif CORECLR
                return client.UpdateMonitoringAlertAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DatapointsToAlert { get; set; }
            public System.Int32? EvaluationPeriod { get; set; }
            public System.String MonitoringAlertName { get; set; }
            public System.String MonitoringScheduleName { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateMonitoringAlertResponse, UpdateSMMonitoringAlertCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
