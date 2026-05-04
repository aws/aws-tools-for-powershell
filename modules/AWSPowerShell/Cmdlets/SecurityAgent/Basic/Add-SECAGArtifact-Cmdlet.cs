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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Uploads an artifact to an agent space. Artifacts provide additional context for security
    /// testing, such as architecture diagrams, API specifications, or configuration files.
    /// </summary>
    [Cmdlet("Add", "SECAGArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Agent AddArtifact API operation.", Operation = new[] {"AddArtifact"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.AddArtifactResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityAgent.Model.AddArtifactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityAgent.Model.AddArtifactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddSECAGArtifactCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent space to add the artifact to.</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter ArtifactContent
        /// <summary>
        /// <para>
        /// <para>The binary content of the artifact to upload.</para>
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
        public byte[] ArtifactContent { get; set; }
        #endregion
        
        #region Parameter ArtifactType
        /// <summary>
        /// <para>
        /// <para>The file type of the artifact. Valid values include TXT, PNG, JPEG, MD, PDF, DOCX,
        /// DOC, JSON, and YAML.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityAgent.ArtifactType")]
        public Amazon.SecurityAgent.ArtifactType ArtifactType { get; set; }
        #endregion
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The file name of the artifact.</para>
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
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ArtifactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.AddArtifactResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.AddArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ArtifactId";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AgentSpaceId),
                nameof(this.FileName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SECAGArtifact (AddArtifact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.AddArtifactResponse, AddSECAGArtifactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArtifactContent = this.ArtifactContent;
            #if MODULAR
            if (this.ArtifactContent == null && ParameterWasBound(nameof(this.ArtifactContent)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArtifactType = this.ArtifactType;
            #if MODULAR
            if (this.ArtifactType == null && ParameterWasBound(nameof(this.ArtifactType)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            System.IO.MemoryStream _ArtifactContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SecurityAgent.Model.AddArtifactRequest();
                
                if (cmdletContext.AgentSpaceId != null)
                {
                    request.AgentSpaceId = cmdletContext.AgentSpaceId;
                }
                if (cmdletContext.ArtifactContent != null)
                {
                    _ArtifactContentStream = new System.IO.MemoryStream(cmdletContext.ArtifactContent);
                    request.ArtifactContent = _ArtifactContentStream;
                }
                if (cmdletContext.ArtifactType != null)
                {
                    request.ArtifactType = cmdletContext.ArtifactType;
                }
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
            finally
            {
                if( _ArtifactContentStream != null)
                {
                    _ArtifactContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecurityAgent.Model.AddArtifactResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.AddArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "AddArtifact");
            try
            {
                return client.AddArtifactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public byte[] ArtifactContent { get; set; }
            public Amazon.SecurityAgent.ArtifactType ArtifactType { get; set; }
            public System.String FileName { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.AddArtifactResponse, AddSECAGArtifactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ArtifactId;
        }
        
    }
}
