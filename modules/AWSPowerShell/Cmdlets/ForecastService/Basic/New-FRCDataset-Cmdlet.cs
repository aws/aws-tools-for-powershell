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
    /// Creates an Amazon Forecast dataset. The information about the dataset that you provide
    /// helps Forecast understand how to consume the data for model training. This includes
    /// the following:
    /// 
    ///  <ul><li><para><i><code>DataFrequency</code></i> - How frequently your historical time-series
    /// data is collected.
    /// </para></li><li><para><i><code>Domain</code></i> and <i><code>DatasetType</code></i> - Each dataset
    /// has an associated dataset domain and a type within the domain. Amazon Forecast provides
    /// a list of predefined domains and types within each domain. For each unique dataset
    /// domain and type within the domain, Amazon Forecast requires your data to include a
    /// minimum set of predefined fields.
    /// </para></li><li><para><i><code>Schema</code></i> - A schema specifies the fields in the dataset, including
    /// the field name and data type.
    /// </para></li></ul><para>
    /// After creating a dataset, you import your training data into it and add the dataset
    /// to a dataset group. You use the dataset group to create a predictor. For more information,
    /// see <a href="https://docs.aws.amazon.com/forecast/latest/dg/howitworks-datasets-groups.html">Importing
    /// datasets</a>.
    /// </para><para>
    /// To get a list of all your datasets, use the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_ListDatasets.html">ListDatasets</a>
    /// operation.
    /// </para><para>
    /// For example Forecast datasets, see the <a href="https://github.com/aws-samples/amazon-forecast-samples">Amazon
    /// Forecast Sample GitHub repository</a>.
    /// </para><note><para>
    /// The <code>Status</code> of a dataset must be <code>ACTIVE</code> before you can import
    /// training data. Use the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_DescribeDataset.html">DescribeDataset</a>
    /// operation to get the status.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FRCDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreateDatasetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCDatasetCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
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
        
        #region Parameter DataFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency of data collection. This parameter is required for RELATED_TIME_SERIES
        /// datasets.</para><para>Valid intervals are Y (Year), M (Month), W (Week), D (Day), H (Hour), 30min (30 minutes),
        /// 15min (15 minutes), 10min (10 minutes), 5min (5 minutes), and 1min (1 minute). For
        /// example, "D" indicates every day and "15min" indicates every 15 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataFrequency { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>A name for the dataset.</para>
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
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para>The dataset type. Valid values depend on the chosen <code>Domain</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ForecastService.DatasetType")]
        public Amazon.ForecastService.DatasetType DatasetType { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domain associated with the dataset. When you add a dataset to a dataset group,
        /// this value and the value specified for the <code>Domain</code> parameter of the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_CreateDatasetGroup.html">CreateDatasetGroup</a>
        /// operation must match.</para><para>The <code>Domain</code> and <code>DatasetType</code> that you choose determine the
        /// fields that must be present in the training data that you import to the dataset. For
        /// example, if you choose the <code>RETAIL</code> domain and <code>TARGET_TIME_SERIES</code>
        /// as the <code>DatasetType</code>, Amazon Forecast requires <code>item_id</code>, <code>timestamp</code>,
        /// and <code>demand</code> fields to be present in your data. For more information, see
        /// <a href="https://docs.aws.amazon.com/forecast/latest/dg/howitworks-datasets-groups.html">Importing
        /// datasets</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ForecastService.Domain")]
        public Amazon.ForecastService.Domain Domain { get; set; }
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
        /// <para>The optional metadata that you apply to the dataset to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreateDatasetResponse, NewFRCDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataFrequency = this.DataFrequency;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetType = this.DatasetType;
            #if MODULAR
            if (this.DatasetType == null && ParameterWasBound(nameof(this.DatasetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfig_KMSKeyArn = this.EncryptionConfig_KMSKeyArn;
            context.EncryptionConfig_RoleArn = this.EncryptionConfig_RoleArn;
            if (this.Schema_Attribute != null)
            {
                context.Schema_Attribute = new List<Amazon.ForecastService.Model.SchemaAttribute>(this.Schema_Attribute);
            }
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
            var request = new Amazon.ForecastService.Model.CreateDatasetRequest();
            
            if (cmdletContext.DataFrequency != null)
            {
                request.DataFrequency = cmdletContext.DataFrequency;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.DatasetType != null)
            {
                request.DatasetType = cmdletContext.DatasetType;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
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
        
        private Amazon.ForecastService.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreateDataset");
            try
            {
                #if DESKTOP
                return client.CreateDataset(request);
                #elif CORECLR
                return client.CreateDatasetAsync(request).GetAwaiter().GetResult();
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
            public System.String DataFrequency { get; set; }
            public System.String DatasetName { get; set; }
            public Amazon.ForecastService.DatasetType DatasetType { get; set; }
            public Amazon.ForecastService.Domain Domain { get; set; }
            public System.String EncryptionConfig_KMSKeyArn { get; set; }
            public System.String EncryptionConfig_RoleArn { get; set; }
            public List<Amazon.ForecastService.Model.SchemaAttribute> Schema_Attribute { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreateDatasetResponse, NewFRCDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetArn;
        }
        
    }
}
