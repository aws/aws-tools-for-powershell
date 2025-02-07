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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Begins a file transfer between local Amazon Web Services storage and a remote AS2
    /// or SFTP server.
    /// 
    ///  <ul><li><para>
    /// For an AS2 connector, you specify the <c>ConnectorId</c> and one or more <c>SendFilePaths</c>
    /// to identify the files you want to transfer.
    /// </para></li><li><para>
    /// For an SFTP connector, the file transfer can be either outbound or inbound. In both
    /// cases, you specify the <c>ConnectorId</c>. Depending on the direction of the transfer,
    /// you also specify the following items:
    /// </para><ul><li><para>
    /// If you are transferring file from a partner's SFTP server to Amazon Web Services storage,
    /// you specify one or more <c>RetrieveFilePaths</c> to identify the files you want to
    /// transfer, and a <c>LocalDirectoryPath</c> to specify the destination folder.
    /// </para></li><li><para>
    /// If you are transferring file to a partner's SFTP server from Amazon Web Services storage,
    /// you specify one or more <c>SendFilePaths</c> to identify the files you want to transfer,
    /// and a <c>RemoteDirectoryPath</c> to specify the destination folder.
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Start", "TFRFileTransfer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP StartFileTransfer API operation.", Operation = new[] {"StartFileTransfer"}, SelectReturnType = typeof(Amazon.Transfer.Model.StartFileTransferResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.StartFileTransferResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.StartFileTransferResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTFRFileTransferCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the connector.</para>
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
        public System.String ConnectorId { get; set; }
        #endregion
        
        #region Parameter LocalDirectoryPath
        /// <summary>
        /// <para>
        /// <para>For an inbound transfer, the <c>LocaDirectoryPath</c> specifies the destination for
        /// one or more files that are transferred from the partner's SFTP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalDirectoryPath { get; set; }
        #endregion
        
        #region Parameter RemoteDirectoryPath
        /// <summary>
        /// <para>
        /// <para>For an outbound transfer, the <c>RemoteDirectoryPath</c> specifies the destination
        /// for one or more files that are transferred to the partner's SFTP server. If you don't
        /// specify a <c>RemoteDirectoryPath</c>, the destination for transferred files is the
        /// SFTP user's home directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteDirectoryPath { get; set; }
        #endregion
        
        #region Parameter RetrieveFilePath
        /// <summary>
        /// <para>
        /// <para>One or more source paths for the partner's SFTP server. Each string represents a source
        /// file path for one inbound file transfer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveFilePaths")]
        public System.String[] RetrieveFilePath { get; set; }
        #endregion
        
        #region Parameter SendFilePath
        /// <summary>
        /// <para>
        /// <para>One or more source paths for the Amazon S3 storage. Each string represents a source
        /// file path for one outbound file transfer. For example, <c><i>amzn-s3-demo-bucket</i>/<i>myfile.txt</i></c>.</para><note><para>Replace <c><i>amzn-s3-demo-bucket</i></c> with one of your actual buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SendFilePaths")]
        public System.String[] SendFilePath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransferId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.StartFileTransferResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.StartFileTransferResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransferId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TFRFileTransfer (StartFileTransfer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.StartFileTransferResponse, StartTFRFileTransferCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocalDirectoryPath = this.LocalDirectoryPath;
            context.RemoteDirectoryPath = this.RemoteDirectoryPath;
            if (this.RetrieveFilePath != null)
            {
                context.RetrieveFilePath = new List<System.String>(this.RetrieveFilePath);
            }
            if (this.SendFilePath != null)
            {
                context.SendFilePath = new List<System.String>(this.SendFilePath);
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
            var request = new Amazon.Transfer.Model.StartFileTransferRequest();
            
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.LocalDirectoryPath != null)
            {
                request.LocalDirectoryPath = cmdletContext.LocalDirectoryPath;
            }
            if (cmdletContext.RemoteDirectoryPath != null)
            {
                request.RemoteDirectoryPath = cmdletContext.RemoteDirectoryPath;
            }
            if (cmdletContext.RetrieveFilePath != null)
            {
                request.RetrieveFilePaths = cmdletContext.RetrieveFilePath;
            }
            if (cmdletContext.SendFilePath != null)
            {
                request.SendFilePaths = cmdletContext.SendFilePath;
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
        
        private Amazon.Transfer.Model.StartFileTransferResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.StartFileTransferRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "StartFileTransfer");
            try
            {
                #if DESKTOP
                return client.StartFileTransfer(request);
                #elif CORECLR
                return client.StartFileTransferAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorId { get; set; }
            public System.String LocalDirectoryPath { get; set; }
            public System.String RemoteDirectoryPath { get; set; }
            public List<System.String> RetrieveFilePath { get; set; }
            public List<System.String> SendFilePath { get; set; }
            public System.Func<Amazon.Transfer.Model.StartFileTransferResponse, StartTFRFileTransferCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransferId;
        }
        
    }
}
