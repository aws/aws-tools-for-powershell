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
using Amazon.InternetMonitor;
using Amazon.InternetMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWIM
{
    /// <summary>
    /// Gets information that Amazon CloudWatch Internet Monitor has generated about an internet
    /// event. Internet Monitor displays information about recent global health events, called
    /// internet events, on a global outages map that is available to all Amazon Web Services
    /// customers. 
    /// 
    ///  
    /// <para>
    /// The information returned here includes the impacted location, when the event started
    /// and (if the event is over) ended, the type of event (<c>PERFORMANCE</c> or <c>AVAILABILITY</c>),
    /// and the status (<c>ACTIVE</c> or <c>RESOLVED</c>).
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWIMInternetEvent")]
    [OutputType("Amazon.InternetMonitor.Model.GetInternetEventResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Internet Monitor GetInternetEvent API operation.", Operation = new[] {"GetInternetEvent"}, SelectReturnType = typeof(Amazon.InternetMonitor.Model.GetInternetEventResponse))]
    [AWSCmdletOutput("Amazon.InternetMonitor.Model.GetInternetEventResponse",
        "This cmdlet returns an Amazon.InternetMonitor.Model.GetInternetEventResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWIMInternetEventCmdlet : AmazonInternetMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventId
        /// <summary>
        /// <para>
        /// <para>The <c>EventId</c> of the internet event to return information for. </para>
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
        public System.String EventId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InternetMonitor.Model.GetInternetEventResponse).
        /// Specifying the name of a property of type Amazon.InternetMonitor.Model.GetInternetEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.InternetMonitor.Model.GetInternetEventResponse, GetCWIMInternetEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventId = this.EventId;
            #if MODULAR
            if (this.EventId == null && ParameterWasBound(nameof(this.EventId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.InternetMonitor.Model.GetInternetEventRequest();
            
            if (cmdletContext.EventId != null)
            {
                request.EventId = cmdletContext.EventId;
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
        
        private Amazon.InternetMonitor.Model.GetInternetEventResponse CallAWSServiceOperation(IAmazonInternetMonitor client, Amazon.InternetMonitor.Model.GetInternetEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Internet Monitor", "GetInternetEvent");
            try
            {
                #if DESKTOP
                return client.GetInternetEvent(request);
                #elif CORECLR
                return client.GetInternetEventAsync(request).GetAwaiter().GetResult();
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
            public System.String EventId { get; set; }
            public System.Func<Amazon.InternetMonitor.Model.GetInternetEventResponse, GetCWIMInternetEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
