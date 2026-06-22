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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Reports the status of one or more instrumentation configurations from SDK instances.
    /// Use this to record when configurations become ready, hit errors, become active, or
    /// are disabled by limits.
    /// 
    ///  
    /// <para>
    /// Report <c>READY</c>, <c>ERROR</c>, and <c>DISABLED</c> when the status changes. Report
    /// <c>ACTIVE</c> periodically (for example, every minute) while instrumentation is running.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWASInstrumentationConfigurationStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals ReportInstrumentationConfigurationStatus API operation.", Operation = new[] {"ReportInstrumentationConfigurationStatus"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse object containing multiple properties."
    )]
    public partial class WriteCWASInstrumentationConfigurationStatusCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>An array of configuration status reports (up to 100) that include the instrumentation
        /// type, signal type, location hash, status, timestamp, and optional error cause.</para><para />
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
        [Alias("Configurations")]
        public Amazon.ApplicationSignals.Model.InstrumentationConfigurationStatusReport[] Configuration { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment that the service is running in.</para>
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
        public System.String Environment { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The service that the reported configurations belong to.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWASInstrumentationConfigurationStatus (ReportInstrumentationConfigurationStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse, WriteCWASInstrumentationConfigurationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Configuration != null)
            {
                context.Configuration = new List<Amazon.ApplicationSignals.Model.InstrumentationConfigurationStatusReport>(this.Configuration);
            }
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Environment = this.Environment;
            #if MODULAR
            if (this.Environment == null && ParameterWasBound(nameof(this.Environment)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configurations = cmdletContext.Configuration;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
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
        
        private Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "ReportInstrumentationConfigurationStatus");
            try
            {
                return client.ReportInstrumentationConfigurationStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ApplicationSignals.Model.InstrumentationConfigurationStatusReport> Configuration { get; set; }
            public System.String Environment { get; set; }
            public System.String Service { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.ReportInstrumentationConfigurationStatusResponse, WriteCWASInstrumentationConfigurationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
