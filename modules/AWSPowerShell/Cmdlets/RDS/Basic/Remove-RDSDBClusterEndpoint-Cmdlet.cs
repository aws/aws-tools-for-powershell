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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Deletes a custom endpoint and removes it from an Amazon Aurora DB cluster.
    /// 
    ///  <note><para>
    /// This action only applies to Aurora DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "RDSDBClusterEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DeleteDBClusterEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBClusterEndpoint API operation.", Operation = new[] {"DeleteDBClusterEndpoint"}, SelectReturnType = typeof(Amazon.RDS.Model.DeleteDBClusterEndpointResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DeleteDBClusterEndpointResponse",
        "This cmdlet returns an Amazon.RDS.Model.DeleteDBClusterEndpointResponse object containing multiple properties."
    )]
    public partial class RemoveRDSDBClusterEndpointCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBClusterEndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier associated with the custom endpoint. This parameter is stored as a
        /// lowercase string.</para>
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
        public System.String DBClusterEndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DeleteDBClusterEndpointResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DeleteDBClusterEndpointResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterEndpointIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBClusterEndpoint (DeleteDBClusterEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DeleteDBClusterEndpointResponse, RemoveRDSDBClusterEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterEndpointIdentifier = this.DBClusterEndpointIdentifier;
            #if MODULAR
            if (this.DBClusterEndpointIdentifier == null && ParameterWasBound(nameof(this.DBClusterEndpointIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterEndpointIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.DeleteDBClusterEndpointRequest();
            
            if (cmdletContext.DBClusterEndpointIdentifier != null)
            {
                request.DBClusterEndpointIdentifier = cmdletContext.DBClusterEndpointIdentifier;
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
        
        private Amazon.RDS.Model.DeleteDBClusterEndpointResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBClusterEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBClusterEndpoint");
            try
            {
                return client.DeleteDBClusterEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBClusterEndpointIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.DeleteDBClusterEndpointResponse, RemoveRDSDBClusterEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
