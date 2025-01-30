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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Creates or updates an Amazon SageMaker model endpoint. You can also use this action
    /// to update the configuration of the model endpoint, including the IAM role and/or the
    /// mapped variables.
    /// </summary>
    [Cmdlet("Write", "FDExternalModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector PutExternalModel API operation.", Operation = new[] {"PutExternalModel"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.PutExternalModelResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.PutExternalModelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.PutExternalModelResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteFDExternalModelCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OutputConfiguration_CsvIndexToVariableMap
        /// <summary>
        /// <para>
        /// <para>A map of CSV index values in the SageMaker response to the Amazon Fraud Detector variables.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable OutputConfiguration_CsvIndexToVariableMap { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_CsvInputTemplate
        /// <summary>
        /// <para>
        /// <para> Template for constructing the CSV input-data sent to SageMaker. At event-evaluation,
        /// the placeholders for variable-names in the template will be replaced with the variable
        /// values before being sent to SageMaker. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_CsvInputTemplate { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_EventTypeName
        /// <summary>
        /// <para>
        /// <para>The event type name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_EventTypeName { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_Format
        /// <summary>
        /// <para>
        /// <para> The format of the model input configuration. The format differs depending on if it
        /// is passed through to SageMaker or constructed by Amazon Fraud Detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FraudDetector.ModelInputDataFormat")]
        public Amazon.FraudDetector.ModelInputDataFormat InputConfiguration_Format { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Format
        /// <summary>
        /// <para>
        /// <para>The format of the model output configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.ModelOutputDataFormat")]
        public Amazon.FraudDetector.ModelOutputDataFormat OutputConfiguration_Format { get; set; }
        #endregion
        
        #region Parameter InvokeModelEndpointRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role used to invoke the model endpoint.</para>
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
        public System.String InvokeModelEndpointRoleArn { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_JsonInputTemplate
        /// <summary>
        /// <para>
        /// <para> Template for constructing the JSON input-data sent to SageMaker. At event-evaluation,
        /// the placeholders for variable names in the template will be replaced with the variable
        /// values before being sent to SageMaker. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_JsonInputTemplate { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_JsonKeyToVariableMap
        /// <summary>
        /// <para>
        /// <para>A map of JSON keys in response from SageMaker to the Amazon Fraud Detector variables.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable OutputConfiguration_JsonKeyToVariableMap { get; set; }
        #endregion
        
        #region Parameter ModelEndpoint
        /// <summary>
        /// <para>
        /// <para>The model endpoints name.</para>
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
        public System.String ModelEndpoint { get; set; }
        #endregion
        
        #region Parameter ModelEndpointStatus
        /// <summary>
        /// <para>
        /// <para>The model endpoint’s status in Amazon Fraud Detector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.ModelEndpointStatus")]
        public Amazon.FraudDetector.ModelEndpointStatus ModelEndpointStatus { get; set; }
        #endregion
        
        #region Parameter ModelSource
        /// <summary>
        /// <para>
        /// <para>The source of the model.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.ModelSource")]
        public Amazon.FraudDetector.ModelSource ModelSource { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of key and value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FraudDetector.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_UseEventVariable
        /// <summary>
        /// <para>
        /// <para>The event variables.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InputConfiguration_UseEventVariables")]
        public System.Boolean? InputConfiguration_UseEventVariable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.PutExternalModelResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelSource parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelSource' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelSource' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FDExternalModel (PutExternalModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.PutExternalModelResponse, WriteFDExternalModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelSource;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InputConfiguration_CsvInputTemplate = this.InputConfiguration_CsvInputTemplate;
            context.InputConfiguration_EventTypeName = this.InputConfiguration_EventTypeName;
            context.InputConfiguration_Format = this.InputConfiguration_Format;
            context.InputConfiguration_JsonInputTemplate = this.InputConfiguration_JsonInputTemplate;
            context.InputConfiguration_UseEventVariable = this.InputConfiguration_UseEventVariable;
            #if MODULAR
            if (this.InputConfiguration_UseEventVariable == null && ParameterWasBound(nameof(this.InputConfiguration_UseEventVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfiguration_UseEventVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvokeModelEndpointRoleArn = this.InvokeModelEndpointRoleArn;
            #if MODULAR
            if (this.InvokeModelEndpointRoleArn == null && ParameterWasBound(nameof(this.InvokeModelEndpointRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvokeModelEndpointRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelEndpoint = this.ModelEndpoint;
            #if MODULAR
            if (this.ModelEndpoint == null && ParameterWasBound(nameof(this.ModelEndpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelEndpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelEndpointStatus = this.ModelEndpointStatus;
            #if MODULAR
            if (this.ModelEndpointStatus == null && ParameterWasBound(nameof(this.ModelEndpointStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelEndpointStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelSource = this.ModelSource;
            #if MODULAR
            if (this.ModelSource == null && ParameterWasBound(nameof(this.ModelSource)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputConfiguration_CsvIndexToVariableMap != null)
            {
                context.OutputConfiguration_CsvIndexToVariableMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OutputConfiguration_CsvIndexToVariableMap.Keys)
                {
                    context.OutputConfiguration_CsvIndexToVariableMap.Add((String)hashKey, (System.String)(this.OutputConfiguration_CsvIndexToVariableMap[hashKey]));
                }
            }
            context.OutputConfiguration_Format = this.OutputConfiguration_Format;
            #if MODULAR
            if (this.OutputConfiguration_Format == null && ParameterWasBound(nameof(this.OutputConfiguration_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputConfiguration_JsonKeyToVariableMap != null)
            {
                context.OutputConfiguration_JsonKeyToVariableMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OutputConfiguration_JsonKeyToVariableMap.Keys)
                {
                    context.OutputConfiguration_JsonKeyToVariableMap.Add((String)hashKey, (System.String)(this.OutputConfiguration_JsonKeyToVariableMap[hashKey]));
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FraudDetector.Model.Tag>(this.Tag);
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
            var request = new Amazon.FraudDetector.Model.PutExternalModelRequest();
            
            
             // populate InputConfiguration
            var requestInputConfigurationIsNull = true;
            request.InputConfiguration = new Amazon.FraudDetector.Model.ModelInputConfiguration();
            System.String requestInputConfiguration_inputConfiguration_CsvInputTemplate = null;
            if (cmdletContext.InputConfiguration_CsvInputTemplate != null)
            {
                requestInputConfiguration_inputConfiguration_CsvInputTemplate = cmdletContext.InputConfiguration_CsvInputTemplate;
            }
            if (requestInputConfiguration_inputConfiguration_CsvInputTemplate != null)
            {
                request.InputConfiguration.CsvInputTemplate = requestInputConfiguration_inputConfiguration_CsvInputTemplate;
                requestInputConfigurationIsNull = false;
            }
            System.String requestInputConfiguration_inputConfiguration_EventTypeName = null;
            if (cmdletContext.InputConfiguration_EventTypeName != null)
            {
                requestInputConfiguration_inputConfiguration_EventTypeName = cmdletContext.InputConfiguration_EventTypeName;
            }
            if (requestInputConfiguration_inputConfiguration_EventTypeName != null)
            {
                request.InputConfiguration.EventTypeName = requestInputConfiguration_inputConfiguration_EventTypeName;
                requestInputConfigurationIsNull = false;
            }
            Amazon.FraudDetector.ModelInputDataFormat requestInputConfiguration_inputConfiguration_Format = null;
            if (cmdletContext.InputConfiguration_Format != null)
            {
                requestInputConfiguration_inputConfiguration_Format = cmdletContext.InputConfiguration_Format;
            }
            if (requestInputConfiguration_inputConfiguration_Format != null)
            {
                request.InputConfiguration.Format = requestInputConfiguration_inputConfiguration_Format;
                requestInputConfigurationIsNull = false;
            }
            System.String requestInputConfiguration_inputConfiguration_JsonInputTemplate = null;
            if (cmdletContext.InputConfiguration_JsonInputTemplate != null)
            {
                requestInputConfiguration_inputConfiguration_JsonInputTemplate = cmdletContext.InputConfiguration_JsonInputTemplate;
            }
            if (requestInputConfiguration_inputConfiguration_JsonInputTemplate != null)
            {
                request.InputConfiguration.JsonInputTemplate = requestInputConfiguration_inputConfiguration_JsonInputTemplate;
                requestInputConfigurationIsNull = false;
            }
            System.Boolean? requestInputConfiguration_inputConfiguration_UseEventVariable = null;
            if (cmdletContext.InputConfiguration_UseEventVariable != null)
            {
                requestInputConfiguration_inputConfiguration_UseEventVariable = cmdletContext.InputConfiguration_UseEventVariable.Value;
            }
            if (requestInputConfiguration_inputConfiguration_UseEventVariable != null)
            {
                request.InputConfiguration.UseEventVariables = requestInputConfiguration_inputConfiguration_UseEventVariable.Value;
                requestInputConfigurationIsNull = false;
            }
             // determine if request.InputConfiguration should be set to null
            if (requestInputConfigurationIsNull)
            {
                request.InputConfiguration = null;
            }
            if (cmdletContext.InvokeModelEndpointRoleArn != null)
            {
                request.InvokeModelEndpointRoleArn = cmdletContext.InvokeModelEndpointRoleArn;
            }
            if (cmdletContext.ModelEndpoint != null)
            {
                request.ModelEndpoint = cmdletContext.ModelEndpoint;
            }
            if (cmdletContext.ModelEndpointStatus != null)
            {
                request.ModelEndpointStatus = cmdletContext.ModelEndpointStatus;
            }
            if (cmdletContext.ModelSource != null)
            {
                request.ModelSource = cmdletContext.ModelSource;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.FraudDetector.Model.ModelOutputConfiguration();
            Dictionary<System.String, System.String> requestOutputConfiguration_outputConfiguration_CsvIndexToVariableMap = null;
            if (cmdletContext.OutputConfiguration_CsvIndexToVariableMap != null)
            {
                requestOutputConfiguration_outputConfiguration_CsvIndexToVariableMap = cmdletContext.OutputConfiguration_CsvIndexToVariableMap;
            }
            if (requestOutputConfiguration_outputConfiguration_CsvIndexToVariableMap != null)
            {
                request.OutputConfiguration.CsvIndexToVariableMap = requestOutputConfiguration_outputConfiguration_CsvIndexToVariableMap;
                requestOutputConfigurationIsNull = false;
            }
            Amazon.FraudDetector.ModelOutputDataFormat requestOutputConfiguration_outputConfiguration_Format = null;
            if (cmdletContext.OutputConfiguration_Format != null)
            {
                requestOutputConfiguration_outputConfiguration_Format = cmdletContext.OutputConfiguration_Format;
            }
            if (requestOutputConfiguration_outputConfiguration_Format != null)
            {
                request.OutputConfiguration.Format = requestOutputConfiguration_outputConfiguration_Format;
                requestOutputConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestOutputConfiguration_outputConfiguration_JsonKeyToVariableMap = null;
            if (cmdletContext.OutputConfiguration_JsonKeyToVariableMap != null)
            {
                requestOutputConfiguration_outputConfiguration_JsonKeyToVariableMap = cmdletContext.OutputConfiguration_JsonKeyToVariableMap;
            }
            if (requestOutputConfiguration_outputConfiguration_JsonKeyToVariableMap != null)
            {
                request.OutputConfiguration.JsonKeyToVariableMap = requestOutputConfiguration_outputConfiguration_JsonKeyToVariableMap;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
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
        
        private Amazon.FraudDetector.Model.PutExternalModelResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.PutExternalModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "PutExternalModel");
            try
            {
                #if DESKTOP
                return client.PutExternalModel(request);
                #elif CORECLR
                return client.PutExternalModelAsync(request).GetAwaiter().GetResult();
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
            public System.String InputConfiguration_CsvInputTemplate { get; set; }
            public System.String InputConfiguration_EventTypeName { get; set; }
            public Amazon.FraudDetector.ModelInputDataFormat InputConfiguration_Format { get; set; }
            public System.String InputConfiguration_JsonInputTemplate { get; set; }
            public System.Boolean? InputConfiguration_UseEventVariable { get; set; }
            public System.String InvokeModelEndpointRoleArn { get; set; }
            public System.String ModelEndpoint { get; set; }
            public Amazon.FraudDetector.ModelEndpointStatus ModelEndpointStatus { get; set; }
            public Amazon.FraudDetector.ModelSource ModelSource { get; set; }
            public Dictionary<System.String, System.String> OutputConfiguration_CsvIndexToVariableMap { get; set; }
            public Amazon.FraudDetector.ModelOutputDataFormat OutputConfiguration_Format { get; set; }
            public Dictionary<System.String, System.String> OutputConfiguration_JsonKeyToVariableMap { get; set; }
            public List<Amazon.FraudDetector.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FraudDetector.Model.PutExternalModelResponse, WriteFDExternalModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
