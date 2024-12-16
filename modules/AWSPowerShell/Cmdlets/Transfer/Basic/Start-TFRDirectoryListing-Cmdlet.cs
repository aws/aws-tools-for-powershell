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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Retrieves a list of the contents of a directory from a remote SFTP server. You specify
    /// the connector ID, the output path, and the remote directory path. You can also specify
    /// the optional <c>MaxItems</c> value to control the maximum number of items that are
    /// listed from the remote directory. This API returns a list of all files and directories
    /// in the remote directory (up to the maximum value), but does not return files or folders
    /// in sub-directories. That is, it only returns a list of files and directories one-level
    /// deep.
    /// 
    ///  
    /// <para>
    /// After you receive the listing file, you can provide the files that you want to transfer
    /// to the <c>RetrieveFilePaths</c> parameter of the <c>StartFileTransfer</c> API call.
    /// </para><para>
    /// The naming convention for the output file is <c><i>connector-ID</i>-<i>listing-ID</i>.json</c>.
    /// The output file contains the following information:
    /// </para><ul><li><para><c>filePath</c>: the complete path of a remote file, relative to the directory of
    /// the listing request for your SFTP connector on the remote server.
    /// </para></li><li><para><c>modifiedTimestamp</c>: the last time the file was modified, in UTC time format.
    /// This field is optional. If the remote file attributes don't contain a timestamp, it
    /// is omitted from the file listing.
    /// </para></li><li><para><c>size</c>: the size of the file, in bytes. This field is optional. If the remote
    /// file attributes don't contain a file size, it is omitted from the file listing.
    /// </para></li><li><para><c>path</c>: the complete path of a remote directory, relative to the directory of
    /// the listing request for your SFTP connector on the remote server.
    /// </para></li><li><para><c>truncated</c>: a flag indicating whether the list output contains all of the items
    /// contained in the remote directory or not. If your <c>Truncated</c> output value is
    /// true, you can increase the value provided in the optional <c>max-items</c> input attribute
    /// to be able to list more items (up to the maximum allowed list size of 10,000 items).
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "TFRDirectoryListing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Transfer.Model.StartDirectoryListingResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP StartDirectoryListing API operation.", Operation = new[] {"StartDirectoryListing"}, SelectReturnType = typeof(Amazon.Transfer.Model.StartDirectoryListingResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.StartDirectoryListingResponse",
        "This cmdlet returns an Amazon.Transfer.Model.StartDirectoryListingResponse object containing multiple properties."
    )]
    public partial class StartTFRDirectoryListingCmdlet : AmazonTransferClientCmdlet, IExecutor
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
        
        #region Parameter OutputDirectoryPath
        /// <summary>
        /// <para>
        /// <para>Specifies the path (bucket and prefix) in Amazon S3 storage to store the results of
        /// the directory listing.</para>
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
        public System.String OutputDirectoryPath { get; set; }
        #endregion
        
        #region Parameter RemoteDirectoryPath
        /// <summary>
        /// <para>
        /// <para>Specifies the directory on the remote SFTP server for which you want to list its contents.</para>
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
        public System.String RemoteDirectoryPath { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>An optional parameter where you can specify the maximum number of file/directory names
        /// to retrieve. The default value is 1,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.StartDirectoryListingResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.StartDirectoryListingResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TFRDirectoryListing (StartDirectoryListing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.StartDirectoryListingResponse, StartTFRDirectoryListingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxItem = this.MaxItem;
            context.OutputDirectoryPath = this.OutputDirectoryPath;
            #if MODULAR
            if (this.OutputDirectoryPath == null && ParameterWasBound(nameof(this.OutputDirectoryPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDirectoryPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RemoteDirectoryPath = this.RemoteDirectoryPath;
            #if MODULAR
            if (this.RemoteDirectoryPath == null && ParameterWasBound(nameof(this.RemoteDirectoryPath)))
            {
                WriteWarning("You are passing $null as a value for parameter RemoteDirectoryPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.StartDirectoryListingRequest();
            
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.OutputDirectoryPath != null)
            {
                request.OutputDirectoryPath = cmdletContext.OutputDirectoryPath;
            }
            if (cmdletContext.RemoteDirectoryPath != null)
            {
                request.RemoteDirectoryPath = cmdletContext.RemoteDirectoryPath;
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
        
        private Amazon.Transfer.Model.StartDirectoryListingResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.StartDirectoryListingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "StartDirectoryListing");
            try
            {
                #if DESKTOP
                return client.StartDirectoryListing(request);
                #elif CORECLR
                return client.StartDirectoryListingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxItem { get; set; }
            public System.String OutputDirectoryPath { get; set; }
            public System.String RemoteDirectoryPath { get; set; }
            public System.Func<Amazon.Transfer.Model.StartDirectoryListingResponse, StartTFRDirectoryListingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
