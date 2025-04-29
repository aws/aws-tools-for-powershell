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
using Amazon.TaxSettings;
using Amazon.TaxSettings.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TSA
{
    /// <summary>
    /// Adds the tax exemption for a single account or all accounts listed in a consolidated
    /// billing family. The IAM action is <c>tax:UpdateExemptions</c>.
    /// </summary>
    [Cmdlet("Write", "TSATaxExemption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Tax Settings PutTaxExemption API operation.", Operation = new[] {"PutTaxExemption"}, SelectReturnType = typeof(Amazon.TaxSettings.Model.PutTaxExemptionResponse))]
    [AWSCmdletOutput("System.String or Amazon.TaxSettings.Model.PutTaxExemptionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.TaxSettings.Model.PutTaxExemptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteTSATaxExemptionCmdlet : AmazonTaxSettingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para> The list of unique account identifiers. </para>
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
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter Authority_Country
        /// <summary>
        /// <para>
        /// <para> The country code for the country that the address is in. </para>
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
        public System.String Authority_Country { get; set; }
        #endregion
        
        #region Parameter ExemptionCertificate_DocumentFile
        /// <summary>
        /// <para>
        /// <para>The exemption certificate file content. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ExemptionCertificate_DocumentFile { get; set; }
        #endregion
        
        #region Parameter ExemptionCertificate_DocumentName
        /// <summary>
        /// <para>
        /// <para>The exemption certificate file name. </para>
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
        public System.String ExemptionCertificate_DocumentName { get; set; }
        #endregion
        
        #region Parameter ExemptionType
        /// <summary>
        /// <para>
        /// <para>The exemption type. Use the supported tax exemption type description. </para>
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
        public System.String ExemptionType { get; set; }
        #endregion
        
        #region Parameter Authority_State
        /// <summary>
        /// <para>
        /// <para> The state that the address is located. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authority_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CaseId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TaxSettings.Model.PutTaxExemptionResponse).
        /// Specifying the name of a property of type Amazon.TaxSettings.Model.PutTaxExemptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CaseId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExemptionCertificate_DocumentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-TSATaxExemption (PutTaxExemption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TaxSettings.Model.PutTaxExemptionResponse, WriteTSATaxExemptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Authority_Country = this.Authority_Country;
            #if MODULAR
            if (this.Authority_Country == null && ParameterWasBound(nameof(this.Authority_Country)))
            {
                WriteWarning("You are passing $null as a value for parameter Authority_Country which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Authority_State = this.Authority_State;
            context.ExemptionCertificate_DocumentFile = this.ExemptionCertificate_DocumentFile;
            #if MODULAR
            if (this.ExemptionCertificate_DocumentFile == null && ParameterWasBound(nameof(this.ExemptionCertificate_DocumentFile)))
            {
                WriteWarning("You are passing $null as a value for parameter ExemptionCertificate_DocumentFile which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExemptionCertificate_DocumentName = this.ExemptionCertificate_DocumentName;
            #if MODULAR
            if (this.ExemptionCertificate_DocumentName == null && ParameterWasBound(nameof(this.ExemptionCertificate_DocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExemptionCertificate_DocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExemptionType = this.ExemptionType;
            #if MODULAR
            if (this.ExemptionType == null && ParameterWasBound(nameof(this.ExemptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ExemptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _ExemptionCertificate_DocumentFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.TaxSettings.Model.PutTaxExemptionRequest();
                
                if (cmdletContext.AccountId != null)
                {
                    request.AccountIds = cmdletContext.AccountId;
                }
                
                 // populate Authority
                var requestAuthorityIsNull = true;
                request.Authority = new Amazon.TaxSettings.Model.Authority();
                System.String requestAuthority_authority_Country = null;
                if (cmdletContext.Authority_Country != null)
                {
                    requestAuthority_authority_Country = cmdletContext.Authority_Country;
                }
                if (requestAuthority_authority_Country != null)
                {
                    request.Authority.Country = requestAuthority_authority_Country;
                    requestAuthorityIsNull = false;
                }
                System.String requestAuthority_authority_State = null;
                if (cmdletContext.Authority_State != null)
                {
                    requestAuthority_authority_State = cmdletContext.Authority_State;
                }
                if (requestAuthority_authority_State != null)
                {
                    request.Authority.State = requestAuthority_authority_State;
                    requestAuthorityIsNull = false;
                }
                 // determine if request.Authority should be set to null
                if (requestAuthorityIsNull)
                {
                    request.Authority = null;
                }
                
                 // populate ExemptionCertificate
                var requestExemptionCertificateIsNull = true;
                request.ExemptionCertificate = new Amazon.TaxSettings.Model.ExemptionCertificate();
                System.IO.MemoryStream requestExemptionCertificate_exemptionCertificate_DocumentFile = null;
                if (cmdletContext.ExemptionCertificate_DocumentFile != null)
                {
                    _ExemptionCertificate_DocumentFileStream = new System.IO.MemoryStream(cmdletContext.ExemptionCertificate_DocumentFile);
                    requestExemptionCertificate_exemptionCertificate_DocumentFile = _ExemptionCertificate_DocumentFileStream;
                }
                if (requestExemptionCertificate_exemptionCertificate_DocumentFile != null)
                {
                    request.ExemptionCertificate.DocumentFile = requestExemptionCertificate_exemptionCertificate_DocumentFile;
                    requestExemptionCertificateIsNull = false;
                }
                System.String requestExemptionCertificate_exemptionCertificate_DocumentName = null;
                if (cmdletContext.ExemptionCertificate_DocumentName != null)
                {
                    requestExemptionCertificate_exemptionCertificate_DocumentName = cmdletContext.ExemptionCertificate_DocumentName;
                }
                if (requestExemptionCertificate_exemptionCertificate_DocumentName != null)
                {
                    request.ExemptionCertificate.DocumentName = requestExemptionCertificate_exemptionCertificate_DocumentName;
                    requestExemptionCertificateIsNull = false;
                }
                 // determine if request.ExemptionCertificate should be set to null
                if (requestExemptionCertificateIsNull)
                {
                    request.ExemptionCertificate = null;
                }
                if (cmdletContext.ExemptionType != null)
                {
                    request.ExemptionType = cmdletContext.ExemptionType;
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
            finally
            {
                if( _ExemptionCertificate_DocumentFileStream != null)
                {
                    _ExemptionCertificate_DocumentFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.TaxSettings.Model.PutTaxExemptionResponse CallAWSServiceOperation(IAmazonTaxSettings client, Amazon.TaxSettings.Model.PutTaxExemptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Tax Settings", "PutTaxExemption");
            try
            {
                return client.PutTaxExemptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.String Authority_Country { get; set; }
            public System.String Authority_State { get; set; }
            public byte[] ExemptionCertificate_DocumentFile { get; set; }
            public System.String ExemptionCertificate_DocumentName { get; set; }
            public System.String ExemptionType { get; set; }
            public System.Func<Amazon.TaxSettings.Model.PutTaxExemptionResponse, WriteTSATaxExemptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CaseId;
        }
        
    }
}
