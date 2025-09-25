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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Updates the computation model.
    /// </summary>
    [Cmdlet("Update", "IOTSWComputationModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.ComputationModelStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateComputationModel API operation.", Operation = new[] {"UpdateComputationModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateComputationModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.ComputationModelStatus or Amazon.IoTSiteWise.Model.UpdateComputationModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.ComputationModelStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.UpdateComputationModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTSWComputationModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputationModelDataBinding
        /// <summary>
        /// <para>
        /// <para>The data binding for the computation model. Key is a variable name defined in configuration.
        /// Value is a <c>ComputationModelDataBindingValue</c> referenced by the variable.</para>
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
        public System.Collections.Hashtable ComputationModelDataBinding { get; set; }
        #endregion
        
        #region Parameter ComputationModelDescription
        /// <summary>
        /// <para>
        /// <para>The description of the computation model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputationModelDescription { get; set; }
        #endregion
        
        #region Parameter ComputationModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the computation model.</para>
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
        public System.String ComputationModelId { get; set; }
        #endregion
        
        #region Parameter ComputationModelName
        /// <summary>
        /// <para>
        /// <para>The name of the computation model.</para>
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
        public System.String ComputationModelName { get; set; }
        #endregion
        
        #region Parameter AnomalyDetection_InputProperty
        /// <summary>
        /// <para>
        /// <para>Define the variable name associated with input properties, with the following format
        /// <c>${VariableName}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputationModelConfiguration_AnomalyDetection_InputProperties")]
        public System.String AnomalyDetection_InputProperty { get; set; }
        #endregion
        
        #region Parameter AnomalyDetection_ResultProperty
        /// <summary>
        /// <para>
        /// <para>Define the variable name associated with the result property, and the following format
        /// <c>${VariableName}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputationModelConfiguration_AnomalyDetection_ResultProperty")]
        public System.String AnomalyDetection_ResultProperty { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComputationModelStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateComputationModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateComputationModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComputationModelStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputationModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputationModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputationModelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputationModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWComputationModel (UpdateComputationModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateComputationModelResponse, UpdateIOTSWComputationModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputationModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.AnomalyDetection_InputProperty = this.AnomalyDetection_InputProperty;
            context.AnomalyDetection_ResultProperty = this.AnomalyDetection_ResultProperty;
            if (this.ComputationModelDataBinding != null)
            {
                context.ComputationModelDataBinding = new Dictionary<System.String, Amazon.IoTSiteWise.Model.ComputationModelDataBindingValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputationModelDataBinding.Keys)
                {
                    context.ComputationModelDataBinding.Add((String)hashKey, (Amazon.IoTSiteWise.Model.ComputationModelDataBindingValue)(this.ComputationModelDataBinding[hashKey]));
                }
            }
            #if MODULAR
            if (this.ComputationModelDataBinding == null && ParameterWasBound(nameof(this.ComputationModelDataBinding)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputationModelDataBinding which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputationModelDescription = this.ComputationModelDescription;
            context.ComputationModelId = this.ComputationModelId;
            #if MODULAR
            if (this.ComputationModelId == null && ParameterWasBound(nameof(this.ComputationModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputationModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputationModelName = this.ComputationModelName;
            #if MODULAR
            if (this.ComputationModelName == null && ParameterWasBound(nameof(this.ComputationModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputationModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.UpdateComputationModelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ComputationModelConfiguration
            var requestComputationModelConfigurationIsNull = true;
            request.ComputationModelConfiguration = new Amazon.IoTSiteWise.Model.ComputationModelConfiguration();
            Amazon.IoTSiteWise.Model.ComputationModelAnomalyDetectionConfiguration requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection = null;
            
             // populate AnomalyDetection
            var requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetectionIsNull = true;
            requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection = new Amazon.IoTSiteWise.Model.ComputationModelAnomalyDetectionConfiguration();
            System.String requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_InputProperty = null;
            if (cmdletContext.AnomalyDetection_InputProperty != null)
            {
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_InputProperty = cmdletContext.AnomalyDetection_InputProperty;
            }
            if (requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_InputProperty != null)
            {
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection.InputProperties = requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_InputProperty;
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetectionIsNull = false;
            }
            System.String requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_ResultProperty = null;
            if (cmdletContext.AnomalyDetection_ResultProperty != null)
            {
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_ResultProperty = cmdletContext.AnomalyDetection_ResultProperty;
            }
            if (requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_ResultProperty != null)
            {
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection.ResultProperty = requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection_anomalyDetection_ResultProperty;
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetectionIsNull = false;
            }
             // determine if requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection should be set to null
            if (requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetectionIsNull)
            {
                requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection = null;
            }
            if (requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection != null)
            {
                request.ComputationModelConfiguration.AnomalyDetection = requestComputationModelConfiguration_computationModelConfiguration_AnomalyDetection;
                requestComputationModelConfigurationIsNull = false;
            }
             // determine if request.ComputationModelConfiguration should be set to null
            if (requestComputationModelConfigurationIsNull)
            {
                request.ComputationModelConfiguration = null;
            }
            if (cmdletContext.ComputationModelDataBinding != null)
            {
                request.ComputationModelDataBinding = cmdletContext.ComputationModelDataBinding;
            }
            if (cmdletContext.ComputationModelDescription != null)
            {
                request.ComputationModelDescription = cmdletContext.ComputationModelDescription;
            }
            if (cmdletContext.ComputationModelId != null)
            {
                request.ComputationModelId = cmdletContext.ComputationModelId;
            }
            if (cmdletContext.ComputationModelName != null)
            {
                request.ComputationModelName = cmdletContext.ComputationModelName;
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
        
        private Amazon.IoTSiteWise.Model.UpdateComputationModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateComputationModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateComputationModel");
            try
            {
                #if DESKTOP
                return client.UpdateComputationModel(request);
                #elif CORECLR
                return client.UpdateComputationModelAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String AnomalyDetection_InputProperty { get; set; }
            public System.String AnomalyDetection_ResultProperty { get; set; }
            public Dictionary<System.String, Amazon.IoTSiteWise.Model.ComputationModelDataBindingValue> ComputationModelDataBinding { get; set; }
            public System.String ComputationModelDescription { get; set; }
            public System.String ComputationModelId { get; set; }
            public System.String ComputationModelName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateComputationModelResponse, UpdateIOTSWComputationModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComputationModelStatus;
        }
        
    }
}
