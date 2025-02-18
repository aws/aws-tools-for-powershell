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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// The <c>ListTypes</c> operation returns a list of types for a specified keyspace.
    /// 
    /// 
    ///  
    /// <para>
    /// To read keyspace metadata using <c>ListTypes</c>, the IAM principal needs <c>Select</c>
    /// action permissions for the system keyspace. To configure the required permissions,
    /// see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/configure-udt-permissions.html#udt-permissions-view">Permissions
    /// to view a UDT</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KSTypeList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces ListTypes API operation.", Operation = new[] {"ListTypes"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.ListTypesResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.ListTypesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Keyspaces.Model.ListTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKSTypeListCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para> The name of the keyspace that contains the listed types. </para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The total number of types to return in the output. If the total number of types available
        /// is more than the value specified, a <c>NextToken</c> is provided in the output. To
        /// resume pagination, provide the <c>NextToken</c> value as an argument of a subsequent
        /// API invocation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token. To resume pagination, provide the <c>NextToken</c> value as
        /// an argument of a subsequent API invocation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Types'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.ListTypesResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.ListTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Types";
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
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.ListTypesResponse, GetKSTypeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Keyspaces.Model.ListTypesRequest();
            
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Keyspaces.Model.ListTypesResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.ListTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "ListTypes");
            try
            {
                return client.ListTypesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KeyspaceName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Keyspaces.Model.ListTypesResponse, GetKSTypeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Types;
        }
        
    }
}
