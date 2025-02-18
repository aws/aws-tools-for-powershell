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
using System.Threading;
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Updates a state template.
    /// 
    ///  <important><para>
    /// Access to certain Amazon Web Services IoT FleetWise features is currently gated. For
    /// more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/fleetwise-regions.html">Amazon
    /// Web Services Region and feature availability</a> in the <i>Amazon Web Services IoT
    /// FleetWise Developer Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "IFWStateTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise UpdateStateTemplate API operation.", Operation = new[] {"UpdateStateTemplate"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse object containing multiple properties."
    )]
    public partial class UpdateIFWStateTemplateCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataExtraDimension
        /// <summary>
        /// <para>
        /// <para>A list of vehicle attributes to associate with the payload published on the state
        /// template's MQTT topic. (See <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/process-visualize-data.html#process-last-known-state-vehicle-data">
        /// Processing last known state vehicle data using MQTT messaging</a>). For example, if
        /// you add <c>Vehicle.Attributes.Make</c> and <c>Vehicle.Attributes.Model</c> attributes,
        /// Amazon Web Services IoT FleetWise will enrich the protobuf encoded payload with those
        /// attributes in the <c>extraDimensions</c> field.</para><para>Default: An empty array</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataExtraDimensions")]
        public System.String[] DataExtraDimension { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the state template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>A unique, service-generated identifier.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter MetadataExtraDimension
        /// <summary>
        /// <para>
        /// <para>A list of vehicle attributes to associate with user properties of the messages published
        /// on the state template's MQTT topic. (See <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/process-visualize-data.html#process-last-known-state-vehicle-data">
        /// Processing last known state vehicle data using MQTT messaging</a>). For example, if
        /// you add <c>Vehicle.Attributes.Make</c> and <c>Vehicle.Attributes.Model</c> attributes,
        /// Amazon Web Services IoT FleetWise will include these attributes as User Properties
        /// with the MQTT message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataExtraDimensions")]
        public System.String[] MetadataExtraDimension { get; set; }
        #endregion
        
        #region Parameter StateTemplatePropertiesToAdd
        /// <summary>
        /// <para>
        /// <para>Add signals from which data is collected as part of the state template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StateTemplatePropertiesToAdd { get; set; }
        #endregion
        
        #region Parameter StateTemplatePropertiesToRemove
        /// <summary>
        /// <para>
        /// <para>Remove signals from which data is collected as part of the state template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StateTemplatePropertiesToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IFWStateTemplate (UpdateStateTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse, UpdateIFWStateTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DataExtraDimension != null)
            {
                context.DataExtraDimension = new List<System.String>(this.DataExtraDimension);
            }
            context.Description = this.Description;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetadataExtraDimension != null)
            {
                context.MetadataExtraDimension = new List<System.String>(this.MetadataExtraDimension);
            }
            if (this.StateTemplatePropertiesToAdd != null)
            {
                context.StateTemplatePropertiesToAdd = new List<System.String>(this.StateTemplatePropertiesToAdd);
            }
            if (this.StateTemplatePropertiesToRemove != null)
            {
                context.StateTemplatePropertiesToRemove = new List<System.String>(this.StateTemplatePropertiesToRemove);
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
            var request = new Amazon.IoTFleetWise.Model.UpdateStateTemplateRequest();
            
            if (cmdletContext.DataExtraDimension != null)
            {
                request.DataExtraDimensions = cmdletContext.DataExtraDimension;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MetadataExtraDimension != null)
            {
                request.MetadataExtraDimensions = cmdletContext.MetadataExtraDimension;
            }
            if (cmdletContext.StateTemplatePropertiesToAdd != null)
            {
                request.StateTemplatePropertiesToAdd = cmdletContext.StateTemplatePropertiesToAdd;
            }
            if (cmdletContext.StateTemplatePropertiesToRemove != null)
            {
                request.StateTemplatePropertiesToRemove = cmdletContext.StateTemplatePropertiesToRemove;
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
        
        private Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.UpdateStateTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "UpdateStateTemplate");
            try
            {
                return client.UpdateStateTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DataExtraDimension { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public List<System.String> MetadataExtraDimension { get; set; }
            public List<System.String> StateTemplatePropertiesToAdd { get; set; }
            public List<System.String> StateTemplatePropertiesToRemove { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.UpdateStateTemplateResponse, UpdateIFWStateTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
