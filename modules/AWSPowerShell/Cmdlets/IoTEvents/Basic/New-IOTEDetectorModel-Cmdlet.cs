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
    /// Creates a detector model.
    /// </summary>
    [Cmdlet("New", "IOTEDetectorModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTEvents.Model.DetectorModelConfiguration")]
    [AWSCmdlet("Calls the AWS IoT Events CreateDetectorModel API operation.", Operation = new[] {"CreateDetectorModel"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.CreateDetectorModelResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.DetectorModelConfiguration or Amazon.IoTEvents.Model.CreateDetectorModelResponse",
        "This cmdlet returns an Amazon.IoTEvents.Model.DetectorModelConfiguration object.",
        "The service call response (type Amazon.IoTEvents.Model.CreateDetectorModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIOTEDetectorModelCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DetectorModelDescription
        /// <summary>
        /// <para>
        /// <para>A brief description of the detector model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorModelDescription { get; set; }
        #endregion
        
        #region Parameter DetectorModelName
        /// <summary>
        /// <para>
        /// <para>The name of the detector model.</para>
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
        public System.String DetectorModelName { get; set; }
        #endregion
        
        #region Parameter EvaluationMethod
        /// <summary>
        /// <para>
        /// <para>Information about the order in which events are evaluated and how actions are executed.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTEvents.EvaluationMethod")]
        public Amazon.IoTEvents.EvaluationMethod EvaluationMethod { get; set; }
        #endregion
        
        #region Parameter DetectorModelDefinition_InitialStateName
        /// <summary>
        /// <para>
        /// <para>The state that is entered at the creation of each detector (instance).</para>
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
        public System.String DetectorModelDefinition_InitialStateName { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The input attribute key used to identify a device or system to create a detector (an
        /// instance of the detector model) and then to route each input received to the appropriate
        /// detector (instance). This parameter uses a JSON-path expression in the message payload
        /// of each input to specify the attribute-value pair that is used to identify the device
        /// associated with the input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants permission to AWS IoT Events to perform its operations.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter DetectorModelDefinition_State
        /// <summary>
        /// <para>
        /// <para>Information about the states of the detector.</para>
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
        [Alias("DetectorModelDefinition_States")]
        public Amazon.IoTEvents.Model.State[] DetectorModelDefinition_State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the detector model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTEvents.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DetectorModelConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.CreateDetectorModelResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.CreateDetectorModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DetectorModelConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DetectorModelName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DetectorModelName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DetectorModelName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTEDetectorModel (CreateDetectorModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.CreateDetectorModelResponse, NewIOTEDetectorModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DetectorModelName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DetectorModelDefinition_InitialStateName = this.DetectorModelDefinition_InitialStateName;
            #if MODULAR
            if (this.DetectorModelDefinition_InitialStateName == null && ParameterWasBound(nameof(this.DetectorModelDefinition_InitialStateName)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelDefinition_InitialStateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DetectorModelDefinition_State != null)
            {
                context.DetectorModelDefinition_State = new List<Amazon.IoTEvents.Model.State>(this.DetectorModelDefinition_State);
            }
            #if MODULAR
            if (this.DetectorModelDefinition_State == null && ParameterWasBound(nameof(this.DetectorModelDefinition_State)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelDefinition_State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorModelDescription = this.DetectorModelDescription;
            context.DetectorModelName = this.DetectorModelName;
            #if MODULAR
            if (this.DetectorModelName == null && ParameterWasBound(nameof(this.DetectorModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationMethod = this.EvaluationMethod;
            context.Key = this.Key;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTEvents.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTEvents.Model.CreateDetectorModelRequest();
            
            
             // populate DetectorModelDefinition
            var requestDetectorModelDefinitionIsNull = true;
            request.DetectorModelDefinition = new Amazon.IoTEvents.Model.DetectorModelDefinition();
            System.String requestDetectorModelDefinition_detectorModelDefinition_InitialStateName = null;
            if (cmdletContext.DetectorModelDefinition_InitialStateName != null)
            {
                requestDetectorModelDefinition_detectorModelDefinition_InitialStateName = cmdletContext.DetectorModelDefinition_InitialStateName;
            }
            if (requestDetectorModelDefinition_detectorModelDefinition_InitialStateName != null)
            {
                request.DetectorModelDefinition.InitialStateName = requestDetectorModelDefinition_detectorModelDefinition_InitialStateName;
                requestDetectorModelDefinitionIsNull = false;
            }
            List<Amazon.IoTEvents.Model.State> requestDetectorModelDefinition_detectorModelDefinition_State = null;
            if (cmdletContext.DetectorModelDefinition_State != null)
            {
                requestDetectorModelDefinition_detectorModelDefinition_State = cmdletContext.DetectorModelDefinition_State;
            }
            if (requestDetectorModelDefinition_detectorModelDefinition_State != null)
            {
                request.DetectorModelDefinition.States = requestDetectorModelDefinition_detectorModelDefinition_State;
                requestDetectorModelDefinitionIsNull = false;
            }
             // determine if request.DetectorModelDefinition should be set to null
            if (requestDetectorModelDefinitionIsNull)
            {
                request.DetectorModelDefinition = null;
            }
            if (cmdletContext.DetectorModelDescription != null)
            {
                request.DetectorModelDescription = cmdletContext.DetectorModelDescription;
            }
            if (cmdletContext.DetectorModelName != null)
            {
                request.DetectorModelName = cmdletContext.DetectorModelName;
            }
            if (cmdletContext.EvaluationMethod != null)
            {
                request.EvaluationMethod = cmdletContext.EvaluationMethod;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.IoTEvents.Model.CreateDetectorModelResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.CreateDetectorModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "CreateDetectorModel");
            try
            {
                #if DESKTOP
                return client.CreateDetectorModel(request);
                #elif CORECLR
                return client.CreateDetectorModelAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorModelDefinition_InitialStateName { get; set; }
            public List<Amazon.IoTEvents.Model.State> DetectorModelDefinition_State { get; set; }
            public System.String DetectorModelDescription { get; set; }
            public System.String DetectorModelName { get; set; }
            public Amazon.IoTEvents.EvaluationMethod EvaluationMethod { get; set; }
            public System.String Key { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.IoTEvents.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTEvents.Model.CreateDetectorModelResponse, NewIOTEDetectorModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DetectorModelConfiguration;
        }
        
    }
}
