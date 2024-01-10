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
    /// Creates a version of the model using the specified model type and model id.
    /// </summary>
    [Cmdlet("New", "FDModelVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FraudDetector.Model.CreateModelVersionResponse")]
    [AWSCmdlet("Calls the Amazon Fraud Detector CreateModelVersion API operation.", Operation = new[] {"CreateModelVersion"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.CreateModelVersionResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.CreateModelVersionResponse",
        "This cmdlet returns an Amazon.FraudDetector.Model.CreateModelVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFDModelVersionCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExternalEventsDetail_DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that provides Amazon Fraud Detector access to the data location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalEventsDetail_DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ExternalEventsDetail_DataLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket location for the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalEventsDetail_DataLocation { get; set; }
        #endregion
        
        #region Parameter IngestedEventsTimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>Timestamp of the final ingested event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IngestedEventsDetail_IngestedEventsTimeWindow_EndTime")]
        public System.String IngestedEventsTimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter LabelSchema_LabelMapper
        /// <summary>
        /// <para>
        /// <para>The label mapper maps the Amazon Fraud Detector supported model classification labels
        /// (<c>FRAUD</c>, <c>LEGIT</c>) to the appropriate event type labels. For example, if
        /// "<c>FRAUD</c>" and "<c>LEGIT</c>" are Amazon Fraud Detector supported labels, this
        /// mapper could be: <c>{"FRAUD" =&gt; ["0"]</c>, <c>"LEGIT" =&gt; ["1"]}</c> or <c>{"FRAUD"
        /// =&gt; ["false"]</c>, <c>"LEGIT" =&gt; ["true"]}</c> or <c>{"FRAUD" =&gt; ["fraud",
        /// "abuse"]</c>, <c>"LEGIT" =&gt; ["legit", "safe"]}</c>. The value part of the mapper
        /// is a list, because you may have multiple label variants from your event type for a
        /// single Amazon Fraud Detector label. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataSchema_LabelSchema_LabelMapper")]
        public System.Collections.Hashtable LabelSchema_LabelMapper { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The model ID. </para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter ModelType
        /// <summary>
        /// <para>
        /// <para>The model type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.ModelTypeEnum")]
        public Amazon.FraudDetector.ModelTypeEnum ModelType { get; set; }
        #endregion
        
        #region Parameter TrainingDataSchema_ModelVariable
        /// <summary>
        /// <para>
        /// <para>The training data schema variables.</para>
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
        [Alias("TrainingDataSchema_ModelVariables")]
        public System.String[] TrainingDataSchema_ModelVariable { get; set; }
        #endregion
        
        #region Parameter IngestedEventsTimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>Timestamp of the first ingensted event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IngestedEventsDetail_IngestedEventsTimeWindow_StartTime")]
        public System.String IngestedEventsTimeWindow_StartTime { get; set; }
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
        
        #region Parameter TrainingDataSource
        /// <summary>
        /// <para>
        /// <para>The training data source location in Amazon S3. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FraudDetector.TrainingDataSourceEnum")]
        public Amazon.FraudDetector.TrainingDataSourceEnum TrainingDataSource { get; set; }
        #endregion
        
        #region Parameter LabelSchema_UnlabeledEventsTreatment
        /// <summary>
        /// <para>
        /// <para>The action to take for unlabeled events.</para><ul><li><para>Use <c>IGNORE</c> if you want the unlabeled events to be ignored. This is recommended
        /// when the majority of the events in the dataset are labeled.</para></li><li><para>Use <c>FRAUD</c> if you want to categorize all unlabeled events as “Fraud”. This is
        /// recommended when most of the events in your dataset are fraudulent.</para></li><li><para>Use <c>LEGIT</c> if you want to categorize all unlabeled events as “Legit”. This is
        /// recommended when most of the events in your dataset are legitimate.</para></li><li><para>Use <c>AUTO</c> if you want Amazon Fraud Detector to decide how to use the unlabeled
        /// data. This is recommended when there is significant unlabeled events in the dataset.</para></li></ul><para>By default, Amazon Fraud Detector ignores the unlabeled data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataSchema_LabelSchema_UnlabeledEventsTreatment")]
        [AWSConstantClassSource("Amazon.FraudDetector.UnlabeledEventsTreatment")]
        public Amazon.FraudDetector.UnlabeledEventsTreatment LabelSchema_UnlabeledEventsTreatment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.CreateModelVersionResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.CreateModelVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FDModelVersion (CreateModelVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.CreateModelVersionResponse, NewFDModelVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExternalEventsDetail_DataAccessRoleArn = this.ExternalEventsDetail_DataAccessRoleArn;
            context.ExternalEventsDetail_DataLocation = this.ExternalEventsDetail_DataLocation;
            context.IngestedEventsTimeWindow_EndTime = this.IngestedEventsTimeWindow_EndTime;
            context.IngestedEventsTimeWindow_StartTime = this.IngestedEventsTimeWindow_StartTime;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelType = this.ModelType;
            #if MODULAR
            if (this.ModelType == null && ParameterWasBound(nameof(this.ModelType)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FraudDetector.Model.Tag>(this.Tag);
            }
            if (this.LabelSchema_LabelMapper != null)
            {
                context.LabelSchema_LabelMapper = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.LabelSchema_LabelMapper.Keys)
                {
                    object hashValue = this.LabelSchema_LabelMapper[hashKey];
                    if (hashValue == null)
                    {
                        context.LabelSchema_LabelMapper.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.LabelSchema_LabelMapper.Add((String)hashKey, valueSet);
                }
            }
            context.LabelSchema_UnlabeledEventsTreatment = this.LabelSchema_UnlabeledEventsTreatment;
            if (this.TrainingDataSchema_ModelVariable != null)
            {
                context.TrainingDataSchema_ModelVariable = new List<System.String>(this.TrainingDataSchema_ModelVariable);
            }
            #if MODULAR
            if (this.TrainingDataSchema_ModelVariable == null && ParameterWasBound(nameof(this.TrainingDataSchema_ModelVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataSchema_ModelVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingDataSource = this.TrainingDataSource;
            #if MODULAR
            if (this.TrainingDataSource == null && ParameterWasBound(nameof(this.TrainingDataSource)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.CreateModelVersionRequest();
            
            
             // populate ExternalEventsDetail
            var requestExternalEventsDetailIsNull = true;
            request.ExternalEventsDetail = new Amazon.FraudDetector.Model.ExternalEventsDetail();
            System.String requestExternalEventsDetail_externalEventsDetail_DataAccessRoleArn = null;
            if (cmdletContext.ExternalEventsDetail_DataAccessRoleArn != null)
            {
                requestExternalEventsDetail_externalEventsDetail_DataAccessRoleArn = cmdletContext.ExternalEventsDetail_DataAccessRoleArn;
            }
            if (requestExternalEventsDetail_externalEventsDetail_DataAccessRoleArn != null)
            {
                request.ExternalEventsDetail.DataAccessRoleArn = requestExternalEventsDetail_externalEventsDetail_DataAccessRoleArn;
                requestExternalEventsDetailIsNull = false;
            }
            System.String requestExternalEventsDetail_externalEventsDetail_DataLocation = null;
            if (cmdletContext.ExternalEventsDetail_DataLocation != null)
            {
                requestExternalEventsDetail_externalEventsDetail_DataLocation = cmdletContext.ExternalEventsDetail_DataLocation;
            }
            if (requestExternalEventsDetail_externalEventsDetail_DataLocation != null)
            {
                request.ExternalEventsDetail.DataLocation = requestExternalEventsDetail_externalEventsDetail_DataLocation;
                requestExternalEventsDetailIsNull = false;
            }
             // determine if request.ExternalEventsDetail should be set to null
            if (requestExternalEventsDetailIsNull)
            {
                request.ExternalEventsDetail = null;
            }
            
             // populate IngestedEventsDetail
            var requestIngestedEventsDetailIsNull = true;
            request.IngestedEventsDetail = new Amazon.FraudDetector.Model.IngestedEventsDetail();
            Amazon.FraudDetector.Model.IngestedEventsTimeWindow requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow = null;
            
             // populate IngestedEventsTimeWindow
            var requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindowIsNull = true;
            requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow = new Amazon.FraudDetector.Model.IngestedEventsTimeWindow();
            System.String requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_EndTime = null;
            if (cmdletContext.IngestedEventsTimeWindow_EndTime != null)
            {
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_EndTime = cmdletContext.IngestedEventsTimeWindow_EndTime;
            }
            if (requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_EndTime != null)
            {
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow.EndTime = requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_EndTime;
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindowIsNull = false;
            }
            System.String requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_StartTime = null;
            if (cmdletContext.IngestedEventsTimeWindow_StartTime != null)
            {
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_StartTime = cmdletContext.IngestedEventsTimeWindow_StartTime;
            }
            if (requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_StartTime != null)
            {
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow.StartTime = requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow_ingestedEventsTimeWindow_StartTime;
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindowIsNull = false;
            }
             // determine if requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow should be set to null
            if (requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindowIsNull)
            {
                requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow = null;
            }
            if (requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow != null)
            {
                request.IngestedEventsDetail.IngestedEventsTimeWindow = requestIngestedEventsDetail_ingestedEventsDetail_IngestedEventsTimeWindow;
                requestIngestedEventsDetailIsNull = false;
            }
             // determine if request.IngestedEventsDetail should be set to null
            if (requestIngestedEventsDetailIsNull)
            {
                request.IngestedEventsDetail = null;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.ModelType != null)
            {
                request.ModelType = cmdletContext.ModelType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrainingDataSchema
            var requestTrainingDataSchemaIsNull = true;
            request.TrainingDataSchema = new Amazon.FraudDetector.Model.TrainingDataSchema();
            List<System.String> requestTrainingDataSchema_trainingDataSchema_ModelVariable = null;
            if (cmdletContext.TrainingDataSchema_ModelVariable != null)
            {
                requestTrainingDataSchema_trainingDataSchema_ModelVariable = cmdletContext.TrainingDataSchema_ModelVariable;
            }
            if (requestTrainingDataSchema_trainingDataSchema_ModelVariable != null)
            {
                request.TrainingDataSchema.ModelVariables = requestTrainingDataSchema_trainingDataSchema_ModelVariable;
                requestTrainingDataSchemaIsNull = false;
            }
            Amazon.FraudDetector.Model.LabelSchema requestTrainingDataSchema_trainingDataSchema_LabelSchema = null;
            
             // populate LabelSchema
            var requestTrainingDataSchema_trainingDataSchema_LabelSchemaIsNull = true;
            requestTrainingDataSchema_trainingDataSchema_LabelSchema = new Amazon.FraudDetector.Model.LabelSchema();
            Dictionary<System.String, List<System.String>> requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_LabelMapper = null;
            if (cmdletContext.LabelSchema_LabelMapper != null)
            {
                requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_LabelMapper = cmdletContext.LabelSchema_LabelMapper;
            }
            if (requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_LabelMapper != null)
            {
                requestTrainingDataSchema_trainingDataSchema_LabelSchema.LabelMapper = requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_LabelMapper;
                requestTrainingDataSchema_trainingDataSchema_LabelSchemaIsNull = false;
            }
            Amazon.FraudDetector.UnlabeledEventsTreatment requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_UnlabeledEventsTreatment = null;
            if (cmdletContext.LabelSchema_UnlabeledEventsTreatment != null)
            {
                requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_UnlabeledEventsTreatment = cmdletContext.LabelSchema_UnlabeledEventsTreatment;
            }
            if (requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_UnlabeledEventsTreatment != null)
            {
                requestTrainingDataSchema_trainingDataSchema_LabelSchema.UnlabeledEventsTreatment = requestTrainingDataSchema_trainingDataSchema_LabelSchema_labelSchema_UnlabeledEventsTreatment;
                requestTrainingDataSchema_trainingDataSchema_LabelSchemaIsNull = false;
            }
             // determine if requestTrainingDataSchema_trainingDataSchema_LabelSchema should be set to null
            if (requestTrainingDataSchema_trainingDataSchema_LabelSchemaIsNull)
            {
                requestTrainingDataSchema_trainingDataSchema_LabelSchema = null;
            }
            if (requestTrainingDataSchema_trainingDataSchema_LabelSchema != null)
            {
                request.TrainingDataSchema.LabelSchema = requestTrainingDataSchema_trainingDataSchema_LabelSchema;
                requestTrainingDataSchemaIsNull = false;
            }
             // determine if request.TrainingDataSchema should be set to null
            if (requestTrainingDataSchemaIsNull)
            {
                request.TrainingDataSchema = null;
            }
            if (cmdletContext.TrainingDataSource != null)
            {
                request.TrainingDataSource = cmdletContext.TrainingDataSource;
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
        
        private Amazon.FraudDetector.Model.CreateModelVersionResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.CreateModelVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "CreateModelVersion");
            try
            {
                #if DESKTOP
                return client.CreateModelVersion(request);
                #elif CORECLR
                return client.CreateModelVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ExternalEventsDetail_DataAccessRoleArn { get; set; }
            public System.String ExternalEventsDetail_DataLocation { get; set; }
            public System.String IngestedEventsTimeWindow_EndTime { get; set; }
            public System.String IngestedEventsTimeWindow_StartTime { get; set; }
            public System.String ModelId { get; set; }
            public Amazon.FraudDetector.ModelTypeEnum ModelType { get; set; }
            public List<Amazon.FraudDetector.Model.Tag> Tag { get; set; }
            public Dictionary<System.String, List<System.String>> LabelSchema_LabelMapper { get; set; }
            public Amazon.FraudDetector.UnlabeledEventsTreatment LabelSchema_UnlabeledEventsTreatment { get; set; }
            public List<System.String> TrainingDataSchema_ModelVariable { get; set; }
            public Amazon.FraudDetector.TrainingDataSourceEnum TrainingDataSource { get; set; }
            public System.Func<Amazon.FraudDetector.Model.CreateModelVersionResponse, NewFDModelVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
