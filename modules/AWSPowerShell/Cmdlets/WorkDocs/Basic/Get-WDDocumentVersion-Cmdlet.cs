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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Retrieves version metadata for the specified document.
    /// </summary>
    [Cmdlet("Get", "WDDocumentVersion")]
    [OutputType("Amazon.WorkDocs.Model.GetDocumentVersionResponse")]
    [AWSCmdlet("Calls the Amazon WorkDocs GetDocumentVersion API operation.", Operation = new[] {"GetDocumentVersion"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.GetDocumentVersionResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.GetDocumentVersionResponse",
        "This cmdlet returns an Amazon.WorkDocs.Model.GetDocumentVersionResponse object containing multiple properties."
    )]
    public partial class GetWDDocumentVersionCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter DocumentId
        /// <summary>
        /// <para>
        /// <para>The ID of the document.</para>
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
        public System.String DocumentId { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of values. Specify "SOURCE" to include a URL for the source
        /// document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Fields")]
        public System.String Field { get; set; }
        #endregion
        
        #region Parameter IncludeCustomMetadata
        /// <summary>
        /// <para>
        /// <para>Set this to TRUE to include custom metadata in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeCustomMetadata { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the document.</para>
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
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.GetDocumentVersionResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.GetDocumentVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DocumentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DocumentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DocumentId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.GetDocumentVersionResponse, GetWDDocumentVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DocumentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthenticationToken = this.AuthenticationToken;
            context.DocumentId = this.DocumentId;
            #if MODULAR
            if (this.DocumentId == null && ParameterWasBound(nameof(this.DocumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Field = this.Field;
            context.IncludeCustomMetadata = this.IncludeCustomMetadata;
            context.VersionId = this.VersionId;
            #if MODULAR
            if (this.VersionId == null && ParameterWasBound(nameof(this.VersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkDocs.Model.GetDocumentVersionRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.DocumentId != null)
            {
                request.DocumentId = cmdletContext.DocumentId;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            if (cmdletContext.IncludeCustomMetadata != null)
            {
                request.IncludeCustomMetadata = cmdletContext.IncludeCustomMetadata.Value;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.WorkDocs.Model.GetDocumentVersionResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.GetDocumentVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "GetDocumentVersion");
            try
            {
                #if DESKTOP
                return client.GetDocumentVersion(request);
                #elif CORECLR
                return client.GetDocumentVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthenticationToken { get; set; }
            public System.String DocumentId { get; set; }
            public System.String Field { get; set; }
            public System.Boolean? IncludeCustomMetadata { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.WorkDocs.Model.GetDocumentVersionResponse, GetWDDocumentVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
