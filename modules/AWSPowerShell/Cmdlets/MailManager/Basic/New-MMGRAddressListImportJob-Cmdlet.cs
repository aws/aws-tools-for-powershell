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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Creates an import job for an address list.
    /// </summary>
    [Cmdlet("New", "MMGRAddressListImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MailManager.Model.CreateAddressListImportJobResponse")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateAddressListImportJob API operation.", Operation = new[] {"CreateAddressListImportJob"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateAddressListImportJobResponse))]
    [AWSCmdletOutput("Amazon.MailManager.Model.CreateAddressListImportJobResponse",
        "This cmdlet returns an Amazon.MailManager.Model.CreateAddressListImportJobResponse object containing multiple properties."
    )]
    public partial class NewMMGRAddressListImportJobCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddressListId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the address list for importing addresses to.</para>
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
        public System.String AddressListId { get; set; }
        #endregion
        
        #region Parameter ImportDataFormat_ImportDataType
        /// <summary>
        /// <para>
        /// <para>The type of file that would be passed as an input for the address list import job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MailManager.ImportDataType")]
        public Amazon.MailManager.ImportDataType ImportDataFormat_ImportDataType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the import job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that Amazon SES uses to recognize subsequent retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateAddressListImportJobResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateAddressListImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AddressListId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRAddressListImportJob (CreateAddressListImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateAddressListImportJobResponse, NewMMGRAddressListImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddressListId = this.AddressListId;
            #if MODULAR
            if (this.AddressListId == null && ParameterWasBound(nameof(this.AddressListId)))
            {
                WriteWarning("You are passing $null as a value for parameter AddressListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ImportDataFormat_ImportDataType = this.ImportDataFormat_ImportDataType;
            #if MODULAR
            if (this.ImportDataFormat_ImportDataType == null && ParameterWasBound(nameof(this.ImportDataFormat_ImportDataType)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportDataFormat_ImportDataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.CreateAddressListImportJobRequest();
            
            if (cmdletContext.AddressListId != null)
            {
                request.AddressListId = cmdletContext.AddressListId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ImportDataFormat
            var requestImportDataFormatIsNull = true;
            request.ImportDataFormat = new Amazon.MailManager.Model.ImportDataFormat();
            Amazon.MailManager.ImportDataType requestImportDataFormat_importDataFormat_ImportDataType = null;
            if (cmdletContext.ImportDataFormat_ImportDataType != null)
            {
                requestImportDataFormat_importDataFormat_ImportDataType = cmdletContext.ImportDataFormat_ImportDataType;
            }
            if (requestImportDataFormat_importDataFormat_ImportDataType != null)
            {
                request.ImportDataFormat.ImportDataType = requestImportDataFormat_importDataFormat_ImportDataType;
                requestImportDataFormatIsNull = false;
            }
             // determine if request.ImportDataFormat should be set to null
            if (requestImportDataFormatIsNull)
            {
                request.ImportDataFormat = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.MailManager.Model.CreateAddressListImportJobResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateAddressListImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateAddressListImportJob");
            try
            {
                return client.CreateAddressListImportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AddressListId { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.MailManager.ImportDataType ImportDataFormat_ImportDataType { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateAddressListImportJobResponse, NewMMGRAddressListImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
