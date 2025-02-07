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
using Amazon.BackupSearch;
using Amazon.BackupSearch.Model;

namespace Amazon.PowerShell.Cmdlets.BAKS
{
    /// <summary>
    /// This operations starts a job to export the results of search job to a designated S3
    /// bucket.
    /// </summary>
    [Cmdlet("Start", "BAKSSearchResultExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BackupSearch.Model.StartSearchResultExportJobResponse")]
    [AWSCmdlet("Calls the AWS Backup Search StartSearchResultExportJob API operation.", Operation = new[] {"StartSearchResultExportJob"}, SelectReturnType = typeof(Amazon.BackupSearch.Model.StartSearchResultExportJobResponse))]
    [AWSCmdletOutput("Amazon.BackupSearch.Model.StartSearchResultExportJobResponse",
        "This cmdlet returns an Amazon.BackupSearch.Model.StartSearchResultExportJobResponse object containing multiple properties."
    )]
    public partial class StartBAKSSearchResultExportJobCmdlet : AmazonBackupSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3ExportSpecification_DestinationBucket
        /// <summary>
        /// <para>
        /// <para>This specifies the destination Amazon S3 bucket for the export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportSpecification_S3ExportSpecification_DestinationBucket")]
        public System.String S3ExportSpecification_DestinationBucket { get; set; }
        #endregion
        
        #region Parameter S3ExportSpecification_DestinationPrefix
        /// <summary>
        /// <para>
        /// <para>This specifies the prefix for the destination Amazon S3 bucket for the export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportSpecification_S3ExportSpecification_DestinationPrefix")]
        public System.String S3ExportSpecification_DestinationPrefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>This parameter specifies the role ARN used to start the search results export jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SearchJobIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique string that specifies the search job.</para>
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
        public System.String SearchJobIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags to include. A tag is a key-value pair you can use to manage, filter,
        /// and search for your resources. Allowed characters include UTF-8 letters, numbers,
        /// spaces, and the following characters: + - = . _ : /. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Include this parameter to allow multiple identical calls for idempotency.</para><para>A client token is valid for 8 hours after the first request that uses it is completed.
        /// After this time, any request with the same token is treated as a new request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupSearch.Model.StartSearchResultExportJobResponse).
        /// Specifying the name of a property of type Amazon.BackupSearch.Model.StartSearchResultExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SearchJobIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SearchJobIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SearchJobIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SearchJobIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKSSearchResultExportJob (StartSearchResultExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupSearch.Model.StartSearchResultExportJobResponse, StartBAKSSearchResultExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SearchJobIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.S3ExportSpecification_DestinationBucket = this.S3ExportSpecification_DestinationBucket;
            context.S3ExportSpecification_DestinationPrefix = this.S3ExportSpecification_DestinationPrefix;
            context.RoleArn = this.RoleArn;
            context.SearchJobIdentifier = this.SearchJobIdentifier;
            #if MODULAR
            if (this.SearchJobIdentifier == null && ParameterWasBound(nameof(this.SearchJobIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchJobIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BackupSearch.Model.StartSearchResultExportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExportSpecification
            var requestExportSpecificationIsNull = true;
            request.ExportSpecification = new Amazon.BackupSearch.Model.ExportSpecification();
            Amazon.BackupSearch.Model.S3ExportSpecification requestExportSpecification_exportSpecification_S3ExportSpecification = null;
            
             // populate S3ExportSpecification
            var requestExportSpecification_exportSpecification_S3ExportSpecificationIsNull = true;
            requestExportSpecification_exportSpecification_S3ExportSpecification = new Amazon.BackupSearch.Model.S3ExportSpecification();
            System.String requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationBucket = null;
            if (cmdletContext.S3ExportSpecification_DestinationBucket != null)
            {
                requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationBucket = cmdletContext.S3ExportSpecification_DestinationBucket;
            }
            if (requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationBucket != null)
            {
                requestExportSpecification_exportSpecification_S3ExportSpecification.DestinationBucket = requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationBucket;
                requestExportSpecification_exportSpecification_S3ExportSpecificationIsNull = false;
            }
            System.String requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationPrefix = null;
            if (cmdletContext.S3ExportSpecification_DestinationPrefix != null)
            {
                requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationPrefix = cmdletContext.S3ExportSpecification_DestinationPrefix;
            }
            if (requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationPrefix != null)
            {
                requestExportSpecification_exportSpecification_S3ExportSpecification.DestinationPrefix = requestExportSpecification_exportSpecification_S3ExportSpecification_s3ExportSpecification_DestinationPrefix;
                requestExportSpecification_exportSpecification_S3ExportSpecificationIsNull = false;
            }
             // determine if requestExportSpecification_exportSpecification_S3ExportSpecification should be set to null
            if (requestExportSpecification_exportSpecification_S3ExportSpecificationIsNull)
            {
                requestExportSpecification_exportSpecification_S3ExportSpecification = null;
            }
            if (requestExportSpecification_exportSpecification_S3ExportSpecification != null)
            {
                request.ExportSpecification.S3ExportSpecification = requestExportSpecification_exportSpecification_S3ExportSpecification;
                requestExportSpecificationIsNull = false;
            }
             // determine if request.ExportSpecification should be set to null
            if (requestExportSpecificationIsNull)
            {
                request.ExportSpecification = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SearchJobIdentifier != null)
            {
                request.SearchJobIdentifier = cmdletContext.SearchJobIdentifier;
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
        
        private Amazon.BackupSearch.Model.StartSearchResultExportJobResponse CallAWSServiceOperation(IAmazonBackupSearch client, Amazon.BackupSearch.Model.StartSearchResultExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Search", "StartSearchResultExportJob");
            try
            {
                #if DESKTOP
                return client.StartSearchResultExportJob(request);
                #elif CORECLR
                return client.StartSearchResultExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String S3ExportSpecification_DestinationBucket { get; set; }
            public System.String S3ExportSpecification_DestinationPrefix { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SearchJobIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BackupSearch.Model.StartSearchResultExportJobResponse, StartBAKSSearchResultExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
