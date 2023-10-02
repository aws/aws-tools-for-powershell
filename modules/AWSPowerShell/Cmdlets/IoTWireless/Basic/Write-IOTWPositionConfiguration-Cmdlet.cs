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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Put position configuration for a given resource.
    /// 
    ///  <important><para>
    /// This action is no longer supported. Calls to update the position configuration should
    /// use the <a href="https://docs.aws.amazon.com/iot-wireless/2020-11-22/apireference/API_UpdateResourcePosition.html">UpdateResourcePosition</a>
    /// API operation instead.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "IOTWPositionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless PutPositionConfiguration API operation.", Operation = new[] {"PutPositionConfiguration"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.PutPositionConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.PutPositionConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.PutPositionConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("This operation is no longer supported.")]
    public partial class WriteIOTWPositionConfigurationCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The position data destination that describes the AWS IoT rule that processes the device's
        /// position data for use by AWS IoT Core for LoRaWAN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter SemtechGnss_Fec
        /// <summary>
        /// <para>
        /// <para>Whether forward error correction is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Solvers_SemtechGnss_Fec")]
        [AWSConstantClassSource("Amazon.IoTWireless.PositionConfigurationFec")]
        public Amazon.IoTWireless.PositionConfigurationFec SemtechGnss_Fec { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>Resource identifier used to update the position configuration.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Resource type of the resource for which you want to update the position configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTWireless.PositionResourceType")]
        public Amazon.IoTWireless.PositionResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter SemtechGnss_Status
        /// <summary>
        /// <para>
        /// <para>The status indicating whether the solver is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Solvers_SemtechGnss_Status")]
        [AWSConstantClassSource("Amazon.IoTWireless.PositionConfigurationStatus")]
        public Amazon.IoTWireless.PositionConfigurationStatus SemtechGnss_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.PutPositionConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTWPositionConfiguration (PutPositionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.PutPositionConfigurationResponse, WriteIOTWPositionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Destination = this.Destination;
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SemtechGnss_Fec = this.SemtechGnss_Fec;
            context.SemtechGnss_Status = this.SemtechGnss_Status;
            
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
            var request = new Amazon.IoTWireless.Model.PutPositionConfigurationRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
             // populate Solvers
            var requestSolversIsNull = true;
            request.Solvers = new Amazon.IoTWireless.Model.PositionSolverConfigurations();
            Amazon.IoTWireless.Model.SemtechGnssConfiguration requestSolvers_solvers_SemtechGnss = null;
            
             // populate SemtechGnss
            var requestSolvers_solvers_SemtechGnssIsNull = true;
            requestSolvers_solvers_SemtechGnss = new Amazon.IoTWireless.Model.SemtechGnssConfiguration();
            Amazon.IoTWireless.PositionConfigurationFec requestSolvers_solvers_SemtechGnss_semtechGnss_Fec = null;
            if (cmdletContext.SemtechGnss_Fec != null)
            {
                requestSolvers_solvers_SemtechGnss_semtechGnss_Fec = cmdletContext.SemtechGnss_Fec;
            }
            if (requestSolvers_solvers_SemtechGnss_semtechGnss_Fec != null)
            {
                requestSolvers_solvers_SemtechGnss.Fec = requestSolvers_solvers_SemtechGnss_semtechGnss_Fec;
                requestSolvers_solvers_SemtechGnssIsNull = false;
            }
            Amazon.IoTWireless.PositionConfigurationStatus requestSolvers_solvers_SemtechGnss_semtechGnss_Status = null;
            if (cmdletContext.SemtechGnss_Status != null)
            {
                requestSolvers_solvers_SemtechGnss_semtechGnss_Status = cmdletContext.SemtechGnss_Status;
            }
            if (requestSolvers_solvers_SemtechGnss_semtechGnss_Status != null)
            {
                requestSolvers_solvers_SemtechGnss.Status = requestSolvers_solvers_SemtechGnss_semtechGnss_Status;
                requestSolvers_solvers_SemtechGnssIsNull = false;
            }
             // determine if requestSolvers_solvers_SemtechGnss should be set to null
            if (requestSolvers_solvers_SemtechGnssIsNull)
            {
                requestSolvers_solvers_SemtechGnss = null;
            }
            if (requestSolvers_solvers_SemtechGnss != null)
            {
                request.Solvers.SemtechGnss = requestSolvers_solvers_SemtechGnss;
                requestSolversIsNull = false;
            }
             // determine if request.Solvers should be set to null
            if (requestSolversIsNull)
            {
                request.Solvers = null;
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
        
        private Amazon.IoTWireless.Model.PutPositionConfigurationResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.PutPositionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "PutPositionConfiguration");
            try
            {
                #if DESKTOP
                return client.PutPositionConfiguration(request);
                #elif CORECLR
                return client.PutPositionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Destination { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public Amazon.IoTWireless.PositionResourceType ResourceType { get; set; }
            public Amazon.IoTWireless.PositionConfigurationFec SemtechGnss_Fec { get; set; }
            public Amazon.IoTWireless.PositionConfigurationStatus SemtechGnss_Status { get; set; }
            public System.Func<Amazon.IoTWireless.Model.PutPositionConfigurationResponse, WriteIOTWPositionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
