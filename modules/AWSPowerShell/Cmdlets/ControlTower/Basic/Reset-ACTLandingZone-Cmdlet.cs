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
    /// This API call resets a landing zone. It starts an asynchronous operation that resets
    /// the landing zone to the parameters specified in the original configuration, which
    /// you specified in the manifest file. Nothing in the manifest file's original landing
    /// zone configuration is changed during the reset process, by default. This API is not
    /// the same as a rollback of a landing zone version, which is not a supported operation.
    /// </summary>
    [Cmdlet("Reset", "ACTLandingZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Control Tower ResetLandingZone API operation.", Operation = new[] {"ResetLandingZone"}, SelectReturnType = typeof(Amazon.ControlTower.Model.ResetLandingZoneResponse))]
    [AWSCmdletOutput("System.String or Amazon.ControlTower.Model.ResetLandingZoneResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ControlTower.Model.ResetLandingZoneResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ResetACTLandingZoneCmdlet : AmazonControlTowerClientCmdlet, IExecutor
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.ResetLandingZoneResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.ResetLandingZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationIdentifier";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LandingZoneIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-ACTLandingZone (ResetLandingZone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.ResetLandingZoneResponse, ResetACTLandingZoneCmdlet>(Select) ??
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
            var request = new Amazon.ControlTower.Model.ResetLandingZoneRequest();
            
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
        
        private Amazon.ControlTower.Model.ResetLandingZoneResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.ResetLandingZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "ResetLandingZone");
            try
            {
                #if DESKTOP
                return client.ResetLandingZone(request);
                #elif CORECLR
                return client.ResetLandingZoneAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ControlTower.Model.ResetLandingZoneResponse, ResetACTLandingZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationIdentifier;
        }
        
    }
}
