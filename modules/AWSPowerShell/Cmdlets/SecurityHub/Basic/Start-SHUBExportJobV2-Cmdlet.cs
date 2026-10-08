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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Starts an ad hoc export job that writes Security Hub findings to an Amazon Simple
    /// Storage Service (Amazon S3) bucket that you own. Because the export runs asynchronously,
    /// this operation returns only the <c>ExportJobId</c> of the new job; it doesn't wait
    /// for the export to finish. Use <c>GetExportJobV2</c> to poll the job, and <c>ListExportJobsV2</c>
    /// to view the export jobs in your account.
    /// 
    ///  
    /// <para>
    /// Security Hub allows only one export job in the <c>RUNNING</c> state per account at
    /// a time. If an export job is already running, this operation returns a <c>ServiceQuotaExceededException</c>.
    /// Wait for the running job to finish, or cancel it with <c>CancelExportJobV2</c>, before
    /// you start a new one.
    /// </para><para>
    /// Specify the destination bucket and Amazon Web Services Key Management Service (Amazon
    /// Web Services KMS) key in the <c>Destination</c> parameter, and the output format (<c>CSV</c>
    /// or <c>OCSF_JSON</c>), optional filters, and field selection in the <c>OutputConfiguration</c>
    /// parameter. Before you call this operation, you must grant Security Hub permission
    /// to write to your bucket and use your Amazon Web Services KMS key by adding the bucket
    /// policy and key policy statements shown in the Examples section.
    /// </para><para>
    /// Two identities use your Amazon Web Services KMS key, and each needs its own permission.
    /// Security Hub uses the key when it writes the export objects to your bucket. The IAM
    /// principal that calls <c>StartExportJobV2</c> must also have <c>kms:GenerateDataKey</c>
    /// and <c>kms:Decrypt</c> permissions on the key. The Examples section shows both grants.
    /// </para><para>
    /// A delegated administrator can use the optional <c>Scopes</c> parameter to export findings
    /// for specific organizations or organizational units (OUs).
    /// </para><para>
    /// To make the request idempotent, provide a <c>ClientToken</c>. If you retry a <c>StartExportJobV2</c>
    /// request with the same <c>ClientToken</c> and the same request parameters, Security
    /// Hub returns the <c>ExportJobId</c> of the original job instead of starting a new one.
    /// If you reuse a <c>ClientToken</c> with different request parameters, this operation
    /// returns a <c>ConflictException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "SHUBExportJobV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Hub StartExportJobV2 API operation.", Operation = new[] {"StartExportJobV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.StartExportJobV2Response))]
    [AWSCmdletOutput("System.String or Amazon.SecurityHub.Model.StartExportJobV2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityHub.Model.StartExportJobV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class StartSHUBExportJobV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Scopes_AwsOrganization
        /// <summary>
        /// <para>
        /// <para>A list of Organizations scopes to include in the export. Each entry in the list specifies
        /// an organization or organizational unit to include for the delegated administrator's
        /// account. If the list specifies multiple entries, the entries are combined using OR
        /// logic.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scopes_AwsOrganizations")]
        public Amazon.SecurityHub.Model.AwsOrganizationScope[] Scopes_AwsOrganization { get; set; }
        #endregion
        
        #region Parameter Destination_S3_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket that Security Hub writes the
        /// export to. You must own the bucket, and its bucket policy must grant the Security
        /// Hub service principal (<c>exportv2.securityhub.amazonaws.com</c>) permission to write
        /// objects. For the required bucket policy, see the Examples section of <c>StartExportJobV2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_S3_BucketArn { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Findings_Filters_CompositeFilter
        /// <summary>
        /// <para>
        /// <para>Enables the creation of complex filtering conditions by combining filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfiguration_Findings_Filters_CompositeFilters")]
        public Amazon.SecurityHub.Model.CompositeFilter[] OutputConfiguration_Findings_Filters_CompositeFilter { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Findings_Filters_CompositeOperator
        /// <summary>
        /// <para>
        /// <para>The logical operators used to combine the filtering on multiple <c>CompositeFilters</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.AllowedOperators")]
        public Amazon.SecurityHub.AllowedOperators OutputConfiguration_Findings_Filters_CompositeOperator { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Findings_Format
        /// <summary>
        /// <para>
        /// <para>The output format of the export. <c>CSV</c> produces comma-separated rows that are
        /// suitable for spreadsheets and analysis tools. <c>OCSF_JSON</c> produces newline-delimited
        /// JSON records in the Open Cybersecurity Schema Framework (OCSF) format used elsewhere
        /// in Security Hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.FindingsExportFormat")]
        public Amazon.SecurityHub.FindingsExportFormat OutputConfiguration_Findings_Format { get; set; }
        #endregion
        
        #region Parameter Destination_S3_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services KMS key that Security Hub uses to encrypt the export
        /// objects with server-side encryption. The key policy must allow the Security Hub service
        /// principal (<c>exportv2.securityhub.amazonaws.com</c>) to use the key through Amazon
        /// S3. For the required key policy, see the Examples section of <c>StartExportJobV2</c>.</para><para>The key must meet all of the following requirements:</para><ul><li><para>It must be a symmetric key with a key usage of <c>ENCRYPT_DECRYPT</c>.</para></li><li><para>It must be a single-Region key. Multi-Region keys, whose key IDs begin with <c>mrk-</c>,
        /// are rejected.</para></li><li><para>You must specify the full key ARN. Key IDs and aliases are rejected.</para></li><li><para>The key must be in the same Amazon Web Services account as the export job.</para></li><li><para>The key must be in the same Amazon Web Services Region as the export job.</para></li><li><para>The key must be in the <c>aws</c>, <c>aws-cn</c>, or <c>aws-us-gov</c> partition.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_S3_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An optional, user-provided name for the export job that helps you identify it in <c>ListExportJobsV2</c>
        /// results. The value can be 1–256 characters. Alphanumeric characters, spaces, and the
        /// following ASCII characters are permitted: <c>. _ , : ( ) / + -</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Destination_S3_ObjectPrefix
        /// <summary>
        /// <para>
        /// <para>An optional key prefix that Security Hub prepends to the Amazon S3 object keys of
        /// the export output. Use a prefix to organize exports within the bucket. The value can
        /// be up to 512 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_S3_ObjectPrefix { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Findings_SelectedField
        /// <summary>
        /// <para>
        /// <para>The OCSF finding fields to include in the export, specified as OCSF field paths (for
        /// example, <c>finding_info.title</c> or <c>severity</c>). You can specify from 1 to
        /// 50 fields.</para><para>Whether this parameter is required depends on the value of <c>Format</c>:</para><ul><li><para><c>CSV</c> – Required. The field paths that you specify become the columns of the
        /// output, in the order that you provide them. If you omit this parameter, the request
        /// returns a <c>ValidationException</c>.</para></li><li><para><c>OCSF_JSON</c> – Not supported. This format includes each finding in full, so field
        /// selection doesn't apply. If you specify this parameter, the request returns a <c>ValidationException</c>.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfiguration_Findings_SelectedFields")]
        public System.String[] OutputConfiguration_Findings_SelectedField { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier used to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportJobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.StartExportJobV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.StartExportJobV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportJobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SHUBExportJobV2 (StartExportJobV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.StartExportJobV2Response, StartSHUBExportJobV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Destination_S3_BucketArn = this.Destination_S3_BucketArn;
            context.Destination_S3_KmsKeyArn = this.Destination_S3_KmsKeyArn;
            context.Destination_S3_ObjectPrefix = this.Destination_S3_ObjectPrefix;
            context.Name = this.Name;
            if (this.OutputConfiguration_Findings_Filters_CompositeFilter != null)
            {
                context.OutputConfiguration_Findings_Filters_CompositeFilter = new List<Amazon.SecurityHub.Model.CompositeFilter>(this.OutputConfiguration_Findings_Filters_CompositeFilter);
            }
            context.OutputConfiguration_Findings_Filters_CompositeOperator = this.OutputConfiguration_Findings_Filters_CompositeOperator;
            context.OutputConfiguration_Findings_Format = this.OutputConfiguration_Findings_Format;
            if (this.OutputConfiguration_Findings_SelectedField != null)
            {
                context.OutputConfiguration_Findings_SelectedField = new List<System.String>(this.OutputConfiguration_Findings_SelectedField);
            }
            if (this.Scopes_AwsOrganization != null)
            {
                context.Scopes_AwsOrganization = new List<Amazon.SecurityHub.Model.AwsOrganizationScope>(this.Scopes_AwsOrganization);
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
            var request = new Amazon.SecurityHub.Model.StartExportJobV2Request();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.SecurityHub.Model.ExportDestination();
            Amazon.SecurityHub.Model.S3ExportDestination requestDestination_destination_S3 = null;
            
             // populate S3
            var requestDestination_destination_S3IsNull = true;
            requestDestination_destination_S3 = new Amazon.SecurityHub.Model.S3ExportDestination();
            System.String requestDestination_destination_S3_destination_S3_BucketArn = null;
            if (cmdletContext.Destination_S3_BucketArn != null)
            {
                requestDestination_destination_S3_destination_S3_BucketArn = cmdletContext.Destination_S3_BucketArn;
            }
            if (requestDestination_destination_S3_destination_S3_BucketArn != null)
            {
                requestDestination_destination_S3.BucketArn = requestDestination_destination_S3_destination_S3_BucketArn;
                requestDestination_destination_S3IsNull = false;
            }
            System.String requestDestination_destination_S3_destination_S3_KmsKeyArn = null;
            if (cmdletContext.Destination_S3_KmsKeyArn != null)
            {
                requestDestination_destination_S3_destination_S3_KmsKeyArn = cmdletContext.Destination_S3_KmsKeyArn;
            }
            if (requestDestination_destination_S3_destination_S3_KmsKeyArn != null)
            {
                requestDestination_destination_S3.KmsKeyArn = requestDestination_destination_S3_destination_S3_KmsKeyArn;
                requestDestination_destination_S3IsNull = false;
            }
            System.String requestDestination_destination_S3_destination_S3_ObjectPrefix = null;
            if (cmdletContext.Destination_S3_ObjectPrefix != null)
            {
                requestDestination_destination_S3_destination_S3_ObjectPrefix = cmdletContext.Destination_S3_ObjectPrefix;
            }
            if (requestDestination_destination_S3_destination_S3_ObjectPrefix != null)
            {
                requestDestination_destination_S3.ObjectPrefix = requestDestination_destination_S3_destination_S3_ObjectPrefix;
                requestDestination_destination_S3IsNull = false;
            }
             // determine if requestDestination_destination_S3 should be set to null
            if (requestDestination_destination_S3IsNull)
            {
                requestDestination_destination_S3 = null;
            }
            if (requestDestination_destination_S3 != null)
            {
                request.Destination.S3 = requestDestination_destination_S3;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.SecurityHub.Model.ExportOutput();
            Amazon.SecurityHub.Model.FindingsOutput requestOutputConfiguration_outputConfiguration_Findings = null;
            
             // populate Findings
            var requestOutputConfiguration_outputConfiguration_FindingsIsNull = true;
            requestOutputConfiguration_outputConfiguration_Findings = new Amazon.SecurityHub.Model.FindingsOutput();
            Amazon.SecurityHub.FindingsExportFormat requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Format = null;
            if (cmdletContext.OutputConfiguration_Findings_Format != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Format = cmdletContext.OutputConfiguration_Findings_Format;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Format != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings.Format = requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Format;
                requestOutputConfiguration_outputConfiguration_FindingsIsNull = false;
            }
            List<System.String> requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_SelectedField = null;
            if (cmdletContext.OutputConfiguration_Findings_SelectedField != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_SelectedField = cmdletContext.OutputConfiguration_Findings_SelectedField;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_SelectedField != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings.SelectedFields = requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_SelectedField;
                requestOutputConfiguration_outputConfiguration_FindingsIsNull = false;
            }
            Amazon.SecurityHub.Model.OcsfFindingFilters requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters = null;
            
             // populate Filters
            var requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_FiltersIsNull = true;
            requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters = new Amazon.SecurityHub.Model.OcsfFindingFilters();
            List<Amazon.SecurityHub.Model.CompositeFilter> requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeFilter = null;
            if (cmdletContext.OutputConfiguration_Findings_Filters_CompositeFilter != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeFilter = cmdletContext.OutputConfiguration_Findings_Filters_CompositeFilter;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeFilter != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters.CompositeFilters = requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeFilter;
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_FiltersIsNull = false;
            }
            Amazon.SecurityHub.AllowedOperators requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeOperator = null;
            if (cmdletContext.OutputConfiguration_Findings_Filters_CompositeOperator != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeOperator = cmdletContext.OutputConfiguration_Findings_Filters_CompositeOperator;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeOperator != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters.CompositeOperator = requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters_outputConfiguration_Findings_Filters_CompositeOperator;
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_FiltersIsNull = false;
            }
             // determine if requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters should be set to null
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_FiltersIsNull)
            {
                requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters = null;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters != null)
            {
                requestOutputConfiguration_outputConfiguration_Findings.Filters = requestOutputConfiguration_outputConfiguration_Findings_outputConfiguration_Findings_Filters;
                requestOutputConfiguration_outputConfiguration_FindingsIsNull = false;
            }
             // determine if requestOutputConfiguration_outputConfiguration_Findings should be set to null
            if (requestOutputConfiguration_outputConfiguration_FindingsIsNull)
            {
                requestOutputConfiguration_outputConfiguration_Findings = null;
            }
            if (requestOutputConfiguration_outputConfiguration_Findings != null)
            {
                request.OutputConfiguration.Findings = requestOutputConfiguration_outputConfiguration_Findings;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            
             // populate Scopes
            var requestScopesIsNull = true;
            request.Scopes = new Amazon.SecurityHub.Model.ExportScopes();
            List<Amazon.SecurityHub.Model.AwsOrganizationScope> requestScopes_scopes_AwsOrganization = null;
            if (cmdletContext.Scopes_AwsOrganization != null)
            {
                requestScopes_scopes_AwsOrganization = cmdletContext.Scopes_AwsOrganization;
            }
            if (requestScopes_scopes_AwsOrganization != null)
            {
                request.Scopes.AwsOrganizations = requestScopes_scopes_AwsOrganization;
                requestScopesIsNull = false;
            }
             // determine if request.Scopes should be set to null
            if (requestScopesIsNull)
            {
                request.Scopes = null;
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
        
        private Amazon.SecurityHub.Model.StartExportJobV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.StartExportJobV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "StartExportJobV2");
            try
            {
                return client.StartExportJobV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Destination_S3_BucketArn { get; set; }
            public System.String Destination_S3_KmsKeyArn { get; set; }
            public System.String Destination_S3_ObjectPrefix { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SecurityHub.Model.CompositeFilter> OutputConfiguration_Findings_Filters_CompositeFilter { get; set; }
            public Amazon.SecurityHub.AllowedOperators OutputConfiguration_Findings_Filters_CompositeOperator { get; set; }
            public Amazon.SecurityHub.FindingsExportFormat OutputConfiguration_Findings_Format { get; set; }
            public List<System.String> OutputConfiguration_Findings_SelectedField { get; set; }
            public List<Amazon.SecurityHub.Model.AwsOrganizationScope> Scopes_AwsOrganization { get; set; }
            public System.Func<Amazon.SecurityHub.Model.StartExportJobV2Response, StartSHUBExportJobV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportJobId;
        }
        
    }
}
