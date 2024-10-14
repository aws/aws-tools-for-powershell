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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Creates a presigned Amazon S3 URL that can be used to upload a file as manual evidence.
    /// For instructions on how to use this operation, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/upload-evidence.html#how-to-upload-manual-evidence-files">Upload
    /// a file from your browser </a> in the <i>Audit Manager User Guide</i>.
    /// 
    ///  
    /// <para>
    /// The following restrictions apply to this operation:
    /// </para><ul><li><para>
    /// Maximum size of an individual evidence file: 100 MB
    /// </para></li><li><para>
    /// Number of daily manual evidence uploads per control: 100
    /// </para></li><li><para>
    /// Supported file formats: See <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/upload-evidence.html#supported-manual-evidence-files">Supported
    /// file types for manual evidence</a> in the <i>Audit Manager User Guide</i></para></li></ul><para>
    /// For more information about Audit Manager service restrictions, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/service-quotas.html">Quotas
    /// and restrictions for Audit Manager</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AUDMEvidenceFileUploadUrl")]
    [OutputType("Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse")]
    [AWSCmdlet("Calls the AWS Audit Manager GetEvidenceFileUploadUrl API operation.", Operation = new[] {"GetEvidenceFileUploadUrl"}, SelectReturnType = typeof(Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse object containing multiple properties."
    )]
    public partial class GetAUDMEvidenceFileUploadUrlCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The file that you want to upload. For a list of supported file formats, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/upload-evidence.html#supported-manual-evidence-files">Supported
        /// file types for manual evidence</a> in the <i>Audit Manager User Guide</i>.</para>
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
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse, GetAUDMEvidenceFileUploadUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.GetEvidenceFileUploadUrlRequest();
            
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
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
        
        private Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.GetEvidenceFileUploadUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "GetEvidenceFileUploadUrl");
            try
            {
                #if DESKTOP
                return client.GetEvidenceFileUploadUrl(request);
                #elif CORECLR
                return client.GetEvidenceFileUploadUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String FileName { get; set; }
            public System.Func<Amazon.AuditManager.Model.GetEvidenceFileUploadUrlResponse, GetAUDMEvidenceFileUploadUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
