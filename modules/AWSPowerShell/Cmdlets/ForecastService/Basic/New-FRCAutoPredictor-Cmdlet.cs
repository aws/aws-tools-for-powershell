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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Creates an Amazon Forecast predictor.
    /// 
    ///  
    /// <para>
    /// Amazon Forecast creates predictors with AutoPredictor, which involves applying the
    /// optimal combination of algorithms to each time series in your datasets. You can use
    /// <a>CreateAutoPredictor</a> to create new predictors or upgrade/retrain existing predictors.
    /// </para><para><b>Creating new predictors</b></para><para>
    /// The following parameters are required when creating a new predictor:
    /// </para><ul><li><para><code>PredictorName</code> - A unique name for the predictor.
    /// </para></li><li><para><code>DatasetGroupArn</code> - The ARN of the dataset group used to train the predictor.
    /// </para></li><li><para><code>ForecastFrequency</code> - The granularity of your forecasts (hourly, daily,
    /// weekly, etc).
    /// </para></li><li><para><code>ForecastHorizon</code> - The number of time-steps that the model predicts.
    /// The forecast horizon is also called the prediction length.
    /// </para></li></ul><para>
    /// When creating a new predictor, do not specify a value for <code>ReferencePredictorArn</code>.
    /// </para><para><b>Upgrading and retraining predictors</b></para><para>
    /// The following parameters are required when retraining or upgrading a predictor:
    /// </para><ul><li><para><code>PredictorName</code> - A unique name for the predictor.
    /// </para></li><li><para><code>ReferencePredictorArn</code> - The ARN of the predictor to retrain or upgrade.
    /// </para></li></ul><para>
    /// When upgrading or retraining a predictor, only specify values for the <code>ReferencePredictorArn</code>
    /// and <code>PredictorName</code>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "FRCAutoPredictor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateAutoPredictor API operation.", Operation = new[] {"CreateAutoPredictor"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateAutoPredictorResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateAutoPredictorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateAutoPredictorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCAutoPredictorCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DataConfig_AdditionalDataset
        /// <summary>
        /// <para>
        /// <para>Additional built-in datasets like Holidays and the Weather Index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataConfig_AdditionalDatasets")]
        public Amazon.ForecastService.Model.AdditionalDataset[] DataConfig_AdditionalDataset { get; set; }
        #endregion
        
        #region Parameter DataConfig_AttributeConfig
        /// <summary>
        /// <para>
        /// <para>Aggregation and filling options for attributes in your dataset group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataConfig_AttributeConfigs")]
        public Amazon.ForecastService.Model.AttributeConfig[] DataConfig_AttributeConfig { get; set; }
        #endregion
        
        #region Parameter DataConfig_DatasetGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the dataset group used to train the predictor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataConfig_DatasetGroupArn { get; set; }
        #endregion
        
        #region Parameter ExplainPredictor
        /// <summary>
        /// <para>
        /// <para>Create an Explainability resource for the predictor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExplainPredictor { get; set; }
        #endregion
        
        #region Parameter ForecastDimension
        /// <summary>
        /// <para>
        /// <para>An array of dimension (field) names that specify how to group the generated forecast.</para><para>For example, if you are generating forecasts for item sales across all your stores,
        /// and your dataset contains a <code>store_id</code> field, you would specify <code>store_id</code>
        /// as a dimension to group sales forecasts for each store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ForecastDimensions")]
        public System.String[] ForecastDimension { get; set; }
        #endregion
        
        #region Parameter ForecastFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency of predictions in a forecast.</para><para>Valid intervals are Y (Year), M (Month), W (Week), D (Day), H (Hour), 30min (30 minutes),
        /// 15min (15 minutes), 10min (10 minutes), 5min (5 minutes), and 1min (1 minute). For
        /// example, "Y" indicates every year and "5min" indicates every five minutes.</para><para>The frequency must be greater than or equal to the TARGET_TIME_SERIES dataset frequency.</para><para>When a RELATED_TIME_SERIES dataset is provided, the frequency must be equal to the
        /// RELATED_TIME_SERIES dataset frequency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ForecastFrequency { get; set; }
        #endregion
        
        #region Parameter ForecastHorizon
        /// <summary>
        /// <para>
        /// <para>The number of time-steps that the model predicts. The forecast horizon is also called
        /// the prediction length.</para><para>The maximum forecast horizon is the lesser of 500 time-steps or 1/4 of the TARGET_TIME_SERIES
        /// dataset length. If you are retraining an existing AutoPredictor, then the maximum
        /// forecast horizon is the lesser of 500 time-steps or 1/3 of the TARGET_TIME_SERIES
        /// dataset length.</para><para>If you are upgrading to an AutoPredictor or retraining an existing AutoPredictor,
        /// you cannot update the forecast horizon parameter. You can meet this requirement by
        /// providing longer time-series in the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ForecastHorizon { get; set; }
        #endregion
        
        #region Parameter ForecastType
        /// <summary>
        /// <para>
        /// <para>The forecast types used to train a predictor. You can specify up to five forecast
        /// types. Forecast types can be quantiles from 0.01 to 0.99, by increments of 0.01 or
        /// higher. You can also specify the mean forecast with <code>mean</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ForecastTypes")]
        public System.String[] ForecastType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfig_KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter MonitorConfig_MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitorConfig_MonitorName { get; set; }
        #endregion
        
        #region Parameter OptimizationMetric
        /// <summary>
        /// <para>
        /// <para>The accuracy metric used to optimize the predictor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ForecastService.OptimizationMetric")]
        public Amazon.ForecastService.OptimizationMetric OptimizationMetric { get; set; }
        #endregion
        
        #region Parameter PredictorName
        /// <summary>
        /// <para>
        /// <para>A unique name for the predictor</para>
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
        public System.String PredictorName { get; set; }
        #endregion
        
        #region Parameter ReferencePredictorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the predictor to retrain or upgrade. This parameter is only used when retraining
        /// or upgrading a predictor. When creating a new predictor, do not specify a value for
        /// this parameter.</para><para>When upgrading or retraining a predictor, only specify values for the <code>ReferencePredictorArn</code>
        /// and <code>PredictorName</code>. The value for <code>PredictorName</code> must be a
        /// unique predictor name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReferencePredictorArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Amazon Forecast can assume to access the AWS KMS key.</para><para>Passing a role across AWS accounts is not allowed. If you pass a role that isn't in
        /// your account, you get an <code>InvalidInputException</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata to help you categorize and organize your predictors. Each tag consists
        /// of a key and an optional value, both of which you define. Tag keys and values are
        /// case sensitive.</para><para>The following restrictions apply to tags:</para><ul><li><para>For each resource, each tag key must be unique and each tag key must have one value.</para></li><li><para>Maximum number of tags per resource: 50.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8.</para></li><li><para>Accepted characters: all letters and numbers, spaces representable in UTF-8, and +
        /// - = . _ : / @. If your tagging schema is used across other services and resources,
        /// the character restrictions of those services also apply. </para></li><li><para>Key prefixes cannot include any upper or lowercase combination of <code>aws:</code>
        /// or <code>AWS:</code>. Values can have this prefix. If a tag value has <code>aws</code>
        /// as its prefix but the key does not, Forecast considers it to be a user tag and will
        /// count against the limit of 50 tags. Tags with only the key prefix of <code>aws</code>
        /// do not count against your tags per resource limit. You cannot edit or delete tag keys
        /// with this prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PredictorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateAutoPredictorResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateAutoPredictorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PredictorArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PredictorName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PredictorName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PredictorName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PredictorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCAutoPredictor (CreateAutoPredictor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateAutoPredictorResponse, NewFRCAutoPredictorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PredictorName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DataConfig_AdditionalDataset != null)
            {
                context.DataConfig_AdditionalDataset = new List<Amazon.ForecastService.Model.AdditionalDataset>(this.DataConfig_AdditionalDataset);
            }
            if (this.DataConfig_AttributeConfig != null)
            {
                context.DataConfig_AttributeConfig = new List<Amazon.ForecastService.Model.AttributeConfig>(this.DataConfig_AttributeConfig);
            }
            context.DataConfig_DatasetGroupArn = this.DataConfig_DatasetGroupArn;
            context.EncryptionConfig_KMSKeyArn = this.EncryptionConfig_KMSKeyArn;
            context.EncryptionConfig_RoleArn = this.EncryptionConfig_RoleArn;
            context.ExplainPredictor = this.ExplainPredictor;
            if (this.ForecastDimension != null)
            {
                context.ForecastDimension = new List<System.String>(this.ForecastDimension);
            }
            context.ForecastFrequency = this.ForecastFrequency;
            context.ForecastHorizon = this.ForecastHorizon;
            if (this.ForecastType != null)
            {
                context.ForecastType = new List<System.String>(this.ForecastType);
            }
            context.MonitorConfig_MonitorName = this.MonitorConfig_MonitorName;
            context.OptimizationMetric = this.OptimizationMetric;
            context.PredictorName = this.PredictorName;
            #if MODULAR
            if (this.PredictorName == null && ParameterWasBound(nameof(this.PredictorName)))
            {
                WriteWarning("You are passing $null as a value for parameter PredictorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReferencePredictorArn = this.ReferencePredictorArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ForecastService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ForecastService.Model.CreateAutoPredictorRequest();
            
            
             // populate DataConfig
            var requestDataConfigIsNull = true;
            request.DataConfig = new Amazon.ForecastService.Model.DataConfig();
            List<Amazon.ForecastService.Model.AdditionalDataset> requestDataConfig_dataConfig_AdditionalDataset = null;
            if (cmdletContext.DataConfig_AdditionalDataset != null)
            {
                requestDataConfig_dataConfig_AdditionalDataset = cmdletContext.DataConfig_AdditionalDataset;
            }
            if (requestDataConfig_dataConfig_AdditionalDataset != null)
            {
                request.DataConfig.AdditionalDatasets = requestDataConfig_dataConfig_AdditionalDataset;
                requestDataConfigIsNull = false;
            }
            List<Amazon.ForecastService.Model.AttributeConfig> requestDataConfig_dataConfig_AttributeConfig = null;
            if (cmdletContext.DataConfig_AttributeConfig != null)
            {
                requestDataConfig_dataConfig_AttributeConfig = cmdletContext.DataConfig_AttributeConfig;
            }
            if (requestDataConfig_dataConfig_AttributeConfig != null)
            {
                request.DataConfig.AttributeConfigs = requestDataConfig_dataConfig_AttributeConfig;
                requestDataConfigIsNull = false;
            }
            System.String requestDataConfig_dataConfig_DatasetGroupArn = null;
            if (cmdletContext.DataConfig_DatasetGroupArn != null)
            {
                requestDataConfig_dataConfig_DatasetGroupArn = cmdletContext.DataConfig_DatasetGroupArn;
            }
            if (requestDataConfig_dataConfig_DatasetGroupArn != null)
            {
                request.DataConfig.DatasetGroupArn = requestDataConfig_dataConfig_DatasetGroupArn;
                requestDataConfigIsNull = false;
            }
             // determine if request.DataConfig should be set to null
            if (requestDataConfigIsNull)
            {
                request.DataConfig = null;
            }
            
             // populate EncryptionConfig
            var requestEncryptionConfigIsNull = true;
            request.EncryptionConfig = new Amazon.ForecastService.Model.EncryptionConfig();
            System.String requestEncryptionConfig_encryptionConfig_KMSKeyArn = null;
            if (cmdletContext.EncryptionConfig_KMSKeyArn != null)
            {
                requestEncryptionConfig_encryptionConfig_KMSKeyArn = cmdletContext.EncryptionConfig_KMSKeyArn;
            }
            if (requestEncryptionConfig_encryptionConfig_KMSKeyArn != null)
            {
                request.EncryptionConfig.KMSKeyArn = requestEncryptionConfig_encryptionConfig_KMSKeyArn;
                requestEncryptionConfigIsNull = false;
            }
            System.String requestEncryptionConfig_encryptionConfig_RoleArn = null;
            if (cmdletContext.EncryptionConfig_RoleArn != null)
            {
                requestEncryptionConfig_encryptionConfig_RoleArn = cmdletContext.EncryptionConfig_RoleArn;
            }
            if (requestEncryptionConfig_encryptionConfig_RoleArn != null)
            {
                request.EncryptionConfig.RoleArn = requestEncryptionConfig_encryptionConfig_RoleArn;
                requestEncryptionConfigIsNull = false;
            }
             // determine if request.EncryptionConfig should be set to null
            if (requestEncryptionConfigIsNull)
            {
                request.EncryptionConfig = null;
            }
            if (cmdletContext.ExplainPredictor != null)
            {
                request.ExplainPredictor = cmdletContext.ExplainPredictor.Value;
            }
            if (cmdletContext.ForecastDimension != null)
            {
                request.ForecastDimensions = cmdletContext.ForecastDimension;
            }
            if (cmdletContext.ForecastFrequency != null)
            {
                request.ForecastFrequency = cmdletContext.ForecastFrequency;
            }
            if (cmdletContext.ForecastHorizon != null)
            {
                request.ForecastHorizon = cmdletContext.ForecastHorizon.Value;
            }
            if (cmdletContext.ForecastType != null)
            {
                request.ForecastTypes = cmdletContext.ForecastType;
            }
            
             // populate MonitorConfig
            var requestMonitorConfigIsNull = true;
            request.MonitorConfig = new Amazon.ForecastService.Model.MonitorConfig();
            System.String requestMonitorConfig_monitorConfig_MonitorName = null;
            if (cmdletContext.MonitorConfig_MonitorName != null)
            {
                requestMonitorConfig_monitorConfig_MonitorName = cmdletContext.MonitorConfig_MonitorName;
            }
            if (requestMonitorConfig_monitorConfig_MonitorName != null)
            {
                request.MonitorConfig.MonitorName = requestMonitorConfig_monitorConfig_MonitorName;
                requestMonitorConfigIsNull = false;
            }
             // determine if request.MonitorConfig should be set to null
            if (requestMonitorConfigIsNull)
            {
                request.MonitorConfig = null;
            }
            if (cmdletContext.OptimizationMetric != null)
            {
                request.OptimizationMetric = cmdletContext.OptimizationMetric;
            }
            if (cmdletContext.PredictorName != null)
            {
                request.PredictorName = cmdletContext.PredictorName;
            }
            if (cmdletContext.ReferencePredictorArn != null)
            {
                request.ReferencePredictorArn = cmdletContext.ReferencePredictorArn;
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
        
        private Amazon.ForecastService.Model.CreateAutoPredictorResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateAutoPredictorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateAutoPredictor");
            try
            {
                #if DESKTOP
                return client.CreateAutoPredictor(request);
                #elif CORECLR
                return client.CreateAutoPredictorAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ForecastService.Model.AdditionalDataset> DataConfig_AdditionalDataset { get; set; }
            public List<Amazon.ForecastService.Model.AttributeConfig> DataConfig_AttributeConfig { get; set; }
            public System.String DataConfig_DatasetGroupArn { get; set; }
            public System.String EncryptionConfig_KMSKeyArn { get; set; }
            public System.String EncryptionConfig_RoleArn { get; set; }
            public System.Boolean? ExplainPredictor { get; set; }
            public List<System.String> ForecastDimension { get; set; }
            public System.String ForecastFrequency { get; set; }
            public System.Int32? ForecastHorizon { get; set; }
            public List<System.String> ForecastType { get; set; }
            public System.String MonitorConfig_MonitorName { get; set; }
            public Amazon.ForecastService.OptimizationMetric OptimizationMetric { get; set; }
            public System.String PredictorName { get; set; }
            public System.String ReferencePredictorArn { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateAutoPredictorResponse, NewFRCAutoPredictorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PredictorArn;
        }
        
    }
}
