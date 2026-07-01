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
using Amazon.Artifact;
using Amazon.Artifact.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ART
{
    /// <summary>
    /// Create a new compliance inquiry.
    /// </summary>
    [Cmdlet("New", "ARTComplianceInquiry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Artifact.Model.CreateComplianceInquiryResponse")]
    [AWSCmdlet("Calls the AWS Artifact CreateComplianceInquiry API operation.", Operation = new[] {"CreateComplianceInquiry"}, SelectReturnType = typeof(Amazon.Artifact.Model.CreateComplianceInquiryResponse))]
    [AWSCmdletOutput("Amazon.Artifact.Model.CreateComplianceInquiryResponse",
        "This cmdlet returns an Amazon.Artifact.Model.CreateComplianceInquiryResponse object containing multiple properties."
    )]
    public partial class NewARTComplianceInquiryCmdlet : AmazonArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InquiryContent_FileContent_Content
        /// <summary>
        /// <para>
        /// <para>Binary content of the uploaded file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] InquiryContent_FileContent_Content { get; set; }
        #endregion
        
        #region Parameter InquiryContent_FileContent_FileSection
        /// <summary>
        /// <para>
        /// <para>List of file sections/sheets to process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InquiryContent_FileContent_FileSections")]
        public System.String[] InquiryContent_FileContent_FileSection { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Title of the inquiry.</para>
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
        
        #region Parameter InquiryContent_Query
        /// <summary>
        /// <para>
        /// <para>Single text query for AI-generated answer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InquiryContent_Query { get; set; }
        #endregion
        
        #region Parameter SupportMode
        /// <summary>
        /// <para>
        /// <para>Support mode for inquiry processing. Only supported for file upload mode. Defaults
        /// to AI_ONLY if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Artifact.InquirySupportMode")]
        public Amazon.Artifact.InquirySupportMode SupportMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the compliance inquiry resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Artifact.Model.CreateComplianceInquiryResponse).
        /// Specifying the name of a property of type Amazon.Artifact.Model.CreateComplianceInquiryResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ARTComplianceInquiry (CreateComplianceInquiry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Artifact.Model.CreateComplianceInquiryResponse, NewARTComplianceInquiryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InquiryContent_FileContent_Content = this.InquiryContent_FileContent_Content;
            if (this.InquiryContent_FileContent_FileSection != null)
            {
                context.InquiryContent_FileContent_FileSection = new List<System.String>(this.InquiryContent_FileContent_FileSection);
            }
            context.InquiryContent_Query = this.InquiryContent_Query;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SupportMode = this.SupportMode;
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
            System.IO.MemoryStream _InquiryContent_FileContent_ContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Artifact.Model.CreateComplianceInquiryRequest();
                
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                
                 // populate InquiryContent
                var requestInquiryContentIsNull = true;
                request.InquiryContent = new Amazon.Artifact.Model.InquiryContent();
                System.String requestInquiryContent_inquiryContent_Query = null;
                if (cmdletContext.InquiryContent_Query != null)
                {
                    requestInquiryContent_inquiryContent_Query = cmdletContext.InquiryContent_Query;
                }
                if (requestInquiryContent_inquiryContent_Query != null)
                {
                    request.InquiryContent.Query = requestInquiryContent_inquiryContent_Query;
                    requestInquiryContentIsNull = false;
                }
                Amazon.Artifact.Model.InquiryFileContent requestInquiryContent_inquiryContent_FileContent = null;
                
                 // populate FileContent
                var requestInquiryContent_inquiryContent_FileContentIsNull = true;
                requestInquiryContent_inquiryContent_FileContent = new Amazon.Artifact.Model.InquiryFileContent();
                System.IO.MemoryStream requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_Content = null;
                if (cmdletContext.InquiryContent_FileContent_Content != null)
                {
                    _InquiryContent_FileContent_ContentStream = new System.IO.MemoryStream(cmdletContext.InquiryContent_FileContent_Content);
                    requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_Content = _InquiryContent_FileContent_ContentStream;
                }
                if (requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_Content != null)
                {
                    requestInquiryContent_inquiryContent_FileContent.Content = requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_Content;
                    requestInquiryContent_inquiryContent_FileContentIsNull = false;
                }
                List<System.String> requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_FileSection = null;
                if (cmdletContext.InquiryContent_FileContent_FileSection != null)
                {
                    requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_FileSection = cmdletContext.InquiryContent_FileContent_FileSection;
                }
                if (requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_FileSection != null)
                {
                    requestInquiryContent_inquiryContent_FileContent.FileSections = requestInquiryContent_inquiryContent_FileContent_inquiryContent_FileContent_FileSection;
                    requestInquiryContent_inquiryContent_FileContentIsNull = false;
                }
                 // determine if requestInquiryContent_inquiryContent_FileContent should be set to null
                if (requestInquiryContent_inquiryContent_FileContentIsNull)
                {
                    requestInquiryContent_inquiryContent_FileContent = null;
                }
                if (requestInquiryContent_inquiryContent_FileContent != null)
                {
                    request.InquiryContent.FileContent = requestInquiryContent_inquiryContent_FileContent;
                    requestInquiryContentIsNull = false;
                }
                 // determine if request.InquiryContent should be set to null
                if (requestInquiryContentIsNull)
                {
                    request.InquiryContent = null;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.SupportMode != null)
                {
                    request.SupportMode = cmdletContext.SupportMode;
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
            finally
            {
                if( _InquiryContent_FileContent_ContentStream != null)
                {
                    _InquiryContent_FileContent_ContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Artifact.Model.CreateComplianceInquiryResponse CallAWSServiceOperation(IAmazonArtifact client, Amazon.Artifact.Model.CreateComplianceInquiryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Artifact", "CreateComplianceInquiry");
            try
            {
                return client.CreateComplianceInquiryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] InquiryContent_FileContent_Content { get; set; }
            public List<System.String> InquiryContent_FileContent_FileSection { get; set; }
            public System.String InquiryContent_Query { get; set; }
            public System.String Name { get; set; }
            public Amazon.Artifact.InquirySupportMode SupportMode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Artifact.Model.CreateComplianceInquiryResponse, NewARTComplianceInquiryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
