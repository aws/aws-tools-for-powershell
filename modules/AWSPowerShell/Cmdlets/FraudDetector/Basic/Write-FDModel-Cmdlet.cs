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
    /// Creates or updates a model.
    /// </summary>
    [Cmdlet("Write", "FDModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector PutModel API operation.", Operation = new[] {"PutModel"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.PutModelResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.PutModelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.PutModelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteFDModelCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        #region Parameter TrainingDataSource_DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The data access role ARN for the training data source.</para>
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
        public System.String TrainingDataSource_DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter TrainingDataSource_DataLocation
        /// <summary>
        /// <para>
        /// <para>The data location of the training data source.</para>
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
        public System.String TrainingDataSource_DataLocation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The model description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LabelSchema_LabelKey
        /// <summary>
        /// <para>
        /// <para>The label key.</para>
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
        public System.String LabelSchema_LabelKey { get; set; }
        #endregion
        
        #region Parameter LabelSchema_LabelMapper
        /// <summary>
        /// <para>
        /// <para>The label mapper maps the Amazon Fraud Detector supported label to the appropriate
        /// source labels. For example, if <code>"FRAUD"</code> and <code>"LEGIT"</code> are Amazon
        /// Fraud Detector supported labels, this mapper could be: <code>{"FRAUD" =&gt; ["0"]</code>,
        /// "LEGIT" =&gt; ["1"]} or <code>{"FRAUD" =&gt; ["false"], "LEGIT" =&gt; ["true"]}</code>
        /// or <code>{"FRAUD" =&gt; ["fraud", "abuse"], "LEGIT" =&gt; ["legit", "safe"]}</code>.
        /// The value part of the mapper is a list, because you may have multiple variants for
        /// a single Amazon Fraud Detector label. </para>
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
        public System.Collections.Hashtable LabelSchema_LabelMapper { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The model ID.</para>
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
        /// <para>The model type. </para>
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
        
        #region Parameter ModelVariable
        /// <summary>
        /// <para>
        /// <para>The model input variables.</para>
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
        [Alias("ModelVariables")]
        public Amazon.FraudDetector.Model.ModelVariable[] ModelVariable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.PutModelResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FDModel (PutModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.PutModelResponse, WriteFDModelCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.LabelSchema_LabelKey = this.LabelSchema_LabelKey;
            #if MODULAR
            if (this.LabelSchema_LabelKey == null && ParameterWasBound(nameof(this.LabelSchema_LabelKey)))
            {
                WriteWarning("You are passing $null as a value for parameter LabelSchema_LabelKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.LabelSchema_LabelMapper.Add((String)hashKey, valueSet);
                }
            }
            #if MODULAR
            if (this.LabelSchema_LabelMapper == null && ParameterWasBound(nameof(this.LabelSchema_LabelMapper)))
            {
                WriteWarning("You are passing $null as a value for parameter LabelSchema_LabelMapper which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.ModelVariable != null)
            {
                context.ModelVariable = new List<Amazon.FraudDetector.Model.ModelVariable>(this.ModelVariable);
            }
            #if MODULAR
            if (this.ModelVariable == null && ParameterWasBound(nameof(this.ModelVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingDataSource_DataAccessRoleArn = this.TrainingDataSource_DataAccessRoleArn;
            #if MODULAR
            if (this.TrainingDataSource_DataAccessRoleArn == null && ParameterWasBound(nameof(this.TrainingDataSource_DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataSource_DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingDataSource_DataLocation = this.TrainingDataSource_DataLocation;
            #if MODULAR
            if (this.TrainingDataSource_DataLocation == null && ParameterWasBound(nameof(this.TrainingDataSource_DataLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingDataSource_DataLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.PutModelRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate LabelSchema
            var requestLabelSchemaIsNull = true;
            request.LabelSchema = new Amazon.FraudDetector.Model.LabelSchema();
            System.String requestLabelSchema_labelSchema_LabelKey = null;
            if (cmdletContext.LabelSchema_LabelKey != null)
            {
                requestLabelSchema_labelSchema_LabelKey = cmdletContext.LabelSchema_LabelKey;
            }
            if (requestLabelSchema_labelSchema_LabelKey != null)
            {
                request.LabelSchema.LabelKey = requestLabelSchema_labelSchema_LabelKey;
                requestLabelSchemaIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestLabelSchema_labelSchema_LabelMapper = null;
            if (cmdletContext.LabelSchema_LabelMapper != null)
            {
                requestLabelSchema_labelSchema_LabelMapper = cmdletContext.LabelSchema_LabelMapper;
            }
            if (requestLabelSchema_labelSchema_LabelMapper != null)
            {
                request.LabelSchema.LabelMapper = requestLabelSchema_labelSchema_LabelMapper;
                requestLabelSchemaIsNull = false;
            }
             // determine if request.LabelSchema should be set to null
            if (requestLabelSchemaIsNull)
            {
                request.LabelSchema = null;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.ModelType != null)
            {
                request.ModelType = cmdletContext.ModelType;
            }
            if (cmdletContext.ModelVariable != null)
            {
                request.ModelVariables = cmdletContext.ModelVariable;
            }
            
             // populate TrainingDataSource
            var requestTrainingDataSourceIsNull = true;
            request.TrainingDataSource = new Amazon.FraudDetector.Model.TrainingDataSource();
            System.String requestTrainingDataSource_trainingDataSource_DataAccessRoleArn = null;
            if (cmdletContext.TrainingDataSource_DataAccessRoleArn != null)
            {
                requestTrainingDataSource_trainingDataSource_DataAccessRoleArn = cmdletContext.TrainingDataSource_DataAccessRoleArn;
            }
            if (requestTrainingDataSource_trainingDataSource_DataAccessRoleArn != null)
            {
                request.TrainingDataSource.DataAccessRoleArn = requestTrainingDataSource_trainingDataSource_DataAccessRoleArn;
                requestTrainingDataSourceIsNull = false;
            }
            System.String requestTrainingDataSource_trainingDataSource_DataLocation = null;
            if (cmdletContext.TrainingDataSource_DataLocation != null)
            {
                requestTrainingDataSource_trainingDataSource_DataLocation = cmdletContext.TrainingDataSource_DataLocation;
            }
            if (requestTrainingDataSource_trainingDataSource_DataLocation != null)
            {
                request.TrainingDataSource.DataLocation = requestTrainingDataSource_trainingDataSource_DataLocation;
                requestTrainingDataSourceIsNull = false;
            }
             // determine if request.TrainingDataSource should be set to null
            if (requestTrainingDataSourceIsNull)
            {
                request.TrainingDataSource = null;
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
        
        private Amazon.FraudDetector.Model.PutModelResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.PutModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "PutModel");
            try
            {
                #if DESKTOP
                return client.PutModel(request);
                #elif CORECLR
                return client.PutModelAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String LabelSchema_LabelKey { get; set; }
            public Dictionary<System.String, List<System.String>> LabelSchema_LabelMapper { get; set; }
            public System.String ModelId { get; set; }
            public Amazon.FraudDetector.ModelTypeEnum ModelType { get; set; }
            public List<Amazon.FraudDetector.Model.ModelVariable> ModelVariable { get; set; }
            public System.String TrainingDataSource_DataAccessRoleArn { get; set; }
            public System.String TrainingDataSource_DataLocation { get; set; }
            public System.Func<Amazon.FraudDetector.Model.PutModelResponse, WriteFDModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
