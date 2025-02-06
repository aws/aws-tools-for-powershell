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
    /// Gets an OTA update.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">GetOTAUpdate</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTOTAUpdate")]
    [OutputType("Amazon.IoT.Model.OTAUpdateInfo")]
    [AWSCmdlet("Calls the AWS IoT GetOTAUpdate API operation.", Operation = new[] {"GetOTAUpdate"}, SelectReturnType = typeof(Amazon.IoT.Model.GetOTAUpdateResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.OTAUpdateInfo or Amazon.IoT.Model.GetOTAUpdateResponse",
        "This cmdlet returns an Amazon.IoT.Model.OTAUpdateInfo object.",
        "The service call response (type Amazon.IoT.Model.GetOTAUpdateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTOTAUpdateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OtaUpdateId
        /// <summary>
        /// <para>
        /// <para>The OTA update ID.</para>
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
        public System.String OtaUpdateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OtaUpdateInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.GetOTAUpdateResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.GetOTAUpdateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OtaUpdateInfo";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.GetOTAUpdateResponse, GetIOTOTAUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OtaUpdateId = this.OtaUpdateId;
            #if MODULAR
            if (this.OtaUpdateId == null && ParameterWasBound(nameof(this.OtaUpdateId)))
            {
                WriteWarning("You are passing $null as a value for parameter OtaUpdateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.GetOTAUpdateRequest();
            
            if (cmdletContext.OtaUpdateId != null)
            {
                request.OtaUpdateId = cmdletContext.OtaUpdateId;
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
        
        private Amazon.IoT.Model.GetOTAUpdateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.GetOTAUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "GetOTAUpdate");
            try
            {
                #if DESKTOP
                return client.GetOTAUpdate(request);
                #elif CORECLR
                return client.GetOTAUpdateAsync(request).GetAwaiter().GetResult();
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
            public System.String OtaUpdateId { get; set; }
            public System.Func<Amazon.IoT.Model.GetOTAUpdateResponse, GetIOTOTAUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OtaUpdateInfo;
        }
        
    }
}
