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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Tests whether the specified event pattern matches the provided event.
    /// 
    ///  
    /// <para>
    /// Most services in Amazon Web Services treat : or / as the same character in Amazon
    /// Resource Names (ARNs). However, EventBridge uses an exact match in event patterns
    /// and rules. Be sure to use the correct ARN characters when creating event patterns
    /// so that they match the ARN syntax in the event you want to match.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "CWEEventPattern")]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events TestEventPattern API operation.", Operation = new[] {"TestEventPattern"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.TestEventPatternResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.CloudWatchEvents.Model.TestEventPatternResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.CloudWatchEvents.Model.TestEventPatternResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCWEEventPatternCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Event
        /// <summary>
        /// <para>
        /// <para>The event, in JSON format, to test against the event pattern. The JSON must follow
        /// the format specified in <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/aws-events.html">Amazon
        /// Web Services Events</a>, and the following fields are mandatory:</para><ul><li><para><c>id</c></para></li><li><para><c>account</c></para></li><li><para><c>source</c></para></li><li><para><c>time</c></para></li><li><para><c>region</c></para></li><li><para><c>resources</c></para></li><li><para><c>detail-type</c></para></li></ul>
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
        public System.String Event { get; set; }
        #endregion
        
        #region Parameter EventPattern
        /// <summary>
        /// <para>
        /// <para>The event pattern. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eventbridge-and-event-patterns.html">Events
        /// and Event Patterns</a> in the <i>Amazon EventBridge User Guide</i>.</para>
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
        public System.String EventPattern { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Result'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.TestEventPatternResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.TestEventPatternResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Result";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Event parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Event' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Event' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.TestEventPatternResponse, TestCWEEventPatternCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Event;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Event = this.Event;
            #if MODULAR
            if (this.Event == null && ParameterWasBound(nameof(this.Event)))
            {
                WriteWarning("You are passing $null as a value for parameter Event which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventPattern = this.EventPattern;
            #if MODULAR
            if (this.EventPattern == null && ParameterWasBound(nameof(this.EventPattern)))
            {
                WriteWarning("You are passing $null as a value for parameter EventPattern which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.TestEventPatternRequest();
            
            if (cmdletContext.Event != null)
            {
                request.Event = cmdletContext.Event;
            }
            if (cmdletContext.EventPattern != null)
            {
                request.EventPattern = cmdletContext.EventPattern;
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
        
        private Amazon.CloudWatchEvents.Model.TestEventPatternResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.TestEventPatternRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "TestEventPattern");
            try
            {
                #if DESKTOP
                return client.TestEventPattern(request);
                #elif CORECLR
                return client.TestEventPatternAsync(request).GetAwaiter().GetResult();
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
            public System.String Event { get; set; }
            public System.String EventPattern { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.TestEventPatternResponse, TestCWEEventPatternCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Result;
        }
        
    }
}
