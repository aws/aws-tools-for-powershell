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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Updates the runtime configuration of a thing.
    /// </summary>
    [Cmdlet("Update", "GGThingRuntimeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Greengrass UpdateThingRuntimeConfiguration API operation.", Operation = new[] {"UpdateThingRuntimeConfiguration"}, SelectReturnType = typeof(Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGGThingRuntimeConfigurationCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TelemetryConfiguration_Telemetry
        /// <summary>
        /// <para>
        /// Configure telemetry to be on or off.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Greengrass.Telemetry")]
        public Amazon.Greengrass.Telemetry TelemetryConfiguration_Telemetry { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// The thing name.
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
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GGThingRuntimeConfiguration (UpdateThingRuntimeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse, UpdateGGThingRuntimeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TelemetryConfiguration_Telemetry = this.TelemetryConfiguration_Telemetry;
            context.ThingName = this.ThingName;
            #if MODULAR
            if (this.ThingName == null && ParameterWasBound(nameof(this.ThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationRequest();
            
            
             // populate TelemetryConfiguration
            var requestTelemetryConfigurationIsNull = true;
            request.TelemetryConfiguration = new Amazon.Greengrass.Model.TelemetryConfigurationUpdate();
            Amazon.Greengrass.Telemetry requestTelemetryConfiguration_telemetryConfiguration_Telemetry = null;
            if (cmdletContext.TelemetryConfiguration_Telemetry != null)
            {
                requestTelemetryConfiguration_telemetryConfiguration_Telemetry = cmdletContext.TelemetryConfiguration_Telemetry;
            }
            if (requestTelemetryConfiguration_telemetryConfiguration_Telemetry != null)
            {
                request.TelemetryConfiguration.Telemetry = requestTelemetryConfiguration_telemetryConfiguration_Telemetry;
                requestTelemetryConfigurationIsNull = false;
            }
             // determine if request.TelemetryConfiguration should be set to null
            if (requestTelemetryConfigurationIsNull)
            {
                request.TelemetryConfiguration = null;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
        
        private Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "UpdateThingRuntimeConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateThingRuntimeConfiguration(request);
                #elif CORECLR
                return client.UpdateThingRuntimeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Greengrass.Telemetry TelemetryConfiguration_Telemetry { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.Greengrass.Model.UpdateThingRuntimeConfigurationResponse, UpdateGGThingRuntimeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
