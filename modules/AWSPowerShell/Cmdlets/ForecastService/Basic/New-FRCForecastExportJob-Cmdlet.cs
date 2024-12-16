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
    /// Exports a forecast created by the <a>CreateForecast</a> operation to your Amazon Simple
    /// Storage Service (Amazon S3) bucket. The forecast file name will match the following
    /// conventions:
    /// 
    ///  
    /// <para>
    /// &lt;ForecastExportJobName&gt;_&lt;ExportTimestamp&gt;_&lt;PartNumber&gt;
    /// </para><para>
    /// where the &lt;ExportTimestamp&gt; component is in Java SimpleDateFormat (yyyy-MM-ddTHH-mm-ssZ).
    /// </para><para>
    /// You must specify a <a>DataDestination</a> object that includes an Identity and Access
    /// Management (IAM) role that Amazon Forecast can assume to access the Amazon S3 bucket.
    /// For more information, see <a>aws-forecast-iam-roles</a>.
    /// </para><para>
    /// For more information, see <a>howitworks-forecast</a>.
    /// </para><para>
    /// To get a list of all your forecast export jobs, use the <a>ListForecastExportJobs</a>
    /// operation.
    /// </para><note><para>
    /// The <c>Status</c> of the forecast export job must be <c>ACTIVE</c> before you can
    /// access the forecast in your Amazon S3 bucket. To get the status, use the <a>DescribeForecastExportJob</a>
    /// operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FRCForecastExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateForecastExportJob API operation.", Operation = new[] {"CreateForecastExportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateForecastExportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateForecastExportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateForecastExportJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFRCForecastExportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ForecastArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the forecast that you want to export.</para>
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
        public System.String ForecastArn { get; set; }
        #endregion
        
        #region Parameter ForecastExportJobName
        /// <summary>
        /// <para>
        /// <para>The name for the forecast export job.</para>
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
        public System.String ForecastExportJobName { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the exported data, CSV or PARQUET. The default value is CSV.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Format { get; set; }
        #endregion
        
        #region Parameter S3Config_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Key Management Service (KMS) key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_S3Config_KMSKeyArn")]
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
        [Alias("Destination_S3Config_Path")]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Destination_S3Config_RoleArn")]
        public System.String S3Config_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the forecast export job to help you categorize
        /// and organize them. Each tag consists of a key and an optional value, both of which
        /// you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for keys as it is reserved for Amazon Web Services use. You cannot edit
        /// or delete tag keys with this prefix. Values can have this prefix. If a tag value has
        /// <c>aws</c> as its prefix but the key does not, then Forecast considers it to be a
        /// user tag and will count against the limit of 50 tags. Tags with only the key prefix
        /// of <c>aws</c> do not count against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ForecastExportJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateForecastExportJobResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateForecastExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ForecastExportJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ForecastExportJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCForecastExportJob (CreateForecastExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateForecastExportJobResponse, NewFRCForecastExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.ForecastArn = this.ForecastArn;
            #if MODULAR
            if (this.ForecastArn == null && ParameterWasBound(nameof(this.ForecastArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForecastExportJobName = this.ForecastExportJobName;
            #if MODULAR
            if (this.ForecastExportJobName == null && ParameterWasBound(nameof(this.ForecastExportJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastExportJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
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
            var request = new Amazon.ForecastService.Model.CreateForecastExportJobRequest();
            
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.ForecastService.Model.DataDestination();
            Amazon.ForecastService.Model.S3Config requestDestination_destination_S3Config = null;
            
             // populate S3Config
            var requestDestination_destination_S3ConfigIsNull = true;
            requestDestination_destination_S3Config = new Amazon.ForecastService.Model.S3Config();
            System.String requestDestination_destination_S3Config_s3Config_KMSKeyArn = null;
            if (cmdletContext.S3Config_KMSKeyArn != null)
            {
                requestDestination_destination_S3Config_s3Config_KMSKeyArn = cmdletContext.S3Config_KMSKeyArn;
            }
            if (requestDestination_destination_S3Config_s3Config_KMSKeyArn != null)
            {
                requestDestination_destination_S3Config.KMSKeyArn = requestDestination_destination_S3Config_s3Config_KMSKeyArn;
                requestDestination_destination_S3ConfigIsNull = false;
            }
            System.String requestDestination_destination_S3Config_s3Config_Path = null;
            if (cmdletContext.S3Config_Path != null)
            {
                requestDestination_destination_S3Config_s3Config_Path = cmdletContext.S3Config_Path;
            }
            if (requestDestination_destination_S3Config_s3Config_Path != null)
            {
                requestDestination_destination_S3Config.Path = requestDestination_destination_S3Config_s3Config_Path;
                requestDestination_destination_S3ConfigIsNull = false;
            }
            System.String requestDestination_destination_S3Config_s3Config_RoleArn = null;
            if (cmdletContext.S3Config_RoleArn != null)
            {
                requestDestination_destination_S3Config_s3Config_RoleArn = cmdletContext.S3Config_RoleArn;
            }
            if (requestDestination_destination_S3Config_s3Config_RoleArn != null)
            {
                requestDestination_destination_S3Config.RoleArn = requestDestination_destination_S3Config_s3Config_RoleArn;
                requestDestination_destination_S3ConfigIsNull = false;
            }
             // determine if requestDestination_destination_S3Config should be set to null
            if (requestDestination_destination_S3ConfigIsNull)
            {
                requestDestination_destination_S3Config = null;
            }
            if (requestDestination_destination_S3Config != null)
            {
                request.Destination.S3Config = requestDestination_destination_S3Config;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.ForecastArn != null)
            {
                request.ForecastArn = cmdletContext.ForecastArn;
            }
            if (cmdletContext.ForecastExportJobName != null)
            {
                request.ForecastExportJobName = cmdletContext.ForecastExportJobName;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
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
        
        private Amazon.ForecastService.Model.CreateForecastExportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateForecastExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateForecastExportJob");
            try
            {
                #if DESKTOP
                return client.CreateForecastExportJob(request);
                #elif CORECLR
                return client.CreateForecastExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ForecastArn { get; set; }
            public System.String ForecastExportJobName { get; set; }
            public System.String Format { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateForecastExportJobResponse, NewFRCForecastExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ForecastExportJobArn;
        }
        
    }
}
