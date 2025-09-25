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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// A what-if forecast is a forecast that is created from a modified version of the baseline
    /// forecast. Each what-if forecast incorporates either a replacement dataset or a set
    /// of transformations to the original dataset.
    /// </summary>
    [Cmdlet("New", "FRCWhatIfForecast", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateWhatIfForecast API operation.", Operation = new[] {"CreateWhatIfForecast"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateWhatIfForecastResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateWhatIfForecastResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateWhatIfForecastResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFRCWhatIfForecastCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Schema_Attribute
        /// <summary>
        /// <para>
        /// <para>An array of attributes specifying the name and type of each field in a dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeSeriesReplacementsDataSource_Schema_Attributes")]
        public Amazon.ForecastService.Model.SchemaAttribute[] Schema_Attribute { get; set; }
        #endregion
        
        #region Parameter TimeSeriesReplacementsDataSource_Format
        /// <summary>
        /// <para>
        /// <para>The format of the replacement data, CSV or PARQUET.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeSeriesReplacementsDataSource_Format { get; set; }
        #endregion
        
        #region Parameter S3Config_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Key Management Service (KMS) key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeSeriesReplacementsDataSource_S3Config_KMSKeyArn")]
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
        [Alias("TimeSeriesReplacementsDataSource_S3Config_Path")]
        public System.String S3Config_Path { get; set; }
        #endregion
        
        #region Parameter S3Config_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Identity and Access Management (IAM) role that Amazon Forecast can
        /// assume to access the Amazon S3 bucket or files. If you provide a value for the <c>KMSKeyArn</c>
        /// key, the role must allow access to the key.</para><para>Passing a role across Amazon Web Services accounts is not allowed. If you pass a role
        /// that isn't in your account, you get an <c>InvalidInputException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeSeriesReplacementsDataSource_S3Config_RoleArn")]
        public System.String S3Config_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/forecast/latest/dg/tagging-forecast-resources.html">tags</a>
        /// to apply to the what if forecast.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimeSeriesTransformation
        /// <summary>
        /// <para>
        /// <para>The transformations that are applied to the baseline time series. Each transformation
        /// contains an action and a set of conditions. An action is applied only when all conditions
        /// are met. If no conditions are provided, the action is applied to all items.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeSeriesTransformations")]
        public Amazon.ForecastService.Model.TimeSeriesTransformation[] TimeSeriesTransformation { get; set; }
        #endregion
        
        #region Parameter TimeSeriesReplacementsDataSource_TimestampFormat
        /// <summary>
        /// <para>
        /// <para>The timestamp format of the replacement data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeSeriesReplacementsDataSource_TimestampFormat { get; set; }
        #endregion
        
        #region Parameter WhatIfAnalysisArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the what-if analysis.</para>
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
        public System.String WhatIfAnalysisArn { get; set; }
        #endregion
        
        #region Parameter WhatIfForecastName
        /// <summary>
        /// <para>
        /// <para>The name of the what-if forecast. Names must be unique within each what-if analysis.</para>
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
        public System.String WhatIfForecastName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WhatIfForecastArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateWhatIfForecastResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateWhatIfForecastResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WhatIfForecastArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WhatIfForecastName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCWhatIfForecast (CreateWhatIfForecast)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateWhatIfForecastResponse, NewFRCWhatIfForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ForecastService.Model.Tag>(this.Tag);
            }
            context.TimeSeriesReplacementsDataSource_Format = this.TimeSeriesReplacementsDataSource_Format;
            context.S3Config_KMSKeyArn = this.S3Config_KMSKeyArn;
            context.S3Config_Path = this.S3Config_Path;
            context.S3Config_RoleArn = this.S3Config_RoleArn;
            if (this.Schema_Attribute != null)
            {
                context.Schema_Attribute = new List<Amazon.ForecastService.Model.SchemaAttribute>(this.Schema_Attribute);
            }
            context.TimeSeriesReplacementsDataSource_TimestampFormat = this.TimeSeriesReplacementsDataSource_TimestampFormat;
            if (this.TimeSeriesTransformation != null)
            {
                context.TimeSeriesTransformation = new List<Amazon.ForecastService.Model.TimeSeriesTransformation>(this.TimeSeriesTransformation);
            }
            context.WhatIfAnalysisArn = this.WhatIfAnalysisArn;
            #if MODULAR
            if (this.WhatIfAnalysisArn == null && ParameterWasBound(nameof(this.WhatIfAnalysisArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfAnalysisArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WhatIfForecastName = this.WhatIfForecastName;
            #if MODULAR
            if (this.WhatIfForecastName == null && ParameterWasBound(nameof(this.WhatIfForecastName)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.CreateWhatIfForecastRequest();
            
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TimeSeriesReplacementsDataSource
            var requestTimeSeriesReplacementsDataSourceIsNull = true;
            request.TimeSeriesReplacementsDataSource = new Amazon.ForecastService.Model.TimeSeriesReplacementsDataSource();
            System.String requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Format = null;
            if (cmdletContext.TimeSeriesReplacementsDataSource_Format != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Format = cmdletContext.TimeSeriesReplacementsDataSource_Format;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Format != null)
            {
                request.TimeSeriesReplacementsDataSource.Format = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Format;
                requestTimeSeriesReplacementsDataSourceIsNull = false;
            }
            System.String requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_TimestampFormat = null;
            if (cmdletContext.TimeSeriesReplacementsDataSource_TimestampFormat != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_TimestampFormat = cmdletContext.TimeSeriesReplacementsDataSource_TimestampFormat;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_TimestampFormat != null)
            {
                request.TimeSeriesReplacementsDataSource.TimestampFormat = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_TimestampFormat;
                requestTimeSeriesReplacementsDataSourceIsNull = false;
            }
            Amazon.ForecastService.Model.Schema requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema = null;
            
             // populate Schema
            var requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_SchemaIsNull = true;
            requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema = new Amazon.ForecastService.Model.Schema();
            List<Amazon.ForecastService.Model.SchemaAttribute> requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema_schema_Attribute = null;
            if (cmdletContext.Schema_Attribute != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema_schema_Attribute = cmdletContext.Schema_Attribute;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema_schema_Attribute != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema.Attributes = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema_schema_Attribute;
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_SchemaIsNull = false;
            }
             // determine if requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema should be set to null
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_SchemaIsNull)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema = null;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema != null)
            {
                request.TimeSeriesReplacementsDataSource.Schema = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_Schema;
                requestTimeSeriesReplacementsDataSourceIsNull = false;
            }
            Amazon.ForecastService.Model.S3Config requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config = null;
            
             // populate S3Config
            var requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3ConfigIsNull = true;
            requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config = new Amazon.ForecastService.Model.S3Config();
            System.String requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_KMSKeyArn = null;
            if (cmdletContext.S3Config_KMSKeyArn != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_KMSKeyArn = cmdletContext.S3Config_KMSKeyArn;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_KMSKeyArn != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config.KMSKeyArn = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_KMSKeyArn;
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3ConfigIsNull = false;
            }
            System.String requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_Path = null;
            if (cmdletContext.S3Config_Path != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_Path = cmdletContext.S3Config_Path;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_Path != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config.Path = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_Path;
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3ConfigIsNull = false;
            }
            System.String requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_RoleArn = null;
            if (cmdletContext.S3Config_RoleArn != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_RoleArn = cmdletContext.S3Config_RoleArn;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_RoleArn != null)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config.RoleArn = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config_s3Config_RoleArn;
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3ConfigIsNull = false;
            }
             // determine if requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config should be set to null
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3ConfigIsNull)
            {
                requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config = null;
            }
            if (requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config != null)
            {
                request.TimeSeriesReplacementsDataSource.S3Config = requestTimeSeriesReplacementsDataSource_timeSeriesReplacementsDataSource_S3Config;
                requestTimeSeriesReplacementsDataSourceIsNull = false;
            }
             // determine if request.TimeSeriesReplacementsDataSource should be set to null
            if (requestTimeSeriesReplacementsDataSourceIsNull)
            {
                request.TimeSeriesReplacementsDataSource = null;
            }
            if (cmdletContext.TimeSeriesTransformation != null)
            {
                request.TimeSeriesTransformations = cmdletContext.TimeSeriesTransformation;
            }
            if (cmdletContext.WhatIfAnalysisArn != null)
            {
                request.WhatIfAnalysisArn = cmdletContext.WhatIfAnalysisArn;
            }
            if (cmdletContext.WhatIfForecastName != null)
            {
                request.WhatIfForecastName = cmdletContext.WhatIfForecastName;
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
        
        private Amazon.ForecastService.Model.CreateWhatIfForecastResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateWhatIfForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateWhatIfForecast");
            try
            {
                return client.CreateWhatIfForecastAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.String TimeSeriesReplacementsDataSource_Format { get; set; }
            public System.String S3Config_KMSKeyArn { get; set; }
            public System.String S3Config_Path { get; set; }
            public System.String S3Config_RoleArn { get; set; }
            public List<Amazon.ForecastService.Model.SchemaAttribute> Schema_Attribute { get; set; }
            public System.String TimeSeriesReplacementsDataSource_TimestampFormat { get; set; }
            public List<Amazon.ForecastService.Model.TimeSeriesTransformation> TimeSeriesTransformation { get; set; }
            public System.String WhatIfAnalysisArn { get; set; }
            public System.String WhatIfForecastName { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateWhatIfForecastResponse, NewFRCWhatIfForecastCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WhatIfForecastArn;
        }
        
    }
}
