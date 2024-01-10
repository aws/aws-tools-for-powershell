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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Evaluates an event against a detector version. If a version ID is not provided, the
    /// detector’s (<c>ACTIVE</c>) version is used.
    /// </summary>
    [Cmdlet("Get", "FDEventPrediction")]
    [OutputType("Amazon.FraudDetector.Model.GetEventPredictionResponse")]
    [AWSCmdlet("Calls the Amazon Fraud Detector GetEventPrediction API operation.", Operation = new[] {"GetEventPrediction"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.GetEventPredictionResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.GetEventPredictionResponse",
        "This cmdlet returns an Amazon.FraudDetector.Model.GetEventPredictionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFDEventPredictionCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The detector ID.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter DetectorVersionId
        /// <summary>
        /// <para>
        /// <para>The detector version ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorVersionId { get; set; }
        #endregion
        
        #region Parameter Entity
        /// <summary>
        /// <para>
        /// <para>The entity type (associated with the detector's event type) and specific entity ID
        /// representing who performed the event. If an entity id is not available, use "UNKNOWN."</para>
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
        [Alias("Entities")]
        public Amazon.FraudDetector.Model.Entity[] Entity { get; set; }
        #endregion
        
        #region Parameter EventId
        /// <summary>
        /// <para>
        /// <para>The unique ID used to identify the event.</para>
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
        public System.String EventId { get; set; }
        #endregion
        
        #region Parameter EventTimestamp
        /// <summary>
        /// <para>
        /// <para>Timestamp that defines when the event under evaluation occurred. The timestamp must
        /// be specified using ISO 8601 standard in UTC.</para>
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
        public System.String EventTimestamp { get; set; }
        #endregion
        
        #region Parameter EventTypeName
        /// <summary>
        /// <para>
        /// <para>The event type associated with the detector specified for the prediction.</para>
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
        public System.String EventTypeName { get; set; }
        #endregion
        
        #region Parameter EventVariable
        /// <summary>
        /// <para>
        /// <para>Names of the event type's variables you defined in Amazon Fraud Detector to represent
        /// data elements and their corresponding values for the event you are sending for evaluation.</para><important><para>You must provide at least one eventVariable</para></important><para>To ensure most accurate fraud prediction and to simplify your data preparation, Amazon
        /// Fraud Detector will replace all missing variables or values as follows:</para><para><b>For Amazon Fraud Detector trained models:</b></para><para>If a null value is provided explicitly for a variable or if a variable is missing,
        /// model will replace the null value or the missing variable (no variable name in the
        /// eventVariables map) with calculated default mean/medians for numeric variables and
        /// with special values for categorical variables.</para><para><b>For imported SageMaker models:</b></para><para>If a null value is provided explicitly for a variable, the model and rules will use
        /// “null” as the value. If a variable is not provided (no variable name in the eventVariables
        /// map), model and rules will use the default value that is provided for the variable.
        /// </para>
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
        [Alias("EventVariables")]
        public System.Collections.Hashtable EventVariable { get; set; }
        #endregion
        
        #region Parameter ExternalModelEndpointDataBlob
        /// <summary>
        /// <para>
        /// <para>The Amazon SageMaker model endpoint input data blobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalModelEndpointDataBlobs")]
        public System.Collections.Hashtable ExternalModelEndpointDataBlob { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.GetEventPredictionResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.GetEventPredictionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.GetEventPredictionResponse, GetFDEventPredictionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorVersionId = this.DetectorVersionId;
            if (this.Entity != null)
            {
                context.Entity = new List<Amazon.FraudDetector.Model.Entity>(this.Entity);
            }
            #if MODULAR
            if (this.Entity == null && ParameterWasBound(nameof(this.Entity)))
            {
                WriteWarning("You are passing $null as a value for parameter Entity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventId = this.EventId;
            #if MODULAR
            if (this.EventId == null && ParameterWasBound(nameof(this.EventId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventTimestamp = this.EventTimestamp;
            #if MODULAR
            if (this.EventTimestamp == null && ParameterWasBound(nameof(this.EventTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventTypeName = this.EventTypeName;
            #if MODULAR
            if (this.EventTypeName == null && ParameterWasBound(nameof(this.EventTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventVariable != null)
            {
                context.EventVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EventVariable.Keys)
                {
                    context.EventVariable.Add((String)hashKey, (String)(this.EventVariable[hashKey]));
                }
            }
            #if MODULAR
            if (this.EventVariable == null && ParameterWasBound(nameof(this.EventVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter EventVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExternalModelEndpointDataBlob != null)
            {
                context.ExternalModelEndpointDataBlob = new Dictionary<System.String, Amazon.FraudDetector.Model.ModelEndpointDataBlob>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExternalModelEndpointDataBlob.Keys)
                {
                    context.ExternalModelEndpointDataBlob.Add((String)hashKey, (ModelEndpointDataBlob)(this.ExternalModelEndpointDataBlob[hashKey]));
                }
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
            var request = new Amazon.FraudDetector.Model.GetEventPredictionRequest();
            
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.DetectorVersionId != null)
            {
                request.DetectorVersionId = cmdletContext.DetectorVersionId;
            }
            if (cmdletContext.Entity != null)
            {
                request.Entities = cmdletContext.Entity;
            }
            if (cmdletContext.EventId != null)
            {
                request.EventId = cmdletContext.EventId;
            }
            if (cmdletContext.EventTimestamp != null)
            {
                request.EventTimestamp = cmdletContext.EventTimestamp;
            }
            if (cmdletContext.EventTypeName != null)
            {
                request.EventTypeName = cmdletContext.EventTypeName;
            }
            if (cmdletContext.EventVariable != null)
            {
                request.EventVariables = cmdletContext.EventVariable;
            }
            if (cmdletContext.ExternalModelEndpointDataBlob != null)
            {
                request.ExternalModelEndpointDataBlobs = cmdletContext.ExternalModelEndpointDataBlob;
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
        
        private Amazon.FraudDetector.Model.GetEventPredictionResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.GetEventPredictionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "GetEventPrediction");
            try
            {
                #if DESKTOP
                return client.GetEventPrediction(request);
                #elif CORECLR
                return client.GetEventPredictionAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public System.String DetectorVersionId { get; set; }
            public List<Amazon.FraudDetector.Model.Entity> Entity { get; set; }
            public System.String EventId { get; set; }
            public System.String EventTimestamp { get; set; }
            public System.String EventTypeName { get; set; }
            public Dictionary<System.String, System.String> EventVariable { get; set; }
            public Dictionary<System.String, Amazon.FraudDetector.Model.ModelEndpointDataBlob> ExternalModelEndpointDataBlob { get; set; }
            public System.Func<Amazon.FraudDetector.Model.GetEventPredictionResponse, GetFDEventPredictionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
