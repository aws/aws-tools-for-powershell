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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Initiates an export of emails from the specified archive.
    /// </summary>
    [Cmdlet("Start", "MMGRArchiveExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager StartArchiveExport API operation.", Operation = new[] {"StartArchiveExport"}, SelectReturnType = typeof(Amazon.MailManager.Model.StartArchiveExportResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.StartArchiveExportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.StartArchiveExportResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartMMGRArchiveExportCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArchiveId
        /// <summary>
        /// <para>
        /// <para>The identifier of the archive to export emails from.</para>
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
        public System.String ArchiveId { get; set; }
        #endregion
        
        #region Parameter FromTimestamp
        /// <summary>
        /// <para>
        /// <para>The start of the timestamp range to include emails from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FromTimestamp { get; set; }
        #endregion
        
        #region Parameter Filters_Include
        /// <summary>
        /// <para>
        /// <para>The filter conditions for emails to include.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MailManager.Model.ArchiveFilterCondition[] Filters_Include { get; set; }
        #endregion
        
        #region Parameter S3_S3Location
        /// <summary>
        /// <para>
        /// <para>The S3 location to deliver the exported email data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDestinationConfiguration_S3_S3Location")]
        public System.String S3_S3Location { get; set; }
        #endregion
        
        #region Parameter ToTimestamp
        /// <summary>
        /// <para>
        /// <para>The end of the timestamp range to include emails from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ToTimestamp { get; set; }
        #endregion
        
        #region Parameter Filters_Unless
        /// <summary>
        /// <para>
        /// <para>The filter conditions for emails to exclude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MailManager.Model.ArchiveFilterCondition[] Filters_Unless { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of email items to include in the export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.StartArchiveExportResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.StartArchiveExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MMGRArchiveExport (StartArchiveExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.StartArchiveExportResponse, StartMMGRArchiveExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchiveId = this.ArchiveId;
            #if MODULAR
            if (this.ArchiveId == null && ParameterWasBound(nameof(this.ArchiveId)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3_S3Location = this.S3_S3Location;
            if (this.Filters_Include != null)
            {
                context.Filters_Include = new List<Amazon.MailManager.Model.ArchiveFilterCondition>(this.Filters_Include);
            }
            if (this.Filters_Unless != null)
            {
                context.Filters_Unless = new List<Amazon.MailManager.Model.ArchiveFilterCondition>(this.Filters_Unless);
            }
            context.FromTimestamp = this.FromTimestamp;
            #if MODULAR
            if (this.FromTimestamp == null && ParameterWasBound(nameof(this.FromTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter FromTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.ToTimestamp = this.ToTimestamp;
            #if MODULAR
            if (this.ToTimestamp == null && ParameterWasBound(nameof(this.ToTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter ToTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.StartArchiveExportRequest();
            
            if (cmdletContext.ArchiveId != null)
            {
                request.ArchiveId = cmdletContext.ArchiveId;
            }
            
             // populate ExportDestinationConfiguration
            var requestExportDestinationConfigurationIsNull = true;
            request.ExportDestinationConfiguration = new Amazon.MailManager.Model.ExportDestinationConfiguration();
            Amazon.MailManager.Model.S3ExportDestinationConfiguration requestExportDestinationConfiguration_exportDestinationConfiguration_S3 = null;
            
             // populate S3
            var requestExportDestinationConfiguration_exportDestinationConfiguration_S3IsNull = true;
            requestExportDestinationConfiguration_exportDestinationConfiguration_S3 = new Amazon.MailManager.Model.S3ExportDestinationConfiguration();
            System.String requestExportDestinationConfiguration_exportDestinationConfiguration_S3_s3_S3Location = null;
            if (cmdletContext.S3_S3Location != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_S3_s3_S3Location = cmdletContext.S3_S3Location;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_S3_s3_S3Location != null)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_S3.S3Location = requestExportDestinationConfiguration_exportDestinationConfiguration_S3_s3_S3Location;
                requestExportDestinationConfiguration_exportDestinationConfiguration_S3IsNull = false;
            }
             // determine if requestExportDestinationConfiguration_exportDestinationConfiguration_S3 should be set to null
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_S3IsNull)
            {
                requestExportDestinationConfiguration_exportDestinationConfiguration_S3 = null;
            }
            if (requestExportDestinationConfiguration_exportDestinationConfiguration_S3 != null)
            {
                request.ExportDestinationConfiguration.S3 = requestExportDestinationConfiguration_exportDestinationConfiguration_S3;
                requestExportDestinationConfigurationIsNull = false;
            }
             // determine if request.ExportDestinationConfiguration should be set to null
            if (requestExportDestinationConfigurationIsNull)
            {
                request.ExportDestinationConfiguration = null;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.MailManager.Model.ArchiveFilters();
            List<Amazon.MailManager.Model.ArchiveFilterCondition> requestFilters_filters_Include = null;
            if (cmdletContext.Filters_Include != null)
            {
                requestFilters_filters_Include = cmdletContext.Filters_Include;
            }
            if (requestFilters_filters_Include != null)
            {
                request.Filters.Include = requestFilters_filters_Include;
                requestFiltersIsNull = false;
            }
            List<Amazon.MailManager.Model.ArchiveFilterCondition> requestFilters_filters_Unless = null;
            if (cmdletContext.Filters_Unless != null)
            {
                requestFilters_filters_Unless = cmdletContext.Filters_Unless;
            }
            if (requestFilters_filters_Unless != null)
            {
                request.Filters.Unless = requestFilters_filters_Unless;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.FromTimestamp != null)
            {
                request.FromTimestamp = cmdletContext.FromTimestamp.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ToTimestamp != null)
            {
                request.ToTimestamp = cmdletContext.ToTimestamp.Value;
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
        
        private Amazon.MailManager.Model.StartArchiveExportResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.StartArchiveExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "StartArchiveExport");
            try
            {
                #if DESKTOP
                return client.StartArchiveExport(request);
                #elif CORECLR
                return client.StartArchiveExportAsync(request).GetAwaiter().GetResult();
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
            public System.String ArchiveId { get; set; }
            public System.String S3_S3Location { get; set; }
            public List<Amazon.MailManager.Model.ArchiveFilterCondition> Filters_Include { get; set; }
            public List<Amazon.MailManager.Model.ArchiveFilterCondition> Filters_Unless { get; set; }
            public System.DateTime? FromTimestamp { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.DateTime? ToTimestamp { get; set; }
            public System.Func<Amazon.MailManager.Model.StartArchiveExportResponse, StartMMGRArchiveExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportId;
        }
        
    }
}
