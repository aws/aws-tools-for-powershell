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
    /// Exports a forecast created by the <a>CreateWhatIfForecast</a> operation to your Amazon
    /// Simple Storage Service (Amazon S3) bucket. The forecast file name will match the following
    /// conventions:
    /// 
    ///  
    /// <para><code>≈&lt;ForecastExportJobName&gt;_&lt;ExportTimestamp&gt;_&lt;PartNumber&gt;</code></para><para>
    /// The &lt;ExportTimestamp&gt; component is in Java SimpleDateFormat (yyyy-MM-ddTHH-mm-ssZ).
    /// </para><para>
    /// You must specify a <a>DataDestination</a> object that includes an AWS Identity and
    /// Access Management (IAM) role that Amazon Forecast can assume to access the Amazon
    /// S3 bucket. For more information, see <a>aws-forecast-iam-roles</a>.
    /// </para><para>
    /// For more information, see <a>howitworks-forecast</a>.
    /// </para><para>
    /// To get a list of all your what-if forecast export jobs, use the <a>ListWhatIfForecastExports</a>
    /// operation.
    /// </para><note><para>
    /// The <code>Status</code> of the forecast export job must be <code>ACTIVE</code> before
    /// you can access the forecast in your Amazon S3 bucket. To get the status, use the <a>DescribeWhatIfForecastExport</a>
    /// operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FRCWhatIfForecastExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateWhatIfForecastExport API operation.", Operation = new[] {"CreateWhatIfForecastExport"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCWhatIfForecastExportCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the exported data, CSV or PARQUET.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Format { get; set; }
        #endregion
        
        #region Parameter S3Config_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS Key Management Service (KMS) key.</para>
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
        [Alias("Destination_S3Config_RoleArn")]
        public System.String S3Config_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/forecast/latest/dg/tagging-forecast-resources.html">tags</a>
        /// to apply to the what if forecast.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter WhatIfForecastArn
        /// <summary>
        /// <para>
        /// <para>The list of what-if forecast Amazon Resource Names (ARNs) to export.</para>
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
        [Alias("WhatIfForecastArns")]
        public System.String[] WhatIfForecastArn { get; set; }
        #endregion
        
        #region Parameter WhatIfForecastExportName
        /// <summary>
        /// <para>
        /// <para>The name of the what-if forecast to export.</para>
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
        public System.String WhatIfForecastExportName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WhatIfForecastExportArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WhatIfForecastExportArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WhatIfForecastExportName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WhatIfForecastExportName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WhatIfForecastExportName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WhatIfForecastExportName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCWhatIfForecastExport (CreateWhatIfForecastExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse, NewFRCWhatIfForecastExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WhatIfForecastExportName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.Format = this.Format;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ForecastService.Model.Tag>(this.Tag);
            }
            if (this.WhatIfForecastArn != null)
            {
                context.WhatIfForecastArn = new List<System.String>(this.WhatIfForecastArn);
            }
            #if MODULAR
            if (this.WhatIfForecastArn == null && ParameterWasBound(nameof(this.WhatIfForecastArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WhatIfForecastExportName = this.WhatIfForecastExportName;
            #if MODULAR
            if (this.WhatIfForecastExportName == null && ParameterWasBound(nameof(this.WhatIfForecastExportName)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastExportName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.CreateWhatIfForecastExportRequest();
            
            
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
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WhatIfForecastArn != null)
            {
                request.WhatIfForecastArns = cmdletContext.WhatIfForecastArn;
            }
            if (cmdletContext.WhatIfForecastExportName != null)
            {
                request.WhatIfForecastExportName = cmdletContext.WhatIfForecastExportName;
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
        
        private Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateWhatIfForecastExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateWhatIfForecastExport");
            try
            {
                #if DESKTOP
                return client.CreateWhatIfForecastExport(request);
                #elif CORECLR
                return client.CreateWhatIfForecastExportAsync(request).GetAwaiter().GetResult();
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
            public System.String Format { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public List<System.String> WhatIfForecastArn { get; set; }
            public System.String WhatIfForecastExportName { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateWhatIfForecastExportResponse, NewFRCWhatIfForecastExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WhatIfForecastExportArn;
        }
        
    }
}
