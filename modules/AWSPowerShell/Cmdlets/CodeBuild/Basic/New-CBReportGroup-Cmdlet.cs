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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Creates a report group. A report group contains a collection of reports.
    /// </summary>
    [Cmdlet("New", "CBReportGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.ReportGroup")]
    [AWSCmdlet("Calls the AWS CodeBuild CreateReportGroup API operation.", Operation = new[] {"CreateReportGroup"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.CreateReportGroupResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.ReportGroup or Amazon.CodeBuild.Model.CreateReportGroupResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.ReportGroup object.",
        "The service call response (type Amazon.CodeBuild.Model.CreateReportGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCBReportGroupCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter S3Destination_Bucket
        /// <summary>
        /// <para>
        /// <para> The name of the S3 bucket where the raw data of a report are exported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_Bucket")]
        public System.String S3Destination_Bucket { get; set; }
        #endregion
        
        #region Parameter S3Destination_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account identifier of the owner of the Amazon S3 bucket. This
        /// allows report data to be exported to an Amazon S3 bucket that is owned by an account
        /// other than the account running the build.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_BucketOwner")]
        public System.String S3Destination_BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3Destination_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> A boolean value that specifies if the results of a report are encrypted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_EncryptionDisabled")]
        public System.Boolean? S3Destination_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter S3Destination_EncryptionKey
        /// <summary>
        /// <para>
        /// <para> The encryption key for the report's encrypted raw data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_EncryptionKey")]
        public System.String S3Destination_EncryptionKey { get; set; }
        #endregion
        
        #region Parameter ExportConfig_ExportConfigType
        /// <summary>
        /// <para>
        /// <para> The export configuration type. Valid values are: </para><ul><li><para><code>S3</code>: The report results are exported to an S3 bucket. </para></li><li><para><code>NO_EXPORT</code>: The report results are not exported. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ReportExportConfigType")]
        public Amazon.CodeBuild.ReportExportConfigType ExportConfig_ExportConfigType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the report group. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Destination_Packaging
        /// <summary>
        /// <para>
        /// <para> The type of build output artifact to create. Valid values include: </para><ul><li><para><code>NONE</code>: CodeBuild creates the raw data in the output bucket. This is the
        /// default if packaging is not specified. </para></li><li><para><code>ZIP</code>: CodeBuild creates a ZIP file with the raw data in the output bucket.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_Packaging")]
        [AWSConstantClassSource("Amazon.CodeBuild.ReportPackagingType")]
        public Amazon.CodeBuild.ReportPackagingType S3Destination_Packaging { get; set; }
        #endregion
        
        #region Parameter S3Destination_Path
        /// <summary>
        /// <para>
        /// <para> The path to the exported report's raw data results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportConfig_S3Destination_Path")]
        public System.String S3Destination_Path { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A list of tag key and value pairs associated with this report group. </para><para>These tags are available for use by Amazon Web Services services that support CodeBuild
        /// report group tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeBuild.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of report group. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ReportType")]
        public Amazon.CodeBuild.ReportType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReportGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.CreateReportGroupResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.CreateReportGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReportGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CBReportGroup (CreateReportGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.CreateReportGroupResponse, NewCBReportGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExportConfig_ExportConfigType = this.ExportConfig_ExportConfigType;
            context.S3Destination_Bucket = this.S3Destination_Bucket;
            context.S3Destination_BucketOwner = this.S3Destination_BucketOwner;
            context.S3Destination_EncryptionDisabled = this.S3Destination_EncryptionDisabled;
            context.S3Destination_EncryptionKey = this.S3Destination_EncryptionKey;
            context.S3Destination_Packaging = this.S3Destination_Packaging;
            context.S3Destination_Path = this.S3Destination_Path;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodeBuild.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeBuild.Model.CreateReportGroupRequest();
            
            
             // populate ExportConfig
            var requestExportConfigIsNull = true;
            request.ExportConfig = new Amazon.CodeBuild.Model.ReportExportConfig();
            Amazon.CodeBuild.ReportExportConfigType requestExportConfig_exportConfig_ExportConfigType = null;
            if (cmdletContext.ExportConfig_ExportConfigType != null)
            {
                requestExportConfig_exportConfig_ExportConfigType = cmdletContext.ExportConfig_ExportConfigType;
            }
            if (requestExportConfig_exportConfig_ExportConfigType != null)
            {
                request.ExportConfig.ExportConfigType = requestExportConfig_exportConfig_ExportConfigType;
                requestExportConfigIsNull = false;
            }
            Amazon.CodeBuild.Model.S3ReportExportConfig requestExportConfig_exportConfig_S3Destination = null;
            
             // populate S3Destination
            var requestExportConfig_exportConfig_S3DestinationIsNull = true;
            requestExportConfig_exportConfig_S3Destination = new Amazon.CodeBuild.Model.S3ReportExportConfig();
            System.String requestExportConfig_exportConfig_S3Destination_s3Destination_Bucket = null;
            if (cmdletContext.S3Destination_Bucket != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_Bucket = cmdletContext.S3Destination_Bucket;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_Bucket != null)
            {
                requestExportConfig_exportConfig_S3Destination.Bucket = requestExportConfig_exportConfig_S3Destination_s3Destination_Bucket;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
            System.String requestExportConfig_exportConfig_S3Destination_s3Destination_BucketOwner = null;
            if (cmdletContext.S3Destination_BucketOwner != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_BucketOwner = cmdletContext.S3Destination_BucketOwner;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_BucketOwner != null)
            {
                requestExportConfig_exportConfig_S3Destination.BucketOwner = requestExportConfig_exportConfig_S3Destination_s3Destination_BucketOwner;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
            System.Boolean? requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionDisabled = null;
            if (cmdletContext.S3Destination_EncryptionDisabled != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionDisabled = cmdletContext.S3Destination_EncryptionDisabled.Value;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionDisabled != null)
            {
                requestExportConfig_exportConfig_S3Destination.EncryptionDisabled = requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionDisabled.Value;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
            System.String requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionKey = null;
            if (cmdletContext.S3Destination_EncryptionKey != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionKey = cmdletContext.S3Destination_EncryptionKey;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionKey != null)
            {
                requestExportConfig_exportConfig_S3Destination.EncryptionKey = requestExportConfig_exportConfig_S3Destination_s3Destination_EncryptionKey;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
            Amazon.CodeBuild.ReportPackagingType requestExportConfig_exportConfig_S3Destination_s3Destination_Packaging = null;
            if (cmdletContext.S3Destination_Packaging != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_Packaging = cmdletContext.S3Destination_Packaging;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_Packaging != null)
            {
                requestExportConfig_exportConfig_S3Destination.Packaging = requestExportConfig_exportConfig_S3Destination_s3Destination_Packaging;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
            System.String requestExportConfig_exportConfig_S3Destination_s3Destination_Path = null;
            if (cmdletContext.S3Destination_Path != null)
            {
                requestExportConfig_exportConfig_S3Destination_s3Destination_Path = cmdletContext.S3Destination_Path;
            }
            if (requestExportConfig_exportConfig_S3Destination_s3Destination_Path != null)
            {
                requestExportConfig_exportConfig_S3Destination.Path = requestExportConfig_exportConfig_S3Destination_s3Destination_Path;
                requestExportConfig_exportConfig_S3DestinationIsNull = false;
            }
             // determine if requestExportConfig_exportConfig_S3Destination should be set to null
            if (requestExportConfig_exportConfig_S3DestinationIsNull)
            {
                requestExportConfig_exportConfig_S3Destination = null;
            }
            if (requestExportConfig_exportConfig_S3Destination != null)
            {
                request.ExportConfig.S3Destination = requestExportConfig_exportConfig_S3Destination;
                requestExportConfigIsNull = false;
            }
             // determine if request.ExportConfig should be set to null
            if (requestExportConfigIsNull)
            {
                request.ExportConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.CodeBuild.Model.CreateReportGroupResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.CreateReportGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "CreateReportGroup");
            try
            {
                #if DESKTOP
                return client.CreateReportGroup(request);
                #elif CORECLR
                return client.CreateReportGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeBuild.ReportExportConfigType ExportConfig_ExportConfigType { get; set; }
            public System.String S3Destination_Bucket { get; set; }
            public System.String S3Destination_BucketOwner { get; set; }
            public System.Boolean? S3Destination_EncryptionDisabled { get; set; }
            public System.String S3Destination_EncryptionKey { get; set; }
            public Amazon.CodeBuild.ReportPackagingType S3Destination_Packaging { get; set; }
            public System.String S3Destination_Path { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CodeBuild.Model.Tag> Tag { get; set; }
            public Amazon.CodeBuild.ReportType Type { get; set; }
            public System.Func<Amazon.CodeBuild.Model.CreateReportGroupResponse, NewCBReportGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReportGroup;
        }
        
    }
}
