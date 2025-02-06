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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Returns details about the landing zone. Displays a message in case of error.
    /// </summary>
    [Cmdlet("Get", "ACTLandingZone")]
    [OutputType("Amazon.ControlTower.Model.LandingZoneDetail")]
    [AWSCmdlet("Calls the AWS Control Tower GetLandingZone API operation.", Operation = new[] {"GetLandingZone"}, SelectReturnType = typeof(Amazon.ControlTower.Model.GetLandingZoneResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.LandingZoneDetail or Amazon.ControlTower.Model.GetLandingZoneResponse",
        "This cmdlet returns an Amazon.ControlTower.Model.LandingZoneDetail object.",
        "The service call response (type Amazon.ControlTower.Model.GetLandingZoneResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTLandingZoneCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LandingZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the landing zone.</para>
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
        public System.String LandingZoneIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LandingZone'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.GetLandingZoneResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.GetLandingZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LandingZone";
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.GetLandingZoneResponse, GetACTLandingZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LandingZoneIdentifier = this.LandingZoneIdentifier;
            #if MODULAR
            if (this.LandingZoneIdentifier == null && ParameterWasBound(nameof(this.LandingZoneIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LandingZoneIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlTower.Model.GetLandingZoneRequest();
            
            if (cmdletContext.LandingZoneIdentifier != null)
            {
                request.LandingZoneIdentifier = cmdletContext.LandingZoneIdentifier;
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
        
        private Amazon.ControlTower.Model.GetLandingZoneResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.GetLandingZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "GetLandingZone");
            try
            {
                #if DESKTOP
                return client.GetLandingZone(request);
                #elif CORECLR
                return client.GetLandingZoneAsync(request).GetAwaiter().GetResult();
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
            public System.String LandingZoneIdentifier { get; set; }
            public System.Func<Amazon.ControlTower.Model.GetLandingZoneResponse, GetACTLandingZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LandingZone;
        }
        
    }
}
