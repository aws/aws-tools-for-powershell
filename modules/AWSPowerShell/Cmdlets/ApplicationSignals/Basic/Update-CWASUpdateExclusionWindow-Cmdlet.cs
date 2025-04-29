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
    /// Add or remove time window exclusions for one or more Service Level Objectives (SLOs).
    /// </summary>
    [Cmdlet("Update", "CWASUpdateExclusionWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals BatchUpdateExclusionWindows API operation.", Operation = new[] {"BatchUpdateExclusionWindows"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse object containing multiple properties."
    )]
    public partial class UpdateCWASUpdateExclusionWindowCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddExclusionWindow
        /// <summary>
        /// <para>
        /// <para>A list of exclusion windows to add to the specified SLOs. You can add up to 10 exclusion
        /// windows per SLO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddExclusionWindows")]
        public Amazon.ApplicationSignals.Model.ExclusionWindow[] AddExclusionWindow { get; set; }
        #endregion
        
        #region Parameter RemoveExclusionWindow
        /// <summary>
        /// <para>
        /// <para>A list of exclusion windows to remove from the specified SLOs. The window configuration
        /// must match an existing exclusion window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveExclusionWindows")]
        public Amazon.ApplicationSignals.Model.ExclusionWindow[] RemoveExclusionWindow { get; set; }
        #endregion
        
        #region Parameter SloId
        /// <summary>
        /// <para>
        /// <para>The list of SLO IDs to add or remove exclusion windows from.</para>
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
        [Alias("SloIds")]
        public System.String[] SloId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SloId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWASUpdateExclusionWindow (BatchUpdateExclusionWindows)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse, UpdateCWASUpdateExclusionWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddExclusionWindow != null)
            {
                context.AddExclusionWindow = new List<Amazon.ApplicationSignals.Model.ExclusionWindow>(this.AddExclusionWindow);
            }
            if (this.RemoveExclusionWindow != null)
            {
                context.RemoveExclusionWindow = new List<Amazon.ApplicationSignals.Model.ExclusionWindow>(this.RemoveExclusionWindow);
            }
            if (this.SloId != null)
            {
                context.SloId = new List<System.String>(this.SloId);
            }
            #if MODULAR
            if (this.SloId == null && ParameterWasBound(nameof(this.SloId)))
            {
                WriteWarning("You are passing $null as a value for parameter SloId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsRequest();
            
            if (cmdletContext.AddExclusionWindow != null)
            {
                request.AddExclusionWindows = cmdletContext.AddExclusionWindow;
            }
            if (cmdletContext.RemoveExclusionWindow != null)
            {
                request.RemoveExclusionWindows = cmdletContext.RemoveExclusionWindow;
            }
            if (cmdletContext.SloId != null)
            {
                request.SloIds = cmdletContext.SloId;
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
        
        private Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "BatchUpdateExclusionWindows");
            try
            {
                return client.BatchUpdateExclusionWindowsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ApplicationSignals.Model.ExclusionWindow> AddExclusionWindow { get; set; }
            public List<Amazon.ApplicationSignals.Model.ExclusionWindow> RemoveExclusionWindow { get; set; }
            public List<System.String> SloId { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.BatchUpdateExclusionWindowsResponse, UpdateCWASUpdateExclusionWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
