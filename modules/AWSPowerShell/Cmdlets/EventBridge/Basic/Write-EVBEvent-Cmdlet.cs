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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Sends custom events to Amazon EventBridge so that they can be matched to rules.
    /// 
    ///  
    /// <para>
    /// The maximum size for a PutEvents event entry is 256 KB. Entry size is calculated including
    /// the event and any necessary characters and keys of the JSON representation of the
    /// event. To learn more, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-putevent-size.html">Calculating
    /// PutEvents event entry size</a> in the <i><i>Amazon EventBridge User Guide</i></i></para><para>
    /// PutEvents accepts the data in JSON format. For the JSON number (integer) data type,
    /// the constraints are: a minimum value of -9,223,372,036,854,775,808 and a maximum value
    /// of 9,223,372,036,854,775,807.
    /// </para><note><para>
    /// PutEvents will only process nested JSON up to 1000 levels deep.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "EVBEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.PutEventsResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge PutEvents API operation.", Operation = new[] {"PutEvents"}, SelectReturnType = typeof(Amazon.EventBridge.Model.PutEventsResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.PutEventsResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.PutEventsResponse object containing multiple properties."
    )]
    public partial class WriteEVBEventCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>The URL subdomain of the endpoint. For example, if the URL for Endpoint is https://abcde.veo.endpoints.event.amazonaws.com,
        /// then the EndpointId is <c>abcde.veo</c>.</para><important><para>When using Java, you must include <c>auth-crt</c> on the class path.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>The entry that defines an event in your system. You can specify several parameters
        /// for the entry such as the source and type of the event, resources associated with
        /// the event, and so on.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Entries")]
        public Amazon.EventBridge.Model.PutEventsRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.PutEventsResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.PutEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Entry parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Entry' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Entry' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Entry), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EVBEvent (PutEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.PutEventsResponse, WriteEVBEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Entry;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndpointId = this.EndpointId;
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.EventBridge.Model.PutEventsRequestEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridge.Model.PutEventsRequest();
            
            if (cmdletContext.EndpointId != null)
            {
                request.EndpointId = cmdletContext.EndpointId;
            }
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
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
        
        private Amazon.EventBridge.Model.PutEventsResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.PutEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "PutEvents");
            try
            {
                #if DESKTOP
                return client.PutEvents(request);
                #elif CORECLR
                return client.PutEventsAsync(request).GetAwaiter().GetResult();
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
            public System.String EndpointId { get; set; }
            public List<Amazon.EventBridge.Model.PutEventsRequestEntry> Entry { get; set; }
            public System.Func<Amazon.EventBridge.Model.PutEventsResponse, WriteEVBEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
