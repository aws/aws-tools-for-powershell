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
    /// Imports your training data to an Amazon Forecast dataset. You provide the location
    /// of your training data in an Amazon Simple Storage Service (Amazon S3) bucket and the
    /// Amazon Resource Name (ARN) of the dataset that you want to import the data to.
    /// 
    ///  
    /// <para>
    /// You must specify a <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_DataSource.html">DataSource</a>
    /// object that includes an AWS Identity and Access Management (IAM) role that Amazon
    /// Forecast can assume to access the data, as Amazon Forecast makes a copy of your data
    /// and processes it in an internal AWS system. For more information, see <a href="https://docs.aws.amazon.com/forecast/latest/dg/aws-forecast-iam-roles.html">Set
    /// up permissions</a>.
    /// </para><para>
    /// The training data must be in CSV format. The delimiter must be a comma (,).
    /// </para><para>
    /// You can specify the path to a specific CSV file, the S3 bucket, or to a folder in
    /// the S3 bucket. For the latter two cases, Amazon Forecast imports all files up to the
    /// limit of 10,000 files.
    /// </para><para>
    /// Because dataset imports are not aggregated, your most recent dataset import is the
    /// one that is used when training a predictor or generating a forecast. Make sure that
    /// your most recent dataset import contains all of the data you want to model off of,
    /// and not just the new data collected since the previous import.
    /// </para><para>
    /// To get a list of all your dataset import jobs, filtered by specified criteria, use
    /// the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_ListDatasetImportJobs.html">ListDatasetImportJobs</a>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FRCDatasetImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateDatasetImportJob API operation.", Operation = new[] {"CreateDatasetImportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateDatasetImportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateDatasetImportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateDatasetImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCDatasetImportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DatasetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Forecast dataset that you want to import
        /// data to.</para>
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
        public System.String DatasetArn { get; set; }
        #endregion
        
        #region Parameter DatasetImportJobName
        /// <summary>
        /// <para>
        /// <para>The name for the dataset import job. We recommend including the current timestamp
        /// in the name, for example, <code>20190721DatasetImport</code>. This can help you avoid
        /// getting a <code>ResourceAlreadyExistsException</code> exception.</para>
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
        public System.String DatasetImportJobName { get; set; }
        #endregion
        
        #region Parameter GeolocationFormat
        /// <summary>
        /// <para>
        /// <para>The format of the geolocation attribute. The geolocation attribute can be formatted
        /// in one of two ways:</para><ul><li><para><code>LAT_LONG</code> - the latitude and longitude in decimal format (Example: 47.61_-122.33).</para></li><li><para><code>CC_POSTALCODE</code> (US Only) - the country code (US), followed by the 5-digit
        /// ZIP code (Example: US_98121).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GeolocationFormat { get; set; }
        #endregion
        
        #region Parameter S3Config_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS Key Management Service (KMS) key.</para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataSource_S3Config_Path")]
        public System.String S3Config_Path { get; set; }
        #endregion
        
        #region Parameter S3Config_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Identity and Access Management (IAM) role that Amazon Forecast
        /// can assume to access the Amazon S3 bucket or files. If you provide a value for the
        /// <code>KMSKeyArn</code> key, the role must allow access to the key.</para><para>Passing a role across AWS accounts is not allowed. If you pass a role that isn't in
        /// your account, you get an <code>InvalidInputException</code> error.</para>
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
        [Alias("DataSource_S3Config_RoleArn")]
        public System.String S3Config_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the dataset import job to help you categorize
        /// and organize them. Each tag consists of a key and an optional value, both of which
        /// you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use <code>aws:</code>, <code>AWS:</code>, or any upper or lowercase combination
        /// of such as a prefix for keys as it is reserved for AWS use. You cannot edit or delete
        /// tag keys with this prefix. Values can have this prefix. If a tag value has <code>aws</code>
        /// as its prefix but the key does not, then Forecast considers it to be a user tag and
        /// will count against the limit of 50 tags. Tags with only the key prefix of <code>aws</code>
        /// do not count against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimestampFormat
        /// <summary>
        /// <para>
        /// <para>The format of timestamps in the dataset. The format that you specify depends on the
        /// <code>DataFrequency</code> specified when the dataset was created. The following formats
        /// are supported</para><ul><li><para>"yyyy-MM-dd"</para><para>For the following data frequencies: Y, M, W, and D</para></li><li><para>"yyyy-MM-dd HH:mm:ss"</para><para>For the following data frequencies: H, 30min, 15min, and 1min; and optionally, for:
        /// Y, M, W, and D</para></li></ul><para>If the format isn't specified, Amazon Forecast expects the format to be "yyyy-MM-dd
        /// HH:mm:ss".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimestampFormat { get; set; }
        #endregion
        
        #region Parameter TimeZone
        /// <summary>
        /// <para>
        /// <para>A single time zone for every item in your dataset. This option is ideal for datasets
        /// with all timestamps within a single time zone, or if all timestamps are normalized
        /// to a single time zone. </para><para>Refer to the <a href="http://joda-time.sourceforge.net/timezones.html">Joda-Time API</a>
        /// for a complete list of valid time zone names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeZone { get; set; }
        #endregion
        
        #region Parameter UseGeolocationForTimeZone
        /// <summary>
        /// <para>
        /// <para>Automatically derive time zone information from the geolocation attribute. This option
        /// is ideal for datasets that contain timestamps in multiple time zones and those timestamps
        /// are expressed in local time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseGeolocationForTimeZone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetImportJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateDatasetImportJobResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateDatasetImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetImportJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetImportJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCDatasetImportJob (CreateDatasetImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateDatasetImportJobResponse, NewFRCDatasetImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetArn = this.DatasetArn;
            #if MODULAR
            if (this.DatasetArn == null && ParameterWasBound(nameof(this.DatasetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetImportJobName = this.DatasetImportJobName;
            #if MODULAR
            if (this.DatasetImportJobName == null && ParameterWasBound(nameof(this.DatasetImportJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetImportJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Config_KMSKeyArn = this.S3Config_KMSKeyArn;
            context.S3Config_Path = this.S3Config_Path;
            #if MODULAR
            if (this.S3Config_Path == null && ParameterWasBound(nameof(this.S3Config_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Config_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Config_RoleArn = this.S3Config_RoleArn;
            #if MODULAR
            if (this.S3Config_RoleArn == null && ParameterWasBound(nameof(this.S3Config_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Config_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GeolocationFormat = this.GeolocationFormat;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ForecastService.Model.Tag>(this.Tag);
            }
            context.TimestampFormat = this.TimestampFormat;
            context.TimeZone = this.TimeZone;
            context.UseGeolocationForTimeZone = this.UseGeolocationForTimeZone;
            
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
            var request = new Amazon.ForecastService.Model.CreateDatasetImportJobRequest();
            
            if (cmdletContext.DatasetArn != null)
            {
                request.DatasetArn = cmdletContext.DatasetArn;
            }
            if (cmdletContext.DatasetImportJobName != null)
            {
                request.DatasetImportJobName = cmdletContext.DatasetImportJobName;
            }
            
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
            if (cmdletContext.GeolocationFormat != null)
            {
                request.GeolocationFormat = cmdletContext.GeolocationFormat;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TimestampFormat != null)
            {
                request.TimestampFormat = cmdletContext.TimestampFormat;
            }
            if (cmdletContext.TimeZone != null)
            {
                request.TimeZone = cmdletContext.TimeZone;
            }
            if (cmdletContext.UseGeolocationForTimeZone != null)
            {
                request.UseGeolocationForTimeZone = cmdletContext.UseGeolocationForTimeZone.Value;
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
        
        private Amazon.ForecastService.Model.CreateDatasetImportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateDatasetImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateDatasetImportJob");
            try
            {
                #if DESKTOP
                return client.CreateDatasetImportJob(request);
                #elif CORECLR
                return client.CreateDatasetImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetArn { get; set; }
            public System.String DatasetImportJobName { get; set; }
            public System.String S3Config_KMSKeyArn { get; set; }
            public System.String S3Config_Path { get; set; }
            public System.String S3Config_RoleArn { get; set; }
            public System.String GeolocationFormat { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.String TimestampFormat { get; set; }
            public System.String TimeZone { get; set; }
            public System.Boolean? UseGeolocationForTimeZone { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateDatasetImportJobResponse, NewFRCDatasetImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetImportJobArn;
        }
        
    }
}
