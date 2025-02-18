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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Returns the current status of an existing association or disassociation request.
    /// 
    /// 
    ///  
    /// <para>
    ///  A <c>ResourceNotFoundException</c> is thrown when no recent association or disassociation
    /// request with the specified token is found, or when the server does not exist. A <c>ValidationException</c>
    /// is raised when parameters of the request are not valid. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OWCMNodeAssociationStatus")]
    [OutputType("Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse")]
    [AWSCmdlet("Calls the AWS OpsWorksCM DescribeNodeAssociationStatus API operation.", Operation = new[] {"DescribeNodeAssociationStatus"}, SelectReturnType = typeof(Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse))]
    [AWSCmdletOutput("Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse",
        "This cmdlet returns an Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse object containing multiple properties."
    )]
    public partial class GetOWCMNodeAssociationStatusCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NodeAssociationStatusToken
        /// <summary>
        /// <para>
        /// <para>The token returned in either the AssociateNodeResponse or the DisassociateNodeResponse.
        /// </para>
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
        public System.String NodeAssociationStatusToken { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server from which to disassociate the node. </para>
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
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse).
        /// Specifying the name of a property of type Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse, GetOWCMNodeAssociationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NodeAssociationStatusToken = this.NodeAssociationStatusToken;
            #if MODULAR
            if (this.NodeAssociationStatusToken == null && ParameterWasBound(nameof(this.NodeAssociationStatusToken)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeAssociationStatusToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerName = this.ServerName;
            #if MODULAR
            if (this.ServerName == null && ParameterWasBound(nameof(this.ServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusRequest();
            
            if (cmdletContext.NodeAssociationStatusToken != null)
            {
                request.NodeAssociationStatusToken = cmdletContext.NodeAssociationStatusToken;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
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
        
        private Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "DescribeNodeAssociationStatus");
            try
            {
                return client.DescribeNodeAssociationStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NodeAssociationStatusToken { get; set; }
            public System.String ServerName { get; set; }
            public System.Func<Amazon.OpsWorksCM.Model.DescribeNodeAssociationStatusResponse, GetOWCMNodeAssociationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
