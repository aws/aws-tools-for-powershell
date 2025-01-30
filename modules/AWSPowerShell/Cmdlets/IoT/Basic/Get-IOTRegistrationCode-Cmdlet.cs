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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Gets a registration code used to register a CA certificate with IoT.
    /// 
    ///  
    /// <para>
    /// IoT will create a registration code as part of this API call if the registration code
    /// doesn't exist or has been deleted. If you already have a registration code, this API
    /// call will return the same registration code.
    /// </para><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">GetRegistrationCode</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTRegistrationCode")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT GetRegistrationCode API operation.", Operation = new[] {"GetRegistrationCode"}, SelectReturnType = typeof(Amazon.IoT.Model.GetRegistrationCodeResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.GetRegistrationCodeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.GetRegistrationCodeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTRegistrationCodeCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistrationCode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.GetRegistrationCodeResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.GetRegistrationCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistrationCode";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.GetRegistrationCodeResponse, GetIOTRegistrationCodeCmdlet>(Select) ??
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
            var request = new Amazon.IoT.Model.GetRegistrationCodeRequest();
            
            
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
        
        private Amazon.IoT.Model.GetRegistrationCodeResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.GetRegistrationCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "GetRegistrationCode");
            try
            {
                #if DESKTOP
                return client.GetRegistrationCode(request);
                #elif CORECLR
                return client.GetRegistrationCodeAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IoT.Model.GetRegistrationCodeResponse, GetIOTRegistrationCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistrationCode;
        }
        
    }
}
