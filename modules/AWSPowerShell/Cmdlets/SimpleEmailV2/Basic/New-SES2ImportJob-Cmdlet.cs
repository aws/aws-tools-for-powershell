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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Creates an import job for a data destination.
    /// </summary>
    [Cmdlet("New", "SES2ImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateImportJob API operation.", Operation = new[] {"CreateImportJob"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateImportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmailV2.Model.CreateImportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmailV2.Model.CreateImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSES2ImportJobCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ContactListDestination_ContactListImportAction
        /// <summary>
        /// <para>
        /// <para>&gt;The type of action that you want to perform on the addresses. Acceptable values:</para><ul><li><para>PUT: add the addresses to the contact list. If the record already exists, it will
        /// override it with the new value.</para></li><li><para>DELETE: remove the addresses from the contact list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportDestination_ContactListDestination_ContactListImportAction")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ContactListImportAction")]
        public Amazon.SimpleEmailV2.ContactListImportAction ContactListDestination_ContactListImportAction { get; set; }
        #endregion
        
        #region Parameter ContactListDestination_ContactListName
        /// <summary>
        /// <para>
        /// <para>The name of the contact list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportDestination_ContactListDestination_ContactListName")]
        public System.String ContactListDestination_ContactListName { get; set; }
        #endregion
        
        #region Parameter ImportDataSource_DataFormat
        /// <summary>
        /// <para>
        /// <para>The data format of the import job's data source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DataFormat")]
        public Amazon.SimpleEmailV2.DataFormat ImportDataSource_DataFormat { get; set; }
        #endregion
        
        #region Parameter ImportDataSource_S3Url
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URL in the format s3://<i>&lt;bucket_name&gt;</i>/<i>&lt;object&gt;</i>.</para>
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
        public System.String ImportDataSource_S3Url { get; set; }
        #endregion
        
        #region Parameter SuppressionListDestination_SuppressionListImportAction
        /// <summary>
        /// <para>
        /// <para>The type of action that you want to perform on the address. Acceptable values:</para><ul><li><para>PUT: add the addresses to the suppression list. If the record already exists, it will
        /// override it with the new value.</para></li><li><para>DELETE: remove the addresses from the suppression list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportDestination_SuppressionListDestination_SuppressionListImportAction")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SuppressionListImportAction")]
        public Amazon.SimpleEmailV2.SuppressionListImportAction SuppressionListDestination_SuppressionListImportAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateImportJobResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.CreateImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2ImportJob (CreateImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateImportJobResponse, NewSES2ImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImportDataSource_DataFormat = this.ImportDataSource_DataFormat;
            #if MODULAR
            if (this.ImportDataSource_DataFormat == null && ParameterWasBound(nameof(this.ImportDataSource_DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportDataSource_DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportDataSource_S3Url = this.ImportDataSource_S3Url;
            #if MODULAR
            if (this.ImportDataSource_S3Url == null && ParameterWasBound(nameof(this.ImportDataSource_S3Url)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportDataSource_S3Url which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactListDestination_ContactListImportAction = this.ContactListDestination_ContactListImportAction;
            context.ContactListDestination_ContactListName = this.ContactListDestination_ContactListName;
            context.SuppressionListDestination_SuppressionListImportAction = this.SuppressionListDestination_SuppressionListImportAction;
            
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
            var request = new Amazon.SimpleEmailV2.Model.CreateImportJobRequest();
            
            
             // populate ImportDataSource
            var requestImportDataSourceIsNull = true;
            request.ImportDataSource = new Amazon.SimpleEmailV2.Model.ImportDataSource();
            Amazon.SimpleEmailV2.DataFormat requestImportDataSource_importDataSource_DataFormat = null;
            if (cmdletContext.ImportDataSource_DataFormat != null)
            {
                requestImportDataSource_importDataSource_DataFormat = cmdletContext.ImportDataSource_DataFormat;
            }
            if (requestImportDataSource_importDataSource_DataFormat != null)
            {
                request.ImportDataSource.DataFormat = requestImportDataSource_importDataSource_DataFormat;
                requestImportDataSourceIsNull = false;
            }
            System.String requestImportDataSource_importDataSource_S3Url = null;
            if (cmdletContext.ImportDataSource_S3Url != null)
            {
                requestImportDataSource_importDataSource_S3Url = cmdletContext.ImportDataSource_S3Url;
            }
            if (requestImportDataSource_importDataSource_S3Url != null)
            {
                request.ImportDataSource.S3Url = requestImportDataSource_importDataSource_S3Url;
                requestImportDataSourceIsNull = false;
            }
             // determine if request.ImportDataSource should be set to null
            if (requestImportDataSourceIsNull)
            {
                request.ImportDataSource = null;
            }
            
             // populate ImportDestination
            var requestImportDestinationIsNull = true;
            request.ImportDestination = new Amazon.SimpleEmailV2.Model.ImportDestination();
            Amazon.SimpleEmailV2.Model.SuppressionListDestination requestImportDestination_importDestination_SuppressionListDestination = null;
            
             // populate SuppressionListDestination
            var requestImportDestination_importDestination_SuppressionListDestinationIsNull = true;
            requestImportDestination_importDestination_SuppressionListDestination = new Amazon.SimpleEmailV2.Model.SuppressionListDestination();
            Amazon.SimpleEmailV2.SuppressionListImportAction requestImportDestination_importDestination_SuppressionListDestination_suppressionListDestination_SuppressionListImportAction = null;
            if (cmdletContext.SuppressionListDestination_SuppressionListImportAction != null)
            {
                requestImportDestination_importDestination_SuppressionListDestination_suppressionListDestination_SuppressionListImportAction = cmdletContext.SuppressionListDestination_SuppressionListImportAction;
            }
            if (requestImportDestination_importDestination_SuppressionListDestination_suppressionListDestination_SuppressionListImportAction != null)
            {
                requestImportDestination_importDestination_SuppressionListDestination.SuppressionListImportAction = requestImportDestination_importDestination_SuppressionListDestination_suppressionListDestination_SuppressionListImportAction;
                requestImportDestination_importDestination_SuppressionListDestinationIsNull = false;
            }
             // determine if requestImportDestination_importDestination_SuppressionListDestination should be set to null
            if (requestImportDestination_importDestination_SuppressionListDestinationIsNull)
            {
                requestImportDestination_importDestination_SuppressionListDestination = null;
            }
            if (requestImportDestination_importDestination_SuppressionListDestination != null)
            {
                request.ImportDestination.SuppressionListDestination = requestImportDestination_importDestination_SuppressionListDestination;
                requestImportDestinationIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.ContactListDestination requestImportDestination_importDestination_ContactListDestination = null;
            
             // populate ContactListDestination
            var requestImportDestination_importDestination_ContactListDestinationIsNull = true;
            requestImportDestination_importDestination_ContactListDestination = new Amazon.SimpleEmailV2.Model.ContactListDestination();
            Amazon.SimpleEmailV2.ContactListImportAction requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListImportAction = null;
            if (cmdletContext.ContactListDestination_ContactListImportAction != null)
            {
                requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListImportAction = cmdletContext.ContactListDestination_ContactListImportAction;
            }
            if (requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListImportAction != null)
            {
                requestImportDestination_importDestination_ContactListDestination.ContactListImportAction = requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListImportAction;
                requestImportDestination_importDestination_ContactListDestinationIsNull = false;
            }
            System.String requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListName = null;
            if (cmdletContext.ContactListDestination_ContactListName != null)
            {
                requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListName = cmdletContext.ContactListDestination_ContactListName;
            }
            if (requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListName != null)
            {
                requestImportDestination_importDestination_ContactListDestination.ContactListName = requestImportDestination_importDestination_ContactListDestination_contactListDestination_ContactListName;
                requestImportDestination_importDestination_ContactListDestinationIsNull = false;
            }
             // determine if requestImportDestination_importDestination_ContactListDestination should be set to null
            if (requestImportDestination_importDestination_ContactListDestinationIsNull)
            {
                requestImportDestination_importDestination_ContactListDestination = null;
            }
            if (requestImportDestination_importDestination_ContactListDestination != null)
            {
                request.ImportDestination.ContactListDestination = requestImportDestination_importDestination_ContactListDestination;
                requestImportDestinationIsNull = false;
            }
             // determine if request.ImportDestination should be set to null
            if (requestImportDestinationIsNull)
            {
                request.ImportDestination = null;
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
        
        private Amazon.SimpleEmailV2.Model.CreateImportJobResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateImportJob");
            try
            {
                #if DESKTOP
                return client.CreateImportJob(request);
                #elif CORECLR
                return client.CreateImportJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleEmailV2.DataFormat ImportDataSource_DataFormat { get; set; }
            public System.String ImportDataSource_S3Url { get; set; }
            public Amazon.SimpleEmailV2.ContactListImportAction ContactListDestination_ContactListImportAction { get; set; }
            public System.String ContactListDestination_ContactListName { get; set; }
            public Amazon.SimpleEmailV2.SuppressionListImportAction SuppressionListDestination_SuppressionListImportAction { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateImportJobResponse, NewSES2ImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
