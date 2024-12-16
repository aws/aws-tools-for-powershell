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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Retrieves the status of a <c>DeleteEventsByEventType</c> action.
    /// </summary>
    [Cmdlet("Get", "FDDeleteEventsByEventTypeStatus")]
    [OutputType("Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse")]
    [AWSCmdlet("Calls the Amazon Fraud Detector GetDeleteEventsByEventTypeStatus API operation.", Operation = new[] {"GetDeleteEventsByEventTypeStatus"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse",
        "This cmdlet returns an Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse object containing multiple properties."
    )]
    public partial class GetFDDeleteEventsByEventTypeStatusCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventTypeName
        /// <summary>
        /// <para>
        /// <para>Name of event type for which to get the deletion status.</para>
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
        public System.String EventTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse, GetFDDeleteEventsByEventTypeStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EventTypeName = this.EventTypeName;
            #if MODULAR
            if (this.EventTypeName == null && ParameterWasBound(nameof(this.EventTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusRequest();
            
            if (cmdletContext.EventTypeName != null)
            {
                request.EventTypeName = cmdletContext.EventTypeName;
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
        
        private Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "GetDeleteEventsByEventTypeStatus");
            try
            {
                #if DESKTOP
                return client.GetDeleteEventsByEventTypeStatus(request);
                #elif CORECLR
                return client.GetDeleteEventsByEventTypeStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String EventTypeName { get; set; }
            public System.Func<Amazon.FraudDetector.Model.GetDeleteEventsByEventTypeStatusResponse, GetFDDeleteEventsByEventTypeStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
