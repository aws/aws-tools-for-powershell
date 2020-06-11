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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Gets a description for one or more Network File System (NFS) file shares from a file
    /// gateway. This operation is only supported for file gateways.
    /// </summary>
    [Cmdlet("Get", "SGNFSFileShareList")]
    [OutputType("Amazon.StorageGateway.Model.NFSFileShareInfo")]
    [AWSCmdlet("Calls the AWS Storage Gateway DescribeNFSFileShares API operation.", Operation = new[] {"DescribeNFSFileShares"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.NFSFileShareInfo or Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse",
        "This cmdlet returns a collection of Amazon.StorageGateway.Model.NFSFileShareInfo objects.",
        "The service call response (type Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSGNFSFileShareListCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter FileShareARNList
        /// <summary>
        /// <para>
        /// <para>An array containing the Amazon Resource Name (ARN) of each file share to be described.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] FileShareARNList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NFSFileShareInfoList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NFSFileShareInfoList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileShareARNList parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileShareARNList' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileShareARNList' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse, GetSGNFSFileShareListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileShareARNList;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FileShareARNList != null)
            {
                context.FileShareARNList = new List<System.String>(this.FileShareARNList);
            }
            #if MODULAR
            if (this.FileShareARNList == null && ParameterWasBound(nameof(this.FileShareARNList)))
            {
                WriteWarning("You are passing $null as a value for parameter FileShareARNList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.DescribeNFSFileSharesRequest();
            
            if (cmdletContext.FileShareARNList != null)
            {
                request.FileShareARNList = cmdletContext.FileShareARNList;
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
        
        private Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeNFSFileSharesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeNFSFileShares");
            try
            {
                #if DESKTOP
                return client.DescribeNFSFileShares(request);
                #elif CORECLR
                return client.DescribeNFSFileSharesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> FileShareARNList { get; set; }
            public System.Func<Amazon.StorageGateway.Model.DescribeNFSFileSharesResponse, GetSGNFSFileShareListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NFSFileShareInfoList;
        }
        
    }
}
