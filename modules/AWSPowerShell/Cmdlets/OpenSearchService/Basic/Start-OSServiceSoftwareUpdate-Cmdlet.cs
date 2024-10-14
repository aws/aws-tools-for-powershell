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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Schedules a service software update for an Amazon OpenSearch Service domain. For more
    /// information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/service-software.html">Service
    /// software updates in Amazon OpenSearch Service</a>.
    /// </summary>
    [Cmdlet("Start", "OSServiceSoftwareUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.ServiceSoftwareOptions")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service StartServiceSoftwareUpdate API operation.", Operation = new[] {"StartServiceSoftwareUpdate"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.ServiceSoftwareOptions or Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.ServiceSoftwareOptions object.",
        "The service call response (type Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartOSServiceSoftwareUpdateCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DesiredStartTime
        /// <summary>
        /// <para>
        /// <para>The Epoch timestamp when you want the service software update to start. You only need
        /// to specify this parameter if you set <c>ScheduleAt</c> to <c>TIMESTAMP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DesiredStartTime { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to update to the latest service software.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ScheduleAt
        /// <summary>
        /// <para>
        /// <para>When to start the service software update.</para><ul><li><para><c>NOW</c> - Immediately schedules the update to happen in the current hour if there's
        /// capacity available.</para></li><li><para><c>TIMESTAMP</c> - Lets you specify a custom date and time to apply the update. If
        /// you specify this value, you must also provide a value for <c>DesiredStartTime</c>.</para></li><li><para><c>OFF_PEAK_WINDOW</c> - Marks the update to be picked up during an upcoming off-peak
        /// window. There's no guarantee that the update will happen during the next immediate
        /// window. Depending on capacity, it might happen in subsequent days.</para></li></ul><para>Default: <c>NOW</c> if you don't specify a value for <c>DesiredStartTime</c>, and
        /// <c>TIMESTAMP</c> if you do.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.ScheduleAt")]
        public Amazon.OpenSearchService.ScheduleAt ScheduleAt { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceSoftwareOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceSoftwareOptions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OSServiceSoftwareUpdate (StartServiceSoftwareUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse, StartOSServiceSoftwareUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DesiredStartTime = this.DesiredStartTime;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleAt = this.ScheduleAt;
            
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
            var request = new Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateRequest();
            
            if (cmdletContext.DesiredStartTime != null)
            {
                request.DesiredStartTime = cmdletContext.DesiredStartTime.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ScheduleAt != null)
            {
                request.ScheduleAt = cmdletContext.ScheduleAt;
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
        
        private Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "StartServiceSoftwareUpdate");
            try
            {
                #if DESKTOP
                return client.StartServiceSoftwareUpdate(request);
                #elif CORECLR
                return client.StartServiceSoftwareUpdateAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? DesiredStartTime { get; set; }
            public System.String DomainName { get; set; }
            public Amazon.OpenSearchService.ScheduleAt ScheduleAt { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.StartServiceSoftwareUpdateResponse, StartOSServiceSoftwareUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceSoftwareOptions;
        }
        
    }
}
