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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Creates a state template. State templates contain state properties, which are signals
    /// that belong to a signal catalog that is synchronized between the Amazon Web Services
    /// IoT FleetWise Edge and the Amazon Web Services Cloud.
    /// 
    ///  <important><para>
    /// Access to certain Amazon Web Services IoT FleetWise features is currently gated. For
    /// more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/fleetwise-regions.html">Amazon
    /// Web Services Region and feature availability</a> in the <i>Amazon Web Services IoT
    /// FleetWise Developer Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IFWStateTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.CreateStateTemplateResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise CreateStateTemplate API operation.", Operation = new[] {"CreateStateTemplate"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.CreateStateTemplateResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.CreateStateTemplateResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.CreateStateTemplateResponse object containing multiple properties."
    )]
    public partial class NewIFWStateTemplateCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataExtraDimension
        /// <summary>
        /// <para>
        /// <para>A list of vehicle attributes to associate with the payload published on the state
        /// template's MQTT topic. (See <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/process-visualize-data.html#process-last-known-state-vehicle-data">
        /// Processing last known state vehicle data using MQTT messaging</a>). For example, if
        /// you add <c>Vehicle.Attributes.Make</c> and <c>Vehicle.Attributes.Model</c> attributes,
        /// Amazon Web Services IoT FleetWise will enrich the protobuf encoded payload with those
        /// attributes in the <c>extraDimensions</c> field.</para>
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
        
        #region Parameter MetadataExtraDimension
        /// <summary>
        /// <para>
        /// <para>A list of vehicle attributes to associate with user properties of the messages published
        /// on the state template's MQTT topic. (See <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/process-visualize-data.html#process-last-known-state-vehicle-data">
        /// Processing last known state vehicle data using MQTT messaging</a>). For example, if
        /// you add <c>Vehicle.Attributes.Make</c> and <c>Vehicle.Attributes.Model</c> attributes,
        /// Amazon Web Services IoT FleetWise will include these attributes as User Properties
        /// with the MQTT message.</para><para>Default: An empty array</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataExtraDimensions")]
        public System.String[] MetadataExtraDimension { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the state template.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SignalCatalogArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the signal catalog associated with the state template.</para>
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
        public System.String SignalCatalogArn { get; set; }
        #endregion
        
        #region Parameter StateTemplateProperty
        /// <summary>
        /// <para>
        /// <para>A list of signals from which data is collected. The state template properties contain
        /// the fully qualified names of the signals.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StateTemplateProperties")]
        public System.String[] StateTemplateProperty { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the state template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTFleetWise.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.CreateStateTemplateResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.CreateStateTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IFWStateTemplate (CreateStateTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.CreateStateTemplateResponse, NewIFWStateTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DataExtraDimension != null)
            {
                context.DataExtraDimension = new List<System.String>(this.DataExtraDimension);
            }
            context.Description = this.Description;
            if (this.MetadataExtraDimension != null)
            {
                context.MetadataExtraDimension = new List<System.String>(this.MetadataExtraDimension);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignalCatalogArn = this.SignalCatalogArn;
            #if MODULAR
            if (this.SignalCatalogArn == null && ParameterWasBound(nameof(this.SignalCatalogArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalCatalogArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StateTemplateProperty != null)
            {
                context.StateTemplateProperty = new List<System.String>(this.StateTemplateProperty);
            }
            #if MODULAR
            if (this.StateTemplateProperty == null && ParameterWasBound(nameof(this.StateTemplateProperty)))
            {
                WriteWarning("You are passing $null as a value for parameter StateTemplateProperty which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTFleetWise.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTFleetWise.Model.CreateStateTemplateRequest();
            
            if (cmdletContext.DataExtraDimension != null)
            {
                request.DataExtraDimensions = cmdletContext.DataExtraDimension;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MetadataExtraDimension != null)
            {
                request.MetadataExtraDimensions = cmdletContext.MetadataExtraDimension;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SignalCatalogArn != null)
            {
                request.SignalCatalogArn = cmdletContext.SignalCatalogArn;
            }
            if (cmdletContext.StateTemplateProperty != null)
            {
                request.StateTemplateProperties = cmdletContext.StateTemplateProperty;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoTFleetWise.Model.CreateStateTemplateResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.CreateStateTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "CreateStateTemplate");
            try
            {
                #if DESKTOP
                return client.CreateStateTemplate(request);
                #elif CORECLR
                return client.CreateStateTemplateAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DataExtraDimension { get; set; }
            public System.String Description { get; set; }
            public List<System.String> MetadataExtraDimension { get; set; }
            public System.String Name { get; set; }
            public System.String SignalCatalogArn { get; set; }
            public List<System.String> StateTemplateProperty { get; set; }
            public List<Amazon.IoTFleetWise.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.CreateStateTemplateResponse, NewIFWStateTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
