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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Enables or disables integration with a service that can be integrated with DevOps
    /// Guru. The one service that can be integrated with DevOps Guru is Amazon CodeGuru Profiler,
    /// which can produce proactive recommendations which can be stored and viewed in DevOps
    /// Guru.
    /// </summary>
    [Cmdlet("Update", "DGURUEventSourcesConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DevOps Guru UpdateEventSourcesConfig API operation.", Operation = new[] {"UpdateEventSourcesConfig"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse))]
    [AWSCmdletOutput("None or Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDGURUEventSourcesConfigCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmazonCodeGuruProfiler_Status
        /// <summary>
        /// <para>
        /// <para>The status of the CodeGuru Profiler integration. Specifies if DevOps Guru is enabled
        /// to consume recommendations that are generated from Amazon CodeGuru Profiler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventSources_AmazonCodeGuruProfiler_Status")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.EventSourceOptInStatus")]
        public Amazon.DevOpsGuru.EventSourceOptInStatus AmazonCodeGuruProfiler_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DGURUEventSourcesConfig (UpdateEventSourcesConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse, UpdateDGURUEventSourcesConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonCodeGuruProfiler_Status = this.AmazonCodeGuruProfiler_Status;
            
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
            var request = new Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigRequest();
            
            
             // populate EventSources
            var requestEventSourcesIsNull = true;
            request.EventSources = new Amazon.DevOpsGuru.Model.EventSourcesConfig();
            Amazon.DevOpsGuru.Model.AmazonCodeGuruProfilerIntegration requestEventSources_eventSources_AmazonCodeGuruProfiler = null;
            
             // populate AmazonCodeGuruProfiler
            var requestEventSources_eventSources_AmazonCodeGuruProfilerIsNull = true;
            requestEventSources_eventSources_AmazonCodeGuruProfiler = new Amazon.DevOpsGuru.Model.AmazonCodeGuruProfilerIntegration();
            Amazon.DevOpsGuru.EventSourceOptInStatus requestEventSources_eventSources_AmazonCodeGuruProfiler_amazonCodeGuruProfiler_Status = null;
            if (cmdletContext.AmazonCodeGuruProfiler_Status != null)
            {
                requestEventSources_eventSources_AmazonCodeGuruProfiler_amazonCodeGuruProfiler_Status = cmdletContext.AmazonCodeGuruProfiler_Status;
            }
            if (requestEventSources_eventSources_AmazonCodeGuruProfiler_amazonCodeGuruProfiler_Status != null)
            {
                requestEventSources_eventSources_AmazonCodeGuruProfiler.Status = requestEventSources_eventSources_AmazonCodeGuruProfiler_amazonCodeGuruProfiler_Status;
                requestEventSources_eventSources_AmazonCodeGuruProfilerIsNull = false;
            }
             // determine if requestEventSources_eventSources_AmazonCodeGuruProfiler should be set to null
            if (requestEventSources_eventSources_AmazonCodeGuruProfilerIsNull)
            {
                requestEventSources_eventSources_AmazonCodeGuruProfiler = null;
            }
            if (requestEventSources_eventSources_AmazonCodeGuruProfiler != null)
            {
                request.EventSources.AmazonCodeGuruProfiler = requestEventSources_eventSources_AmazonCodeGuruProfiler;
                requestEventSourcesIsNull = false;
            }
             // determine if request.EventSources should be set to null
            if (requestEventSourcesIsNull)
            {
                request.EventSources = null;
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
        
        private Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "UpdateEventSourcesConfig");
            try
            {
                #if DESKTOP
                return client.UpdateEventSourcesConfig(request);
                #elif CORECLR
                return client.UpdateEventSourcesConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DevOpsGuru.EventSourceOptInStatus AmazonCodeGuruProfiler_Status { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.UpdateEventSourcesConfigResponse, UpdateDGURUEventSourcesConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
