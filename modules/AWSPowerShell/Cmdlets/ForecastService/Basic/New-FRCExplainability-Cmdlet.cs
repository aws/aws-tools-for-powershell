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
    /// <note><para>
    /// Explainability is only available for Forecasts and Predictors generated from an AutoPredictor
    /// (<a>CreateAutoPredictor</a>)
    /// </para></note><para>
    /// Creates an Amazon Forecast Explainability.
    /// </para><para>
    /// Explainability helps you better understand how the attributes in your datasets impact
    /// forecast. Amazon Forecast uses a metric called Impact scores to quantify the relative
    /// impact of each attribute and determine whether they increase or decrease forecast
    /// values.
    /// </para><para>
    /// To enable Forecast Explainability, your predictor must include at least one of the
    /// following: related time series, item metadata, or additional datasets like Holidays
    /// and the Weather Index.
    /// </para><para>
    /// CreateExplainability accepts either a Predictor ARN or Forecast ARN. To receive aggregated
    /// Impact scores for all time series and time points in your datasets, provide a Predictor
    /// ARN. To receive Impact scores for specific time series and time points, provide a
    /// Forecast ARN.
    /// </para><para><b>CreateExplainability with a Predictor ARN</b></para><note><para>
    /// You can only have one Explainability resource per predictor. If you already enabled
    /// <code>ExplainPredictor</code> in <a>CreateAutoPredictor</a>, that predictor already
    /// has an Explainability resource.
    /// </para></note><para>
    /// The following parameters are required when providing a Predictor ARN:
    /// </para><ul><li><para><code>ExplainabilityName</code> - A unique name for the Explainability.
    /// </para></li><li><para><code>ResourceArn</code> - The Arn of the predictor.
    /// </para></li><li><para><code>TimePointGranularity</code> - Must be set to “ALL”.
    /// </para></li><li><para><code>TimeSeriesGranularity</code> - Must be set to “ALL”.
    /// </para></li></ul><para>
    /// Do not specify a value for the following parameters:
    /// </para><ul><li><para><code>DataSource</code> - Only valid when TimeSeriesGranularity is “SPECIFIC”.
    /// </para></li><li><para><code>Schema</code> - Only valid when TimeSeriesGranularity is “SPECIFIC”.
    /// </para></li><li><para><code>StartDateTime</code> - Only valid when TimePointGranularity is “SPECIFIC”.
    /// </para></li><li><para><code>EndDateTime</code> - Only valid when TimePointGranularity is “SPECIFIC”.
    /// </para></li></ul><para><b>CreateExplainability with a Forecast ARN</b></para><note><para>
    /// You can specify a maximum of 50 time series and 500 time points.
    /// </para></note><para>
    /// The following parameters are required when providing a Predictor ARN:
    /// </para><ul><li><para><code>ExplainabilityName</code> - A unique name for the Explainability.
    /// </para></li><li><para><code>ResourceArn</code> - The Arn of the forecast.
    /// </para></li><li><para><code>TimePointGranularity</code> - Either “ALL” or “SPECIFIC”.
    /// </para></li><li><para><code>TimeSeriesGranularity</code> - Either “ALL” or “SPECIFIC”.
    /// </para></li></ul><para>
    /// If you set TimeSeriesGranularity to “SPECIFIC”, you must also provide the following:
    /// </para><ul><li><para><code>DataSource</code> - The S3 location of the CSV file specifying your time series.
    /// </para></li><li><para><code>Schema</code> - The Schema defines the attributes and attribute types listed
    /// in the Data Source.
    /// </para></li></ul><para>
    /// If you set TimePointGranularity to “SPECIFIC”, you must also provide the following:
    /// </para><ul><li><para><code>StartDateTime</code> - The first timestamp in the range of time points.
    /// </para></li><li><para><code>EndDateTime</code> - The last timestamp in the range of time points.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "FRCExplainability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateExplainability API operation.", Operation = new[] {"CreateExplainability"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateExplainabilityResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateExplainabilityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateExplainabilityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCExplainabilityCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Schema_Attribute
        /// <summary>
        /// <para>
        /// <para>An array of attributes specifying the name and type of each field in a dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schema_Attributes")]
        public Amazon.ForecastService.Model.SchemaAttribute[] Schema_Attribute { get; set; }
        #endregion
        
        #region Parameter EnableVisualization
        /// <summary>
        /// <para>
        /// <para>Create an Explainability visualization that is viewable within the Amazon Web Services
        /// console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableVisualization { get; set; }
        #endregion
        
        #region Parameter EndDateTime
        /// <summary>
        /// <para>
        /// <para>If <code>TimePointGranularity</code> is set to <code>SPECIFIC</code>, define the last
        /// time point for the Explainability.</para><para>Use the following timestamp format: yyyy-MM-ddTHH:mm:ss (example: 2015-01-01T20:00:00)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndDateTime { get; set; }
        #endregion
        
        #region Parameter ExplainabilityName
        /// <summary>
        /// <para>
        /// <para>A unique name for the Explainability.</para>
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
        public System.String ExplainabilityName { get; set; }
        #endregion
        
        #region Parameter S3Config_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Key Management Service (KMS) key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_S3Config_KMSKeyArn")]
        public System.String S3Config_KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter S3Config_Path
        /// <summary>
        /// <para>
        /// <para>The path to an Amazon Simple Storage Service (Amazon S3) bucket or file(s) in an Amazon
        /// S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_S3Config_Path")]
        public System.String S3Config_Path { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Predictor or Forecast used to create the Explainability.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter S3Config_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Identity and Access Management (IAM) role that Amazon Forecast can
        /// assume to access the Amazon S3 bucket or files. If you provide a value for the <code>KMSKeyArn</code>
        /// key, the role must allow access to the key.</para><para>Passing a role across Amazon Web Services accounts is not allowed. If you pass a role
        /// that isn't in your account, you get an <code>InvalidInputException</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_S3Config_RoleArn")]
        public System.String S3Config_RoleArn { get; set; }
        #endregion
        
        #region Parameter StartDateTime
        /// <summary>
        /// <para>
        /// <para>If <code>TimePointGranularity</code> is set to <code>SPECIFIC</code>, define the first
        /// point for the Explainability.</para><para>Use the following timestamp format: yyyy-MM-ddTHH:mm:ss (example: 2015-01-01T20:00:00)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartDateTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata to help you categorize and organize your resources. Each tag consists
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
        
        #region Parameter ExplainabilityConfig_TimePointGranularity
        /// <summary>
        /// <para>
        /// <para>To create an Explainability for all time points in your forecast horizon, use <code>ALL</code>.
        /// To create an Explainability for specific time points in your forecast horizon, use
        /// <code>SPECIFIC</code>.</para><para>Specify time points with the <code>StartDateTime</code> and <code>EndDateTime</code>
        /// parameters within the <a>CreateExplainability</a> operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ForecastService.TimePointGranularity")]
        public Amazon.ForecastService.TimePointGranularity ExplainabilityConfig_TimePointGranularity { get; set; }
        #endregion
        
        #region Parameter ExplainabilityConfig_TimeSeriesGranularity
        /// <summary>
        /// <para>
        /// <para>To create an Explainability for all time series in your datasets, use <code>ALL</code>.
        /// To create an Explainability for specific time series in your datasets, use <code>SPECIFIC</code>.</para><para>Specify time series by uploading a CSV or Parquet file to an Amazon S3 bucket and
        /// set the location within the <a>DataDestination</a> data type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ForecastService.TimeSeriesGranularity")]
        public Amazon.ForecastService.TimeSeriesGranularity ExplainabilityConfig_TimeSeriesGranularity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExplainabilityArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateExplainabilityResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateExplainabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExplainabilityArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExplainabilityName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExplainabilityName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExplainabilityName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExplainabilityName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCExplainability (CreateExplainability)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateExplainabilityResponse, NewFRCExplainabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExplainabilityName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3Config_KMSKeyArn = this.S3Config_KMSKeyArn;
            context.S3Config_Path = this.S3Config_Path;
            context.S3Config_RoleArn = this.S3Config_RoleArn;
            context.EnableVisualization = this.EnableVisualization;
            context.EndDateTime = this.EndDateTime;
            context.ExplainabilityConfig_TimePointGranularity = this.ExplainabilityConfig_TimePointGranularity;
            #if MODULAR
            if (this.ExplainabilityConfig_TimePointGranularity == null && ParameterWasBound(nameof(this.ExplainabilityConfig_TimePointGranularity)))
            {
                WriteWarning("You are passing $null as a value for parameter ExplainabilityConfig_TimePointGranularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExplainabilityConfig_TimeSeriesGranularity = this.ExplainabilityConfig_TimeSeriesGranularity;
            #if MODULAR
            if (this.ExplainabilityConfig_TimeSeriesGranularity == null && ParameterWasBound(nameof(this.ExplainabilityConfig_TimeSeriesGranularity)))
            {
                WriteWarning("You are passing $null as a value for parameter ExplainabilityConfig_TimeSeriesGranularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExplainabilityName = this.ExplainabilityName;
            #if MODULAR
            if (this.ExplainabilityName == null && ParameterWasBound(nameof(this.ExplainabilityName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExplainabilityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Schema_Attribute != null)
            {
                context.Schema_Attribute = new List<Amazon.ForecastService.Model.SchemaAttribute>(this.Schema_Attribute);
            }
            context.StartDateTime = this.StartDateTime;
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
            var request = new Amazon.ForecastService.Model.CreateExplainabilityRequest();
            
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.ForecastService.Model.DataSource();
            Amazon.ForecastService.Model.S3Config requestDataSource_dataSource_S3Config = null;
            
             // populate S3Config
            var requestDataSource_dataSource_S3ConfigIsNull = true;
            requestDataSource_dataSource_S3Config = new Amazon.ForecastService.Model.S3Config();
            System.String requestDataSource_dataSource_S3Config_s3Config_KMSKeyArn = null;
            if (cmdletContext.S3Config_KMSKeyArn != null)
            {
                requestDataSource_dataSource_S3Config_s3Config_KMSKeyArn = cmdletContext.S3Config_KMSKeyArn;
            }
            if (requestDataSource_dataSource_S3Config_s3Config_KMSKeyArn != null)
            {
                requestDataSource_dataSource_S3Config.KMSKeyArn = requestDataSource_dataSource_S3Config_s3Config_KMSKeyArn;
                requestDataSource_dataSource_S3ConfigIsNull = false;
            }
            System.String requestDataSource_dataSource_S3Config_s3Config_Path = null;
            if (cmdletContext.S3Config_Path != null)
            {
                requestDataSource_dataSource_S3Config_s3Config_Path = cmdletContext.S3Config_Path;
            }
            if (requestDataSource_dataSource_S3Config_s3Config_Path != null)
            {
                requestDataSource_dataSource_S3Config.Path = requestDataSource_dataSource_S3Config_s3Config_Path;
                requestDataSource_dataSource_S3ConfigIsNull = false;
            }
            System.String requestDataSource_dataSource_S3Config_s3Config_RoleArn = null;
            if (cmdletContext.S3Config_RoleArn != null)
            {
                requestDataSource_dataSource_S3Config_s3Config_RoleArn = cmdletContext.S3Config_RoleArn;
            }
            if (requestDataSource_dataSource_S3Config_s3Config_RoleArn != null)
            {
                requestDataSource_dataSource_S3Config.RoleArn = requestDataSource_dataSource_S3Config_s3Config_RoleArn;
                requestDataSource_dataSource_S3ConfigIsNull = false;
            }
             // determine if requestDataSource_dataSource_S3Config should be set to null
            if (requestDataSource_dataSource_S3ConfigIsNull)
            {
                requestDataSource_dataSource_S3Config = null;
            }
            if (requestDataSource_dataSource_S3Config != null)
            {
                request.DataSource.S3Config = requestDataSource_dataSource_S3Config;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.EnableVisualization != null)
            {
                request.EnableVisualization = cmdletContext.EnableVisualization.Value;
            }
            if (cmdletContext.EndDateTime != null)
            {
                request.EndDateTime = cmdletContext.EndDateTime;
            }
            
             // populate ExplainabilityConfig
            var requestExplainabilityConfigIsNull = true;
            request.ExplainabilityConfig = new Amazon.ForecastService.Model.ExplainabilityConfig();
            Amazon.ForecastService.TimePointGranularity requestExplainabilityConfig_explainabilityConfig_TimePointGranularity = null;
            if (cmdletContext.ExplainabilityConfig_TimePointGranularity != null)
            {
                requestExplainabilityConfig_explainabilityConfig_TimePointGranularity = cmdletContext.ExplainabilityConfig_TimePointGranularity;
            }
            if (requestExplainabilityConfig_explainabilityConfig_TimePointGranularity != null)
            {
                request.ExplainabilityConfig.TimePointGranularity = requestExplainabilityConfig_explainabilityConfig_TimePointGranularity;
                requestExplainabilityConfigIsNull = false;
            }
            Amazon.ForecastService.TimeSeriesGranularity requestExplainabilityConfig_explainabilityConfig_TimeSeriesGranularity = null;
            if (cmdletContext.ExplainabilityConfig_TimeSeriesGranularity != null)
            {
                requestExplainabilityConfig_explainabilityConfig_TimeSeriesGranularity = cmdletContext.ExplainabilityConfig_TimeSeriesGranularity;
            }
            if (requestExplainabilityConfig_explainabilityConfig_TimeSeriesGranularity != null)
            {
                request.ExplainabilityConfig.TimeSeriesGranularity = requestExplainabilityConfig_explainabilityConfig_TimeSeriesGranularity;
                requestExplainabilityConfigIsNull = false;
            }
             // determine if request.ExplainabilityConfig should be set to null
            if (requestExplainabilityConfigIsNull)
            {
                request.ExplainabilityConfig = null;
            }
            if (cmdletContext.ExplainabilityName != null)
            {
                request.ExplainabilityName = cmdletContext.ExplainabilityName;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate Schema
            var requestSchemaIsNull = true;
            request.Schema = new Amazon.ForecastService.Model.Schema();
            List<Amazon.ForecastService.Model.SchemaAttribute> requestSchema_schema_Attribute = null;
            if (cmdletContext.Schema_Attribute != null)
            {
                requestSchema_schema_Attribute = cmdletContext.Schema_Attribute;
            }
            if (requestSchema_schema_Attribute != null)
            {
                request.Schema.Attributes = requestSchema_schema_Attribute;
                requestSchemaIsNull = false;
            }
             // determine if request.Schema should be set to null
            if (requestSchemaIsNull)
            {
                request.Schema = null;
            }
            if (cmdletContext.StartDateTime != null)
            {
                request.StartDateTime = cmdletContext.StartDateTime;
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
        
        private Amazon.ForecastService.Model.CreateExplainabilityResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateExplainabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateExplainability");
            try
            {
                #if DESKTOP
                return client.CreateExplainability(request);
                #elif CORECLR
                return client.CreateExplainabilityAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Config_KMSKeyArn { get; set; }
            public System.String S3Config_Path { get; set; }
            public System.String S3Config_RoleArn { get; set; }
            public System.Boolean? EnableVisualization { get; set; }
            public System.String EndDateTime { get; set; }
            public Amazon.ForecastService.TimePointGranularity ExplainabilityConfig_TimePointGranularity { get; set; }
            public Amazon.ForecastService.TimeSeriesGranularity ExplainabilityConfig_TimeSeriesGranularity { get; set; }
            public System.String ExplainabilityName { get; set; }
            public System.String ResourceArn { get; set; }
            public List<Amazon.ForecastService.Model.SchemaAttribute> Schema_Attribute { get; set; }
            public System.String StartDateTime { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateExplainabilityResponse, NewFRCExplainabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExplainabilityArn;
        }
        
    }
}
