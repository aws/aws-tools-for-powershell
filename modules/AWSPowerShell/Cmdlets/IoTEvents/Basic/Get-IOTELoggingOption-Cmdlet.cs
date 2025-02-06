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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Retrieves the current settings of the AWS IoT Events logging options.
    /// </summary>
    [Cmdlet("Get", "IOTELoggingOption")]
    [OutputType("Amazon.IoTEvents.Model.LoggingOptions")]
    [AWSCmdlet("Calls the AWS IoT Events DescribeLoggingOptions API operation.", Operation = new[] {"DescribeLoggingOptions"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.LoggingOptions or Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse",
        "This cmdlet returns an Amazon.IoTEvents.Model.LoggingOptions object.",
        "The service call response (type Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTELoggingOptionCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingOptions";
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
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse, GetIOTELoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.IoTEvents.Model.DescribeLoggingOptionsRequest();
            
            
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
        
        private Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.DescribeLoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "DescribeLoggingOptions");
            try
            {
                #if DESKTOP
                return client.DescribeLoggingOptions(request);
                #elif CORECLR
                return client.DescribeLoggingOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IoTEvents.Model.DescribeLoggingOptionsResponse, GetIOTELoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingOptions;
        }
        
    }
}
